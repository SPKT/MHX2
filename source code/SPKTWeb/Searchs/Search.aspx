<%@ Import namespace="SPKTCore.Core.Domain"%>
<%@ Register Src="~/Friends/UserControl/FriendProfile.ascx" TagPrefix="uc7" TagName="FriendProfile" %>
<%@ Register Src="~/Styles/LEFT_MENU.ascx" TagName="menu" TagPrefix="uc4" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_P.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="SPKTWeb.Search.Search" %>

<asp:Content ID="cont" ContentPlaceHolderID="left" runat="server">
    <div style="margin-top:-50px;">
        <uc4:menu ID="menu" runat="server" />
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
<div style=" padding-left:100px; padding:30px; margin-top:87px; margin-left:23%; background-color:White; width:92%; height:auto; background-image: url('../../Image/bo8.gif'); background-repeat: repeat-y; height:1000px;">
        <div align="center" style=" margin-left:-10px;background-image: url('../Image/thead.gif'); background-repeat: repeat; height:25px; width:72%">
            <asp:Label ID="lblSearchTerm" runat="server" ForeColor="#FF3300"></asp:Label>
        </div>
        <div style=" margin-left:20px; margin-top:30px;width:70%; margin-left:0px;">
            <asp:Repeater ID="repAccounts" runat="server" OnItemDataBound="repAccounts_ItemDataBound">
                            <ItemTemplate>
                                <uc7:FriendProfile ShowDeleteButton="false" ID="pdProfileDisplay" runat="server"></uc7:FriendProfile>
                            </ItemTemplate>
             </asp:Repeater>
        </div>
    </div>
</asp:Content>
