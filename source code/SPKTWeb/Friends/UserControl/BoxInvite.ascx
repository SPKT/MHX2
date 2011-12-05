<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BoxInvite.ascx.cs" Inherits="SPKTWeb.Friends.BoxInvite" %>
<%@ Register Src="~/Friends/UserControl/BoxFriend.ascx" TagPrefix="uc1" TagName="BoxFriend" %>
<div>
    <div align="center">
        <asp:Repeater ID="repInFriends" runat="server" OnItemDataBound="repInFriends_ItemDataBound">
             <ItemTemplate>
                    <uc1:BoxFriend ID="pdBoxFriend" ShowDeleteButton="false" runat="server"></uc1:BoxFriend>  
             </ItemTemplate>
        </asp:Repeater>
    </div>
</div>

 