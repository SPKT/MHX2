<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_R.Master" AutoEventWireup="true" CodeBehind="CreateAlbum.aspx.cs" Inherits="SPKTWeb.Photo.CreateAlbum" %>
<%@ Register Src="~/Photo/UserControl/CreateAlbum.ascx" TagName="CreateAlbum" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="right" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
<div style="width:100%; height:100%">
    
    <uc1:CreateAlbum ID="CreateAlbum1" runat="server" />
    
    </div>
</asp:Content>
