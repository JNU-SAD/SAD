using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel1.Visible = Panel1.Visible ? false : true;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (TextBox3.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('Email can not be empty.')", true);
            return;
        }
        else if(TextBox4.Text==""||TextBox5.Text=="")
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('Password can not be empty.')", true);
            return;
        }
        else if (TextBox4.Text != TextBox5.Text)
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('Passwords must be matched.')", true);
            return;
        }
        Customer customer = new Customer();
        customer.EmailAddress = TextBox3.Text;
        customer.Password = TextBox4.Text;
        customer.FirstName = customer.LastName = customer.PhoneNumber = customer.Sex = customer.CreditCardNumber = "";
        DatabaseConnector dbc = new DatabaseConnector();
        if (dbc.AddCustomer(customer))
        {
            Session["Customer"] = customer.EmailAddress;
            Panel1.Visible = false;
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('Email already Exist.')", true);
            return;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "" || TextBox2.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('Email and password can not be empty.')", true);
            return;
        }
        String password=TextBox2.Text;
        DatabaseConnector dbc = new DatabaseConnector();
        Customer customer = dbc.GetCustomer(TextBox1.Text);
        if (customer != null)
        {
            if (customer.Password.Equals(password))
            {
                Panel1.Visible = false;
                Session["Customer"] = customer.EmailAddress;
            }
        }
        else
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('Incorrect email or password.')", true);
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Session.Contents.Clear();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
