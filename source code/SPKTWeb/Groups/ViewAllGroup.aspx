<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MXH_P.master" CodeBehind="ViewAllGroup.aspx.cs" Inherits="SPKTWeb.Groups.ViewAllGroup" EnableEventValidation="false" %>
<%@ Import Namespace="SPKTCore.Core.Domain" %>
<%@ Register Src="~/UserControl/Comments.ascx" TagName="Comment" TagPrefix="uc2" %>
<%@ Register Src="~/Styles/LEFT_MENU.ascx" TagName="menu" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
</asp:Content>
<asp:Content ID="cont" ContentPlaceHolderID="left" runat="server">
    <div style="margin-top:0px;">
        <uc4:menu ID="menu" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="divMain">
        <div class="divtitle">All Group</div>
     <div class="divContainer">
        <div class="divContainerBox">
        <div class="divContainerRow" style="margin:10px">

                <asp:Label ID="lblMessage" ForeColor="Red" runat="server"></asp:Label>
                
 <asp:ListView id="lvGroups" runat="server" OnItemDataBound="lvGroups_ItemDataBound">
                    <LayoutTemplate>
                        <ul class="groupsList">
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                        </ul>
                    </LayoutTemplate>
                    
                    <ItemTemplate>
                   
                        <div style="width: 100%;">
                            <asp:Literal Visible="false" ID="litImageID" runat="server" Text='<%# ((SPKTCore.Core.Domain.Group)Container.DataItem).FileID %>'></asp:Literal>
                            <asp:Literal ID="litPageName" Visible="false" runat="server" Text='<%# ((SPKTCore.Core.Domain.Group)Container.DataItem).PageName %>'></asp:Literal>
                            <asp:Literal Visible="false" ID="litGroupID" runat="server" Text='<%# ((SPKTCore.Core.Domain.Group)Container.DataItem).GroupID %>'></asp:Literal>
                            <div style="width: 100%;" >
                                <div style="float: left;">
                                    <div style="float: left;">
                                        <div>
                                            <asp:LinkButton OnClick="lbPageName_Click" ID="lbPageName" runat="server" Text='<%# ((SPKTCore.Core.Domain.Group)Container.DataItem).Name %>'></asp:LinkButton>
                                        </div>
                                        <asp:Image ID="imgGroupImage" runat="server" />
                                    </div>
                                    <div>
                                        <br />
                                        <asp:Label ID="lblName" runat="server" Text='<%# ((SPKTCore.Core.Domain.Group)Container.DataItem).Name %>'></asp:Label>
                                        Ngày tạo:<asp:Label ID="Label1" Text='<%# ((SPKTCore.Core.Domain.Group)Container.DataItem).CreateDate %>'
                                            runat="server"></asp:Label><br />
                                        Mô tả:<asp:Label ID="lbl" Text='<%# ((SPKTCore.Core.Domain.Group)Container.DataItem).MemberCount %>'
                                            runat="server"></asp:Label><br />
                                        Số lượng thành viên:<asp:Label ID="Label2" Text='<%# ((SPKTCore.Core.Domain.Group)Container.DataItem).Description %>'
                                            runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div>
                                <uc2:Comment ID="ucComment" runat="server" SystemObjectID="2" SystemObjectRecordID='<%#((SPKTCore.Core.Domain.Group)Container.DataItem).GroupID%>' />
                            </div>
                        
                        
                         </div>
                        <br />
                        <img id="img" alt="kk" src="../../Image/post_entry_bkgr.png" runat="server" style="width: 100%;
                            height: 1px;" />
                        
                    </ItemTemplate>
                   
                    <EmptyDataTemplate>
                        
                    </EmptyDataTemplate>
                </asp:ListView>
               
            </div>
           <%-- <div class="divContainerRow">
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
            </div>--%>
            </div>
        </div>
    </div>
    
    </asp:Content>