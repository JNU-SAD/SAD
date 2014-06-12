<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SearchResult.aspx.cs" Inherits="SearchResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link type="text/css" rel="stylesheet" href="css/updown.css"/>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#updown").css("top", window.screen.availHeight / 2 + "px");
            $(window).scroll(function () {
                if ($(window).scrollTop() >= 100) {
                    $('#updown').fadeIn(300);
                } else {
                    $('#updown').fadeOut(300);
                }
            });
            $('#updown .up').click(function () { $('html,body').animate({ scrollTop: '0px' }, 800); });
            $('#updown .down').click(function () { $('html,body').animate({ scrollTop: document.body.clientHeight + 'px' }, 800); });
            
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="updown"><span class="up"></span></div>
    <!------------ 主体开始 ------------>
    <div class="mainBody">
        <div class="position">
            <ul id="breadcrumb">
                <li><a href="Default.aspx">Home</a></li>
                <li><a href="#">Find a Hotel</a></li>
            </ul>
        </div>
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
                <h1 class="title">Hotel Specifics</h1>
                <span>Hotel Name:</span>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="input" />
                <asp:Button ID="Button1" runat="server" CssClass="button1" Text="Go" OnClick="Button1_Click" />
                <span>Hotel Chain:</span>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdowmlist" />
            </div>
            <hr style="width:85%" />
            <!------------ 价格搜索 ------------>
            <div class="detail">
                <h1 class="title">Price Range</h1>
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
            <hr style="width:85%" />
            <!------------ 星级搜索 ------------>
            <div class="detail">
                <h1 class="title">Star Rating</h1>
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
            <hr style="width:85%" />
            <!------------ 功能搜索 ------------>
            <div class="detail">
                <h1 class="title">Amenities</h1>
                <div class="checkline">
                    <asp:CheckBox ID="CheckBox10" runat="server" CssClass="checkbox" AutoPostBack="true" OnCheckedChanged="CheckBox10_CheckedChanged"/>
                    <img src="image/tie.png" class="icon" alt="star" />
                    <div class="text">Business Center</div>
                    <asp:Label ID="Label10" runat="server" Text="(0)" CssClass="label" />
                </div>
                <div class="checkline">
                    <asp:CheckBox ID="CheckBox11" runat="server"  CssClass="checkbox" AutoPostBack="true" OnCheckedChanged="CheckBox11_CheckedChanged"/>
                    <img src="image/trainers.png" class="icon" alt="star" />
                    <div class="text">Fitness Center</div>
                    <asp:Label ID="Label11" runat="server" Text="(0)" CssClass="label" />
                </div>
                <div class="checkline">
                    <asp:CheckBox ID="CheckBox12" runat="server"  CssClass="checkbox" AutoPostBack="true" OnCheckedChanged="CheckBox12_CheckedChanged"/>
                    <img src="image/no_smoking_512.png" class="icon" alt="star" />
                    <div class="text">Non Smoking</div>
                    <asp:Label ID="Label12" runat="server" Text="(0)" CssClass="label" />
                </div>
                <div class="checkline">
                    <asp:CheckBox ID="CheckBox13" runat="server"  CssClass="checkbox" AutoPostBack="true" OnCheckedChanged="CheckBox13_CheckedChanged"/>
                    <img src="image/dog_2.png" class="icon" alt="star" />
                    <div class="text">Pets Allowed</div>
                    <asp:Label ID="Label13" runat="server" Text="(0)" CssClass="label" />
                </div>
                <div class="checkline">
                    <asp:CheckBox ID="CheckBox14" runat="server"  CssClass="checkbox" AutoPostBack="true" OnCheckedChanged="CheckBox14_CheckedChanged"/>
                    <img src="image/f0f4.png" class="icon" alt="star" />
                    <div class="text">Free Breakfast</div>
                    <asp:Label ID="Label14" runat="server" Text="(0)" CssClass="label" />
                </div>
                <div class="checkline">
                    <asp:CheckBox ID="CheckBox15" runat="server"  CssClass="checkbox" AutoPostBack="true" OnCheckedChanged="CheckBox15_CheckedChanged"/>
                    <img src="image/wifi.png" class="icon" alt="star" />
                    <div class="text">Free Internet</div>
                    <asp:Label ID="Label15" runat="server" Text="(0)" CssClass="label" />
                </div>
                <div class="checkline">
                    <asp:CheckBox ID="CheckBox16" runat="server"  CssClass="checkbox" AutoPostBack="true" OnCheckedChanged="CheckBox16_CheckedChanged"/>
                    <img src="image/swimming.png" class="icon" alt="star" />
                    <div class="text">Swimming Pool</div>
                    <asp:Label ID="Label16" runat="server" Text="(0)" CssClass="label" />
                </div>
                <div class="checkline">
                    <asp:CheckBox ID="CheckBox17" runat="server"  CssClass="checkbox" AutoPostBack="true" OnCheckedChanged="CheckBox17_CheckedChanged"/>
                    <img src="image/bus.png" class="icon" alt="star" />
                    <div class="text">Airport Shuttle</div>
                    <asp:Label ID="Label17" runat="server" Text="(0)" CssClass="label" />
                </div>
                <div class="checkline">
                    <asp:CheckBox ID="CheckBox18" runat="server"  CssClass="checkbox" AutoPostBack="true" OnCheckedChanged="CheckBox18_CheckedChanged"/>
                    <img src="image/car.png" class="icon" alt="star" />
                    <div class="text">Free Parking</div>
                    <asp:Label ID="Label18" runat="server" Text="(0)" CssClass="label" />
                </div>
                <div class="checkline">
                    <asp:CheckBox ID="CheckBox19" runat="server"  CssClass="checkbox" AutoPostBack="true" OnCheckedChanged="CheckBox19_CheckedChanged"/>
                    <img src="image/wheelchair.png" class="icon" alt="star" />
                    <div class="text">Accessible</div>
                    <asp:Label ID="Label19" runat="server" Text="(0)" CssClass="label" />
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
                    <asp:ListItem>Sort by stars - low to high</asp:ListItem>
                    <asp:ListItem>Sort by stars - high to low</asp:ListItem>
                    <asp:ListItem>Sort by rating - low to high</asp:ListItem>
                    <asp:ListItem>Sort by rating - high to low</asp:ListItem>
                    <asp:ListItem>Sort by name</asp:ListItem>
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
                <asp:Button ID="ButtonFilter11" runat="server" CssClass="filterbutton" Text="Business Center" Visible="false" OnClick="ButtonFilter11_Click"/>
                <asp:Button ID="ButtonFilter12" runat="server" CssClass="filterbutton" Text="Fitness Center" Visible="false" OnClick="ButtonFilter12_Click"/>
                <asp:Button ID="ButtonFilter13" runat="server" CssClass="filterbutton" Text="Non Smoking" Visible="false" OnClick="ButtonFilter13_Click"/>
                <asp:Button ID="ButtonFilter14" runat="server" CssClass="filterbutton" Text="Pets Allowed" Visible="false" OnClick="ButtonFilter14_Click"/>
                <asp:Button ID="ButtonFilter15" runat="server" CssClass="filterbutton" Text="Free Breakfast" Visible="false" OnClick="ButtonFilter15_Click"/>
                <asp:Button ID="ButtonFilter16" runat="server" CssClass="filterbutton" Text="Free Internet" Visible="false" OnClick="ButtonFilter16_Click"/>
                <asp:Button ID="ButtonFilter17" runat="server" CssClass="filterbutton" Text="Swimming Pool" Visible="false" OnClick="ButtonFilter17_Click"/>
                <asp:Button ID="ButtonFilter18" runat="server" CssClass="filterbutton" Text="Airport Shuttle" Visible="false" OnClick="ButtonFilter18_Click"/>
                <asp:Button ID="ButtonFilter19" runat="server" CssClass="filterbutton" Text="Free Parking" Visible="false" OnClick="ButtonFilter19_Click"/>
                <asp:Button ID="ButtonFilter20" runat="server" CssClass="filterbutton" Text="Accessible" Visible="false" OnClick="ButtonFilter20_Click"/>
            </div>
            <!------------ 搜索结果 ------------>
            <%
                
                foreach (Table_Hotel hotel in filteredResult)
                {
                %>
            <div class="resultbox">
                <a href="HotelDetail.aspx?hotelId=<%=hotel.Id %>&Address=<%=Request["Address"] %>&CheckIn=<%=Request["CheckIn"] %>&CheckOut=<%=Request["CheckOut"] %>&RoomNum=<%=Request["RoomNum"] %>&GuestNum=<%=Request["GuestNum"] %>"><img src="<%=@"image/hotel/" + hotel.ImageUrl%>" alt="hotel" class="img"/></a>
                <div class="detail">
                    <div class="hotelName">
                        <a style="color:black;text-decoration:none" href="HotelDetail.aspx?hotelId=<%=hotel.Id %>&Address=<%=Request["Address"] %>&CheckIn=<%=Request["CheckIn"] %>&CheckOut=<%=Request["CheckOut"] %>&RoomNum=<%=Request["RoomNum"] %>&GuestNum=<%=Request["GuestNum"] %>"><%=hotel.Name%></a>
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
                    <br />
                    <div>
                        <img src="image/3220.png" style="max-height:15px;margin-top:10px" />
                        <span style="font-weight:600"><%=Rating(hotel.Rating)+", "+hotel.Rating.ToString() %></span>
                    </div>
                </div>
                <div class="price">
                    <div class="cost"><%="$"+hotel.Price.ToString() %></div>
                    <div class="perNight">per night</div>
                    <a href="HotelDetail.aspx?hotelId=<%=hotel.Id %>&Address=<%=Request["Address"] %>&CheckIn=<%=Request["CheckIn"] %>&CheckOut=<%=Request["CheckOut"] %>&RoomNum=<%=Request["RoomNum"] %>&GuestNum=<%=Request["GuestNum"] %>" class="bookNow">Book Now</a>
                </div>
            </div>
           <%   
           } %>
        </div>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>

