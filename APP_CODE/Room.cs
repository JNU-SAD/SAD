using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Room 的摘要说明
/// </summary>
public class Room
{
	public Room()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    private int hotelId;
    private String roomType;
    private int fullRate;
    private int totalNumber;
    private int capacity;
    private List<Arrangement> arrangements;

    public List<Arrangement> Arrangements
    {
        get { return arrangements; }
        set { arrangements = value; }
    }
    public int Capacity
    {
        get { return capacity; }
        set { capacity = value; }
    }
    public int TotalNumber
    {
        get { return totalNumber; }
        set { totalNumber = value; }
    }
    public int FullRate
    {
        get { return fullRate; }
        set { fullRate = value; }
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
}