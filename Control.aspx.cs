using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Control : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.Items.Clear();
            DropDownList1.DataSource = dbc.GetHotelIds();
            DropDownList1.DataBind();
        }
    }
    private DatabaseConnector dbc = new DatabaseConnector();
    protected void Button2_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = dbc.GetAllHotel();
        GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Hotel hotel = new Hotel();
        hotel.Name = TextBox1.Text;
        hotel.Address = TextBox2.Text;
        hotel.StarLevel = Convert.ToInt32(TextBox3.Text);
        hotel.ContactNumber = TextBox4.Text;
        hotel.ImageUrl = TextBox5.Text;
        if(dbc.AddHotel(hotel))
            Response.Write("<script>alert('Added')</script>");
        else
            Response.Write("<script>alert('Failed')</script>");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Room room = new Room();
        room.HotelId = Convert.ToInt32(DropDownList1.SelectedValue);
        room.RoomType = TextBox7.Text;
        room.FullRate = Convert.ToInt32(TextBox8.Text);
        room.TotalNumber = Convert.ToInt32(TextBox9.Text);
        room.Capacity = Convert.ToInt32(TextBox10.Text);
        if (dbc.AddRoom(room))
            Response.Write("<script>alert('Added')</script>");
        else
            Response.Write("<script>alert('Failed')</script>");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = dbc.GetAllRoom();
        GridView1.DataBind();
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        Arrangement a = new Arrangement();
        a.HotelId = Convert.ToInt32(TextBox11.Text);
        a.RoomType = TextBox12.Text;
        a.Date = Calendar1.SelectedDate;
        a.Rate = Convert.ToInt32(TextBox14.Text);
        a.BookedNumber = Convert.ToInt32(TextBox15.Text);
        if (dbc.AddArrangement(a))
            Response.Write("<script>alert('Added')</script>");
        else
            Response.Write("<script>alert('Failed')</script>");
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = dbc.GetAllArrangement();
        GridView1.DataBind();
    }
}