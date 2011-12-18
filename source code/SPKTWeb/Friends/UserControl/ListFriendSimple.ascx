<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListFriendSimple.ascx.cs"
    Inherits="SPKTWeb.Friends.ListFriendSimple" %>
<%@ Register Src="FriendSimple.ascx" TagName="FriendSimple" TagPrefix="uc1" %>
<div align="center" style="border: 1px solid #999999; font-family: Constantia; font-weight: bold;
    color: #006600; background-image: url('../../Image/htitle.gif'); background-repeat: repeat-x;
    width: 100%; height: 25; padding-bottom: 10px;">
    <asp:LinkButton ID="lbt_Friend" runat="server" Font-Names="Times New Roman" Font-Underline="False"
        ForeColor="#006600">Danh Sách Bạn Bè</asp:LinkButton>
    <div style="background-color: #000066; height:2px; margin-top:8px;"></div>
    <div style="width:100%; height:auto; margin:10px; margin-left:0px;">
        <asp:Repeater ID="repFriends" runat="server" OnItemDataBound="repFriends_ItemDataBound">
            <ItemTemplate>
                <uc1:FriendSimple ID="pdFriendSimple" runat="server"></uc1:FriendSimple>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
