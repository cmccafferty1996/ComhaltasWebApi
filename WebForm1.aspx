<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ComhaltasWebApi.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="TestDS" DataTextField="first_name" DataValueField="first_name"></asp:DropDownList>
            <asp:SqlDataSource ID="TestDS" runat="server" ConnectionString="<%$ ConnectionStrings:comhaltasTestConnectionString %>" SelectCommand="SELECT [first_name], [surname], [user_name] FROM [Admin_users]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
