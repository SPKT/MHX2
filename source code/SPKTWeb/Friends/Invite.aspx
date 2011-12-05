<%@ Page Title="" Language="C#" MasterPageFile="~/MXH1.Master" AutoEventWireup="true" CodeBehind="Invite.aspx.cs" Inherits="SPKTWeb.Friends.Invite" %>
<%@ Register src="~/Friends/UserControl/InviteFriends.ascx" tagname="InviteFriends" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

    <uc1:InviteFriends ID="InviteFriends1" runat="server" />

</asp:Content>
