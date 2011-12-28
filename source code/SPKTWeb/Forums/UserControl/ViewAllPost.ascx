<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewAllPost.ascx.cs"
    Inherits="SPKTWeb.Forums.UserControl.ViewAllPost" %>
<%@ Import Namespace="SPKTCore.Core.Domain" %>
<style type="text/css">
    .style1
    {
        width: 100%;
        padding-left: 2%;
    }
    .style2
    {
        width: 419px;
        padding-left: 2%;
    }
    .style3
    {
        width: 90px;
        text-align: center;
    }
    .style4
    {
        width: 90px;
        text-align: center;
    }
    .style5
    {
        width: 157px;
    }
    .style6
    {
        width: 162px;
    }
</style>
<div style="width: 100%; height: 100%;">
    <asp:Literal ID="litCategoryPageName" runat="server" Visible="false"></asp:Literal>
    <asp:Literal ID="litForumPageName" runat="server" Visible="false"></asp:Literal>
    <br />
    <div style="background-image: url('/Image/2g.gif'); background-repeat: repeat-x;
        margin-bottom: 10px;">
        <table class="Subject" style="border-width: 0px 2px 0px 2px; border-style: solid;
            border-color: #CCCCCC; text-indent: 0px;" cellspacing="0px">
            <tr style="border-color: Blue;">
                <td class="style2">
                    Tiêu đề
                </td>
                <td class="style3">
                    Lượt xem
                </td>
                <td class="style4">
                    Phản hồi
                </td>
                <td class="style5">
                    Cập nhật cuối
                </td>
                <td id="tdAdmin" runat="server" class="style6">
                    Quản lý
                </td>
            </tr>
            <asp:Repeater ID="repTopics" runat="server">
                <ItemTemplate>
                    <tr style="border-style: solid; margin: 0px; border-width: 1px 1px 2px 1px; border-color: #CCCCCC;
                        width: 100%; height: 100px; background-color: #CCCCCC; background-image: url('../../Image/2i.gif');
                        background-repeat: repeat-x;">
                        <td class="style2">
                            <div>
                                <div style="float: left; width: 20%; height: 10%">
                                    <a id="linkUsername1" class="Sub_Link" runat="server" href='<%#"/"+((BoardPost)Container.DataItem).Username %>'>
                                        <%#((BoardPost)Container.DataItem).Username %></a>
                                    <br />
                                    <asp:Image Width="90%" Height="80%" ID="Image2" ImageUrl='<%# "/image/ProfileAvatar.aspx?AccountID=" + ((BoardPost)Container.DataItem).AccountID %>'
                                        runat="server" />
                                </div>
                                <div style="margin-top: 20px; margin-left: 22%; font-size: larger; color: Blue;">
                                    <a class="Sub_Link1" href='/forums/ViewPost1.aspx?PostID=<%#((BoardPost)Container.DataItem).PostID%>'>
                                        <%#((BoardPost)Container.DataItem).Name %></a>
                                    <br />
                                    <asp:Label ID="lblCreateDate" CssClass="Subject" runat="server" Font-Italic="true" Text="Ngày tạo:"><%#((BoardPost)Container.DataItem).CreateDate.ToString("dd/MM/yyyy Lúc HH:mm:ss")%></asp:Label>
                                </div>
                            </div>
                        </td>
                        <td class="style3">
                            <%#((BoardPost)Container.DataItem).ViewCount %>
                        </td>
                        <td class="style4">
                            <%#((BoardPost)Container.DataItem).ReplyCount %>
                        </td>
                        <td>
                            <a id="linkReplyUsername" class="Sub_Link" runat="server" href=' <%# "/" + ((BoardPost)Container.DataItem).ReplyByUsername %>'>
                                <%#((BoardPost)Container.DataItem).ReplyByUsername %></a>
                        </td>
                        <td id="tdAdmin">
                            <asp:ImageButton Width="20px" Height="20px" ID="ibDelete" runat="server" ImageUrl="/image/icon_close.gif" />
                            <asp:ImageButton Width="20px" Height="20px" ID="ibEdit" runat="server" ImageUrl="/image/pencil.jpg" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</div>
