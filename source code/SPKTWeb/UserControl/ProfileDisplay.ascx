<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileDisplay.ascx.cs" Inherits="SPKTWeb.UserControl.ProfileDisplay" %>
<%@ Import namespace="SPKTCore.Core.Domain"%>
<div style="float:left;">
    <div style="height:130px;float:left;">
        <a href="/Profiles/UserProfile2.aspx?AccountID=<asp:Literal id='litAccountID' runat='server'></asp:Literal>">
        <asp:Image style="padding:5px;width:100px;height:100px;" ImageAlign="Left" Width="100" Height="100" ID="imgAvatar" ImageUrl="~/image/ProfileAvatar.aspx" runat="server" /></a>
        <asp:ImageButton ImageAlign="AbsMiddle" ID="ibInviteFriend" runat="server" Text="Become Friends" OnClick="lbInviteFriend_Click" ImageUrl="~/image/icon_friends.gif"></asp:ImageButton> 
        <asp:ImageButton ImageAlign="AbsMiddle" ID="ibDelete" runat="server" OnClick="ibDelete_Click" ImageUrl="~/image/icon_close.gif" /><br />
        <asp:Label ID="lblUsername" runat="server"></asp:Label><br />
        <asp:Label ID="lblFirstName" runat="server"></asp:Label> <asp:Label ID="lblLastName" runat="server"></asp:Label><br />
        Since: <asp:Label ID="lblCreateDate" runat="server"></asp:Label><br />
        <asp:Label ID="lblFriendID" runat="server" Visible="false"></asp:Label>
    </div>        
</div>