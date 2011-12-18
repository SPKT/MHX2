<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Friend.ascx.cs" Inherits="SPKTWeb.Friends.UserControl.Friend" %>
<style type="text/css">
        span.link {
        position: relative;
        }
 
        span.link a span {
        display: none;
        }
 
        span.link a:hover {
        font-size: 99%;
        color: #000000;
        }
 
        span.link a:hover span {
        display: block;
        position: absolute;
        margin-top: 2px;
        margin-left: -10px;
        width: 75px; padding: 2px;
        z-index: 100;
        color: #000000;
        background: #FFFFAA;
        font: 12px "Arial", sans-serif;
        text-align: left;
        text-decoration: none;
        }
 </style>
<div align="center" style="width: 100%;">
    <div style="width: 30px; height: 30px;">
        <asp:Image ID="Image1" runat="server" Width="30px" Height="30px"/>
        <span class="link">
        <a href="javascript: void(0)">
        <span>trợ giúp</span>
        </a>
        </span>
    </div>
    <div>
        <asp:Label ID="name" runat="server" Font-Size="8px" ForeColor="#333333"></asp:Label>
        <asp:Label ID="Label1" runat="server" Font-Size="8px" Text="Label" 
            Visible="False"></asp:Label>
    </div>
</div>
