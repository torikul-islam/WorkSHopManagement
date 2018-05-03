<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Approval.aspx.cs" Inherits="UserInterface.Admin.Approval" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="grdWorkShopRequest" AutoGenerateSelectButton="True" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"  DataKeyNames="UserId,WorkShopId">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <asp:RadioButtonList ID="rblApproveReject" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblApproveReject_SelectedIndexChanged" >
        <asp:ListItem  Value="1" Text="Approve"></asp:ListItem>
        <asp:ListItem  Value="2" Text="Reject" > </asp:ListItem>
    </asp:RadioButtonList>
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />





</asp:Content>
