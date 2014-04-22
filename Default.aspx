<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <%DateTime date = System.DateTime.Now;
      String s = "1111/02/03"; %>
    <%=DateTime.ParseExact(s, "yyyy/MM/dd", System.Globalization.CultureInfo.CurrentCulture) %>
    </div>
    </form>
</body>
</html>
