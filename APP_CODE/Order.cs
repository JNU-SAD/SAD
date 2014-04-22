using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Order 的摘要说明
/// </summary>
public class Order
{
	public Order()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    private int id;
    private String owner;
    private String status;
    private List<int> reservationIds;
    
    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    public List<int> ReservationIds
    {
        get { return reservationIds; }
        set { reservationIds = value; }
    }
    public String Owner
    {
        get { return owner; }
        set { owner = value; }
    }
    public String Status
    {
        get { return status; }
        set { status = value; }
    }
    public String ListReservationIdsToString()
    {
        String result = String.Empty;
        foreach (int reservationId in reservationIds)
        {
            result += reservationId.ToString();
            result += ";";
        }
        return result.Substring(0, result.Length - 1);
    }
    public List<int> StringReservationIdsToList(String str)
    {
        List<int> result = new List<int>();
        String[] reservationIds = str.Split(';');
        foreach (String reservationId in reservationIds)
        {
            result.Add(Convert.ToInt32(reservationId));
        }
        return result;
    }
}