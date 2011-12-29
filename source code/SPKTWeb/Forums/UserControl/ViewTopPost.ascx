<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewTopPost.ascx.cs" Inherits="SPKTWeb.Forums.UserControl.ViewTopPost" %>
<!-- Post nhieu nguoi xem nhat -->
<%@ Import Namespace="SPKTCore.Core.Domain"%>
<div class="header" style=" margin-top:10px; color:DarkBlue;">
 
</div>
<asp:Repeater ID="repPosts" runat="server">
    <ItemTemplate>
        <div>
             
             <div>                  
                    <a href='/forums/ViewPost1.aspx?PostID=<%#((BoardPost)Container.DataItem).PostID%>' > <%#((BoardPost)Container.DataItem).Name.ToLower() %></a>
                    <asp:Label id="lblCreateDate" Font-Size="Smaller" runat="server" Text="Ngày tạo:"><%#((BoardPost)Container.DataItem).CreateDate.ToString("dd/MM/yyyy HH:mm:ss")%></asp:Label>
                    Đăng bởi: <asp:HyperLink ID="linkUsername" NavigateUrl='<%# "/" + ((BoardPost)Container.DataItem).Username %>' runat="server" Text=' <%#((BoardPost)Container.DataItem).Username %>'></asp:HyperLink>
                <div style="">
                    <asp:Label ID="lblViewCount" Text="Tổng lượt xem:" runat="server"> <%#((BoardPost)Container.DataItem).ViewCount.ToString() %></asp:Label>
                </div>
                 <img width="100%" alt="k" height="2px" id="img2" src="../../Image/bground2.gif" />
        </div>
    </ItemTemplate>
</asp:Repeater>