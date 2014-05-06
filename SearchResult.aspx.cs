using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchResult : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DatabaseConnector dbc = new DatabaseConnector();
            List<Hotel> result = new List<Hotel>();
            String Location = Request["Location"];
            foreach (Hotel hotel in dbc.GetAllHotel())
            {
                if (hotel.Address.Contains(Location))
                    result.Add(hotel);
            }
            GridView1.DataSource = result;
            GridView1.DataBind();

        }
    }
}