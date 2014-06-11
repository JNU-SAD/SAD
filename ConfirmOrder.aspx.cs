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

            reservation = (Table_HotelReservation)Session["Reservation"];
            if (reservation.Id != null)
            {
                TextBox1.Text = reservation.name.Substring(0, reservation.name.IndexOf(".", 0));
                TextBox2.Text = reservation.name.Substring(reservation.name.IndexOf(".", 0), reservation.name.Length - reservation.name.IndexOf(".", 0));
                TextBox5.Text = reservation.EmailAddress;
                if (reservation.sex == "male")
                    DropDownList1.SelectedIndex = 0;
                else
                    DropDownList1.SelectedIndex = 1;
            }
            //如果用户已经登陆则textbox1-5依次填入用户信息。
            if (Session["Customer"] != null)
            {
                Table_Customer customer = dbc.GetCustomer(Session["Customer"].ToString());
                TextBox1.Text = customer.FirstName;
                TextBox2.Text = customer.LastName;
                TextBox3.Text = customer.PhoneNumber;
                TextBox5.Text = customer.EmailAddress;
                if (customer.Sex == "male")
                    DropDownList1.SelectedIndex = 0;
                else
                    DropDownList1.SelectedIndex = 1;
                TextBox1.Enabled = TextBox2.Enabled = TextBox3.Enabled = TextBox5.Enabled = false;
                DropDownList1.Enabled = false;
            }
            //如果用户没有登陆，则textbook1-5为空
            //加载右边订单信息
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
        TextBox1.Text = TextBox2.Text = TextBox3.Text = TextBox5.Text = String.Empty;
        TextBox1.Enabled = TextBox2.Enabled = TextBox3.Enabled = TextBox5.Enabled = true;
        DropDownList1.Enabled = true;
        DropDownList1.SelectedIndex = 0;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Session["Customer"] != null)
        {
            if (TextBox1.Text == String.Empty || TextBox2.Text == String.Empty || TextBox3.Text == String.Empty || TextBox5.Text == String.Empty)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('All fields must not be empty.')", true);
                return;
            }
            try
            {
                reservation.name = TextBox1.Text +"."+ TextBox2.Text;
                reservation.sex = DropDownList1.Text.ToString();
                reservation.EmailAddress = TextBox5.Text.ToString();
                reservation.Customer = Session["Customer"].ToString();
                Response.Redirect("PayMethod.aspx");
            }
            catch (Exception) { }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('Login Required')", true);
            return;
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (Session["Customer"] != null)
        {
            Table_Customer customer = dbc.GetCustomer(Session["Customer"].ToString());
            TextBox1.Text = customer.FirstName;
            TextBox2.Text = customer.LastName;
            TextBox3.Text = customer.PhoneNumber;
            TextBox5.Text = customer.EmailAddress;
            if (customer.Sex == "male")
                DropDownList1.SelectedIndex = 0;
            else
                DropDownList1.SelectedIndex = 1;
            TextBox1.Enabled = TextBox2.Enabled = TextBox3.Enabled  = TextBox5.Enabled = false;
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
        if (Session["Customer"] != null)
        {
            if (TextBox1.Text == String.Empty || TextBox2.Text == String.Empty || TextBox3.Text == String.Empty || TextBox5.Text == String.Empty)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('All fields must not be empty.')", true);
                return;
            }
            try
            {
                reservation.name = TextBox1.Text + TextBox2.Text;
                reservation.sex = DropDownList1.Text.ToString();
                reservation.EmailAddress = TextBox5.Text.ToString();
                reservation.Customer = Session["Customer"].ToString();
                if (reservation.Id == null)
                    dbc.AddHotelReservation(reservation);
                Response.Redirect("Management.aspx");
            }
            catch (Exception) { }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('Login Required')", true);
            return;
        }
    }
    
}