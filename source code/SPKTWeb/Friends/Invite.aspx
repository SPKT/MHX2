<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_E.Master" AutoEventWireup="true" CodeBehind="Invite.aspx.cs" Inherits="SPKTWeb.Friends.Invite" %>
<%@ Register src="~/Friends/UserControl/InviteFriends.ascx" tagname="InviteFriends" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
<div style="margin:50px;">
<uc1:InviteFriends ID="InviteFriends1" runat="server" />
</div>
</asp:Content>
