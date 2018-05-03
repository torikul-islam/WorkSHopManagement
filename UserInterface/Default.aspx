<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UserInterface.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <center><h1>Welcome to WorkShop Management Portal</h1></center>
        <br />
        <br />
        <Marquee onMouseOver="stop();" onMouseOut="start();"><a href="Common/Workshop.aspx">Enroll here for upcoming workshop</a></Marquee><br />
        <br />
        <br />
        <br />
        <br />

        <center>   
            <table>
                    <tr>
                        <td>
                            UserName:
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserName" runat="server" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Password:
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                          
                        </td>
                        <td>
                            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>

        </center>
       
    </div>
    </form>
</body>
</html>
