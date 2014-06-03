using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ComfirmOrder : System.Web.UI.Page
{
    private Dbc dbc = new Dbc();
    protected static Table_Hotel hotel = new Table_Hotel();
    protected static Table_Room room = new Table_Room();
    protected static Table_HotelReservation reservation = new Table_HotelReservation();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            //如果用户已经登陆则textbox1-5依次填入用户信息。
            if (Session["Customer"] != null)
            {
                Table_Customer customer = dbc.GetCustomer(Session["Customer"].ToString());
                TextBox1.Text = customer.FirstName;
                TextBox2.Text = customer.LastName;
                TextBox3.Text = customer.PhoneNumber;
                TextBox4.Text = customer.CreditCardNumber;
                TextBox5.Text = customer.EmailAddress;
                if (customer.Sex == "male")
                    DropDownList1.SelectedIndex = 0;
                else
                    DropDownList1.SelectedIndex = 1;
                TextBox1.Enabled = TextBox2.Enabled = TextBox3.Enabled = TextBox4.Enabled = TextBox5.Enabled = false;
                DropDownList1.Enabled = false;
            }
            //如果用户没有登陆，则textbook1-5为空
            //加载右边订单信息
            reservation = (Table_HotelReservation)Session["Reservation"];
            hotel = dbc.GetHotelById(reservation.HotelId);
            room = dbc.GetRoomByHotelIdAndRoomType(reservation.HotelId, reservation.RoomType);
            TimeSpan t=reservation.CheckOut-reservation.CheckIn;
            //
            Label10.Text = "$" + room.FullRate.ToString();
            Label1.Text = t.Days.ToString();
            Label2.Text = reservation.RoomNum.ToString();
            Label3.Text = reservation.GuestNum.ToString();
            Label4.Text = "$" + reservation.Value.ToString();
            Label_cost.InnerText = "$" + reservation.Value.ToString();
            Label5.Text = hotel.Name;
            Label6.Text = hotel.Address;
            Label7.Text = reservation.RoomType;
            Label8.Text = reservation.CheckIn.ToString("yyyy/MM/dd");
            Label9.Text = reservation.CheckOut.ToString("yyyy/MM/dd");

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //按下按钮清空联系人信息
        TextBox1.Text = TextBox2.Text = TextBox3.Text = TextBox4.Text = TextBox5.Text = String.Empty;
        TextBox1.Enabled = TextBox2.Enabled = TextBox3.Enabled = TextBox4.Enabled = TextBox5.Enabled = true;
        DropDownList1.Enabled = true;
        DropDownList1.SelectedIndex = 0;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == String.Empty || TextBox2.Text == String.Empty || TextBox3.Text == String.Empty || TextBox4.Text == String.Empty || TextBox5.Text == String.Empty)
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('All fields must not be empty.')", true);
            return;
        }
        Response.Redirect("PayMethod.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (Session["Customer"] != null)
        {
            Table_Customer customer = dbc.GetCustomer(Session["Customer"].ToString());
            TextBox1.Text = customer.FirstName;
            TextBox2.Text = customer.LastName;
            TextBox3.Text = customer.PhoneNumber;
            TextBox4.Text = customer.CreditCardNumber;
            TextBox5.Text = customer.EmailAddress;
            if (customer.Sex == "male")
                DropDownList1.SelectedIndex = 0;
            else
                DropDownList1.SelectedIndex = 1;
            TextBox1.Enabled = TextBox2.Enabled = TextBox3.Enabled = TextBox4.Enabled = TextBox5.Enabled = false;
            DropDownList1.Enabled = false;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('Login Required.')", true);
            return;
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == String.Empty || TextBox2.Text == String.Empty || TextBox3.Text == String.Empty || TextBox4.Text == String.Empty || TextBox5.Text == String.Empty)
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('All fields must not be empty.')", true);
            return;
        }
        try
        {
            reservation.Customer = Session["Customer"].ToString();
            dbc.AddHotelReservation(reservation);
            Response.Redirect("Management.aspx");
        }
        catch (Exception) { }
    }
}