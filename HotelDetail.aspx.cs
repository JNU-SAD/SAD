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
    protected static List<Table_Arrangement> arrangement = new List<Table_Arrangement>();
    protected static List<Table_Arrangement> _arrangement = new List<Table_Arrangement>();
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
   

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefleshPanel2();
        
    
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            GridView1.Rows[i].Cells[1].Text = "$" + GridView1.Rows[i].Cells[1].Text;
            
        }
        GridView1.SelectedIndex = 0;
        RefleshPanel2();
    }
    private void RefleshPanel2()
    {
        String roomtype = GridView1.SelectedRow.Cells[0].Text;
        int hotelId = hotel.Id;
        arrangement = dbc.GetArrangementByHotelIdAndRoomType(hotelId, roomtype);
        _arrangement.Clear();
        for (int i = 0; i < 10; i++)
        {
            bool found = false;
            foreach (Table_Arrangement a in arrangement)
            {
                if (a.Date.ToShortDateString() == DateTime.Now.AddDays(i).ToShortDateString())
                {
                    _arrangement.Add(a);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Table_Arrangement a = new Table_Arrangement();
                a.HotelId = hotel.Id;
                a.RoomType = GridView1.SelectedRow.Cells[0].Text;
                a.Date = DateTime.Now.AddDays(i);
                a.BookedNumber = 0;
                a.Rate = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text.Substring(1, GridView1.SelectedRow.Cells[1].Text.Length - 1));
                _arrangement.Add(a);
            }
        }
    }

    protected void Button_BookNow_Click(object sender, EventArgs e)
    {

        DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
        dtFormat.ShortDatePattern = "yyyy/MM/dd";
        Table_HotelReservation reservation = new Table_HotelReservation();
        
        reservation.CheckIn = Convert.ToDateTime(CheckIn, dtFormat);
        reservation.CheckOut = Convert.ToDateTime(CheckOut, dtFormat);
        reservation.HotelId = hotel.Id;
        reservation.RoomNum = RoomNum;
        reservation.RoomType = GridView1.SelectedRow.Cells[0].Text;
        reservation.GuestNum = GuestNum;
        reservation.Status = 0;
        reservation.Value = dbc.GetRoomByHotelIdAndRoomType(reservation.HotelId, reservation.RoomType).FullRate * reservation.RoomNum * (reservation.CheckOut - reservation.CheckIn).Days;
        //订单的用户将在下一个页面确定
        Session["Reservation"] = reservation;
        Response.Redirect("ComfirmOrder.aspx?hotelId=" + Request["hotelId"] + "&Address=" + Request["Address"] + "&CheckIn=" + Request["CheckIn"] + "&CheckOut=" + Request["CheckOut"] + "&RoomNum=" + Request["RoomNum"] + "&GuestNum=" + Request["GuestNum"]);

    }
}