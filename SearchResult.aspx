<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SearchResult.aspx.cs" Inherits="SearchResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <!------------ 主体开始 ------------>
    <div class="mainBody">
        <!------------ 搜索信息栏 ------------>
        <div class="searchInfo">
            <img src="image/location.png" alt="location" />
            <span><%=Request["Address"] %></span>
            <img src="image/date.png" alt="date" />
            <span><%=Request["CheckIn"] + " - " + Request["CheckOut"] %></span>
            <img src="image/room.png" alt="date" />
            <span><%=Request["RoomNum"] + " Room, " + Request["GuestNum"] + " Guset"%></span>
            <asp:Button ID="ButtonResearch" runat="server" CssClass="researchButton" Text="SEARCH AGAIN" OnClick="ButtonResearch_Click"/>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <!------------ 侧边栏 ------------>
        <div class="aside">
            <!------------ 酒店精确搜索 ------------>
            <div class="detail">
                <h1>Hotel Specifics</h1>
                <span>Hotel Name:</span>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="input" />
                <asp:Button ID="Button1" runat="server" CssClass="button" Text="Go" OnClick="Button1_Click" />
                <span>Hotel Chain:</span>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdowmlist" />
            </div>
            <!------------ 价格搜索 ------------>
            <div class="detail">
                <h1>Price Range</h1>
                <div class="checkline">
                     <asp:CheckBox ID="CheckBox1" runat="server" Text="$70 - $359"  CssClass="checkbox" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged"/>
                     <asp:Label ID="Label1" runat="server" Text="(0)" CssClass="label" />
                 </div>
                 <div class="checkline">
                     <asp:CheckBox ID="CheckBox2" runat="server" Text="$360 - $649"  CssClass="checkbox" AutoPostBack="true" OnCheckedChanged="CheckBox2_CheckedChanged"/>
                     <asp:Label ID="Label2" runat="server" Text="(0)" CssClass="label" />
                </div>
                <div class="checkline">
                        <asp:CheckBox ID="CheckBox3" runat="server" Text="$650 - $929"  CssClass="checkbox" AutoPostBack="true" OnCheckedChanged="CheckBox3_CheckedChanged"/>
                        <asp:Label ID="Label3" runat="server" Text="(0)" CssClass="label" />
                </div>
                <div class="checkline">
                        <asp:CheckBox ID="CheckBox4" runat="server" Text="$930 - $1220"  CssClass="checkbox" AutoPostBack="true" OnCheckedChanged="CheckBox4_CheckedChanged"/>
                        <asp:Label ID="Label4" runat="server" Text="(0)" CssClass="label" />
                </div>

            </div>
            <!------------ 星级搜索 ------------>
            <div class="detail">
                <h1>Star Rating</h1>
                <div class="checkline">
                    <asp:CheckBox ID="CheckBox5" runat="server" CssClass="checkbox" AutoPostBack="true" OnCheckedChanged="CheckBox5_CheckedChanged"/>
                    <img src="image/star.png" class="star" alt="star" />
                    <asp:Label ID="Label5" runat="server" Text="(0)" CssClass="label" />
                </div>
                <div class="checkline">
                    <asp:CheckBox ID="CheckBox6" runat="server"  CssClass="checkbox" AutoPostBack="true" OnCheckedChanged="CheckBox6_CheckedChanged"/>
                    <img src="image/star.png" class="star" alt="star" /><img src="image/star.png" class="star" alt="star" />
                    <asp:Label ID="Label6" runat="server" Text="(0)" CssClass="label" />
                </div>
                <div class="checkline">
                    <asp:CheckBox ID="CheckBox7" runat="server"  CssClass="checkbox" AutoPostBack="true" OnCheckedChanged="CheckBox7_CheckedChanged"/>
                    <img src="image/star.png" class="star" alt="star" /><img src="image/star.png" class="star" alt="star" /><img src="image/star.png" class="star" alt="star" />
                    <asp:Label ID="Label7" runat="server" Text="(0)" CssClass="label" />
                </div>
                <div class="checkline">
                    <asp:CheckBox ID="CheckBox8" runat="server"  CssClass="checkbox" AutoPostBack="true" OnCheckedChanged="CheckBox8_CheckedChanged"/>
                    <img src="image/star.png" class="star" alt="star" /><img src="image/star.png" class="star" alt="star" /><img src="image/star.png" class="star" alt="star" /><img src="image/star.png" class="star" alt="star" />
                    <asp:Label ID="Label8" runat="server" Text="(0)" CssClass="label" />
                </div>
                <div class="checkline">
                    <asp:CheckBox ID="CheckBox9" runat="server"  CssClass="checkbox" AutoPostBack="true" OnCheckedChanged="CheckBox9_CheckedChanged"/>
                    <img src="image/star.png" class="star" alt="star" /><img src="image/star.png" class="star" alt="star" /><img src="image/star.png" class="star" alt="star" /><img src="image/star.png" class="star" alt="star" /><img src="image/star.png" class="star" alt="star" />
                    <asp:Label ID="Label9" runat="server" Text="(0)" CssClass="label" />
                </div>
            </div>
        </div>
        <!------------ 搜索结果显示 ------------>
        <div class="result">
            <!------------ 概要以及排序 ------------>
            <div class="head">
                <div class="summary"><%=filteredResult.Count + " out of " + result.Count + " Hotels Available"%></div>
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="sort" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                    <asp:ListItem>Sort by price - low to high</asp:ListItem>
                    <asp:ListItem>Sort by price - high to low</asp:ListItem>
                </asp:DropDownList>
            </div>
            <!------------ 过滤器区 ------------>
            <div class="filters" runat="server" id="divFilters" visible="false">
                <asp:Button ID="ButtonFilter1" runat="server" CssClass="filterbutton" Text="Name" Visible="false" OnClick="ButtonFilter1_Click"/>
                <asp:Button ID="ButtonFilter2" runat="server" CssClass="filterbutton" Text="$70 - $359" Visible="false" OnClick="ButtonFilter2_Click"/>
                <asp:Button ID="ButtonFilter3" runat="server" CssClass="filterbutton" Text="$360 - $649" Visible="false" OnClick="ButtonFilter3_Click"/>
                <asp:Button ID="ButtonFilter4" runat="server" CssClass="filterbutton" Text="$650 - $929" Visible="false" OnClick="ButtonFilter4_Click"/>
                <asp:Button ID="ButtonFilter5" runat="server" CssClass="filterbutton" Text="$930 - $1220" Visible="false" OnClick="ButtonFilter5_Click"/>
                <asp:Button ID="ButtonFilter6" runat="server" CssClass="filterbutton" Text="1 star" Visible="false" OnClick="ButtonFilter6_Click"/>
                <asp:Button ID="ButtonFilter7" runat="server" CssClass="filterbutton" Text="2 stars" Visible="false" OnClick="ButtonFilter7_Click"/>
                <asp:Button ID="ButtonFilter8" runat="server" CssClass="filterbutton" Text="3 stars" Visible="false" OnClick="ButtonFilter8_Click"/>
                <asp:Button ID="ButtonFilter9" runat="server" CssClass="filterbutton" Text="4 stars" Visible="false" OnClick="ButtonFilter9_Click"/>
                <asp:Button ID="ButtonFilter10" runat="server" CssClass="filterbutton" Text="5 stars" Visible="false" OnClick="ButtonFilter10_Click"/>
            </div>
            <!------------ 搜索结果 ------------>
            <%
                
                foreach (Table_Hotel hotel in filteredResult)
                {
                %>
            <div class="resultbox">
                <img src="<%=@"image/hotel/" + hotel.ImageUrl%>" alt="hotel" class="img"/>
                <div class="detail">
                    <div class="hotelName">
                        <%=hotel.Name%>
                    </div>
                    <div class="hotelAddress">
                        <%=hotel.Address%>
                    </div>
                    <div class="hotelStar">
                        <%for (int i = 0; i < hotel.StarLevel; i++)
                          { %>
                        <img src="image/star.png" class="star" alt="star" />
                        <%} %>
                    </div>
                </div>
                <div class="price">
                    <div class="cost"><%="$"+hotel.Price.ToString() %></div>
                    <div class="perNight">per night</div>
                    <a href="HotelDetail.aspx?hotelId=<%=hotel.Id %>&CheckIn=<%=Request["CheckIn"] %>&CheckOut=<%=Request["CheckOut"] %> &RoomNum=<%=Request["RoomNum"] %>&GuestNum=<%=Request["GuestNum"] %>" class="bookNow">Book Now</a>
                </div>
            </div>
           <%   
           } %>
        </div>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>

