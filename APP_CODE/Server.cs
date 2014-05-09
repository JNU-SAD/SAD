using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Server 的摘要说明
/// </summary>
public class Server
{
    private DatabaseConnector dbc = new DatabaseConnector();
	public Server()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public List<Hotel> Search(List<Hotel> source, DateTime CheckIn, DateTime CheckOut, int RoomNum, int GuestNum)
    {
        List<Hotel> result = new List<Hotel>(source);
        int daySpan = (CheckOut - CheckIn).Days;
        List<DateTime> days = new List<DateTime>();
        for (int i = 0; i < daySpan; i++)
        {
            days.Add(CheckIn.AddDays(i));
        }
        if (result.Count == 0)
            return result;
        foreach (Hotel hotel in result)
        {
            hotel.Rooms = dbc.GetRoomByHotelId(hotel.Id);
            foreach (Room room in hotel.Rooms)
            {
                room.Arrangements = dbc.GetArrangementByHotelIdAndRoomType(room.HotelId, room.RoomType);
            }
        }
        for (int i = result.Count - 1; i >= 0; i--)
        {
            bool enoughRoom = false;
            bool badArrangementFound = false;
            foreach (Room room in result[i].Rooms)
            {
                if (room.Arrangements.Count == 0)
                {
                    if (room.TotalNumber >= RoomNum)
                        enoughRoom = true;
                }
                else
                {
                    foreach (Arrangement a in room.Arrangements)
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
        foreach (Hotel hotel in result)
            hotel.Price = dbc.GetHotelPrice(hotel.Id);
        return result;

    }

}