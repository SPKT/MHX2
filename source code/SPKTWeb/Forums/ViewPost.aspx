<%@ Page Title="" Language="C#" MasterPageFile="~/Temp.Master" AutoEventWireup="true" CodeBehind="ViewPost.aspx.cs" Inherits="SPKTWeb.Forums.ViewPost" %>
<%@ Import Namespace="SPKTCore.Core.Domain"%>
<asp:Content ID="Content6" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
 .divContainer {font-size:12px;background-image:Url("..\Image\bg.png");background-color:Gray;background-repeat: repeat-x; padding: 10px; width:90%; margin-left:auto;margin-right:auto;text-align:center; }
        .divContainerBox {border:solid 1px #a3bdef; background-color:#ffffff;  margin: 3px;}
        .divContainerRow { background-color:#ffffff;text-align:left; float:none; padding:5px;}
        .divContainerCell { display: block; text-align:left; }
        .divContainerFooter { text-align:right; }
        .divContainerTitle {margin-bottom:5px;background-color:#d8dfea;border-bottom:solid 1px #a3bdef;border-top:solid 1px #5c76a4; font-weight:bold;text-align:left;padding-bottom:5px;padding-top:5px;padding-left:5px;}
        .divContainerCellHeader {display:block; height:100%;padding-right:5px; width:150px;text-align:right;font-weight:bold;float:left; }
        .divInnerRowHeader {text-align: right; width: 100px; font-size: 10px; color: #000000; font-weight:bold; float:left; padding-right: 5px; }
        .divInnerRowCell { width: 100%; font-size: 10px; color: #000000; padding-left: 5px; }
        .divContainerHelpText { font-size:10px; color:#777777; font-weight:normal; }
        .divContainerSeparator { border-top:solid 1px #a3bdef; padding-top: 5px; padding-bottom: 5px; }
        .Wizard { width:90%;padding:10px 10px 10px 10px; }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
 <div class="divContainer">
        <div class="divContainerBox">
            <div class="divContainerRow">
                <table cellpadding="5" cellspacing="0" width="100%">
                    <tr>
                        <td colspan="5" valign="top" style="font-weight:bold;font-size:16px;"><asp:Label ID="lblSubject" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td rowspan="2" valign="top" style="width:100px;"><asp:Image Width="100" Height="100" ID="imgProfile" runat="server" /></td>
                        <td style="height:12px;">by: <asp:HyperLink ID="linkUsername" runat="server"></asp:HyperLink></td>
                        <td>on: <asp:Label ID="lblCreateDate" runat="server"></asp:Label></td>
                        <td>updated: <asp:Label ID="lblUpdateDate" runat="server"></asp:Label></td>
                        <td><asp:HyperLink ID="linkReply" Text="Reply" runat="server"></asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td colspan="4" valign="top"><asp:Label ID="lblDescription" runat="server"></asp:Label></td>
                    </tr>
                    <asp:Repeater ID="repPosts" runat="server" OnItemDataBound="repPosts_ItemDataBound">
                        <ItemTemplate>
                            <tr style="background-color:#dddddd;">
                                <td colspan="5" style="font-weight:bold;font-size:16px;">
                                    <asp:Label ID="lblSubject" runat="server" Text='<%#((BoardPost)Container.DataItem).Name%>'></asp:Label>
                                </td>
                            </tr>
                            <tr style="background-color:#dddddd;">
                                <td rowspan="2" valign="top" style="width:100px;"><asp:Image Width="100" Height="100" ID="imgProfile" runat="server" ImageUrl='<%# "/image/ProfileAvatar.aspx?AccountID=" + ((BoardPost)Container.DataItem).AccountID %>' /></td>
                                <td style="height:12px;">by: <asp:HyperLink ID="linkUsername" NavigateUrl='<%# "/" + ((BoardPost)Container.DataItem).Username %>' runat="server" Text='<%#((BoardPost)Container.DataItem).Username %>'></asp:HyperLink></td>
                                <td>on: <asp:Label ID="lblCreateDate" runat="server" Text='<%#((BoardPost)Container.DataItem).CreateDate.ToShortDateString() %>'></asp:Label></td>
                                <td>updated: <asp:Label ID="lblUpdateDate" runat="server" Text='<%#((BoardPost)Container.DataItem).UpdateDate.ToShortDateString() %>'></asp:Label></td>
                                <td><asp:HyperLink runat="server" ID="linkReply" NavigateUrl='<%# "/forums/post.aspx?postID=" + ((BoardPost)Container.DataItem).PostID %>' Text="Reply"></asp:HyperLink></td>
                            </tr>
                            <tr style="background-color:#dddddd;">
                                <td colspan="4" valign="top"><asp:Label ID="lblDescription" runat="server" Text='<%#((BoardPost)Container.DataItem).Post%>'></asp:Label></td>
                            </tr>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <tr>
                                <td colspan="5" valign="top" style="font-weight:bold;font-size:16px;">
                                    <asp:Label ID="lblSubject" runat="server" Text='<%#((BoardPost)Container.DataItem).Name %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="2" valign="top" style="width:100px;"><asp:Image Width="100" Height="100" ID="imgProfile" runat="server" ImageUrl='<%# "/image/ProfileAvatar.aspx?AccountID=" + ((BoardPost)Container.DataItem).AccountID %>' /></td>
                                <td style="height:12px;">by: <asp:HyperLink ID="linkUsername" NavigateUrl='<%# "/" + ((BoardPost)Container.DataItem).Username %>' runat="server" Text='<%#((BoardPost)Container.DataItem).Username %>'></asp:HyperLink></td>
                                <td>on: <asp:Label ID="lblCreateDate" runat="server" Text='<%#((BoardPost)Container.DataItem).CreateDate.ToShortDateString() %>'></asp:Label></td>
                                <td>updated: <asp:Label ID="lblUpdateDate" runat="server" Text='<%#((BoardPost)Container.DataItem).UpdateDate.ToShortDateString() %>'></asp:Label></td>
                                <td><asp:HyperLink runat="server" ID="linkReply" NavigateUrl='<%# "/forums/post.aspx?postID=" + ((BoardPost)Container.DataItem).PostID %>' Text="Reply"></asp:HyperLink></td>
                            </tr>
                            <tr>
                                <td colspan="4" valign="top"><asp:Label ID="lblDescription" runat="server" Text='<%#((BoardPost)Container.DataItem).Post %>'></asp:Label></td>
                            </tr>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

