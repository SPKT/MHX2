<%@ Import namespace="SPKTCore.Core.Domain"%>
<%@ Register Src="~/Friends/UserControl/FriendProfile.ascx" TagPrefix="uc7" TagName="FriendProfile" %>
<%@ Register Src="~/Styles/LEFT_MENU.ascx" TagName="menu" TagPrefix="uc4" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_PE.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="SPKTWeb.Search.Search" %>

<asp:Content ID="cont" ContentPlaceHolderID="left" runat="server">
    <div style="margin-top:0px;">
        <uc4:menu ID="menu" runat="server" />
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div>
        <div align="center" style=" margin-left:0px;background-image: url('../Image/thead.gif'); background-repeat: repeat; height:25px; width:72%">
            <asp:Label ID="lblSearchTerm" runat="server" ForeColor="#FF3300"></asp:Label>
        </div>
        <div style=" margin-left:30px; margin-top:0px;width:70%; margin-left:0px;">
            <asp:Repeater ID="repAccounts" runat="server" OnItemDataBound="repAccounts_ItemDataBound">
                            <ItemTemplate>
                                <uc7:FriendProfile ShowDeleteButton="false" ID="pdProfileDisplay" runat="server"></uc7:FriendProfile>
                            </ItemTemplate>
             </asp:Repeater>
        </div>
    </div>
</asp:Content>
