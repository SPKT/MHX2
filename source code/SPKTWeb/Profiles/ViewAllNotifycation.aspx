<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_PE.Master" AutoEventWireup="true" CodeBehind="ViewAllNotifycation.aspx.cs" Inherits="SPKTWeb.Profiles.ViewAllNotifycation" %>
<%@ Import Namespace="SPKTCore.Core.Domain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
<div>
    <div>
        Danh sách Notifycation!
        <div >
        <asp:Label ID="lblMessage" Visible="false" runat="server"></asp:Label>
        </div>
    </div>
    <div>
       <asp:Panel ID="pnlNotify" runat="server">
            <asp:Repeater ID="repNotify" runat="server">
                <ItemTemplate>
                    <div>
                        <asp:Label ID="lblBody" runat="server" Text='<%#((Notification)Container.DataItem).Body %>'>
                        </asp:Label>
                        <img id="img" alt="kk" src="/Image/post_entry_bkgr.png" runat="server" style="width:100%; height:1px;" />
                    </div>
                </ItemTemplate>
                
            </asp:Repeater>
        </asp:Panel>
    </div>
</div>
</asp:Content>
