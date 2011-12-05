<%@ Import namespace="SPKTCore.Core.Domain"%>
<%@ Register Src="~/Friends/UserControl/FriendProfile.ascx" TagPrefix="uc7" TagName="FriendProfile" %>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowFriend.ascx.cs" Inherits="SPKTWeb.Friends.ShowFriend" %>

<div class="divContainer">
        <div class="divContainerBox" style="vertical-align:middle; margin-left:10%">
            <div class="divContainerTitle"><asp:Label ID="lblSearchTerm" runat="server"></asp:Label></div>
            <div class="divContainerRow" style="height:350px;">
               <div class="divContainerCell">
                    <asp:Panel ID="pnlFriends" Height="350" ScrollBars="Vertical" runat="server">
                        <asp:Repeater ID="repFriends" runat="server" OnItemDataBound="repFriends_ItemDataBound">
                            <ItemTemplate>
                                <uc7:FriendProfile ShowDeleteButton="false" ID="pdProfileDisplay" runat="server"></uc7:FriendProfile>
                            </ItemTemplate>
                        </asp:Repeater>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
