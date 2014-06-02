using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ComfirmOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //如果用户已经登陆则textbox1-5依次填入用户信息。
            //如果用户没有登陆，则textbook1-5为空
            //加载右边订单信息
            Table_HotelReservation reservation = (Table_HotelReservation)Session["Reservation"];
            Label7.Text = reservation.RoomType;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //按下按钮清空联系人信息
        TextBox1.Text = TextBox2.Text = TextBox3.Text = TextBox4.Text = TextBox5.Text = null;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if(TextBox1.Text==null||TextBox2.Text==null||TextBox3.Text==null||TextBox4.Text==null||TextBox5.Text==null)
        {
            //ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('All fields must not be empty.')", true);
            return;
        }

    }
}