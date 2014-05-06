using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Arrangement 的摘要说明
/// </summary>
public class Arrangement
{
	public Arrangement()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    private int hotelId;
    private String roomType;
    private DateTime date;
    private float rate;
    private int bookedNumber;

    public int BookedNumber
    {
        get { return bookedNumber; }
        set { bookedNumber = value; }
    }
    public float Rate
    {
        get { return rate; }
        set { rate = value; }
    }
    public DateTime Date
    {
        get { return date; }
        set { date = value; }
    }
    public String RoomType
    {
        get { return roomType; }
        set { roomType = value; }
    }
    public int HotelId
    {
        get { return hotelId; }
        set { hotelId = value; }
    }

    public String DateTimeDateToString()
    {
        return date.ToString("yyyy/MM/dd");
    }
    public DateTime StringDateToDateTime(String str)
    {
        return DateTime.ParseExact(str, "yyyy/MM/dd", System.Globalization.CultureInfo.CurrentCulture);
    }

}