using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Management : System.Web.UI.Page
{
    private Dbc dbc = new Dbc();
    private DataClassesDataContext data = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Customer"] == null)
            Response.Redirect("Default.aspx");
        if (!IsPostBack)
        {
            
            Panel3.Visible = true;

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel4.Visible = Panel2.Visible = Panel3.Visible = false;
        Panel1.Visible = true;

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Panel4.Visible = Panel1.Visible = Panel3.Visible = false;
        Panel2.Visible = true;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel4.Visible = Panel2.Visible = Panel1.Visible = false;
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

            GridView2.Rows[i].Cells[1].Text = dbc.GetHotelById(Convert.ToInt32(GridView2.Rows[i].Cells[1].Text)).Name;
            GridView2.Rows[i].Cells[3].Text = "$" + GridView2.Rows[i].Cells[3].Text;
            if (GridView2.Rows[i].Cells[4].Text == "1")
                GridView2.Rows[i].Cells[4].Text = "Paid";
            else
                GridView2.Rows[i].Cells[4].Text = "Unpaid";
        }
    }
    protected void DetailsView2_DataBound(object sender, EventArgs e)
    {
        if (DetailsView2.Rows.Count == 0)
        {
            div1.Visible = true;
            Button5.Visible = false;
            Button6.Visible = false;
            return;
        }
        DetailsView2.Rows[1].Cells[1].Text = dbc.GetHotelById(Convert.ToInt32(DetailsView2.Rows[1].Cells[1].Text)).Name;
        DetailsView2.Rows[4].Cells[1].Text = DetailsView2.Rows[4].Cells[1].Text.Substring(0, DetailsView2.Rows[4].Cells[1].Text.IndexOf(" ")).Trim();
        DetailsView2.Rows[5].Cells[1].Text = DetailsView2.Rows[5].Cells[1].Text.Substring(0, DetailsView2.Rows[5].Cells[1].Text.IndexOf(" ")).Trim();
        DetailsView2.Rows[6].Cells[1].Text = "$" + DetailsView2.Rows[6].Cells[1].Text;
        DetailsView2.Rows[7].Cells[1].Text = DetailsView2.Rows[7].Cells[1].Text == "0" ? "Unpaid" : "Paid";
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        if (GridView2.SelectedRow.Cells[4].Text == "Paid")
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('Had Paid')", true);
            return;
        }
        Session["Reservation"] = dbc.GetHotelReservationById(Convert.ToInt32(GridView2.SelectedRow.Cells[0].Text));
        Response.Redirect("ConfirmOrder.aspx");
    }
    protected void Button_comment_Click(object sender, EventArgs e)
    {
        if (dbc.GetCommentByReservationId(Convert.ToInt32(GridView2.SelectedRow.Cells[0].Text)))
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('You Had Commented The Reservation!')", true);
            return;
        }
        try
        {
            Table_Comment c = new Table_Comment();
            c.Date = DateTime.Now;
            c.HotelId = dbc.GetHotelReservationById(Convert.ToInt32(GridView2.SelectedRow.Cells[0].Text)).HotelId;
            c.Score = DropDownList1.SelectedIndex + 1;
            c.Comment = textbox_comment.Text + " ";
            c.CustomerEmail = Session["Customer"].ToString();
            c.ReservationId = Convert.ToInt32(DetailsView3.Rows[4].Cells[1].Text);
            data.Table_Comment.InsertOnSubmit(c);
            data.SubmitChanges();
        }
        catch (Exception) { }

    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        Panel1.Visible = Panel2.Visible = Panel3.Visible = false;
        Panel4.Visible = true;
    }
    protected void GridView3_DataBound(object sender, EventArgs e)
    {
        GridView3.SelectedIndex = 0;
        try
        {
            for (int i = 0; i < GridView3.Rows.Count; i++)
            {

                GridView3.Rows[i].Cells[1].Text = dbc.GetHotelById(Convert.ToInt32(GridView3.Rows[i].Cells[1].Text)).Name;
                GridView3.Rows[i].Cells[3].Text = GridView3.Rows[i].Cells[3].Text.Substring(0, GridView3.Rows[i].Cells[3].Text.IndexOf(" ")).Trim();
            }
        }
        catch (Exception) { }
    }
    protected void DetailsView3_DataBound(object sender, EventArgs e)
    {
        if (DetailsView3.Rows.Count == 0)
        {

            return;
        }
        DetailsView3.Rows[0].Cells[1].Text = dbc.GetHotelById(Convert.ToInt32(DetailsView3.Rows[0].Cells[1].Text)).Name;
        
    }
    
}