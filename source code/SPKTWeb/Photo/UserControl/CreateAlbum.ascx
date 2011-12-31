<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateAlbum.ascx.cs" Inherits="SPKTWeb.Photo.UserControl.CreateAlbum" %>
<%@ Register src="FileListItemAlbum.ascx" tagname="FileListItemAlbum" tagprefix="uc1" %>
<div style="padding:20px; height:auto">
    <asp:Label ID="Label1" runat="server" Text="Tên Album"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" Width="244px"></asp:TextBox>
    &nbsp;<asp:Label ID="Label2" runat="server" Text="Mô tả"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server" Width="240px"></asp:TextBox>
    <asp:CheckBox ID="Ispublic" runat="server" Text="IsPublic" />
&nbsp;<asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Thêm" 
        BackColor="Maroon" ForeColor="White" />
    <br />
    &nbsp;
        <br />
        <div id="pa" runat="server">
        <asp:Button ID="Button2" runat="server" Text="Upload" onclick="Button2_Click" 
                BackColor="Maroon" ForeColor="#FFCC00" />
        <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
        <div>
            <uc1:FileListItemAlbum ID="FileListItemAlbum1" runat="server" />
        </div>
    </div>
    <br />
</div>