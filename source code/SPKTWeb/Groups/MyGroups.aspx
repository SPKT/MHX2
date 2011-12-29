<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MXH_PE.master" CodeBehind="MyGroups.aspx.cs" Inherits="SPKTWeb.Groups.MyGroups" EnableEventValidation="false" %>

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
        .accordionHeader
        {
            border: 1px solid #2F4F4F;
            color: white;
            background-color: #5078B3;
            font-family: Arial, Sans-Serif;
            font-size: 12px;
            font-weight: bold;
            padding: 5px;
            margin-top: 5px;
            cursor: pointer;
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
        .divContent{margin:5px;}
    </style>
</asp:Content>
<asp:Content ID="cont" ContentPlaceHolderID="left" runat="server">
    <div style="margin-top:0px;">
        <uc4:menu ID="menu" runat="server" />
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div >
    <div align="left" class="Main_Subject">
             <asp:Label ID="lb" runat="server" Width="100%" Height="100%" Text="Group của bạn"></asp:Label>
         </div>
        <div style="background-color: #CCCCCC; width: 100%; height: 2px; margin-bottom: 0px;">
        </div>
                <asp:Label ID="lblMessage" ForeColor="Red" runat="server"></asp:Label>
                
 <asp:ListView id="lvGroups" runat="server" OnItemDataBound="lvGroups_ItemDataBound">
               
                    
                    <ItemTemplate>
                   
                   <div style="width:100%;">
                     
                            <asp:Literal Visible="false" ID="litImageID" runat="server" Text='<%# ((SPKTCore.Core.Domain.Group)Container.DataItem).FileID %>'></asp:Literal>
                            <asp:Literal ID="litPageName" Visible="false" runat="server" Text='<%# ((SPKTCore.Core.Domain.Group)Container.DataItem).PageName %>'></asp:Literal>
                            <div style="padding-left:20px;">
                                <div style="float:left;">
                                    <div style="float:left; width:80px; height:80px;">
                                        <div class="Sub_Link">
                                        <asp:LinkButton OnClick="lbPageName_Click" id="lbPageName" runat="server" Text='<%# ((SPKTCore.Core.Domain.Group)Container.DataItem).Name %>'></asp:LinkButton>
                                        </div>
                                        <div style="width:60px; height:60px">
                                        <asp:Image ID="imgGroupImage" Width="100%" Height="100%"  runat="server" />
                                        </div>
                                    </div>
                                    <div style="margin-left:100px; margin-right:50px; font-family:Times New Roman; font-style:italic; color:Gray;">
                                        <br />
                                        Ngày tạo:<asp:Label  Font-Italic="true" ID="Label1" Text='<%# ((SPKTCore.Core.Domain.Group)Container.DataItem).CreateDate %>' runat="server"></asp:Label><br />
                                        Mô tả:<asp:Label ID="lbl"  ForeColor="Maroon" Text='<%# ((SPKTCore.Core.Domain.Group)Container.DataItem).Description %>' runat="server"></asp:Label><br />
                                        Số lượng thành viên:<asp:Label ID="Label2" ForeColor="Blue" Text='<%# ((SPKTCore.Core.Domain.Group)Container.DataItem).MemberCount %>' runat="server"></asp:Label>
                                    </div>
                                </div>
                                
                                <div style="text-align:right; padding-right:50px; vertical-align:middle;"><asp:ImageButton Width="20px" Height="20px" ID="ibDelete" OnClick="ibDelete_Click" runat="server" ImageUrl="~/image/icon_close.gif" />
                                <asp:ImageButton Width="20px" Height="20px" ID="ibEdit" OnClick="ibEdit_Click" runat="server" ImageUrl="~/image/pencil.jpg" />
                                </div>
                            </div>  
                         <asp:Literal Visible="false" ID="litGroupID" runat="server" Text='<%# ((SPKTCore.Core.Domain.Group)Container.DataItem).GroupID %>'></asp:Literal>
                        </div>
                        <br />
                        <img id="img" alt="kk" src="../../Image/post_entry_bkgr.png" runat="server" style="width:100%; height:1px;" />
                        
                       </div>
                    </ItemTemplate>
                    
                    <EmptyDataTemplate>
                        
                    </EmptyDataTemplate>
                </asp:ListView>
               
            
    </div>
    </asp:Content>

