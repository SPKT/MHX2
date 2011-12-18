<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FriendList.ascx.cs" Inherits="SPKTWeb.Friends.UserControl.FriendList" %>
<div style="background-image: url('http://localhost:4120/Image/a2.gif'); background-repeat: repeat-x; margin-bottom:0px; height: 86px;">
    <div class="menu_link">
        <a href="~/Profiles/UserProfile2.aspx?AccountID=<asp:Literal id='litAccountID' runat='server'></asp:Literal>">
        <asp:Image style="padding:5px; margin-top: 6px;" ImageAlign="Left" 
            ID="imgAvatar" 
            runat="server" CssClass="img" /></a>
        <br />
        <asp:LinkButton 
            ID="lblUsername" runat="server" Font-Size="Small" Font-Underline="False" 
            CssClass="menu_link" onclick="lblUsername_Click1"></asp:LinkButton>
        <br />
        <asp:Label ID="lblCreateDate" runat="server" 
            Font-Italic="True" Font-Size="Small" Visible="False"></asp:Label><br />
        &nbsp;<asp:Label ID="lblFriendID" runat="server" Visible="False"></asp:Label>
    </div>
    <br />
</div>
<div style="border: 1px solid #808080; margin-top: 2px; height:2px; width:100%">
 </div>
