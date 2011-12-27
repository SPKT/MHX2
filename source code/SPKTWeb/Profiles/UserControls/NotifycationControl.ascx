<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NotifycationControl.ascx.cs" Inherits="SPKTWeb.Profiles.UserControls.NotifycationControl" %>
<%@ Import Namespace="SPKTCore.Core.Domain" %>

<div class="divContainer" id="com" style="border: 1px solid #999999; width: 621px;
    -moz-border-radius: 5px; -webkit-border-radius: 5px; background-color: White;">
    <div class="divContainerBox">
        <div style="width: 621px; background-image: url('/Image/bground1.gif'); background-repeat: repeat-x;
            height: 22px;">
        </div>
        <div class="divContainerTitle" style="border: 0px none #000066; font-family: 'Times New Roman', Times, serif;
            font-weight: bold; color: #3366FF; width: 621px; height: 33px; background-image: url('/Image/thead.gif');
            font-size: 22px; background-repeat: repeat-x;" align="center">
            Notifications<br />
        </div>
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
        
        <div class="divContainerRow">
            <div class="divContainerCell" style="border: thin none #000066; width: 621px; height: 42px;
                background-color: #CCCCCC; font-size: 11px; background-image: url('/Image/page_top_bkgr.gif');">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblMessage" runat="server" ForeColor="Maroon"></asp:Label><br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:HyperLink ID="hlkViewAll" NavigateUrl="/Profiles/ViewAllNotifycation.aspx" runat="server" Font-Size="Large">Tất cả</asp:HyperLink>
                <br />

                <br />
            </div>
        </div>
    </div>
</div>
