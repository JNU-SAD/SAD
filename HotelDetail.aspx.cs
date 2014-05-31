using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HotelDetial : System.Web.UI.Page
{
    protected Dbc dbc = new Dbc();
    protected  List<Table_Room> Room =new List<Table_Room>();
    protected Table_Hotel hotel = new Table_Hotel();
    protected int price;
    protected string CheckIn;
    protected string CheckOut;
    protected int RoomNum;
    protected int GuestNum;
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
        RoomNum = Convert.ToInt32(DropDownList1.SelectedValue);
        GuestNum = Convert.ToInt32(DropDownList2.SelectedValue);
        Panel1.Visible = false;
    }
    protected void Button5_Click(object sender, EventArgs e)
    {

    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        Button2.Text = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
        Calendar1.Visible = false;
    }
    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        Button3.Text = Calendar2.SelectedDate.ToString("yyyy/MM/dd");
        Calendar2.Visible = false;
    }
}