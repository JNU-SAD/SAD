using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class Dbc
{
    private DataClassesDataContext data = new DataClassesDataContext();

    //添加新用户
    public void AddCustomer(Table_Customer customer)
    {
        data.Table_Customer.InsertOnSubmit(customer);
        data.SubmitChanges();
    }
    //删除用户
    public void DeleteCustomer(String EmailAddress)
    {
        var q = from s in data.Table_Customer
                where s.EmailAddress == EmailAddress
                select s;
        data.Table_Customer.DeleteAllOnSubmit(q);
        data.SubmitChanges();


    }
    //更新已存在用户
    public void UpdateCustomer(Table_Customer customer)
    {
        var q = from s in data.Table_Customer
                where s.EmailAddress == customer.EmailAddress
                select s;
        foreach (Table_Customer c in q)
        {
            c.CreditCardNumber = customer.CreditCardNumber;
            c.FirstName = customer.FirstName;
            c.LastName = customer.LastName;
            c.Password = customer.Password;
            c.PhoneNumber = customer.PhoneNumber;
            c.Sex = customer.Sex;
        
        }
        data.SubmitChanges();
    }
    //根据邮箱地址获取用户
    public Table_Customer GetCustomer(String EmailAddress)
    {
        var q = from s in data.Table_Customer
                where s.EmailAddress == EmailAddress
                select s;
        return q.Count() == 0 ? null : q.First();
    }
    //添加新酒店预订
    public void AddHotelReservation(Table_HotelReservation hotelReservation)
    {
        data.Table_HotelReservation.InsertOnSubmit(hotelReservation);
        data.SubmitChanges();
    }
    //根据id查找一个预订
    public Table_HotelReservation GetHotelReservationById(int id)
    {
        var q = from s in data.Table_HotelReservation
                where s.Id == id
                select s;
        return q.Count() == 0 ? null : q.First();
    }
    //根据用户名(邮箱地址)查找所属的所有预订
    public List<Table_HotelReservation> GetHotelReservationByEmailAddress(String Customer)
    {
        var q = from s in data.Table_HotelReservation
                where s.Customer == Customer
                select s;
        return q.ToList();
    }
    //更新一个预订
    public void UpdateHotelReservation(Table_HotelReservation hotelReservation)
    {
        var q = from s in data.Table_HotelReservation
                where s.Id == hotelReservation.Id
                select s;
        foreach (Table_HotelReservation c in q)
        {
            c.CheckIn = hotelReservation.CheckIn;
            c.CheckOut = hotelReservation.CheckOut;
            c.Customer = hotelReservation.Customer;
            c.HotelId = hotelReservation.HotelId;
            c.RoomNum = hotelReservation.RoomNum;
            c.RoomType = hotelReservation.RoomType;
            c.Status = hotelReservation.Status;
        }
        data.SubmitChanges();
    }
    //删除一个预订
    public void DeleteHotelReservation(int Id)
    {
        var q = from s in data.Table_HotelReservation
                where s.Id == Id
                select s;
        data.Table_HotelReservation.DeleteAllOnSubmit(q);
        data.SubmitChanges();
    }
    
    //添加新酒店
    public void AddHotel(Table_Hotel hotel)
    {
        data.Table_Hotel.InsertOnSubmit(hotel);
        data.SubmitChanges();
    }
    //获取所有酒店id
    public List<int> GetHotelIds()
    {
        var q = from s in data.Table_Hotel
                select s.Id;
        return q.ToList();
    }

    //根据酒店名获取酒店信息
    public Table_Hotel GetHotelByName(String name)
    {
        var q = from s in data.Table_Hotel
                where s.Name == name
                select s;
        return q.Count() == 0 ? null : q.First();
    }
    //根据地址获取酒店信息
    public List<Table_Hotel> GetHotelByAddress(String address)
    {
        var q = from s in data.Table_Hotel
                where s.Address.Contains(address)
                select s;
        return q.ToList();
    }
    //根据酒店Id获取酒店
    public Table_Hotel GetHotelById(int id)
    {
        var q = from s in data.Table_Hotel
                where s.Id == id
                select s;
        return q.Count() == 0 ? null : q.First();

    }
    //获取所有酒店
    public List<Table_Hotel> GetAllHotel()
    {
        var q = from s in data.Table_Hotel
                select s;
        return q.ToList();
    }
    //获取id所属酒店房间的最低价
    public int GetHotelPrice(int id)
    {
        var q = (from s in data.Table_Room
                 where s.HotelId == id
                 select s.FullRate).Min();
        return q;
    }
    //更新酒店信息
    public void UpdateHotel(Table_Hotel hotel)
    {
        var q = from s in data.Table_Hotel
                where s.Id==hotel.Id
                select s;
        foreach (Table_Hotel c in q)
        {
            c.Address = hotel.Address;
            c.ContactNumber = hotel.ContactNumber;
            c.ImageUrl = hotel.ImageUrl;
            c.Name = hotel.Name;
            c.StarLevel = hotel.StarLevel;
            
        }
        data.SubmitChanges();
    }
    //删除一个酒店
    public void DeleteHotel(int id)
    {
        var q = from s in data.Table_Hotel
                where s.Id == id
                select s;
        data.Table_Hotel.DeleteAllOnSubmit(q);
        data.SubmitChanges();
    }
    //添加新房间
    public void AddRoom(Table_Room room)
    {
        data.Table_Room.InsertOnSubmit(room);
        data.SubmitChanges();
    }
    //根据酒店id获取所属房间
    public List<Table_Room> GetRoomByHotelId(int hotelId)
    {
        var q = from s in data.Table_Room
                where s.HotelId == hotelId
                select s;
        return q.ToList();
    }
    //根据酒店id和房间名获取房间
    public Table_Room GetRoomByHotelIdAndRoomType(int hotelId, String roomType)
    {
        var q = from s in data.Table_Room
                where s.HotelId == hotelId && s.RoomType == roomType
                select s;
        return q.Count() == 0 ? null : q.First();
    }

    //获取所有房间
    public List<Table_Room> GetAllRoom()
    {
        var q = from s in data.Table_Room
                select s;
        return q.ToList();
    }
    //更新房间信息
    public void UpdateRoom(Table_Room room)
    {
        var q = from s in data.Table_Room
                where s.HotelId == room.HotelId && s.RoomType == room.RoomType
                select s;
        foreach (Table_Room c in q)
        {
            c.Capacity = room.Capacity;
            c.FullRate = room.FullRate;
            c.TotalNumber = room.TotalNumber;
        }
        data.SubmitChanges();
    }
    //删除一个房间
    public void DeleteRoom(int HotelId, String RoomType)
    {
        var q = from s in data.Table_Room
                where s.HotelId == HotelId && s.RoomType == RoomType
                select s;
        data.Table_Room.DeleteAllOnSubmit(q);
        data.SubmitChanges();
    }
    //添加新日程
    public void AddArrangement(Table_Arrangement arrangement)
    {
        data.Table_Arrangement.InsertOnSubmit(arrangement);
        data.SubmitChanges();
    }
    //根据酒店id和房间类型获取所属日程
    public List<Table_Arrangement> GetArrangementByHotelIdAndRoomType(int hotelId,String roomType)
    {
        var q = from s in data.Table_Arrangement
                where s.HotelId == hotelId && s.RoomType == roomType
                select s;
        return q.ToList();
    }
    //获取所有日程
    public List<Table_Arrangement> GetAllArrangement()
    {
        var q = from s in data.Table_Arrangement
                select s;
        return q.ToList();
    }
    //更新日程信息
    public void UpdateArrangement(Table_Arrangement arrangement)
    {
        var q = from s in data.Table_Arrangement
                where s.HotelId == arrangement.HotelId && s.RoomType == arrangement.RoomType
                select s;
        foreach (Table_Arrangement c in q)
        {
            c.BookedNumber = arrangement.BookedNumber;
            c.Date = arrangement.Date;
            c.Rate = arrangement.Rate;
            
        }
        data.SubmitChanges();
    }
    //删除一个日程
    public void DeleteArrangement(int hotelId, String roomType, DateTime date)
    {
        var q = from s in data.Table_Arrangement
                where s.HotelId == hotelId && s.RoomType == roomType && s.Date.ToShortDateString() == date.ToShortDateString()
                select s;
        data.Table_Arrangement.DeleteAllOnSubmit(q);
        data.SubmitChanges();
    }

    //获得所有支付方式
    public List<Table_PayMethod> GetAllPayMethod()
    {
        var q = from s in data.Table_PayMethod
                select s;
        return q.ToList();
    }
}