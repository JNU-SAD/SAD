using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Customer 的摘要说明
/// </summary>
public class Customer
{
	public Customer()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    private String emailAddress;
    private String password;
    private String firstName;
    private String lastName;
    private String sex;
    private String phoneNumber;
    private Basket basket;
    private String creditCardNumber;
    public String EmailAddress
    {
        get { return emailAddress; }
        set { emailAddress = value; }
    }
    public String Password
    {
        get { return password; }
        set { password = value; }
    }
    public String FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }
    public String LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }
    public String Sex
    {
        get { return sex; }
        set { sex = value; }
    }
    public String PhoneNumber
    {
        get { return phoneNumber; }
        set { phoneNumber = value; }
    }
    public Basket Basket
    {
        get { return basket; }
        set { basket = value; }
    }
    public String CreditCardNumber
    {
        get { return creditCardNumber; }
        set { creditCardNumber = value; }
    }

    
}