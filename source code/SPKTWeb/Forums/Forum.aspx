<%@ Page Title="" Language="C#" MasterPageFile="~/Temp.Master" AutoEventWireup="true" CodeBehind="Forum.aspx.cs" Inherits="SPKTWeb.Forums.Forum" %>
<%@ Import Namespace="SPKTCore.Core.Domain"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
 .divContainer {font-size:12px;background-image:Url('..\Image\bg.png'); background-repeat: repeat-x; padding: 10px; width:100%; margin-left:auto;margin-right:auto;text-align:center; height:auto}
        .divContainerBox {}
        .divContainerRow { float:none; padding:0px; width:100%;   }
        .divContainerCell { display: block;text-align:left; }
        .divContainerFooter { text-align:right; }
        .divContainerTitle {margin-bottom:1px;
                             -moz-border-radius:10px; 
                             -webkit-border-radius:10px;
                             background-color:#cfccff;
                             border-bottom:solid 1px #a3bdef;
                             border-top:solid 1px #5c76a4;
                              font-weight:bold;text-align:left;
                              padding-bottom:5px;padding-top:5px;
                              padding-left:5px;
                              color:Gray;
                              text-align:center;
                             height: 16px;
                             width: 100%;
        }
        .divContainerCellHeader {display:block; height:100%;padding-right:5px; width:150px;text-align:right;font-weight:bold;float:left; }
        .divInnerRowHeader {text-align: right; width: 100px; font-size: 10px; color: #000000; font-weight:bold; float:left; padding-right: 5px; }
        .divInnerRowCell { width: 100%; font-size: 10px; color: #000000; padding-left: 5px; }
        .divContainerHelpText { font-size:10px; color:#777777; font-weight:normal; }
        .divContainerSeparator { border-top:solid 1px #a3bdef; padding-top: 5px; padding-bottom: 5px; }
        .Wizard { width:90%;padding:10px 10px 10px 10px; }
        .Content
        {
            padding: 10px;
            
        }
        #Container
        {
            width=100%;
            height:auto;
            -moz-border-radius:10px; -webkit-border-radius:10px;
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
    
    <div >
    <div class="divContainerTitle">
    Danh mục các forum
    </div>
    
    <div class="main_box" >
        <div id="Container" class="divContainerRow" >
            <asp:Repeater ID="repCategories" runat="server" OnItemDataBound="repCategories_ItemDataBound">
                <HeaderTemplate>
                    <table width="100%" >
                        <tr style="font-weight:bold; color:White;background-image: url('../Image/thanh.JPG');">
                            <td class="Content">Title</td>
                            <td class="Content">Subject</td>
                            <td class="Content">Threads</td>
                            <td class="Content">Posts</td>
                            <td class="Content">Last Post by</td>
                            <td class="Content">Last Post on</td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr style="background-image: url('../Image/thanh.JPG');;font-weight:bold; color:Red">
                        <td class="content"><%# ((BoardCategory)Container.DataItem).Name %></td>
                        <td class="content"><%# ((BoardCategory)Container.DataItem).Subject %></td>
                        <td class="content"><%# ((BoardCategory)Container.DataItem).ThreadCount %></td>
                        <td class="content"><%# ((BoardCategory)Container.DataItem).PostCount %></td>
                        <td class="content"><%# ((BoardCategory)Container.DataItem).LastPostByUsername %></td>
                        <td class="content"><%# ((BoardCategory)Container.DataItem).LastPostDate.ToString() %></td>
                    </tr>
                    <asp:Repeater ID="repForums" runat="server" OnItemDataBound="repForums_ItemDataBound">
                        <ItemTemplate>
                            <tr style="background-image: url('../Image/thanh.JPG'); color:Blue;">
                                <td>
                                    <asp:LinkButton ID="lbForum" runat="server" Text='<%# ((BoardForum)Container.DataItem).Name %>' OnClick="lbForum_Click"></asp:LinkButton>
                                    <asp:Literal ID="litPageName" runat="server" Text='<%# ((BoardForum)Container.DataItem).PageName%>' Visible="false"></asp:Literal>
                                </td>
                                <td  class="content"><%# ((BoardForum)Container.DataItem).Subject%></td>
                                <td  class="content"><%# ((BoardForum)Container.DataItem).ThreadCount%></td>
                                <td  class="content"><%# ((BoardForum)Container.DataItem).PostCount%></td>
                                <td  class="content"><%# ((BoardForum)Container.DataItem).LastPostByUsername%></td>
                                <td  class="content"><%# ((BoardForum)Container.DataItem).LastPostDate.ToString() %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>
</asp:Content>
