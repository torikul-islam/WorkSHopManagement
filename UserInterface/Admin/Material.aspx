<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Material.aspx.cs" Inherits="UserInterface.Admin.Material" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <table style="width: 388px">
       <tr>
           <td>
               Workshop:
           </td>
           <td>
               <asp:DropDownList ID="ddlWorkshop" runat="server" Height="16px" Width="155px" AppendDataBoundItems="True">
                   <asp:ListItem Value="0">Select</asp:ListItem>
               </asp:DropDownList>
           </td>
       </tr>
       <tr>
           <td>
               Material: 
           </td>
           <td>
               <asp:FileUpload ID="MaterialUpload" runat="server" Height="23px" Width="211px" />
           </td>
       </tr>
       <tr>
            <td style="text-align: right">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" Height="24px" Width="66px" OnClick="btnSave_Click1" />
                
            </td>
        </tr>

       <tr>
           <td colspan="2" style="text-align: right">
           <asp:GridView ID="grdMaterial" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="237px" style="margin-top: 1px">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Download">
                            <ItemTemplate>
                                <asp:HyperLink ID="Hyperlink" runat="server" NavigateUrl= '<%# Eval("MaterialPath") %>' Text="Download" ></asp:HyperLink>
                            </ItemTemplate>

                        </asp:TemplateField>

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

           </td>
       </tr>



   </table>


</asp:Content>
