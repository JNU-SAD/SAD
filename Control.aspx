<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Control.aspx.cs" Inherits="Control" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <!------------ 此页面为测试用 ------------>
    <form id="form1" runat="server">
    <div>
        <asp:GridView runat="server" ID="GridView1" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <h2>hotel</h2>
        Name<asp:TextBox ID="TextBox1" runat="server" />
        Address<asp:TextBox ID="TextBox2" runat="server" />
        StarLevel<asp:TextBox ID="TextBox3" runat="server" />
        ContactNumber<asp:TextBox ID="TextBox4" runat="server" />
        ImageUrl<asp:TextBox ID="TextBox5" runat="server" />
        <asp:Button ID="Button1" Text="Add" runat="server" OnClick="Button1_Click"/>
        <asp:Button ID="Button2" Text="Show All" runat="server" OnClick="Button2_Click"/>
        <br />
        <h2>room</h2>
        HotelId<asp:DropDownList ID="DropDownList1" runat="server" />
        RoomType<asp:TextBox ID="TextBox7" runat="server" />
        FullRate<asp:TextBox ID="TextBox8" runat="server" />
        TotalNumber<asp:TextBox ID="TextBox9" runat="server" />
        Capacity<asp:TextBox ID="TextBox10" runat="server" />
        <asp:Button ID="Button3" Text="Add" runat="server" OnClick="Button3_Click"/>
        <asp:Button ID="Button4" Text="Show All" runat="server" OnClick="Button4_Click"/>
        <br />
        <h2>arrangement</h2>
        HotelId<asp:TextBox ID="TextBox11" runat="server" />
        RoomType<asp:TextBox ID="TextBox12" runat="server" />
        Date<asp:Calendar ID="Calendar1" runat="server" />
        Rate<asp:TextBox ID="TextBox14" runat="server" />
        BookedNumber<asp:TextBox ID="TextBox15" runat="server" />
        <asp:Button ID="Button5" Text="Add" runat="server" OnClick="Button5_Click"/>
        <asp:Button ID="Button6" Text="Show All" runat="server" OnClick="Button6_Click"/>
        <br />
    </div>
    </form>
</body>
</html>
