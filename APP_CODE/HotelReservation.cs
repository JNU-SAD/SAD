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
    private String owner;
    private int hotelId;
    private Dictionary<String, int> rooms;
    private DateTime checkIn;
    private DateTime checkOut;
    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    public String Owner
    {
        get { return owner; }
        set { owner = value; }
    }
    public int HotelId
    {
        get { return hotelId; }
        set { hotelId = value; }
    }
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
    public DateTime CheckIn
    {
        get { return checkIn; }
        set { checkIn = value; }
    }
    public DateTime CheckOut
    {
        get { return checkOut; }
        set { checkOut = value; }
    }
    public String DateTimeDateToString(DateTime dateTime)
    {
        return dateTime.ToString("yyyy/MM/dd");
    }
    public DateTime StringDateToDateTime(String str)
    {
        return DateTime.ParseExact(str, "yyyy/MM/dd", System.Globalization.CultureInfo.CurrentCulture);
    }
}