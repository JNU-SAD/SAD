using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
///DatabaseConnector 的摘要说明
/// </summary>
public class DatabaseConnector
{
    private readonly String HOSTSTR = "Server=.;Database=SAD;User ID=edisond;Password=33635468";
    private SqlConnection dbConnection;
    private SqlCommand cmd;
    //构建函数时创建SQL连接
	public DatabaseConnector()
	{
        dbConnection = new SqlConnection(HOSTSTR);
	}
    //添加新用户
    public bool AddCustomer(Customer customer)
    {
        try
        {
            dbConnection.Open();
            cmd = new SqlCommand("insert into Table_Customer values('"
                + customer.EmailAddress + "','"
                + customer.Password + "','"
                + customer.FirstName + "','"
                + customer.LastName + "','"
                + customer.Sex + "','"
                + customer.PhoneNumber + "','"
                + customer.CreditCardNumber + "')"
                , dbConnection);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception e)
        {
            Console.Write(e.ToString());
            return false;
        }
        finally
        {
            dbConnection.Close();
        }
    }
    //删除用户
    public bool DeleteCustomer(String EmailAddress)
    {
        try
        {
            dbConnection.Open();
            cmd = new SqlCommand("delete from Table_Customer where EmailAddress = '" + EmailAddress + "'", dbConnection);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception e)
        {
            Console.Write(e.ToString());
            return false;
        }
        finally
        {
            dbConnection.Close();
        }
    }
    //更新已存在用户
    public bool UpdateCustomer(Customer customer)
    {
        try
        {
            dbConnection.Open();
            cmd = new SqlCommand("update Table_Customer set Password='"
                + customer.Password + "',FirstName='"
                + customer.FirstName + "',LastName='"
                + customer.LastName + "',Sex='"
                + customer.Sex + "',CreditCardNumber='"
                + customer.CreditCardNumber + "',PhoneNumber='"
                + customer.PhoneNumber + "' where EmailAddress='"
                + customer.EmailAddress + "'", dbConnection);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception e)
        {
            Console.Write(e.ToString());
            return false;
        }
        finally
        {
            dbConnection.Close();
        }
    }
    //根据邮箱地址获取用户
    public Customer GetCustomer(String EmailAddress)
    {
        try
        {
            dbConnection.Open();
            cmd = new SqlCommand("Select * from Table_Customer where EmailAddress ='" + EmailAddress + "'", dbConnection);
            SqlDataReader result = cmd.ExecuteReader();
            while (result.Read())
            {
                Customer customer = new Customer();
                customer.EmailAddress = result.GetString(0);
                customer.Password = result.GetString(1);
                customer.FirstName = result.GetString(2);
                customer.LastName = result.GetString(3);
                customer.Sex = result.GetString(4);
                customer.PhoneNumber = result.GetString(5);
                customer.CreditCardNumber = result.GetString(6);
                return customer;
            }
            return null;
        }
        catch (Exception e)
        {
            Console.Write(e.ToString());
            return null;
        }
        finally
        {
            dbConnection.Close();
        }
    }
    //添加新酒店预订
    public bool AddHotelReservation(HotelReservation hotelReservation)
    {
        try
        {
            dbConnection.Open();
            //预订的id是一个自增值，不用添加
            cmd = new SqlCommand("insert into Table_HotelReservation values('"
                + hotelReservation.Owner + "','"
                + hotelReservation.HotelName + "','"
                + hotelReservation.DictionaryRoomsToString() + "','"
                + hotelReservation.CheckIn.ToString() + "','"
                + hotelReservation.CheckOut.ToString() + "','"
                + hotelReservation.Cost.ToString() + "')"
                , dbConnection);
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception e)
        {
            Console.Write(e.ToString());
            return false;
        }
        finally
        {
            dbConnection.Close();
        }
    }
    //根据id查找一个预订
    public HotelReservation GetHotelReservation(int id)
    {
        try
        {
            dbConnection.Open();
            cmd = new SqlCommand("Select * from Table_HotelReservation where id ='" + id.ToString() + "'", dbConnection);
            SqlDataReader result = cmd.ExecuteReader();
            while (result.Read())
            {
                HotelReservation hotelReservation = new HotelReservation();
                hotelReservation.Id = result.GetInt32(0);
                hotelReservation.Owner = result.GetString(1);
                hotelReservation.HotelName = result.GetString(2);
                hotelReservation.Rooms = hotelReservation.StringRoomsToDictionary(result.GetString(3));
                hotelReservation.CheckIn = result.GetDateTime(4);
                hotelReservation.CheckOut = result.GetDateTime(5);
                hotelReservation.Cost = result.GetDouble(6);
                return hotelReservation;
            }
            return null;
        }
        catch (Exception e)
        {
            Console.Write(e.ToString());
            return null;
        }
        finally
        {
            dbConnection.Close();
        }
    }

}