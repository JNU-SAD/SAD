using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Hotel 的摘要说明
/// </summary>
public class Hotel
{
	public Hotel()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    private int id;
    private String name;
    private String address;
    private int starLevel;
    private String contactNumber;
    private List<Room> rooms;

    public List<Room> Rooms
    {
        get { return rooms; }
        set { rooms = value; }
    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    

    public String Name
    {
        get { return name; }
        set { name = value; }
    }
    

    public String Address
    {
        get { return address; }
        set { address = value; }
    }
    

    public int StarLevel
    {
        get { return starLevel; }
        set { starLevel = value; }
    }
    

    public String ContactNumber
    {
        get { return contactNumber; }
        set { contactNumber = value; }
    }

}