<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="WorkShop.aspx.cs" Inherits="UserInterface.Admin.WorkShop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function (){
            $("#txtWorkShopDate").datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true
            })
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="margin: 0 auto" >
        <tr>
            <td>
                WorkShop Title:
            </td>
            <td>
                <asp:TextBox ID="txtWorkShopTitle" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                WorkShop Date:
            </td>
            <td>
                <asp:TextBox ID="txtWorkShopDate" runat="server" ClientIDMode="Static"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                WorkShop Duration:
            </td>
            <td>
                <asp:TextBox ID="txtWorkShopDuration" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                WorkShop Topics:
            </td>
            <td>
                <asp:TextBox ID="txtWorkShopTopics" runat="server" height="67px" TextMode="MultiLine" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <b>Trainer:</b>
                <asp:CheckBoxList ID="ckbLTrainer" runat="server">   
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td >
               <asp:Button ID="btnCreateWs" runat="server" Text="Create Workshop" OnClick="btnCreateWs_Click" />
               <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
               <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" /> 
            </td>
        </tr>
       
    </table>
     <br /> 
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateSelectButton="True" DataKeyNames="WorkShopId">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <br />
    
    <asp:Button ID="btnAssaignTrainer" runat="server" Text="Assign" OnClick="btnAssaignTrainer_Click" />
</asp:Content>
