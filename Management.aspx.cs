using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Management : System.Web.UI.Page
{
    private Dbc dbc = new Dbc();
    //protected static List<Table_HotelReservation> reservations = new List<Table_HotelReservation>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel3.Visible = true;
            //reservations = dbc.GetHotelReservationByEmailAddress(Session["Customer"].ToString());

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel2.Visible = Panel3.Visible = false;
        Panel1.Visible = true;
        
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Panel1.Visible = Panel3.Visible = false;
        Panel2.Visible = true;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel2.Visible = Panel1.Visible = false;
        Panel3.Visible = true;
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == String.Empty || TextBox2.Text == String.Empty || TextBox3.Text == String.Empty)
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('All fields must not be empty.')", true);
            return;
        }
        if (TextBox2.Text != TextBox3.Text)
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('New Passwords must be match.')", true);
            return;
        }
        Table_Customer c = dbc.GetCustomer(Session["Customer"].ToString());
        if (TextBox1.Text != c.Password)
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('Incorrect old password.')", true);
        }
        else
        {
            c.Password = TextBox2.Text;
            dbc.UpdateCustomer(c);
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('Success.')", true);
        }
    }


    protected void GridView2_DataBound(object sender, EventArgs e)
    {
        GridView2.SelectedIndex = 0;
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            GridView2.Rows[i].Cells[4].Text = GridView2.Rows[i].Cells[4].Text.Substring(0, GridView2.Rows[i].Cells[4].Text.IndexOf(" ")).Trim();
            GridView2.Rows[i].Cells[5].Text = GridView2.Rows[i].Cells[5].Text.Substring(0, GridView2.Rows[i].Cells[5].Text.IndexOf(" ")).Trim();
            if (GridView2.Rows[i].Cells[6].Text == "1")
                GridView2.Rows[i].Cells[6].Text = "Paid";
            else
                GridView2.Rows[i].Cells[6].Text = "Unpaid";
        }
    }
    protected void DetailsView2_DataBound(object sender, EventArgs e)
    {
        DetailsView2.Rows[5].Cells[1].Text = DetailsView2.Rows[5].Cells[1].Text.Substring(0, DetailsView2.Rows[5].Cells[1].Text.IndexOf(" ")).Trim();
        DetailsView2.Rows[6].Cells[1].Text = DetailsView2.Rows[6].Cells[1].Text.Substring(0, DetailsView2.Rows[6].Cells[1].Text.IndexOf(" ")).Trim();
        DetailsView2.Rows[7].Cells[1].Text = DetailsView2.Rows[7].Cells[1].Text == "0" ? "Unpaid" : "Paid";
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        Session["Reservation"] = dbc.GetHotelReservationById(Convert.ToInt32(GridView2.SelectedRow.Cells[0].Text));
        Response.Redirect("ComfirmOrder.aspx");
    }
}