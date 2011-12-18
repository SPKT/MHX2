<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListFriend.ascx.cs" Inherits="SPKTWeb.Friends.UserControl.ListFriend" %>
<%@ Register src="FriendList.ascx" tagname="FriendList" tagprefix="uc1" %>

<div style="width:100%; height:auto; margin:5px; margin-left:0px; background-color:White;">
        <asp:Repeater ID="repFriends" runat="server" OnItemDataBound="repFriends_ItemDataBound">
             <ItemTemplate>
                    <uc1:FriendList id="pdFriendList" runat="server"></uc1:FriendList>
             </ItemTemplate>
        </asp:Repeater>
    </div>