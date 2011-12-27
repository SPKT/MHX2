<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_E.Master" AutoEventWireup="true" CodeBehind="AllForum.aspx.cs" Inherits="SPKTWeb.Forums.AllForum" EnableEventValidation="false" %>
<%@ Import Namespace="SPKTCore.Core.Domain"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <style type="text/css">
 .divContainer {font-size:12px;background-image:Url('..\Image\bg.png'); background-repeat: repeat-x; padding: 10px; width:94%; margin-left:2%;margin-right:3%;text-align:center; height:auto}
        .divContainerBox {}
        .divContainerRow { float:none; padding:0px; width:94%;   }
        .divContainerCell { display: block;text-align:left; }
        .divContainerFooter { text-align:right; }
        .divContainerTitle {margin-bottom:1px;
                             -moz-border-radius:10px; 
                             -webkit-border-radius:10px;
                             margin-right:2%;
                             margin-left:2%;
                             background-image:Url('..\Image\lista.png');
                             border-bottom:solid 1px #a3bdef;
                             border-top:solid 1px #5c76a4;
                              font-weight:bold;text-align:left;
                              padding-bottom:5px;padding-top:5px;
                              padding-left:5px;
                              color:Orange;
                              text-align:center;
                             height: 24px;
                             width: 94%;
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
            background-image: url('../Image/thanhtren.gif'); background-repeat:repeat-x;
        }
        #Container
        { margin-right:3%;
           margin-left:2%; width: 90%;
            height:auto;
            -moz-border-radius:10px; -webkit-border-radius:10px;
            border-color:#666666;
            border-style:solid;
            border-width:1px;
            margin-top:-2px;
            padding-left:4%;
            padding-bottom:20px;
            background-image:url('../Image/bo5.gif'); background-repeat:repeat-x;
            padding-top:0px;
           
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
    
    <div  style="width:100%; height:100%; padding-top:30px;">
    <div class="divContainerTitle" align="center" 
            style="background-image: url('../Image/pro_15_0.gif'); background-repeat: repeat-x">
    Danh mục các forum
    </div>
    
    <div>
        <div id="Container" class="divContainerRow" >
            <asp:Repeater ID="repCategories" runat="server" OnItemDataBound="repCategories_ItemDataBound">
                <HeaderTemplate>
                    <table width="98%"  style="margin-right:20px;" >
                        <tr style="font-weight:bold; color:Gray; vertical-align:middle;background-image: url('../Image/thanhtren1.gif.png'); margin-top:2px; margin-bottom:2px; margin:0px; background-repeat:repeat-x;">
                            <td class="Content">Title</td>
                            <td class="Content">Subject</td>
                            <td class="Content">Threads</td>
                            <td class="Content">Posts</td>
                            <td class="Content">Last Post by</td>
                            <td class="Content">Last Post on</td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr style="background-image: url('../Image/thanhtren.gif');font-weight:bold; color:Red">
                        <td class="content"><%# ((BoardCategory)Container.DataItem).Name %></td>
                        <td class="content"><%# ((BoardCategory)Container.DataItem).Subject %></td>
                        <td class="content"><%# ((BoardCategory)Container.DataItem).ThreadCount %></td>
                        <td class="content"><%# ((BoardCategory)Container.DataItem).PostCount %></td>
                        <td class="content"><%# ((BoardCategory)Container.DataItem).LastPostByUsername %></td>
                        <td class="content"><%# ((BoardCategory)Container.DataItem).LastPostDate.ToString() %></td>
                    </tr>
                    <asp:Repeater ID="repForums" runat="server" OnItemDataBound="repForums_ItemDataBound">
                        <ItemTemplate>
                            <tr style=" color:Blue;">
                                <td>
                                <a href='/Forums/ViewForum1.aspx?ForumID=<%#((BoardForum)Container.DataItem).ForumID %>' ><%#((BoardForum)Container.DataItem).Name %></a>                                    
                                    <asp:Literal ID="litPageName" runat="server" Text='<%# ((BoardForum)Container.DataItem).PageName%>' Visible="false"></asp:Literal>
                                </td>
                                <td  class="content"><%# ((BoardForum)Container.DataItem).Subject%></td>
                                <td  class="content"><%# ((BoardForum)Container.DataItem).ThreadCount%></td>
                                <td  class="content"><%# ((BoardForum)Container.DataItem).PostCount%></td>
                                <td  class="content"><%# ((BoardForum)Container.DataItem).LastPostByUsername%></td>
                                <td  class="content">
                                <%# ((BoardForum)Container.DataItem).LastPostDate.ToString() %>
                                 <asp:ImageButton Width="20px" Height="20px" ID="ibEdit" OnClick="EditButton_Click" runat="server" ImageUrl="~/image/pencil.jpg" />
                                </td>
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
<asp:Content ID="Content4" ContentPlaceHolderID="right1" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="right" runat="server">
</asp:Content>
