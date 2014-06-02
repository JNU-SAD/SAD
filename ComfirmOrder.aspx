<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ComfirmOrder.aspx.cs" Inherits="ComfirmOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="mainBody">
    <div class="information">
        <div class="title">
            <span>Your Information:</span>
            <asp:Button ID="Button1" runat="server" Text="Change Contact" CssClass="changeContact" OnClick="Button1_Click" />
        </div>
        <div class="informationDetail">
            <span><b>Guest Name</b></span><br />
            <span>First Name:&nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" CssClass="name" ></asp:TextBox></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <span>Last Name:&nbsp;&nbsp;<asp:TextBox ID="TextBox2" runat="server" CssClass="name" ></asp:TextBox></span><br /><br />
            <span><b>Sex:</b></span>
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="textBox" Width="90px"><asp:ListItem>male</asp:ListItem><asp:ListItem>female</asp:ListItem></asp:DropDownList><br /><br />
            <span><b>PhoneNumber:</b></span><asp:TextBox ID="TextBox3" runat="server" CssClass="textBox" ></asp:TextBox><br /><br />
            <span><b>CreditCardNumber:</b></span><asp:TextBox ID="TextBox4" runat="server" CssClass="textBox" ></asp:TextBox><br /><br />
            <span><b>Email:</b></span><asp:TextBox ID="TextBox5" runat="server" CssClass="textBox" ></asp:TextBox><br /><br />
        </div>
        <asp:Button ID="Button2" runat="server" Text="Pay Now" CssClass="payNow" OnClick="Button2_Click" />

    </div>
    <div class="Order">
       <div class="orderDetail">
            <h1>Summary of Charges</h1>
            <p class="p1">(All prices are in USD)</p>
                <p>Room cost (per night):<asp:Label ID="Label10" runat="server" CssClass="labelStyle" >123</asp:Label></p>
                <p>Nights:<asp:Label ID="Label1" runat="server" CssClass="labelStyle" >123</asp:Label></p>
                <p>Rooms:<asp:Label ID="Label2" runat="server" CssClass="labelStyle" >123</asp:Label></p>
                <p>Guests:<asp:Label ID="Label3" runat="server" CssClass="labelStyle" >123</asp:Label></p>
                <p>Room Subtotal:<asp:Label ID="Label4" runat="server" CssClass="labelStyle" >123</asp:Label></p>
            
            <hr />
            <div class="s1">TOTAL CHARGES</div>
            <div class="cost">$<span></span></div>
       </div> 
        
            <div class="hotelDetail">
                <img src="#" runat="server" />
                <asp:Label ID="Label5" runat="server" CssClass="hotelName">123</asp:Label>
                <div class="starLevel">starLevel</div>
            </div>
        <div class="check">
            <p><b>Address:</b></p>
            <asp:Label ID="Label6" runat="server">123</asp:Label><br /><br />
            <p><b>Room Type:</b></p>
            <asp:Label ID="Label7" runat="server">1213</asp:Label><br /><br />
            <p><b>Check In:</b></p>
            <asp:Label ID="Label8" runat="server">123</asp:Label><br /><br />
            <p><b>Check Out:</b></p>
            <asp:Label ID="Label9" runat="server">123</asp:Label><br /><br />
        </div>
            
        </div>
    
    </div>
</asp:Content>

