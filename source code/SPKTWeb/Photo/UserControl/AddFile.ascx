<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddFile.ascx.cs" Inherits="SPKTWeb.Photo.UserControl.AddFile" %>
<div style="width:100%; height:100%">
    <div>
        <asp:FileUpload ID="FileUpload1" runat="server" />

        <br />
        <asp:Button ID="Button1" runat="server" Text="Upload" onclick="Button1_Click" />

    </div>
</div>