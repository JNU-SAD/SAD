<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PayMethod.aspx.cs" Inherits="PayMethod" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('.payMethod').click(function () {
                $('#mask').animate({ opacity: '1', zIndex: '999' }, 800);
            });
            $('#button2').click(function () {
                $('#mask').animate({ opacity: '0', zIndex: '-1' }, 800);
            });
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="mainBody">

    <div id="mask" style="text-align:center;background-color:rgba(0,0,0,0.8);height:100%;width:100%;position:fixed;top:0;left:0;z-index:-1;opacity:0">
        <asp:Button ID="button1" Text="Payment Complete" CssClass="payButton" runat="server" OnClick="button1_Click" /><br />
        <input type="button" id="button2" value="Next Time..." class="cancelButton" />
    </div>
<div class="payMethodList">
    
    <h1>We Accept Payments Via Products Below:</h1>
    <%foreach(Table_PayMethod paymethod in paymethods)
      { %>
    <a href="<%=paymethod.Url %>" target="_blank" ><img class="payMethod" alt="pay" src="<%=paymethod.ImgUrl %>" /></a>
    <%} %>
</div>
</div>
</asp:Content>

