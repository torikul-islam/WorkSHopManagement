<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="UserInterface.Common.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Sent A Request for Attending WorkShop</h1> <br />
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
        <asp:Button ID="btnSubmitWorkShop" runat="server" Text="Submit" OnClick="btnSubmitWorkShop_Click" />

    </div>
    </form>
</body>
</html>
