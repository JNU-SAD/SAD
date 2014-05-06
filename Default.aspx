<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hotel</title>
    <link type="text/css" rel="stylesheet" href="css/style.css"/>
</head>
<body>
<form runat="server" id="Form1" defaultbutton="Button3">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    <div class="mainBox">
    <h1>Find your perfect hotel now!</h1>
    <h2>over 100,000 hotels to choose from</h2>
    <div class="inputBox">
    <asp:TextBox  ID="TextBox1" runat="server" class="inputCity" />
    <asp:Button ID="Button1" runat="server" class="datePickerButton" Text="Check In" 
            onclick="Button1_Click"/>
    <asp:Button ID="Button2" runat="server" class="datePickerButton" Text="Check Out" 
            onclick="Button2_Click"/>
    <asp:DropDownList ID="DropDownList1" runat="server" class="inputElse">
    <asp:ListItem>1 Room</asp:ListItem>
    <asp:ListItem>2 Rooms</asp:ListItem>
    <asp:ListItem>3 Rooms</asp:ListItem>
    <asp:ListItem>4 Rooms</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="DropDownList2" runat="server" class="inputElse" >
    <asp:ListItem>1 Guest</asp:ListItem>
    <asp:ListItem>2 Guests</asp:ListItem>
    <asp:ListItem>3 Guests</asp:ListItem>
    <asp:ListItem>4 Guests</asp:ListItem>
    </asp:DropDownList>
    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" 
            DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
            ForeColor="Black" Height="180px" 
            Width="200px" Visible="False" 
            onselectionchanged="Calendar1_SelectionChanged" CellPadding="4">
        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
        <NextPrevStyle VerticalAlign="Bottom" />
        <OtherMonthDayStyle ForeColor="#808080" />
        <SelectedDayStyle BackColor="#666666" ForeColor="White" Font-Bold="True" />
        <SelectorStyle BackColor="#CCCCCC" />
        <TitleStyle BackColor="#999999" Font-Bold="True" BorderColor="Black" />
        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
        <WeekendDayStyle BackColor="#FFFFCC" />
        </asp:Calendar>
    <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#999999" 
            DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
            ForeColor="Black" Height="180px" 
            Width="200px" Visible="False" class="inputCheckOut"
            onselectionchanged="Calendar2_SelectionChanged" CellPadding="4">
        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
        <NextPrevStyle VerticalAlign="Bottom" />
        <OtherMonthDayStyle ForeColor="#808080" />
        <SelectedDayStyle BackColor="#666666" ForeColor="White" Font-Bold="True" />
        <SelectorStyle BackColor="#CCCCCC" />
        <TitleStyle BackColor="#999999" Font-Bold="True" BorderColor="Black" />
        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
        <WeekendDayStyle BackColor="#FFFFCC" />
        </asp:Calendar>
    <asp:Button ID="Button3" runat="server" class="serachButton" Text="Search" onclick="Button3_Click"/>
    </div>
    </div>
</ContentTemplate>
</asp:UpdatePanel>
</form>
</body>
</html>
