<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HotelDetail.aspx.cs" Inherits="HotelDetial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="mainBody">
        <div class="position">
            <ul id="breadcrumb">
                <li><a href="Default.aspx">Home</a></li>
                <li><a href="SearchResult.aspx?Address=<%=Request["Address"] %>&CheckIn=<%=Request["CheckIn"] %>&CheckOut=<%=Request["CheckOut"] %>&RoomNum=<%=Request["RoomNum"] %>&GuestNum=<%=Request["GuestNum"] %>">Find a Hotel</a></li>
                <li><a href="#">Room Specific</a></li>
            </ul>
            
        </div>
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
        <div class="detail1">
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
                onselectionchanged="Calendar2_SelectionChanged" CellPadding="4" >
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#808080" />
            <SelectedDayStyle BackColor="#666666" ForeColor="White" Font-Bold="True" />
            <SelectorStyle BackColor="#CCCCCC" />
            <TitleStyle BackColor="#999999" Font-Bold="True" BorderColor="Black" />
            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
            <WeekendDayStyle BackColor="#FFFFCC" />
        </asp:Calendar>
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
                

                <asp:Button ID="Button4" runat="server" Text="Check Availability" CssClass="checkAvailability" OnClick="Button4_Click" />
                <hr />
            </asp:Panel>
                    
            </ContentTemplate>
            </asp:UpdatePanel>
            <span>from $<b><%=price %> </b>per night</span>
            <a href="#room" class="chooseARoom" >Choose a Room</a>
        </div>
        </div>
        
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
        <div class="roomDetail">
        <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="False" CellPadding="20" DataKeyNames="HotelId,RoomType" DataSourceID="LinqDataSource1" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="970px" OnDataBound="GridView1_DataBound">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="RoomType" HeaderText="Room Type" ReadOnly="True" SortExpression="RoomType">
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="FullRate" HeaderText="Full Rate" SortExpression="FullRate">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="TotalNumber" HeaderText="Total Number" SortExpression="TotalNumber">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:CommandField SelectText="Select" ShowSelectButton="True">
                <ItemStyle HorizontalAlign="Center" />
                </asp:CommandField>
            </Columns>
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
        <asp:LinqDataSource ID="LinqDataSource1" runat="server" EntityTypeName="" ContextTypeName="DataClassesDataContext" TableName="Table_Room" Where="HotelId == @HotelId1" EnableDelete="True" EnableUpdate="True">
            <WhereParameters>
                <asp:QueryStringParameter Name="HotelId1" QueryStringField="hotelId" Type="Int32" />
            </WhereParameters>
        </asp:LinqDataSource>
        
        <asp:Panel ID="Panel2" runat="server" Visible="true">
        <div class="title"><%=GridView1.SelectedRow.Cells[0].Text %> Detail of Next 10 Days
            <asp:Button ID="Button_BookNow" runat="server" CssClass="booknow" Text="Book Now!" OnClick="Button_BookNow_Click" />
        </div>
        <div class="item">
        <table cellpadding="8">
            <tr>
                <td></td>
                <%foreach(Table_Arrangement a in _arrangement){ %>
                <td align="center"><%=a.Date.ToShortDateString().Substring(0, a.Date.ToShortDateString().IndexOf(" ")).Trim() %></td>
                <%} %>
            </tr>
            <tr>
                <td>Rate</td>
                <%foreach(Table_Arrangement a in _arrangement){ %>
                <td align="center"><%="$"+a.Rate.ToString() %></td>
                <%} %>
            </tr>
            <tr>
                <td>Availability</td>
                <%foreach(Table_Arrangement a in _arrangement){ %>
                <td align="center">
                    <% if(Convert.ToInt32(GridView1.SelectedRow.Cells[2].Text)-a.BookedNumber>=RoomNum) {%>
                    <img alt="yes" src="image/3284.png" style="max-width:20px;" />
                    <%}else {%>
                    <img alt="no" src="image/3227.png" style="max-width:20px;" />
                    <%} %>
                <%} %>
            </tr>
        </table>
        </div>
        </asp:Panel>
        
        </div>
        </ContentTemplate>
        </asp:UpdatePanel>


       
        </div>
</asp:Content>

