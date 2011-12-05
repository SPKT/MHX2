<%@ Import namespace="SPKTCore.Core.Domain"%>
<%@ Register Src="~/Friends/UserControl/FriendProfile.ascx" TagPrefix="uc7" TagName="FriendProfile" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_1.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="SPKTWeb.Search.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="right1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="left" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="right" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
<div class="divContainer">
        <div class="divContainerBox" style="vertical-align:middle;">
            <div class="divContainerTitle" style="margin-left:40%;outline-color:Red;"><asp:Label ID="lblSearchTerm" runat="server" ForeColor="Red"></asp:Label><br /> <asp:Label ID="lb_Soluong" runat="server" Text="  Kết quả: " ForeColor="Blue"></asp:Label></div>
            <div class="divContainerRow" style="height:400px; margin-left:30%; margin-top:3%">
               <div class="divContainerCell" style="vertical-align:middle;">
                    <asp:Panel ID="pnlFriends" Height="350" ScrollBars="Vertical" runat="server" HorizontalAlign="Center">
                        <asp:Repeater ID="repAccounts" runat="server" OnItemDataBound="repAccounts_ItemDataBound">
                            <ItemTemplate>
                                <uc7:FriendProfile ShowDeleteButton="false" ID="pdProfileDisplay" runat="server"></uc7:FriendProfile>
                            </ItemTemplate>
                        </asp:Repeater>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
