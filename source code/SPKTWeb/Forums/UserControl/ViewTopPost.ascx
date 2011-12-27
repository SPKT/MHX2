<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewTopPost.ascx.cs" Inherits="SPKTWeb.Forums.UserControl.ViewTopPost" %>
<!-- Post nhieu nguoi xem nhat -->
<%@ Import Namespace="SPKTCore.Core.Domain"%>
<asp:Repeater ID="repPosts" runat="server">
    <ItemTemplate>
        <div>
             <div>                  
                    <a href='/forums/ViewPost1.aspx?PostID=<%#((BoardPost)Container.DataItem).PostID%>' > <%#((BoardPost)Container.DataItem).Name %></a>
                    <asp:Label id="lblCreateDate" Font-Size="Smaller" runat="server" Text="Ngày tạo:"><%#((BoardPost)Container.DataItem).CreateDate.ToString("dd/MM/yyyy Lúc HH:mm:ss")%></asp:Label>
                                       <div style=" width:60px;">
                    <asp:Label ID="lblViewCount" Text="Tổng lượt xem:" runat="server"> <%#((BoardPost)Container.DataItem).ViewCount.ToString() %></asp:Label>
                </div>
        </div>
    </ItemTemplate>
</asp:Repeater>