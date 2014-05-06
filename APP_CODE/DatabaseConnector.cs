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
    private readonly String HOSTSTR = "Server=a2a5bad2-d4fc-47f9-b241-a2ed00d7fc16.sqlserver.sequelizer.com;Database=dba2a5bad2d4fc47f9b241a2ed00d7fc16;User ID=tnucjrzwvfrcgpqd;Password=mHVvDSviXMhKcMseBMbVNP4Vh3jhscQ78mgy2jRciNpRGuYn4LKLHZBEN8oJGoYU;";
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
                + hotelReservation.HotelId.ToString() + "','"
                + hotelReservation.DictionaryRoomsToString() + "','"
                + hotelReservation.DateTimeDateToString(hotelReservation.CheckIn) + "','"
                + hotelReservation.DateTimeDateToString(hotelReservation.CheckOut) + "')"
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
    public HotelReservation GetHotelReservationById(int id)
    {
        try
        {
            dbConnection.Open();
            cmd = new SqlCommand("Select * from Table_HotelReservation where Id ='" + id.ToString() + "'", dbConnection);
            SqlDataReader result = cmd.ExecuteReader();
            while (result.Read())
            {
                HotelReservation hotelReservation = new HotelReservation();
                hotelReservation.Id = result.GetInt32(0);
                hotelReservation.Owner = result.GetString(1);
                hotelReservation.HotelId = result.GetInt32(2);
                hotelReservation.Rooms = hotelReservation.StringRoomsToDictionary(result.GetString(3));
                hotelReservation.CheckIn = hotelReservation.StringDateToDateTime(result.GetString(4));
                hotelReservation.CheckOut = hotelReservation.StringDateToDateTime(result.GetString(5));
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
    //根据用户名(邮箱地址)查找所属的所有预订
    public List<HotelReservation> GetHotelReservationByEmailAddress(String EmailAddress)
    {
        try
        {
            dbConnection.Open();
            cmd = new SqlCommand("Select * from Table_HotelReservation where Owner ='" + EmailAddress + "'", dbConnection);
            SqlDataReader result = cmd.ExecuteReader();
            List<HotelReservation> hotelReservations = new List<HotelReservation>();
            while (result.Read())
            {
                HotelReservation hotelReservation = new HotelReservation();
                hotelReservation.Id = result.GetInt32(0);
                hotelReservation.Owner = result.GetString(1);
                hotelReservation.HotelId = result.GetInt32(2);
                hotelReservation.Rooms = hotelReservation.StringRoomsToDictionary(result.GetString(3));
                hotelReservation.CheckIn = hotelReservation.StringDateToDateTime(result.GetString(4));
                hotelReservation.CheckOut = hotelReservation.StringDateToDateTime(result.GetString(5));
                hotelReservations.Add(hotelReservation);
            }
            if (hotelReservations.Count != 0)
            {
                return hotelReservations;
            }
            else
            {
                return null;
            }
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
    //更新一个预订
    public bool UpdateHotelReservation(HotelReservation hotelReservation)
    {
        try
        {
            dbConnection.Open();
            cmd = new SqlCommand("update Table_HotelReservation set Owner='"
                + hotelReservation.Owner + "',HotelName='"
                + hotelReservation.HotelId + "',Rooms='"
                + hotelReservation.DictionaryRoomsToString() + "',CheckIn='"
                + hotelReservation.DateTimeDateToString(hotelReservation.CheckIn) + "',CheckOut='"
                + hotelReservation.DateTimeDateToString(hotelReservation.CheckOut) + "' where Id='"
                + hotelReservation.Id.ToString() + "'", dbConnection);
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
    //删除一个预订
    public bool DeleteHotelReservation(int Id)
    {
        try
        {
            dbConnection.Open();
            cmd = new SqlCommand("delete from Table_HotelReservation where Id = '" + Id.ToString() + "'", dbConnection);
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
    //添加一个新订单
    public bool AddOrder(Order order)
    {
        try
        {
            dbConnection.Open();
            //订单的id是一个自增值，不用添加
            cmd = new SqlCommand("insert into Table_Order values('"
                + order.Owner + "','"
                + order.Status + "','"
                + order.ListReservationIdsToString() + "')"
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
    //根据订单号查找一个订单
    public Order GetOrderById(int id)
    {
        try
        {
            dbConnection.Open();
            cmd = new SqlCommand("Select * from Table_Order where Id ='" + id.ToString() + "'", dbConnection);
            SqlDataReader result = cmd.ExecuteReader();
            while (result.Read())
            {
                Order order = new Order();
                order.Id = result.GetInt32(0);
                order.Owner = result.GetString(1);
                order.Status = result.GetString(2);
                order.ReservationIds = order.StringReservationIdsToList(result.GetString(3));
                return order;
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
    //根据用户名(邮箱地址)查找所属的所有订单
    public List<Order> GetOrderByEmailAddress(String EmailAddress)
    {
        try
        {
            dbConnection.Open();
            cmd = new SqlCommand("Select * from Table_Order where Owner ='" + EmailAddress + "'", dbConnection);
            SqlDataReader result = cmd.ExecuteReader();
            List<Order> orders = new List<Order>();
            while (result.Read())
            {
                Order order = new Order();
                order.Id = result.GetInt32(0);
                order.Owner = result.GetString(1);
                order.Status = result.GetString(2);
                order.ReservationIds = order.StringReservationIdsToList(result.GetString(3));
                orders.Add(order);
            }
            if (orders.Count != 0)
            {
                return orders;
            }
            else
            {
                return null;
            }
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
    //更新一个订单
    public bool UpdateOrder(Order order)
    {
        try
        {
            dbConnection.Open();
            cmd = new SqlCommand("update Table_Order set Owner='"
                + order.Owner + "',Status='"
                + order.Status + "',ReservationIds='"
                + order.ListReservationIdsToString() + "' where Id='"
                + order.Id.ToString() + "'", dbConnection);
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
    //删除一个订单
    public bool DeleteOrder(int id)
    {
        try
        {
            dbConnection.Open();
            cmd = new SqlCommand("delete from Table_Order where Id = '" + id.ToString() + "'", dbConnection);
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
    //添加新酒店
    public bool AddHotel(Hotel hotel)
    {
        try
        {
            dbConnection.Open();
            //酒店的id是一个自增值，不用添加
            cmd = new SqlCommand("insert into Table_Hotel values('"
                + hotel.Name + "','"
                + hotel.Address + "','"
                + hotel.StarLevel.ToString() + "','"
                + hotel.ContactNumber + "')"
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
    //根据酒店名获取酒店信息
    public Hotel GetHotelByName(String name)
    {
        try
        {
            dbConnection.Open();
            cmd = new SqlCommand("Select * from Table_Hotel where Name ='" + name + "'", dbConnection);
            SqlDataReader result = cmd.ExecuteReader();
            while (result.Read())
            {
                Hotel hotel = new Hotel();
                hotel.Id = result.GetInt32(0);
                hotel.Name = result.GetString(1);
                hotel.Address = result.GetString(2);
                hotel.StarLevel = result.GetInt32(3);
                hotel.ContactNumber = result.GetString(4);
                
                return hotel;
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
    //获取所有酒店
    public List<Hotel> GetAllHotel()
    {
        try
        {
            dbConnection.Open();
            cmd = new SqlCommand("Select * from Table_Hotel", dbConnection);
            SqlDataReader result = cmd.ExecuteReader();
            List<Hotel> hotels = new List<Hotel>();
            while (result.Read())
            {
                Hotel hotel = new Hotel();
                hotel.Id = result.GetInt32(0);
                hotel.Name = result.GetString(1);
                hotel.Address = result.GetString(2);
                hotel.StarLevel = result.GetInt32(3);
                hotel.ContactNumber = result.GetString(4);
                hotels.Add(hotel);
            }
            return hotels;
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
    //更新酒店信息
    public bool UpdateHotel(Hotel hotel)
    {
        try
        {
            dbConnection.Open();
            cmd = new SqlCommand("update Table_Hotel set Name='"
                + hotel.Name + "',Address='"
                + hotel.Address + "',StarLevel='"
                + hotel.StarLevel.ToString() + "',ContactNumber='"
                + hotel.ContactNumber + "' where Id='"
                + hotel.Id.ToString() + "'", dbConnection);
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
    //删除一个酒店
    public bool DeleteHotel(int id)
    {
        try
        {
            dbConnection.Open();
            cmd = new SqlCommand("delete from Table_Hotel where Id = '" + id.ToString() + "'", dbConnection);
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
    //添加新房间
    public bool AddRoom(Room room)
    {
        try
        {
            dbConnection.Open();
            
            cmd = new SqlCommand("insert into Table_Room values('"
                + room.HotelId.ToString() + "','"
                + room.RoomType + "','"
                + room.FullRate.ToString() + "','"
                + room.TotalNumber.ToString() + "','"
                + room.Capacity.ToString() + "')"
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
    //根据酒店id获取所属房间
    public List<Room> GetRoomByHotelId(int hotelId)
    {
        try
        {
            dbConnection.Open();
            cmd = new SqlCommand("Select * from Table_Room where HotelId ='" + hotelId.ToString() + "'", dbConnection);
            SqlDataReader result = cmd.ExecuteReader();
            List<Room> rooms = new List<Room>();
            while (result.Read())
            {
                Room room = new Room();
                room.HotelId = result.GetInt32(0);
                room.RoomType = result.GetString(1);
                room.FullRate = result.GetFloat(2);
                room.TotalNumber = result.GetInt32(3);
                room.Capacity = result.GetInt32(4);
                rooms.Add(room);
            }
            if (rooms.Count != 0)
            {
                return rooms;
            }
            else
            {
                return null;
            }
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
    //更新房间信息
    public bool UpdateRoom(Room room)
    {
        try
        {
            dbConnection.Open();
            cmd = new SqlCommand("update Table_Room set FullRate='"
                + room.FullRate.ToString() + "',TotalNumber='"
                + room.TotalNumber.ToString() + "',Capacity='"
                + room.Capacity.ToString() + "' where HotelId='"
                + room.HotelId.ToString() + "' and RoomType='"
                + room.RoomType + "'", dbConnection);
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
    //删除一个房间
    public bool DeleteRoom(int hotelId, String roomType)
    {
        try
        {
            dbConnection.Open();
            cmd = new SqlCommand("delete from Table_Room where HotelId = '" + hotelId.ToString() + "' and RoomType = '" + roomType + "'", dbConnection);
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
    //添加新日程
    public bool AddArrangement(Arrangement arrangement)
    {
        try
        {
            dbConnection.Open();

            cmd = new SqlCommand("insert into Table_Arrangement values('"
                + arrangement.HotelId.ToString() + "','"
                + arrangement.RoomType + "','"
                + arrangement.DateTimeDateToString() + "','"
                + arrangement.Rate.ToString() + "','"
                + arrangement.BookedNumber.ToString() + "')"
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
    //根据酒店id和房间类型获取所属日程
    public List<Arrangement> GetArrangementByHotelIdAndRoomType(int hotelId,String roomType)
    {
        try
        {
            dbConnection.Open();
            cmd = new SqlCommand("Select * from Table_Arrangement where HotelId ='" + hotelId.ToString() + "' and RoomType = '" + roomType + "'", dbConnection);
            SqlDataReader result = cmd.ExecuteReader();
            List<Arrangement> arrangements = new List<Arrangement>();
            while (result.Read())
            {
                Arrangement arrangement = new Arrangement();
                arrangement.HotelId = result.GetInt32(0);
                arrangement.RoomType = result.GetString(1);
                arrangement.Date = arrangement.StringDateToDateTime(result.GetString(2));
                arrangement.Rate = result.GetFloat(3);
                arrangement.BookedNumber = result.GetInt32(4);
                arrangements.Add(arrangement);
            }
            if (arrangements.Count != 0)
            {
                return arrangements;
            }
            else
            {
                return null;
            }
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
    //更新日程信息
    public bool UpdateArrangement(Arrangement arrangement)
    {
        try
        {
            dbConnection.Open();
            cmd = new SqlCommand("update Table_Arrangement set Rate='"
                + arrangement.Rate.ToString() + "',BookedNumber='"
                + arrangement.BookedNumber.ToString() + "' where HotelId='"
                + arrangement.HotelId.ToString() + "' and RoomType='"
                + arrangement.RoomType + "' and Date='"
                + arrangement.DateTimeDateToString() + "'", dbConnection);
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
    //删除一个日程
    public bool DeleteArrangement(int hotelId, String roomType, String date)
    {
        try
        {
            dbConnection.Open();
            cmd = new SqlCommand("delete from Table_Arrangement where HotelId = '" + hotelId.ToString() + "' and RoomType = '" + roomType + "' and Date = '" + date + "'", dbConnection);
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
}