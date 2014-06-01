<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HotelDetail.aspx.cs" Inherits="HotelDetial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="mainBody">
        <div class="hotel">
            <div class="name"><%=hotel.Name %>
            <%for (int i = 0; i < hotel.StarLevel; i++)
                          { %>
                        <img src="image/star.png" class="star" alt="star" />
                        <%} %>
            
        </div> <br /><br />
         <span><%=hotel.Address %></span><br />
        <span><%=hotel.ContactNumber %></span>
        </div>
        <div class="detail">
        <div class="imgbox">
            <img src="<%=@"image/hotel/" + hotel.ImageUrl%>" alt="img" />
        </div>
        <div class="roomInfo">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
            <p>Check in:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Visible="true" ></asp:Label></p>
            <p>Check out:&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Visible="true" ></asp:Label></p>
            <p>Details:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Visible="true" ></asp:Label></p>
            <asp:Button ID="Button1" runat="server" Text="Change Dates" OnClick="Button1_Click" CssClass="check" />
            <hr />
            
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <asp:Button ID="Button2" runat="server" class="datePickerButton" Text="Check In" CssClass="datacheck" onclick="Button2_Click"/>
                <asp:Button ID="Button3" runat="server" class="datePickerButton" Text="Check Out" CssClass="datacheck" onclick="Button3_Click"/><br />
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
        <!------------ 日历2 ------------>
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

                <asp:Button ID="Button4" runat="server" Text="Check Availability" CssClass="checkAvailability" OnClick="Button4_Click" />
                <hr />
            </asp:Panel>
                    
            </ContentTemplate>
            </asp:UpdatePanel>
            <span>from $<b><%=price %> </b>per night</span>
            <a href="#room" class="chooseARoom" >Choose a Room</a>
        </div>
        </div>
        <div class="roomDetail">
            <div class="title"><a id="room"></a>
                Special Rates
            </div>
            <%foreach(Table_Room r in Room)
              { %>
            <div class="item">
                <div class="roomtype">
                    <span><%=r.RoomType %></span>
                </div>
                <div class="price">
                    <div class="pernight"><span>$<b><%=r.FullRate %></b>per night</span></div>
                    <asp:Button ID="Button5" runat="server" Text="Book Now" CssClass="bookNow" OnClick="Button5_Click" />
                </div>
            </div>
            <%} %>
        </div>
        </div>
</asp:Content>

