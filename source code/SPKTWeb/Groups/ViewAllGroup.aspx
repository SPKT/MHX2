<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAllGroup.aspx.cs" Inherits="SPKTWeb.Groups.ViewAllGroup" %>
<%@ Import Namespace="SPKTCore.Core.Domain" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <style type="text/css">
            .divMain
            {
                width:600px;
                height: auto;
                background-color:#CCFFCC;
                border-color: Blue;
            }
            .divContainer
            {
               margin: 5px;
            }
            .divtitle
            {
                color: Gray;
                font-size:x-large;
                text-align:center;
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
        <div class="divtitle">All Group</div>
     <div class="divContainer">
        <div class="divContainerBox">
            <div class="divContainerRow">
                <table cellpadding="0" cellspacing="0" width="100%"><tr><td>
                <asp:Label ID="lblMessage" ForeColor="Red" runat="server"></asp:Label>
                <asp:ListView id="lvGroups" runat="server" OnItemDataBound="lvGroups_ItemDataBound">
                    <LayoutTemplate>
                        <ul class="groupsList">
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                        </ul>
                    </LayoutTemplate>
                    
                    <ItemTemplate>
                        <li class="divContent">
                            <asp:Literal Visible="false" ID="litImageID" runat="server" Text='<%# ((SPKTCore.Core.Domain.Group)Container.DataItem).FileID %>'></asp:Literal>
                            <asp:Literal ID="litPageName" Visible="false" runat="server" Text='<%# ((SPKTCore.Core.Domain.Group)Container.DataItem).PageName %>'></asp:Literal>
                            <asp:LinkButton OnClick="lbPageName_Click" id="lbPageName" runat="server" Text='<%# ((SPKTCore.Core.Domain.Group)Container.DataItem).Name %>'></asp:LinkButton>
                            <asp:Image ID="imgGroupImage" runat="server" />
                            <asp:Label ID="lblName" runat="server" Text='<%# ((SPKTCore.Core.Domain.Group)Container.DataItem).Name %>'></asp:Label>
                        </li>
                    </ItemTemplate>
                    
                    <EmptyDataTemplate>
                        
                    </EmptyDataTemplate>
                </asp:ListView>
                </td></tr></table>
            </div>
        </div>
    </div>
    </div>
    </form>
</body>
</html>
