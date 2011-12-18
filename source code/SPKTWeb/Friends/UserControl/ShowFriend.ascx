<%@ Import Namespace="SPKTCore.Core.Domain" %>
<%@ Register Src="~/Friends/UserControl/FriendProfile.ascx" TagPrefix="uc7" TagName="FriendProfile" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowFriend.ascx.cs"
    Inherits="SPKTWeb.Friends.ShowFriend" %>
<div style="width:100%; height:auto">
    <div style="border-style: solid; border-width: 1px 0px 1px 0px; border-color: #CCCCCC #FFFFFF #CCCCCC #FFFFFF; background-image: url('../Image/thead.gif'); height:25px; background-repeat: repeat-x; height:25px;">
        <asp:Label ID="lblSearchTerm" runat="server" ForeColor="#FF3300"></asp:Label>
    </div>
    <div style=" margin:20px; margin-left:5px;">
        <asp:Repeater ID="repFriends" runat="server" OnItemDataBound="repFriends_ItemDataBound">
            <ItemTemplate>
                <div>
                    <ul style="list-style-image:none; list-style-type: none;margin-top:35px;">
                        <li style="  list-style-image:none; list-style-type: none;">
                            <uc7:FriendProfile ShowDeleteButton="false" ID="pdProfileDisplay" runat="server">
                            </uc7:FriendProfile>
                        </li>
                    </ul>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
