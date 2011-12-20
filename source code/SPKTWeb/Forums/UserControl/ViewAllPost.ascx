<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewAllPost.ascx.cs" Inherits="SPKTWeb.Forums.UserControl.ViewAllPost" %>
<%@ Import Namespace="SPKTCore.Core.Domain"%>
  <style type="text/css">
      .style1
      {
          width: 100%;
      }
      .style2
      {
          width: 419px;
          text-align:center;
      }
      .style3
      {
          width: 90px;
          text-align:center;
      }
      .style4
      {
          width: 90px;
          text-align:center;
      }
  </style>
  <div style=" ">
            <asp:Literal ID="litCategoryPageName" runat="server" Visible="false"></asp:Literal>
            <asp:Literal ID="litForumPageName" runat="server" Visible="false"></asp:Literal>
            
            <br />
            <div>
                
                <table class="style1">
                    <tr style="border-color:Blue; background-color:Menu">
                        <td class="style2">
                            Tiêu đề</td>
                        <td class="style3">
                            Lượt xem</td>
                        <td class="style4">
                            Phản hồi</td>
                        <td>
                            Cập nhật cuối</td>
                    </tr>
              <asp:Repeater ID="repTopics" runat="server" OnItemDataBound="repTopics_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td class="style2">
                            <div>
                                <div style="float:left; width:60px;">
                               <a ID="linkUsername1"  runat="server"  href='<%#"/"+((BoardPost)Container.DataItem).Username %>' ><%#((BoardPost)Container.DataItem).Username %></a>
                               <br />
                               <asp:Image Width="50" Height="50" ID="Image2" ImageUrl='<%# "/image/ProfileAvatar.aspx?AccountID=" + ((BoardPost)Container.DataItem).AccountID %>' runat="server" />
                               </div>
                               <div style="margin-top:20px; margin-left:20px; font-size:larger; color:Blue;">
                               <a ID="linkViewTopic" runat="server" href='/Forums/ViewPost.aspx' ><%#((BoardPost)Container.DataItem).Name %></a>
                               <br />
                               <asp:Label id="lblCreateDate" Font-Size="Small" runat="server" Text="Ngày tạo:"></asp:Label>
                                </div>
                           </div>
                        </td>
                        <td class="style3">
                            <%#((BoardPost)Container.DataItem).ViewCount %></td>
                        <td class="style4">
                            <%#((BoardPost)Container.DataItem).ReplyCount %></td>
                        <td>
                            <a ID="linkReplyUsername" runat="server"  href=' <%# "/" + ((BoardPost)Container.DataItem).ReplyByUsername %>'><%#((BoardPost)Container.DataItem).ReplyByUsername %></a></td>
                            <asp:ImageButton Width="20px" Height="20px" ID="ibDelete" runat="server" ImageUrl="~/image/icon_close.gif" />
                            <asp:ImageButton Width="20px" Height="20px" ID="ibEdit" runat="server" ImageUrl="~/image/pencil.jpg" />
                    </tr>
                 </ItemTemplate>
                 </asp:Repeater>
                </table>
                
            </div>
  </div>