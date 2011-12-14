<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupForumUC.ascx.cs" Inherits="SPKTWeb.Groups.UserControl.GroupForumUC" %>
<%@ Import Namespace="SPKTCore.Core.Domain"%>
<div  style="background-color:white">
    <div>
        <div>
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