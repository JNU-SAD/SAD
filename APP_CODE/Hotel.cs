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

    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    private String name;

    public String Name
    {
        get { return name; }
        set { name = value; }
    }
    private String address;

    public String Address
    {
        get { return address; }
        set { address = value; }
    }
    private int starLevel;

    public int StarLevel
    {
        get { return starLevel; }
        set { starLevel = value; }
    }
    private String contactNumber;

    public String ContactNumber
    {
        get { return contactNumber; }
        set { contactNumber = value; }
    }

}