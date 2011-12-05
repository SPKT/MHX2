<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_1.Master" AutoEventWireup="true" CodeBehind="RecoverPassword.aspx.cs" Inherits="SPKTWeb.Accounts.RecoverPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="right" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Main" runat="server">
<asp:Panel ID="pnlRecoverPassword" Visible="true" runat="server">
<table border="0"  height:243px;" style="width: 602px">

                 <caption>
                     <a class="divContainerTitle" 
                         style="height: 65px; width: 370px; color: #FF0000; font-size: x-large; font-weight: bold;">
                     Phục hồi mật khẩu</a><br />
                     <tr>
                         <td align="Right" class="style105" style="color: #0000FF; font-size: large;">
                             Tên đăng nhập:</td>
                         <td align="left" class="style108">
                             <asp:TextBox ID="txtUserName" runat="server" BorderStyle="Inset" 
                                 BorderWidth="2px" Height="22px" Width="170px"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td align="right" class="style104" style="color: #0000FF; font-size: large;">
                             Email:</td>
                         <td align="left" class="style104">
                             <asp:TextBox ID="txtEmail" runat="server" BorderStyle="Inset" BorderWidth="2px" 
                                 Height="21px" Width="170px"></asp:TextBox>
                         </td>
                     </tr>
                     <tr>
                         <td class="style107">
                         </td>
                         <td align="left" class="style110">
                            <asp:Button ID="btnRecoverPassword" runat="server" Text="Phục hồi" 
                                 onclick="btnRecoverPassword_Click" BorderColor="#0099FF"></asp:Button>
                         </td>
                     </tr>
                     <tr>
                         <td class="style107">
                         </td>
                         <td align="left" class="style110">
                             <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
                         </td>
                     </tr>
                 </caption>
     
                </table>
</asp:Panel>
<asp:Panel ID="pnlMessage" Visible="false" runat="server">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
</asp:Panel>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="right1" runat="server">
</asp:Content>
