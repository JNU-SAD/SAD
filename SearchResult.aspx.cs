using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchResult : System.Web.UI.Page
{
    private Server server = new Server();
    private Dbc dbc = new Dbc();
    private static String nameFilter = null;//储存要过滤的酒店名
    protected static List<Table_Hotel> result = new List<Table_Hotel>();//符合地址的所有酒店集合
    protected static List<Table_Hotel> unFilteredResult = new List<Table_Hotel>();//在result基础上根据日期，房间数，人数过滤后的酒店集合
    protected static List<Table_Hotel> filteredResult = new List<Table_Hotel>();//在unFilteredResult基础上根据酒店名，价格，星级过滤后的集合

    protected bool isFiltering()//判断是否使用了页内过滤
    {
        return isNameFiltering() || isPriceFiltering() || isStarFiltering();
    }
    private bool isNameFiltering()//判断是否使用了酒店名过滤
    {
        if (nameFilter == null)
            return false;
        return true;
    }
    private bool isPriceFiltering()//判断是否使用了价格过滤
    {
        return CheckBox1.Checked || CheckBox2.Checked || CheckBox3.Checked || CheckBox4.Checked;
    }
    private bool isStarFiltering()//判断是否使用了星级过滤
    {
        return CheckBox5.Checked || CheckBox6.Checked || CheckBox7.Checked || CheckBox8.Checked || CheckBox9.Checked;
    }
    private void doFilter()//执行过滤
    {
        filteredResult.Clear();
        divFilters.Visible = true;
        //过滤酒店名
        if (nameFilter != null)
        {
            foreach (Table_Hotel hotel in unFilteredResult)
            {
                if (hotel.Name.Contains(nameFilter))
                    filteredResult.Add(hotel);
            }
            ButtonFilter1.Text = "\"" + nameFilter + "\"";
            ButtonFilter1.Visible = true;
        }
        else
        {
            filteredResult = new List<Table_Hotel>(unFilteredResult);
            ButtonFilter1.Visible = false;
        }
        //过滤价格
        if (isPriceFiltering())
        {
            List<Table_Hotel> temp = new List<Table_Hotel>(filteredResult);
            filteredResult.Clear();
            foreach (Table_Hotel hotel in temp)
            {
                if (CheckBox1.Checked && hotel.Price >= 70 && hotel.Price <= 359)
                    filteredResult.Add(hotel);
                else if (CheckBox2.Checked && hotel.Price >= 360 && hotel.Price <= 649)
                    filteredResult.Add(hotel);
                else if (CheckBox3.Checked && hotel.Price >= 650 && hotel.Price <= 929)
                    filteredResult.Add(hotel);
                else if (CheckBox4.Checked && hotel.Price >= 930 && hotel.Price <= 1220)
                    filteredResult.Add(hotel);
            }  
        }
        ButtonFilter2.Visible = CheckBox1.Checked;
        ButtonFilter3.Visible = CheckBox2.Checked;
        ButtonFilter4.Visible = CheckBox3.Checked;
        ButtonFilter5.Visible = CheckBox4.Checked;
        //过滤星级
        if (isStarFiltering())
        {
            List<Table_Hotel> temp = new List<Table_Hotel>(filteredResult);
            filteredResult.Clear();
            foreach (Table_Hotel hotel in temp)
            {
                if (CheckBox5.Checked && hotel.StarLevel == 1)
                    filteredResult.Add(hotel);
                else if (CheckBox6.Checked && hotel.StarLevel == 2)
                    filteredResult.Add(hotel);
                else if (CheckBox7.Checked && hotel.StarLevel == 3)
                    filteredResult.Add(hotel);
                else if (CheckBox8.Checked && hotel.StarLevel == 4)
                    filteredResult.Add(hotel);
                else if (CheckBox9.Checked && hotel.StarLevel == 5)
                    filteredResult.Add(hotel);
            }
        }
        ButtonFilter6.Visible = CheckBox5.Checked;
        ButtonFilter7.Visible = CheckBox6.Checked;
        ButtonFilter8.Visible = CheckBox7.Checked;
        ButtonFilter9.Visible = CheckBox8.Checked;
        ButtonFilter10.Visible = CheckBox9.Checked;
        if (!isFiltering())
            divFilters.Visible = false;
    }
    
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                result = dbc.GetHotelByAddress(Request["Address"]);
                unFilteredResult = server.Search(result, DateTime.ParseExact(Request["CheckIn"], "yyyy/MM/dd", System.Globalization.CultureInfo.CurrentCulture), DateTime.ParseExact(Request["CheckOut"], "yyyy/MM/dd", System.Globalization.CultureInfo.CurrentCulture), Convert.ToInt32(Request["RoomNum"]), Convert.ToInt32(Request["GuestNum"]));
                unFilteredResult.Sort(new HotelComparePriceLowToHigh());
                filteredResult = new List<Table_Hotel>(unFilteredResult);
                int[] price = { 0, 0, 0, 0 };
                int[] star = { 0, 0, 0, 0, 0 };
                foreach (Table_Hotel hotel in unFilteredResult)
                {
                    if (hotel.Price >= 70 && hotel.Price <= 359)
                        price[0]++;
                    else if (hotel.Price >= 360 && hotel.Price <= 649)
                        price[1]++;
                    else if (hotel.Price >= 650 && hotel.Price <= 929)
                        price[2]++;
                    else if (hotel.Price >= 930 && hotel.Price <= 1220)
                        price[3]++;
                    star[hotel.StarLevel - 1]++;
                }
                Label1.Text = "(" + price[0].ToString() + ")";
                Label2.Text = "(" + price[1].ToString() + ")";
                Label3.Text = "(" + price[2].ToString() + ")";
                Label4.Text = "(" + price[3].ToString() + ")";
                Label5.Text = "(" + star[0].ToString() + ")";
                Label6.Text = "(" + star[1].ToString() + ")";
                Label7.Text = "(" + star[2].ToString() + ")";
                Label8.Text = "(" + star[3].ToString() + ")";
                Label9.Text = "(" + star[4].ToString() + ")";
                
            }
            catch (Exception) { }
        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList2.SelectedIndex == 0)
        {
            filteredResult.Sort(new HotelComparePriceLowToHigh());
            unFilteredResult.Sort(new HotelComparePriceLowToHigh());
        }
        else if (DropDownList2.SelectedIndex == 1)
        {
            filteredResult.Sort(new HotelComparePriceHighToLow());
            unFilteredResult.Sort(new HotelComparePriceHighToLow());
        }
        else if (DropDownList2.SelectedIndex == 2)
        {
            filteredResult.Sort(new HotelCompareStarLowToHigh());
            unFilteredResult.Sort(new HotelCompareStarLowToHigh());
        }
        else if (DropDownList2.SelectedIndex == 3)
        {
            filteredResult.Sort(new HotelCompareStarHighToLow());
            unFilteredResult.Sort(new HotelCompareStarHighToLow());
        }
        else if (DropDownList2.SelectedIndex == 4)
        {
            filteredResult.Sort(new HotelCompareName());
            unFilteredResult.Sort(new HotelCompareName());
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('Enter a name!')", true);
            return;
        }
        nameFilter = TextBox1.Text;
        doFilter();
    }
    
    protected void ButtonFilter1_Click(object sender, EventArgs e)
    {
        nameFilter = null;
        doFilter();
    }
    protected void ButtonFilter2_Click(object sender, EventArgs e)
    {
        CheckBox1.Checked = false;
        doFilter();
    }
    protected void ButtonFilter3_Click(object sender, EventArgs e)
    {
        CheckBox2.Checked = false;
        doFilter();
    }
    protected void ButtonFilter4_Click(object sender, EventArgs e)
    {
        CheckBox3.Checked = false;
        doFilter();
    }
    protected void ButtonFilter5_Click(object sender, EventArgs e)
    {
        CheckBox4.Checked = false;
        doFilter();
    }
    protected void ButtonFilter6_Click(object sender, EventArgs e)
    {
        CheckBox5.Checked = false;
        doFilter();
    }
    protected void ButtonFilter7_Click(object sender, EventArgs e)
    {
        CheckBox6.Checked = false;
        doFilter();
    }
    protected void ButtonFilter8_Click(object sender, EventArgs e)
    {
        CheckBox7.Checked = false;
        doFilter();
    }
    protected void ButtonFilter9_Click(object sender, EventArgs e)
    {
        CheckBox8.Checked = false;
        doFilter();
    }
    protected void ButtonFilter10_Click(object sender, EventArgs e)
    {
        CheckBox9.Checked = false;
        doFilter();
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        doFilter();
    }
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        doFilter();
    }
    protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
    {
        doFilter();
    }
    protected void CheckBox4_CheckedChanged(object sender, EventArgs e)
    {
        doFilter();
    }
    protected void CheckBox5_CheckedChanged(object sender, EventArgs e)
    {
        doFilter();
    }
    protected void CheckBox6_CheckedChanged(object sender, EventArgs e)
    {
        doFilter();
    }
    protected void CheckBox7_CheckedChanged(object sender, EventArgs e)
    {
        doFilter();
    }
    protected void CheckBox8_CheckedChanged(object sender, EventArgs e)
    {
        doFilter();
    }
    protected void CheckBox9_CheckedChanged(object sender, EventArgs e)
    {
        doFilter();
    }
    protected void ButtonResearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
//酒店排序方法：价格低到高
public class HotelComparePriceLowToHigh : IComparer<Table_Hotel>
{
    public int Compare(Table_Hotel x, Table_Hotel y)
    {
        return (x.Price.CompareTo(y.Price));
    }
}
//酒店排序方法：价格高到低
public class HotelComparePriceHighToLow : IComparer<Table_Hotel>
{
    public int Compare(Table_Hotel x, Table_Hotel y)
    {
        return (y.Price.CompareTo(x.Price));
    }
}
//酒店排序方法：星级低到高
public class HotelCompareStarLowToHigh : IComparer<Table_Hotel>
{
    public int Compare(Table_Hotel x, Table_Hotel y)
    {
        return (x.StarLevel.CompareTo(y.StarLevel));
    }
}
//酒店排序方法：星级高到低
public class HotelCompareStarHighToLow : IComparer<Table_Hotel>
{
    public int Compare(Table_Hotel x, Table_Hotel y)
    {
        return (y.StarLevel.CompareTo(x.StarLevel));
    }
}
//酒店排序方法：名字
public class HotelCompareName : IComparer<Table_Hotel>
{
    public int Compare(Table_Hotel x, Table_Hotel y)
    {
        return (x.Name.CompareTo(y.Name));
    }
}