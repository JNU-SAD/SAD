using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
public partial class HotelDetial : System.Web.UI.Page
{
    protected Dbc dbc = new Dbc();
    protected static List<Table_Room> Room = new List<Table_Room>();
    protected static Table_Hotel hotel = new Table_Hotel();
    protected static int price;
    protected static string CheckIn;
    protected static string CheckOut;
    protected static int RoomNum;
    protected static int GuestNum;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                Room = dbc.GetRoomByHotelId(Convert.ToInt32(Request["hotelId"]));
                hotel = dbc.GetHotelById(Convert.ToInt32(Request["hotelId"]));
                price = dbc.GetHotelPrice(Convert.ToInt32(Request["hotelId"]));
                CheckIn = Request["CheckIn"];
                CheckOut = Request["CheckOut"];
                RoomNum = Convert.ToInt32(Request["RoomNum"]);
                GuestNum = Convert.ToInt32(Request["GuestNum"]);
            }
            catch (Exception) { }
            Calendar1.SelectedDate = System.DateTime.Now;
            Calendar2.SelectedDate = System.DateTime.Now.AddDays(1);
            Button2.Text = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
            Button3.Text = Calendar2.SelectedDate.ToString("yyyy/MM/dd");
            Label1.Text = CheckIn;
            Label2.Text = CheckOut;
            Label3.Text = RoomNum.ToString() + "Room," + GuestNum.ToString() + "Guest";

            Label_hotelId.Text = hotel.Id.ToString();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = Panel1.Visible ? false : true;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Calendar1.Visible == false)
        {
            Calendar2.Visible = false;
            Calendar1.Visible = true;
        }
        else
        {
            Calendar2.Visible = false;
            Calendar1.Visible = false;
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (Calendar2.Visible == false)
        {
            Calendar1.Visible = false;
            Calendar2.Visible = true;
        }
        else
        {
            Calendar1.Visible = false;
            Calendar2.Visible = false;
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        CheckIn = Button2.Text;
        CheckOut = Button3.Text;
        Label1.Text = Button2.Text;
        Label2.Text = Button3.Text;
        RoomNum = Convert.ToInt32(DropDownList1.SelectedValue.Substring(0,1));
        GuestNum = Convert.ToInt32(DropDownList2.SelectedValue.Substring(0, 1));
        Label3.Text = RoomNum.ToString() + "Room," + GuestNum.ToString() + "Guest";
        Panel1.Visible = false;
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        if (Calendar1.SelectedDate > Calendar2.SelectedDate)
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('Please select a real date.')", true);
            Calendar1.SelectedDate = Calendar2.SelectedDate;
        }
        Button2.Text = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
        Calendar1.Visible = false;
    }
    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        if (Calendar1.SelectedDate > Calendar2.SelectedDate)
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('Please select a real date.')", true);
            Calendar2.SelectedDate = Calendar1.SelectedDate.AddDays(1);
        }
        Button3.Text = Calendar2.SelectedDate.ToString("yyyy/MM/dd");
        Calendar2.Visible = false;
    }
    /*
    protected void Button5_Command(object sender, CommandEventArgs e)
    {
        //先判断是否登陆
        if (Session["Customer"] == null)
        {
            Response.Write("<script>alert('Login Required.')</script>");
            return;
        }
        DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
        dtFormat.ShortDatePattern = "yyyy/MM/dd";
        Table_HotelReservation reservation = new Table_HotelReservation();
        reservation.CheckIn = Convert.ToDateTime(CheckIn, dtFormat);
        reservation.CheckOut = Convert.ToDateTime(CheckOut, dtFormat);
        reservation.Customer = Session["Customer"].ToString();
        reservation.HotelId = hotel.Id;
        reservation.RoomNum = RoomNum;
        reservation.RoomType = e.CommandName;
        reservation.Status = 0;
        Session["Reservation"] = reservation;
        Response.Redirect("ComfirmOrder.aspx");
    }
    */
}