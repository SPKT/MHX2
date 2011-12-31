<%@ Register Src="~/Photo/UserControl/NewAlbum.ascx" TagName="add" TagPrefix="uc1" %>
<%@ Register Src="~/Photo/UserControl/AddFile.ascx" TagName="file" TagPrefix="uc2" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_E.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="ManagePhoto.aspx.cs" Inherits="SPKTWeb.Photo.ManagePhoto" %>

<%@ Register Src="UserControl/FileListItem.ascx" TagName="FileListItem" TagPrefix="uc3" %>
<%@ Register Src="UserControl/CreateAlbum.ascx" TagName="CreateAlbum" TagPrefix="uc4" %>
<%@ Register Src="UserControl/LoadAlbum.ascx" TagName="LoadAlbum" TagPrefix="uc5" %>
<%@ Register src="UserControl/ListFileShare.ascx" tagname="ListFileShare" tagprefix="uc6" %>
<%@ Register src="UserControl/ListFolderShare.ascx" tagname="ListFolderShare" tagprefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">
    <div style="border: 1px solid #9999FF; height: auto;  background-color: White;">
        <div style="width:100%; height:25px;">
            <asp:Image ID="Image1" runat="server" Width="100%" Height="100%" ImageUrl="~/Image/q1.jpg" />
        </div>
        <div style="margin-left: 20px; margin-right: 20px;">
            <asp:LinkButton ID="lb_album" runat="server" Width="90%" Height="100%" 
                Font-Underline="false" onclick="lb_album_Click">Album ảnh</asp:LinkButton>
        </div>
        <div style="margin-left: 20px; margin-right: 20px;">
            <asp:LinkButton ID="lb_taomoi" runat="server" Width="90%" Height="100%" OnClick="lb_taomoi_Click"
                Font-Underline="false">Tạo album</asp:LinkButton>
        </div>
        <div style="margin-left: 20px; margin-right: 20px;">
            <asp:LinkButton ID="LinkButton1" runat="server" Width="90%" Height="100%" OnClick="lb_taomoi1_Click"
                Font-Underline="false">Ảnh cá nhân</asp:LinkButton>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
    <div id="di" runat="server" visible="true" style=" margin-left:1%; margin-right:1%;">
        <div align="center">
            
            <asp:Label ID="Label2" runat="server" Text="Mô tả"></asp:Label>
            
            &nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            &nbsp;
            <asp:CheckBox ID="Ispublic" runat="server" Text="IsPublic" />
        &nbsp;<asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="Button2" runat="server" Text="Upload" OnClick="Button2_Click" />
        </div>
        
        
        <div style="height: 17px; color: #800000; padding-left: 20px; font-size: small; background-image: url('../Image/thead.gif');
            background-repeat: repeat-x;">
            Ảnh của bạn
        </div>
        <div style="height: 17px; color: #800000; padding-left: 20px; font-size: small; background-image: url('../Image/thead.gif');
            background-repeat: repeat-x;">
            Album của bạn
            <asp:Label ID="countA" runat="server" Text="Label"></asp:Label>
        </div>
        
            <div>
                <uc5:LoadAlbum ID="LoadAlbum1" runat="server"  />
            </div>
            <div>
                <uc7:ListFolderShare ID="ListFolderShare1" runat="server" />
            </div>
            <div>
                <uc6:ListFileShare ID="ListFileShare1" runat="server" />
            </div>
        <div>
            <uc3:FileListItem ID="FileListItem1" runat="server" />
        </div>
    </div>
</asp:Content>
