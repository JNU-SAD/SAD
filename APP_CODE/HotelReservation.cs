using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///HotelReservation 的摘要说明
/// </summary>
public class HotelReservation:Reservation
{
	public HotelReservation()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    private int id;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    private String owner;

    public String Owner
    {
        get { return owner; }
        set { owner = value; }
    }

    private String hotelName;

    public String HotelName
    {
        get { return hotelName; }
        set { hotelName = value; }
    }
    private Dictionary<String, int> rooms;
    
    public Dictionary<String, int> Rooms
    {
        get { return rooms; }
        set { rooms = value; }
    }

    public String DictionaryRoomsToString()
    {
        String result = String.Empty;
        foreach (KeyValuePair<String, int> room in Rooms)
        {
            result += room.Key;
            result += ",";
            result += room.Value.ToString();
            result += ";";
        }
        result = result.Substring(0, result.Length - 1);
        return result;
    }

    public Dictionary<String, int> StringRoomsToDictionary(String str)
    {
        Dictionary<String, int> result = new Dictionary<string, int>();
        String[] pairs = str.Split(';');
        foreach (String pair in pairs)
        {
            String[] keyValuePair = pair.Split(',');
            result.Add(keyValuePair[0], Convert.ToInt32(keyValuePair[1]));
        }
        return result;
    }

    private DateTime checkIn;

    public DateTime CheckIn
    {
        get { return checkIn; }
        set { checkIn = value; }
    }
    private DateTime checkOut;

    public DateTime CheckOut
    {
        get { return checkOut; }
        set { checkOut = value; }
    }
    private Double cost;

    public Double Cost
    {
        get { return cost; }
        set { cost = value; }
    }

}