<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Management.aspx.cs" Inherits="Management" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1
        {
            height: 43px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

        
    <div class="mainBody">
        <div class="aside" style="background-color:transparent">
            <asp:Button ID="Button1" runat="server" Text="Information" CssClass="button" OnClick="Button1_Click"/>
            <asp:Button ID="Button3" runat="server" Text="Change Password" CssClass="button" OnClick="Button3_Click"/>
            <asp:Button ID="Button2" runat="server" Text="Reservations"  CssClass="button" OnClick="Button2_Click"/>
        </div>
        <div class="result" style="background-color:transparent">
            <asp:Panel ID="Panel1" runat="server" Visible="false" >
            <asp:DetailsView runat="server" ID="DetailsView1" AutoGenerateRows="False" CellPadding="20" DataKeyNames="EmailAddress" DataSourceID="LinqDataSource1" ForeColor="#333333" GridLines="None" Width="700px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                <EditRowStyle BackColor="White" />
                <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                <Fields>
                    <asp:BoundField DataField="EmailAddress" HeaderText="Email Address" ReadOnly="True" SortExpression="EmailAddress" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                    <asp:BoundField DataField="Sex" HeaderText="Sex" SortExpression="Sex" />
                    <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" SortExpression="PhoneNumber" />
                    <asp:BoundField DataField="CreditCardNumber" HeaderText="Credit Card Number" SortExpression="CreditCardNumber" />
                    <asp:CommandField CancelText="Cancel" DeleteText="Delete" EditText="Edit" ShowEditButton="True" UpdateText="Update" />
                </Fields>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderTemplate>
                    Account Information
                </HeaderTemplate>
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            </asp:DetailsView>

            <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="DataClassesDataContext" EnableUpdate="True" EntityTypeName="" TableName="Table_Customer" Where="EmailAddress == @EmailAddress">
                <WhereParameters>
                    <asp:SessionParameter Name="EmailAddress" SessionField="Customer" Type="String" />
                </WhereParameters>
            </asp:LinqDataSource>
            </asp:Panel>

            <asp:Panel ID="Panel2" runat="server" Visible="false" >
                <table  cellspacing="20">
                    <tr>
                        <td class="auto-style1">Old password</td>
                        <td class="auto-style1"><asp:TextBox runat="server" ID="TextBox1" TextMode="Password" CssClass="input"  /></td>
                    </tr>
                    <tr>
                        <td>New password</td>
                        <td><asp:TextBox runat="server" ID="TextBox2" TextMode="Password" CssClass="input"  /></td>
                    </tr>
                    <tr>
                        <td>Confirm</td>
                        <td><asp:TextBox runat="server" ID="TextBox3" TextMode="Password" CssClass="input" /></td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="Button4" runat="server" Text="Submit" OnClick="Button4_Click" CssClass="button"/></td>
                    </tr>
                </table>
            </asp:Panel>

            <asp:Panel ID="Panel3" runat="server" Visible="false" >
                <div class="reservation">
                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="10" DataKeyNames="Id" DataSourceID="LinqDataSource2" ForeColor="#333333" GridLines="None" OnDataBound="GridView2_DataBound" HorizontalAlign="Center" Width="700px">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                            <asp:BoundField DataField="HotelId" HeaderText="Hotel Id" SortExpression="HotelId">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RoomType" HeaderText="Room Type" SortExpression="RoomType">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RoomNum" HeaderText="Num." SortExpression="RoomNum">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CheckIn" HeaderText="Check In" SortExpression="CheckIn">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CheckOut" HeaderText="Check Out" SortExpression="CheckOut">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:CommandField SelectText="View Detail" ShowSelectButton="True">
                            <ItemStyle HorizontalAlign="Right" />
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
                    <br />
                    <asp:DetailsView ID="DetailsView2" runat="server" AutoGenerateRows="False" CellPadding="20" DataKeyNames="Id" DataSourceID="LinqDataSource3" ForeColor="#333333" GridLines="None" OnDataBound="DetailsView2_DataBound" Width="700px">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                        <EditRowStyle BackColor="#999999" />
                        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                        <Fields>
                            <asp:BoundField DataField="Id" HeaderText="Reservation Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                            <asp:BoundField DataField="Customer" HeaderText="Customer" SortExpression="Customer" />
                            <asp:BoundField DataField="HotelId" HeaderText="Hotel Id" SortExpression="HotelId" />
                            <asp:BoundField DataField="RoomType" HeaderText="Room Type" SortExpression="RoomType" />
                            <asp:BoundField DataField="RoomNum" HeaderText="Room Number" SortExpression="RoomNum" />
                            <asp:BoundField DataField="CheckIn" HeaderText="Check In" SortExpression="CheckIn" />
                            <asp:BoundField DataField="CheckOut" HeaderText="Check Out" SortExpression="CheckOut" />
                            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                        </Fields>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    </asp:DetailsView>
                    <br />
                    <asp:Button ID="Button5" runat="server" Text="Pay now!" CssClass="button" OnClick="Button5_Click"/>
                    <asp:LinqDataSource ID="LinqDataSource3" runat="server" ContextTypeName="DataClassesDataContext" EntityTypeName="" TableName="Table_HotelReservation" Where="Id == @Id">
                        <WhereParameters>
                            <asp:ControlParameter ControlID="GridView2" Name="Id" PropertyName="SelectedValue" Type="Int32" />
                        </WhereParameters>
                    </asp:LinqDataSource>
                    <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="DataClassesDataContext" EntityTypeName="" TableName="Table_HotelReservation">
                    </asp:LinqDataSource>
                     
                </div>
            </asp:Panel>
        </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

