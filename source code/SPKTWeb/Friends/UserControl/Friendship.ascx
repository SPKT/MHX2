<%@ Register src="Friend.ascx" tagname="Friend" tagprefix="uc1" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Friendship.ascx.cs" Inherits="SPKTWeb.Friends.UserControl.Friendship" %>
<div style="width:auto; float:left;">
    <ul style="list-style-type: none;">
        <asp:Repeater ID="repFriends" runat="server" OnItemDataBound="repFriends_ItemDataBound">
             <ItemTemplate>
                <li style="float:left">
                <uc1:Friend ID="Friend" runat="server" />
                </li>
             </ItemTemplate>   
        </asp:Repeater>
    </ul>
</div>