<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MXH_PE.master"  CodeBehind="ViewGroupForumPost.aspx.cs" Inherits="SPKTWeb.Groups.ViewGroupForumPost" %>

<%@ Register src="UserControl/GroupHeader.ascx" tagname="GroupHeader" tagprefix="uc1" %>
<%@ Register src="UserControl/ViewMemberUC.ascx" tagname="ViewMemberUC" tagprefix="uc2" %>
<%@ Register src="UserControl/ViewPostUC.ascx" tagname="ViewPostUC" tagprefix="uc3" %>

<%@ Register Src="~/Styles/LEFT_MENU.ascx" TagName="menu" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
            .divMain
            {
                width:100%;
                height: auto;
                background-color:#CCFFCC;
                border-color: Blue;
            }
            .divContainer
            {
               margin: 5px;
               width:80%;
               float:left;
            }
           .divContainerUC
            {
               
               width:100%;
               float:left;
            }
            .divContainerunder
            {
            
               width:20%;
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
        .divContainerBox {border:solid ; background-color:#ffffff; width:100%}
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
    <div class="divMain">

    <div class="divContainer">
        <div class="divContainerBox"; style=" border-width:0px;">
          <asp:Panel ID="pnlHeader" runat="server" BorderStyle="None">
            <uc1:GroupHeader ID="GroupHeaderUC" runat="server" />
          </asp:Panel>
        </div>
        <div class="divContainerunder">
        <asp:Panel ID="pnlMember" runat="server">
            <uc2:ViewMemberUC ID="ViewMemberUC" runat="server" />
        </asp:Panel>
        </div>
        <div style="float: right; width: 80%">
         <asp:Panel ID="pnlForum" runat="server" Width="100%">
             <uc3:ViewPostUC ID="ViewPostUC" runat="server" />           
        </asp:Panel>

        </div>
    </div>

    </div>
    </asp:Content>
