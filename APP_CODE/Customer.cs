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

    public String EmailAddress
    {
        get { return emailAddress; }
        set { emailAddress = value; }
    }

    private String password;

    public String Password
    {
        get { return password; }
        set { password = value; }
    }

    private String firstName;

    public String FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    private String lastName;

    public String LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    private String sex;

    public String Sex
    {
        get { return sex; }
        set { sex = value; }
    }

    private String phoneNumber;

    public String PhoneNumber
    {
        get { return phoneNumber; }
        set { phoneNumber = value; }
    }

    private Basket basket;

    public Basket Basket
    {
        get { return basket; }
        set { basket = value; }
    }

    private String creditCardNumber;

    public String CreditCardNumber
    {
        get { return creditCardNumber; }
        set { creditCardNumber = value; }
    }

    
}