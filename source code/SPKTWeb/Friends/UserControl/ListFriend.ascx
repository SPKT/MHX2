<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListFriend.ascx.cs" Inherits="SPKTWeb.Friends.UserControl.ListFriend" %>
<%@ Register src="FriendList.ascx" tagname="FriendList" tagprefix="uc1" %>
<div>
    <div align="center">
        <asp:Repeater ID="repFriends" runat="server" OnItemDataBound="repFriends_ItemDataBound">
             <ItemTemplate>
                    <uc1:FriendList id="pdFriendList" runat="server"></uc1:FriendList>
             </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
