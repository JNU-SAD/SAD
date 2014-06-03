﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18408
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;



[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Database")]
public partial class DataClassesDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region 可扩展性方法定义
  partial void OnCreated();
  partial void InsertTable_Arrangement(Table_Arrangement instance);
  partial void UpdateTable_Arrangement(Table_Arrangement instance);
  partial void DeleteTable_Arrangement(Table_Arrangement instance);
  partial void InsertTable_Customer(Table_Customer instance);
  partial void UpdateTable_Customer(Table_Customer instance);
  partial void DeleteTable_Customer(Table_Customer instance);
  partial void InsertTable_Hotel(Table_Hotel instance);
  partial void UpdateTable_Hotel(Table_Hotel instance);
  partial void DeleteTable_Hotel(Table_Hotel instance);
  partial void InsertTable_Room(Table_Room instance);
  partial void UpdateTable_Room(Table_Room instance);
  partial void DeleteTable_Room(Table_Room instance);
  partial void InsertTable_HotelReservation(Table_HotelReservation instance);
  partial void UpdateTable_HotelReservation(Table_HotelReservation instance);
  partial void DeleteTable_HotelReservation(Table_HotelReservation instance);
  #endregion
	
	public DataClassesDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<Table_Arrangement> Table_Arrangement
	{
		get
		{
			return this.GetTable<Table_Arrangement>();
		}
	}
	
	public System.Data.Linq.Table<Table_Customer> Table_Customer
	{
		get
		{
			return this.GetTable<Table_Customer>();
		}
	}
	
	public System.Data.Linq.Table<Table_Hotel> Table_Hotel
	{
		get
		{
			return this.GetTable<Table_Hotel>();
		}
	}
	
	public System.Data.Linq.Table<Table_Room> Table_Room
	{
		get
		{
			return this.GetTable<Table_Room>();
		}
	}
	
	public System.Data.Linq.Table<Table_HotelReservation> Table_HotelReservation
	{
		get
		{
			return this.GetTable<Table_HotelReservation>();
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Table_Arrangement")]
public partial class Table_Arrangement : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _HotelId;
	
	private string _RoomType;
	
	private System.DateTime _Date;
	
	private int _Rate;
	
	private int _BookedNumber;
	
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnHotelIdChanging(int value);
    partial void OnHotelIdChanged();
    partial void OnRoomTypeChanging(string value);
    partial void OnRoomTypeChanged();
    partial void OnDateChanging(System.DateTime value);
    partial void OnDateChanged();
    partial void OnRateChanging(int value);
    partial void OnRateChanged();
    partial void OnBookedNumberChanging(int value);
    partial void OnBookedNumberChanged();
    #endregion
	
	public Table_Arrangement()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HotelId", DbType="Int NOT NULL", IsPrimaryKey=true)]
	public int HotelId
	{
		get
		{
			return this._HotelId;
		}
		set
		{
			if ((this._HotelId != value))
			{
				this.OnHotelIdChanging(value);
				this.SendPropertyChanging();
				this._HotelId = value;
				this.SendPropertyChanged("HotelId");
				this.OnHotelIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoomType", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
	public string RoomType
	{
		get
		{
			return this._RoomType;
		}
		set
		{
			if ((this._RoomType != value))
			{
				this.OnRoomTypeChanging(value);
				this.SendPropertyChanging();
				this._RoomType = value;
				this.SendPropertyChanged("RoomType");
				this.OnRoomTypeChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="DateTime NOT NULL", IsPrimaryKey=true)]
	public System.DateTime Date
	{
		get
		{
			return this._Date;
		}
		set
		{
			if ((this._Date != value))
			{
				this.OnDateChanging(value);
				this.SendPropertyChanging();
				this._Date = value;
				this.SendPropertyChanged("Date");
				this.OnDateChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Rate", DbType="Int NOT NULL")]
	public int Rate
	{
		get
		{
			return this._Rate;
		}
		set
		{
			if ((this._Rate != value))
			{
				this.OnRateChanging(value);
				this.SendPropertyChanging();
				this._Rate = value;
				this.SendPropertyChanged("Rate");
				this.OnRateChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BookedNumber", DbType="Int NOT NULL")]
	public int BookedNumber
	{
		get
		{
			return this._BookedNumber;
		}
		set
		{
			if ((this._BookedNumber != value))
			{
				this.OnBookedNumberChanging(value);
				this.SendPropertyChanging();
				this._BookedNumber = value;
				this.SendPropertyChanged("BookedNumber");
				this.OnBookedNumberChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Table_Customer")]
public partial class Table_Customer : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private string _EmailAddress;
	
	private string _Password;
	
	private string _FirstName;
	
	private string _LastName;
	
	private string _Sex;
	
	private string _PhoneNumber;
	
	private string _CreditCardNumber;
	
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnEmailAddressChanging(string value);
    partial void OnEmailAddressChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnSexChanging(string value);
    partial void OnSexChanged();
    partial void OnPhoneNumberChanging(string value);
    partial void OnPhoneNumberChanged();
    partial void OnCreditCardNumberChanging(string value);
    partial void OnCreditCardNumberChanged();
    #endregion
	
	public Table_Customer()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmailAddress", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
	public string EmailAddress
	{
		get
		{
			return this._EmailAddress;
		}
		set
		{
			if ((this._EmailAddress != value))
			{
				this.OnEmailAddressChanging(value);
				this.SendPropertyChanging();
				this._EmailAddress = value;
				this.SendPropertyChanged("EmailAddress");
				this.OnEmailAddressChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="VarChar(50) NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
	public string Password
	{
		get
		{
			return this._Password;
		}
		set
		{
			if ((this._Password != value))
			{
				this.OnPasswordChanging(value);
				this.SendPropertyChanging();
				this._Password = value;
				this.SendPropertyChanged("Password");
				this.OnPasswordChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="VarChar(50)", UpdateCheck=UpdateCheck.Never)]
	public string FirstName
	{
		get
		{
			return this._FirstName;
		}
		set
		{
			if ((this._FirstName != value))
			{
				this.OnFirstNameChanging(value);
				this.SendPropertyChanging();
				this._FirstName = value;
				this.SendPropertyChanged("FirstName");
				this.OnFirstNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="VarChar(50)", UpdateCheck=UpdateCheck.Never)]
	public string LastName
	{
		get
		{
			return this._LastName;
		}
		set
		{
			if ((this._LastName != value))
			{
				this.OnLastNameChanging(value);
				this.SendPropertyChanging();
				this._LastName = value;
				this.SendPropertyChanged("LastName");
				this.OnLastNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sex", DbType="VarChar(50)", UpdateCheck=UpdateCheck.Never)]
	public string Sex
	{
		get
		{
			return this._Sex;
		}
		set
		{
			if ((this._Sex != value))
			{
				this.OnSexChanging(value);
				this.SendPropertyChanging();
				this._Sex = value;
				this.SendPropertyChanged("Sex");
				this.OnSexChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PhoneNumber", DbType="VarChar(50)", UpdateCheck=UpdateCheck.Never)]
	public string PhoneNumber
	{
		get
		{
			return this._PhoneNumber;
		}
		set
		{
			if ((this._PhoneNumber != value))
			{
				this.OnPhoneNumberChanging(value);
				this.SendPropertyChanging();
				this._PhoneNumber = value;
				this.SendPropertyChanged("PhoneNumber");
				this.OnPhoneNumberChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreditCardNumber", DbType="VarChar(50)", UpdateCheck=UpdateCheck.Never)]
	public string CreditCardNumber
	{
		get
		{
			return this._CreditCardNumber;
		}
		set
		{
			if ((this._CreditCardNumber != value))
			{
				this.OnCreditCardNumberChanging(value);
				this.SendPropertyChanging();
				this._CreditCardNumber = value;
				this.SendPropertyChanged("CreditCardNumber");
				this.OnCreditCardNumberChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Table_Hotel")]
public partial class Table_Hotel : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _Id;
	
	private string _Name;
	
	private string _Address;
	
	private int _StarLevel;
	
	private string _ContactNumber;
	
	private string _ImageUrl;

    private int price;

    public int Price
    {
        get { return price; }
        set { price = value; }
    }
    private List<Table_Room> room;

    public List<Table_Room> Room
    {
        get { return room; }
        set { room = value; }
    }
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnAddressChanging(string value);
    partial void OnAddressChanged();
    partial void OnStarLevelChanging(int value);
    partial void OnStarLevelChanged();
    partial void OnContactNumberChanging(string value);
    partial void OnContactNumberChanged();
    partial void OnImageUrlChanging(string value);
    partial void OnImageUrlChanged();
    #endregion

	
	public Table_Hotel()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int Id
	{
		get
		{
			return this._Id;
		}
		set
		{
			if ((this._Id != value))
			{
				this.OnIdChanging(value);
				this.SendPropertyChanging();
				this._Id = value;
				this.SendPropertyChanged("Id");
				this.OnIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
	public string Name
	{
		get
		{
			return this._Name;
		}
		set
		{
			if ((this._Name != value))
			{
				this.OnNameChanging(value);
				this.SendPropertyChanging();
				this._Name = value;
				this.SendPropertyChanged("Name");
				this.OnNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="VarChar(500) NOT NULL", CanBeNull=false)]
	public string Address
	{
		get
		{
			return this._Address;
		}
		set
		{
			if ((this._Address != value))
			{
				this.OnAddressChanging(value);
				this.SendPropertyChanging();
				this._Address = value;
				this.SendPropertyChanged("Address");
				this.OnAddressChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StarLevel", DbType="Int NOT NULL")]
	public int StarLevel
	{
		get
		{
			return this._StarLevel;
		}
		set
		{
			if ((this._StarLevel != value))
			{
				this.OnStarLevelChanging(value);
				this.SendPropertyChanging();
				this._StarLevel = value;
				this.SendPropertyChanged("StarLevel");
				this.OnStarLevelChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ContactNumber", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
	public string ContactNumber
	{
		get
		{
			return this._ContactNumber;
		}
		set
		{
			if ((this._ContactNumber != value))
			{
				this.OnContactNumberChanging(value);
				this.SendPropertyChanging();
				this._ContactNumber = value;
				this.SendPropertyChanged("ContactNumber");
				this.OnContactNumberChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ImageUrl", DbType="VarChar(500)")]
	public string ImageUrl
	{
		get
		{
			return this._ImageUrl;
		}
		set
		{
			if ((this._ImageUrl != value))
			{
				this.OnImageUrlChanging(value);
				this.SendPropertyChanging();
				this._ImageUrl = value;
				this.SendPropertyChanged("ImageUrl");
				this.OnImageUrlChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Table_Room")]
public partial class Table_Room : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _HotelId;
	
	private string _RoomType;
	
	private int _FullRate;
	
	private int _TotalNumber;
	
	private int _Capacity;

    private List<Table_Arrangement> arrangement;

    public List<Table_Arrangement> Arrangement
    {
        get { return arrangement; }
        set { arrangement = value; }
    }
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnHotelIdChanging(int value);
    partial void OnHotelIdChanged();
    partial void OnRoomTypeChanging(string value);
    partial void OnRoomTypeChanged();
    partial void OnFullRateChanging(int value);
    partial void OnFullRateChanged();
    partial void OnTotalNumberChanging(int value);
    partial void OnTotalNumberChanged();
    partial void OnCapacityChanging(int value);
    partial void OnCapacityChanged();
    #endregion
	
	public Table_Room()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HotelId", DbType="Int NOT NULL", IsPrimaryKey=true)]
	public int HotelId
	{
		get
		{
			return this._HotelId;
		}
		set
		{
			if ((this._HotelId != value))
			{
				this.OnHotelIdChanging(value);
				this.SendPropertyChanging();
				this._HotelId = value;
				this.SendPropertyChanged("HotelId");
				this.OnHotelIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoomType", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
	public string RoomType
	{
		get
		{
			return this._RoomType;
		}
		set
		{
			if ((this._RoomType != value))
			{
				this.OnRoomTypeChanging(value);
				this.SendPropertyChanging();
				this._RoomType = value;
				this.SendPropertyChanged("RoomType");
				this.OnRoomTypeChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FullRate", DbType="Int NOT NULL")]
	public int FullRate
	{
		get
		{
			return this._FullRate;
		}
		set
		{
			if ((this._FullRate != value))
			{
				this.OnFullRateChanging(value);
				this.SendPropertyChanging();
				this._FullRate = value;
				this.SendPropertyChanged("FullRate");
				this.OnFullRateChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TotalNumber", DbType="Int NOT NULL")]
	public int TotalNumber
	{
		get
		{
			return this._TotalNumber;
		}
		set
		{
			if ((this._TotalNumber != value))
			{
				this.OnTotalNumberChanging(value);
				this.SendPropertyChanging();
				this._TotalNumber = value;
				this.SendPropertyChanged("TotalNumber");
				this.OnTotalNumberChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Capacity", DbType="Int NOT NULL")]
	public int Capacity
	{
		get
		{
			return this._Capacity;
		}
		set
		{
			if ((this._Capacity != value))
			{
				this.OnCapacityChanging(value);
				this.SendPropertyChanging();
				this._Capacity = value;
				this.SendPropertyChanged("Capacity");
				this.OnCapacityChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Table_HotelReservation")]
public partial class Table_HotelReservation : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _Id;
	
	private string _Customer;
	
	private int _HotelId;
	
	private string _RoomType;
	
	private System.DateTime _CheckIn;
	
	private System.DateTime _CheckOut;
	
	private int _RoomNum;
	
	private int _Status;
	
	private int _GuestNum;
	
	private int _Value;
	
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnCustomerChanging(string value);
    partial void OnCustomerChanged();
    partial void OnHotelIdChanging(int value);
    partial void OnHotelIdChanged();
    partial void OnRoomTypeChanging(string value);
    partial void OnRoomTypeChanged();
    partial void OnCheckInChanging(System.DateTime value);
    partial void OnCheckInChanged();
    partial void OnCheckOutChanging(System.DateTime value);
    partial void OnCheckOutChanged();
    partial void OnRoomNumChanging(int value);
    partial void OnRoomNumChanged();
    partial void OnStatusChanging(int value);
    partial void OnStatusChanged();
    partial void OnGuestNumChanging(int value);
    partial void OnGuestNumChanged();
    partial void OnValueChanging(int value);
    partial void OnValueChanged();
    #endregion
	
	public Table_HotelReservation()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int Id
	{
		get
		{
			return this._Id;
		}
		set
		{
			if ((this._Id != value))
			{
				this.OnIdChanging(value);
				this.SendPropertyChanging();
				this._Id = value;
				this.SendPropertyChanged("Id");
				this.OnIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Customer", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
	public string Customer
	{
		get
		{
			return this._Customer;
		}
		set
		{
			if ((this._Customer != value))
			{
				this.OnCustomerChanging(value);
				this.SendPropertyChanging();
				this._Customer = value;
				this.SendPropertyChanged("Customer");
				this.OnCustomerChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HotelId", DbType="Int NOT NULL")]
	public int HotelId
	{
		get
		{
			return this._HotelId;
		}
		set
		{
			if ((this._HotelId != value))
			{
				this.OnHotelIdChanging(value);
				this.SendPropertyChanging();
				this._HotelId = value;
				this.SendPropertyChanged("HotelId");
				this.OnHotelIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoomType", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
	public string RoomType
	{
		get
		{
			return this._RoomType;
		}
		set
		{
			if ((this._RoomType != value))
			{
				this.OnRoomTypeChanging(value);
				this.SendPropertyChanging();
				this._RoomType = value;
				this.SendPropertyChanged("RoomType");
				this.OnRoomTypeChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CheckIn", DbType="DateTime NOT NULL")]
	public System.DateTime CheckIn
	{
		get
		{
			return this._CheckIn;
		}
		set
		{
			if ((this._CheckIn != value))
			{
				this.OnCheckInChanging(value);
				this.SendPropertyChanging();
				this._CheckIn = value;
				this.SendPropertyChanged("CheckIn");
				this.OnCheckInChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CheckOut", DbType="DateTime NOT NULL")]
	public System.DateTime CheckOut
	{
		get
		{
			return this._CheckOut;
		}
		set
		{
			if ((this._CheckOut != value))
			{
				this.OnCheckOutChanging(value);
				this.SendPropertyChanging();
				this._CheckOut = value;
				this.SendPropertyChanged("CheckOut");
				this.OnCheckOutChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoomNum", DbType="Int NOT NULL")]
	public int RoomNum
	{
		get
		{
			return this._RoomNum;
		}
		set
		{
			if ((this._RoomNum != value))
			{
				this.OnRoomNumChanging(value);
				this.SendPropertyChanging();
				this._RoomNum = value;
				this.SendPropertyChanged("RoomNum");
				this.OnRoomNumChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Int NOT NULL")]
	public int Status
	{
		get
		{
			return this._Status;
		}
		set
		{
			if ((this._Status != value))
			{
				this.OnStatusChanging(value);
				this.SendPropertyChanging();
				this._Status = value;
				this.SendPropertyChanged("Status");
				this.OnStatusChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GuestNum", DbType="Int NOT NULL")]
	public int GuestNum
	{
		get
		{
			return this._GuestNum;
		}
		set
		{
			if ((this._GuestNum != value))
			{
				this.OnGuestNumChanging(value);
				this.SendPropertyChanging();
				this._GuestNum = value;
				this.SendPropertyChanged("GuestNum");
				this.OnGuestNumChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Value", DbType="Int NOT NULL")]
	public int Value
	{
		get
		{
			return this._Value;
		}
		set
		{
			if ((this._Value != value))
			{
				this.OnValueChanging(value);
				this.SendPropertyChanging();
				this._Value = value;
				this.SendPropertyChanged("Value");
				this.OnValueChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
#pragma warning restore 1591
