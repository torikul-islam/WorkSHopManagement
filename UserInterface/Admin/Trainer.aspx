<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Trainer.aspx.cs" Inherits="UserInterface.Admin.Trainer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 336px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table cellpadding="0" cellspacing="0" class="auto-style1">
        <tr>
            <td style="text-align: right">Trainer&#39;s First Name:</td>
            <td>
                <asp:TextBox ID="txtTrainerFirstName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">Trainer&#39;s Last Name:</td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">Trainer&#39;s Email:</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                &nbsp;</td>
            <td>
                <asp:Button class="button submit" ID="txtTnrSave" runat="server"  Text="Save" OnClick="txtSave_Click1" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="grdTrainers" Width="101%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grdTrainers_SelectedIndexChanged1">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
            </td>
        </tr>
    </table>


</asp:Content>
