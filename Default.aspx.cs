using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TextBox1.Attributes.Add("Value", "Enter a City or Airport");
            TextBox1.Attributes.Add("OnFocus", "if(this.value=='Enter a City or Airport') {this.value=''}");
            TextBox1.Attributes.Add("OnBlur", "if(this.value==''){this.value='Enter a City or Airport'}");
            Calendar1.SelectedDate = System.DateTime.Now;
            Calendar2.SelectedDate = System.DateTime.Now.AddDays(1);
            Button1.Text = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
            Button2.Text = Calendar2.SelectedDate.ToString("yyyy/MM/dd");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
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
    protected void Button2_Click(object sender, EventArgs e)
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
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        Button1.Text = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
        Calendar1.Visible = false;
    }
    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        Button2.Text = Calendar2.SelectedDate.ToString("yyyy/MM/dd");
        Calendar2.Visible = false;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "Enter a City or Airport")
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('Enter a City or Airport.')", true);
            return;
        }
        if (Button1.Text == "Check In" || Button2.Text == "Check Out")
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('Check In and Check Out date could not be empty.')", true);
            return;
        }
        Response.Redirect("SearchResult.aspx?Address=" + TextBox1.Text + "&CheckIn=" + Button1.Text + "&CheckOut=" + Button2.Text + "&RoomNum=" + DropDownList1.SelectedValue.ToString().Substring(0, 1) + "&GuestNum=" + DropDownList2.SelectedValue.ToString().Substring(0, 1));
    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        e.Day.IsSelectable = e.Day.Date >= DateTime.Now.Date;
    }
    protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
    {
        e.Day.IsSelectable = e.Day.Date > DateTime.Now.Date;
    }
}