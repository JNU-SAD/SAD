using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Basket 的摘要说明
/// </summary>
public class Basket
{
	public Basket()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    private List<Reservation> reservations;

    public List<Reservation> Reservations
    {
        get { return reservations; }
        set { reservations = value; }
    }

}