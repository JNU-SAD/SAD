<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Management.aspx.cs" Inherits="Management" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div class="mainBody">
                <div id="myModal" class="reveal-modal">
                    <h2>Comment</h2>
                    <p style="color:black">Hotel：<%=GridView2.SelectedIndex>0?GridView2.SelectedRow.Cells[1].Text:"" %></p>
                    <p style="color:black">Score：
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>1-Very Poor</asp:ListItem><asp:ListItem>2-Acceptable</asp:ListItem><asp:ListItem>3-Acceptable</asp:ListItem>
                            <asp:ListItem>4-Acceptable</asp:ListItem><asp:ListItem>5-Above Average</asp:ListItem><asp:ListItem>6-Pleasant</asp:ListItem>
                            <asp:ListItem>7-Good</asp:ListItem><asp:ListItem>8-Fantastic</asp:ListItem><asp:ListItem>9-Wonderful</asp:ListItem><asp:ListItem>10-Exceptional</asp:ListItem>
                        </asp:DropDownList>
                    </p>
                    <p style="color:black">Comment：
                        <asp:TextBox ID="textbox_comment" runat="server" TextMode="MultiLine" Columns="50" Rows="5"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Button ID="Button_comment" runat="server" Text="Submit" OnClick="Button_comment_Click" />
                    </p>
                    <a class="close-reveal-modal">×</a>
                </div>
                <div class="aside" style="background-color: transparent">
                    <asp:Button ID="Button2" runat="server" Text="Reservations" CssClass="button" OnClick="Button2_Click" />
                    <asp:Button ID="Button7" runat="server" Text="My Comments" CssClass="button" OnClick="Button7_Click" />
                    <asp:Button ID="Button1" runat="server" Text="Information" CssClass="button" OnClick="Button1_Click" />
                    <asp:Button ID="Button3" runat="server" Text="Change Password" CssClass="button" OnClick="Button3_Click" />

                </div>
                <div class="result" style="background-color: transparent">
                    <asp:Panel ID="Panel1" runat="server" Visible="false">
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

                    <asp:Panel ID="Panel2" runat="server" Visible="false">
                        <table cellspacing="20">
                            <tr>
                                <td style="color: white">Old password</td>
                                <td>
                                    <asp:TextBox runat="server" ID="TextBox1" TextMode="Password" CssClass="input" /></td>
                            </tr>
                            <tr>
                                <td style="color: white">New password</td>
                                <td>
                                    <asp:TextBox runat="server" ID="TextBox2" TextMode="Password" CssClass="input" /></td>
                            </tr>
                            <tr>
                                <td style="color: white">Confirm</td>
                                <td>
                                    <asp:TextBox runat="server" ID="TextBox3" TextMode="Password" CssClass="input" /></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button4" runat="server" Text="Submit" OnClick="Button4_Click" CssClass="button" /></td>
                            </tr>
                        </table>
                    </asp:Panel>

                    <asp:Panel ID="Panel3" runat="server" Visible="false">
                        <div class="reservation">
                            <div runat="server" id="div1" visible="false" style="color: white">
                                No Reservation Found.
                            </div>
                            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="10" DataKeyNames="Id" DataSourceID="LinqDataSource2" ForeColor="#333333" GridLines="None" OnDataBound="GridView2_DataBound" HorizontalAlign="Center" Width="700px" PageSize="5">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                                    <asp:BoundField DataField="HotelId" HeaderText="Hotel" SortExpression="HotelId">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RoomType" HeaderText="Room Type" SortExpression="RoomType">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Value" HeaderText="Value" SortExpression="Value">
                                        <HeaderStyle HorizontalAlign="Center" />
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
                                    <asp:BoundField DataField="Customer" HeaderText="Customer" SortExpression="Customer" />
                                    <asp:BoundField DataField="HotelId" HeaderText="Hotel" SortExpression="HotelId" />
                                    <asp:BoundField DataField="RoomType" HeaderText="Room Type" SortExpression="RoomType" />
                                    <asp:BoundField DataField="RoomNum" HeaderText="Room Number" SortExpression="RoomNum" />
                                    <asp:BoundField DataField="CheckIn" HeaderText="Check In" SortExpression="CheckIn" />
                                    <asp:BoundField DataField="CheckOut" HeaderText="Check Out" SortExpression="CheckOut" />
                                    <asp:BoundField DataField="Value" HeaderText="Value" />
                                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                </Fields>
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderTemplate>
                                    Detail
                                </HeaderTemplate>
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            </asp:DetailsView>
                            <br />
                            <asp:Button ID="Button5" runat="server" Text="Pay now!" CssClass="button" OnClick="Button5_Click" />
                            <br />
                            <a class="buttonc" href="javascript:void(0);" data-reveal-id="myModal" runat="server" id="Button6">Comment</a>


                            <asp:LinqDataSource ID="LinqDataSource3" runat="server" ContextTypeName="DataClassesDataContext" EntityTypeName="" TableName="Table_HotelReservation" Where="Id == @Id">
                                <WhereParameters>
                                    <asp:ControlParameter ControlID="GridView2" DefaultValue="-1" Name="Id" PropertyName="SelectedValue" Type="Int32" />
                                </WhereParameters>
                            </asp:LinqDataSource>
                            <asp:LinqDataSource ID="LinqDataSource2" runat="server" ContextTypeName="DataClassesDataContext" EntityTypeName="" TableName="Table_HotelReservation" Where="Customer == @Customer">
                                <WhereParameters>
                                    <asp:SessionParameter Name="Customer" SessionField="Customer" Type="String" />
                                </WhereParameters>
                            </asp:LinqDataSource>

                        </div>
                    </asp:Panel>
                    <asp:Panel ID="Panel4" runat="server" Visible="false">
                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="10" DataKeyNames="Id" DataSourceID="LinqDataSource4" ForeColor="#333333" GridLines="None" OnDataBound="GridView3_DataBound" Width="700px">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                                <asp:BoundField DataField="HotelId" HeaderText="Hotel" SortExpression="HotelId" />
                                <asp:BoundField DataField="Score" HeaderText="Score" SortExpression="Score" />
                                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                                <asp:CommandField SelectText="View Detail" ShowSelectButton="True" />
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
                        <asp:DetailsView ID="DetailsView3" runat="server" AutoGenerateRows="False" CellPadding="20" DataKeyNames="Id" DataSourceID="LinqDataSource5" ForeColor="#333333" GridLines="None" OnDataBound="DetailsView3_DataBound" Width="700px">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                            <EditRowStyle BackColor="#999999" />
                            <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                            <Fields>
                                <asp:BoundField DataField="HotelId" HeaderText="Hotel" SortExpression="HotelId" />
                                <asp:BoundField DataField="Comment" HeaderText="Comment" SortExpression="Comment" />
                                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                                <asp:BoundField DataField="Score" HeaderText="Score" SortExpression="Score" />
                            </Fields>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        </asp:DetailsView>
                        <asp:LinqDataSource ID="LinqDataSource5" runat="server" ContextTypeName="DataClassesDataContext" EntityTypeName="" TableName="Table_Comment" Where="Id == @Id">
                            <WhereParameters>
                                <asp:ControlParameter ControlID="GridView3" DefaultValue="-1" Name="Id" PropertyName="SelectedValue" Type="Int32" />
                            </WhereParameters>
                        </asp:LinqDataSource>
                        <asp:LinqDataSource ID="LinqDataSource4" runat="server" ContextTypeName="DataClassesDataContext" EntityTypeName="" TableName="Table_Comment" Where="CustomerEmail == @CustomerEmail">
                            <WhereParameters>
                                <asp:SessionParameter Name="CustomerEmail" SessionField="Customer" Type="String" />
                            </WhereParameters>
                        </asp:LinqDataSource>
                    </asp:Panel>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

