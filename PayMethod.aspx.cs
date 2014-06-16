using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PayMethod : System.Web.UI.Page
{
    protected static Dbc dbc = new Dbc();
    protected static List<Table_PayMethod> paymethods = new List<Table_PayMethod>();
    protected static Table_HotelReservation Reservation = new Table_HotelReservation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["Reservation"] == null) || (Session["Customer"] == null))
            Response.Redirect("Default.aspx");
        if (!IsPostBack)
        {
            Reservation = (Table_HotelReservation)Session["Reservation"];
            paymethods = dbc.GetAllPayMethod();
        }
    }
    protected void button1_Click(object sender, EventArgs e)
    {
        Reservation.Status = 1;
        if (Reservation.Id == -1)
        {
            dbc.AddHotelReservation(Reservation);
        }
        else
        {
            dbc.UpdateHotelReservation(Reservation);
        }
        try
        {
            DateTime time = new DateTime();
            for (time = Reservation.CheckIn; time != Reservation.CheckOut; time.AddDays(1))
            {
                Table_Arrangement arrangement = new Table_Arrangement();
                if (!dbc.GetArrangementByHotelIdRoomTypeData(Reservation.HotelId, Reservation.RoomType, time))
                {
                    arrangement.BookedNumber = 1;
                    arrangement.Date = time;
                    arrangement.HotelId = Reservation.HotelId;
                    arrangement.RoomType = Reservation.RoomType;
                    arrangement.Rate = (dbc.GetRoomByHotelIdAndRoomType(Reservation.HotelId, Reservation.RoomType)).FullRate;
                    dbc.AddArrangement(arrangement);
                }
                else
                {
                    arrangement = dbc.GetArrangementByHotelIdRoomTypeAndData(Reservation.HotelId, Reservation.RoomType, time);
                    arrangement.BookedNumber++;
                    dbc.UpdateArrangement(arrangement);
                }
            }
        }
        catch (Exception) { }
        Response.Redirect("Management.aspx");
    }
}