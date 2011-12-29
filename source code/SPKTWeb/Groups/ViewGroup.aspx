<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MXH_PE.master" CodeBehind="ViewGroup.aspx.cs" Inherits="SPKTWeb.Groups.ViewGroup" %>
<%@ Import Namespace="SPKTCore.Core.Domain"%>
<%@ Register src="UserControl/GroupForumUC.ascx" tagname="GroupForumUC" tagprefix="uc1" %>
<%@ Register Src="~/Styles/LEFT_MENU.ascx" TagName="menu" TagPrefix="uc4" %>

<%@ Register src="UserControl/GroupHeader.ascx" tagname="GroupHeader" tagprefix="uc2" %>

<%@ Register src="UserControl/ViewMemberUC.ascx" tagname="ViewMemberUC" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
            .divMain
            {
                width:100%;
                height: auto;
                background-color:#CCFFCC;
            }
            .divContainer
            {
               margin: 5px;
               width:80%;
               float:left;
            }
            .divContainerunder
            {
            
               width:17%;
               float:left;
               border-color: Blue;
            }
            .divtitle
            {
                color: Gray;
                font-size:x-large;
                text-align:center;
            }
            .divForum
            {
                float:right;
                <%--width:75%;--%>
            }
        .divContainerCell { display: block; text-align:left; }
        .divContainerFooter { text-align:right; }
        .divContainerTitle {margin-bottom:5px;background-color:#d8dfea;color:Teal;border-bottom:solid 1px #a3bdef;border-top:solid 1px #5c76a4; font-weight:bold;text-align:left;padding-bottom:5px;padding-top:5px;padding-left:5px;}
        .divContainerCellHeader {display:block; height:100%;padding-right:5px; width:150px;text-align:right;font-weight:bold;float:left; }
        .divInnerRowHeader {text-align: right; width: 100px; font-size: 10px; color: #000000; font-weight:bold; float:left; padding-right: 5px; }
        .divInnerRowCell { width: 100%; font-size: 10px; color: #000000; padding-left: 5px; }
        .divContainerHelpText { font-size:10px; color:#777777; font-weight:normal; }
        .divContainerSeparator { border-top:solid 1px #a3bdef; padding-top: 5px; padding-bottom: 5px; }
        .Wizard { width:90%;padding:10px 10px 10px 10px; }
        .divContainerBox {border:solid 1px #ffffff; background-color:#ffffff;}
        .style1
        {
            color: #FF6666;
            font-size: x-large;
            text-align: center;
        }
        .divContent{margin:5px;}
    </style>
</asp:Content>
<asp:Content ID="cont" ContentPlaceHolderID="left" runat="server">
    <div style="margin-top:0px;">
        <uc4:menu ID="menu" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
<div style="width:100%; height:100%;"> 
<asp:Panel ID="pnlHeader" runat="server" BorderStyle="None">
    <uc2:GroupHeader ID="UCGroupHeader" runat="server" />
    </asp:Panel>
</div>
    <div style="width:100%; height:100%; float:left">
    <div style="width:20%; height:100%; margin:0px; float:left">
    <asp:Panel ID="pnlMember" runat="server">
        <uc3:ViewMemberUC ID="ViewMemberUC" runat="server" />
        </asp:Panel>
    </div>
    <div style="width:78%; height:100%; margin:0px; margin-left:21%">
    <asp:Panel ID="pnlForum" runat="server">
        <uc1:GroupForumUC ID="uc" runat="server" />
        </asp:Panel>
    </div>
    </div>
    </asp:Content>