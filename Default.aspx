<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <!------------ 搜索盒子 ------------>
    <div class="mainBox">
        <h1>Find your perfect hotel now!</h1>
        <h2>over 100,000 hotels to choose from</h2>
        <!------------ 输入区 ------------>
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
        <!------------ 日历1 ------------>
        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" 
                DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                ForeColor="Black" Height="180px" 
                Width="200px" Visible="False" 
                onselectionchanged="Calendar1_SelectionChanged" CellPadding="4" OnDayRender="Calendar1_DayRender">
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#808080" />
            <SelectedDayStyle BackColor="#666666" ForeColor="White" Font-Bold="True" />
            <SelectorStyle BackColor="#CCCCCC" />
            <TitleStyle BackColor="#999999" Font-Bold="True" BorderColor="Black" />
            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
            <WeekendDayStyle BackColor="#FFFFCC" />
        </asp:Calendar>
        <!------------ 日历2 ------------>
        <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#999999" 
                DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                ForeColor="Black" Height="180px" 
                Width="200px" Visible="False" class="inputCheckOut"
                onselectionchanged="Calendar2_SelectionChanged" CellPadding="4" OnDayRender="Calendar2_DayRender">
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#808080" />
            <SelectedDayStyle BackColor="#666666" ForeColor="White" Font-Bold="True" />
            <SelectorStyle BackColor="#CCCCCC" />
            <TitleStyle BackColor="#999999" Font-Bold="True" BorderColor="Black" />
            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
            <WeekendDayStyle BackColor="#FFFFCC" />
        </asp:Calendar>
        <asp:Button ID="Button3" runat="server" class="serachButton" Text="SEARCH" onclick="Button3_Click"/>
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

