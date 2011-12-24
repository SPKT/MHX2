<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_1.Master" AutoEventWireup="true" CodeBehind="ViewForum.aspx.cs" Inherits="SPKTWeb.Forums.ViewForum" %>
<%@ Import Namespace="SPKTCore.Core.Domain"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
 .divContainer {font-size:12px;background-image:Url("..\Image\bg.png"); padding: 10px;width:100%; margin-left:auto;margin-right:auto;text-align:center; }
        .divContainerBox {border:solid 1px #a3bdef; background-color:#ffffff; margin: 3px}
        .divContainerRow { background-color:#ffffff;text-align:left; float:none; padding:5px;}
        .divContainerCell { display: block; text-align:left; }
        .divContainerFooter { text-align:right; }
        .divContainerTitle {margin-bottom:5px;background-color:#d8dfea;border-bottom:solid 1px #a3bdef;border-top:solid 1px #5c76a4; font-weight:bold;text-align:left;padding-bottom:5px;padding-top:5px;padding-left:5px;}
        .divContainerCellHeader {display:block; height:100%;padding-right:5px; text-align:center;font-weight:bold;float:left; font-size:larger; color:Gray }
        .divInnerRowHeader {text-align: right; width: 100px; font-size: 10px; color: #000000; font-weight:bold; float:left; padding-right: 5px; }
        .divInnerRowCell { width: 100%; font-size: 10px; color: #000000; padding-left: 5px; }
        .divContainerHelpText { font-size:10px; color:#777777; font-weight:normal; }
        .divContainerSeparator { border-top:solid 1px #a3bdef; padding-top: 5px; padding-bottom: 5px; }
        .Wizard { width:90%;padding:10px 10px 10px 10px; }
        .left{ float:left; width:25%; border:blue; border-width:1px;}
        .right{float:none;width:70%; margin-left:2%;margin-right:2%;border:blue; border-width:1px;}
        .Header{ font-size:x-large; font-style:oblique; font-weight:bolder; color:Fuchsia}
        .content{ border-color:Fuchsia; border-width:2px;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
    <div  style="background-color:White">
    <div>
        <div style="width:70%; ">
            <asp:Literal ID="litCategoryPageName" runat="server" Visible="false"></asp:Literal>
            <asp:Literal ID="litForumPageName" runat="server" Visible="false"></asp:Literal>
            <table width="100%" cellpadding="5" cellspacing="0">
                        <tr style="background-color:#ccffaa;font-weight:bold;">
                            <td colspan="2">Người tạo</td>
                            <td>Vào ngày</td>
                            <td>Cập nhật</td>
                            <td>Lượt xem</td>
                            <td>Phản hồi</td>
                            <td colspan="1">Cập nhật cuối</td>
                            <td><asp:HyperLink ID="linkNewThread" runat="server" Text="Tạo bài mới"></asp:HyperLink></td>
                        </tr>
            <asp:Repeater ID="repTopics" runat="server" OnItemDataBound="repTopics_ItemDataBound">
                <ItemTemplate>
                        <tr style="background-color:#ffffff;">
                            <td colspan="8">
                                <a href="ViewForum1.aspx"><%#((BoardPost)Container.DataItem).Name %></a>
                                <asp:HyperLink ID="linkViewTopic" runat="server" Text='<%#((BoardPost)Container.DataItem).Name %>'></asp:HyperLink>
                            </td>
                        </tr>
                        <tr style="background-color:#ffffff;">
                            <td><asp:HyperLink ID="linkUsername1" runat="server" Text='<%#((BoardPost)Container.DataItem).Username %>' NavigateUrl='<%# "/" + ((BoardPost)Container.DataItem).Username %>'></asp:HyperLink></td>
                            <td><asp:Image Width="100" Height="100" ID="Image2" ImageUrl='<%# "/image/ProfileAvatar.aspx?AccountID=" + ((BoardPost)Container.DataItem).AccountID %>' runat="server" /></td>
                            <td><%#((BoardPost)Container.DataItem).CreateDate.ToShortDateString() %></td>
                            <td><%#((BoardPost)Container.DataItem).UpdateDate.ToShortDateString() %></td>
                            <td><%#((BoardPost)Container.DataItem).ViewCount %></td>
                            <td><%#((BoardPost)Container.DataItem).ReplyCount %></td>
                            <td><asp:HyperLink ID="linkReplyUsername" runat="server" Text='<%#((BoardPost)Container.DataItem).ReplyByUsername %>' NavigateUrl=' <%# "/" + ((BoardPost)Container.DataItem).ReplyByUsername %>'></asp:HyperLink></td>
                        </tr>

                </ItemTemplate>
<%--                <AlternatingItemTemplate>
                        <tr style="background-color:#ffffff;">
                            <td colspan="8">
                                <asp:HyperLink ID="linkViewTopic" runat="server" Text='<%#((BoardPost)Container.DataItem).Name %>'></asp:HyperLink>
                            </td>
                        </tr>
                        <tr style="background-color:#ffffff;">
                            <td><asp:HyperLink ID="linkUsername" runat="server" Text='<%#((BoardPost)Container.DataItem).Username %>' NavigateUrl='<%# "~/" + ((BoardPost)Container.DataItem).Username %>'></asp:HyperLink></td>
                            <td><asp:Image Width="100" Height="100" ID="Image2" ImageUrl='<%# "/Image/ProfileAvatar.aspx?AccountID=" + ((BoardPost)Container.DataItem).AccountID %>' runat="server" /></td>
                            <td><%#((BoardPost)Container.DataItem).CreateDate.ToShortDateString()%></td>
                            <td><%#((BoardPost)Container.DataItem).UpdateDate.ToShortDateString()%></td>
                            <td><%#((BoardPost)Container.DataItem).ViewCount %></td>
                            <td><%#((BoardPost)Container.DataItem).ReplyCount %></td>
                            <td><asp:HyperLink ID="linkReplyUsername" runat="server" Text='<%#((BoardPost)Container.DataItem).ReplyByUsername %>' NavigateUrl=' <%# "~/" + ((BoardPost)Container.DataItem).ReplyByUsername %>'></asp:HyperLink></td>
                            
                        </tr>
                </AlternatingItemTemplate>--%>
            </asp:Repeater>
            </table>
        </div>
    </div>
</div>
</asp:Content>

