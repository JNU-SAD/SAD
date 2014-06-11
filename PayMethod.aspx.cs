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
        dbc.AddHotelReservation(Reservation);
        Response.Redirect("Management.aspx");
    }
}