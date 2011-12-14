<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostGroupforum.aspx.cs" Inherits="SPKTWeb.Groups.PostGroupforum" %>
<%@ Register src="UserControl/GroupHeader.ascx" tagname="GroupHeader" tagprefix="uc1" %>
<%@ Register src="UserControl/ViewMemberUC.ascx" tagname="ViewMemberUC" tagprefix="uc2" %>

<%@ Register src="UserControl/Post.ascx" tagname="Post" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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
        .divContainerBox {border:solid 1px #a3bdef; background-color:#ffffff;}
        .style1
        {
            color: #FF6666;
            font-size: x-large;
            text-align: center;
        }
        .divContent{margin:5px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="divMain">

    <div class="divContainer">
        <div class="divContainerBox">
          <asp:Panel ID="pnlHeader" runat="server">
            <uc1:GroupHeader ID="GroupHeaderUC" runat="server" />
          </asp:Panel>
        </div>
        <div class="divContainerunder">
        <asp:Panel ID="pnlMember" runat="server">
            <uc2:ViewMemberUC ID="ViewMemberUC" runat="server" />
        </asp:Panel>
        </div>
        <div style="float: right; width: 80%">
         <asp:Panel ID="pnlForum" runat="server">
             <uc3:Post ID="Post1" runat="server" />
                     
        </asp:Panel>

        </div>
    </div>

    <div class="divForum">
        Danh sách các forum của group
    </div>
    </div>
    </form>
</body>
</html>
