<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewAlbum.ascx.cs" Inherits="SPKTWeb.Photo.UserControl.NewAlbum" %>
<div>
    <asp:Label ID="Label1" runat="server" Text="Tên Album"></asp:Label>
    <br />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Mô tả"></asp:Label>
    <br />
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Thêm" />
</div>