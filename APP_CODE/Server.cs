using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Server 的摘要说明
/// </summary>
public class Server
{
    private Dbc dbc = new Dbc();
	public Server()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public List<Table_Hotel> Search(List<Table_Hotel> source, DateTime CheckIn, DateTime CheckOut, int RoomNum, int GuestNum)
    {
        List<Table_Hotel> result = new List<Table_Hotel>(source);
        int daySpan = (CheckOut - CheckIn).Days;
        List<DateTime> days = new List<DateTime>();
        for (int i = 0; i < daySpan; i++)
        {
            days.Add(CheckIn.AddDays(i));
        }
        if (result.Count == 0)
            return result;
        foreach (Table_Hotel hotel in result)
        {
            hotel.Room = dbc.GetRoomByHotelId(hotel.Id);
            foreach (Table_Room room in hotel.Room)
            {
                room.Arrangement = dbc.GetArrangementByHotelIdAndRoomType(room.HotelId, room.RoomType);
            }
        }
        for (int i = result.Count - 1; i >= 0; i--)
        {
            bool enoughRoom = false;
            bool badArrangementFound = false;
            foreach (Table_Room room in result[i].Room)
            {
                if (room.Arrangement.Count == 0)
                {
                    if (room.TotalNumber >= RoomNum)
                        enoughRoom = true;
                }
                else
                {
                    foreach (Table_Arrangement a in room.Arrangement)
                    {
                        if (days.Contains(a.Date))
                        {
                            if (room.TotalNumber - a.BookedNumber < RoomNum)
                                badArrangementFound = true;
                            break;
                        }
                    }
                    if (badArrangementFound)
                        break;
                    else
                        enoughRoom = true;
                }
                if (enoughRoom)
                    break;
            }
            if (!enoughRoom)
                result.RemoveAt(i);
        }
        foreach (Table_Hotel hotel in result)
            hotel.Price = dbc.GetHotelPrice(hotel.Id);
        return result;

    }

}