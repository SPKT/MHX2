<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewPostUC.ascx.cs" Inherits="SPKTWeb.Groups.UserControl.ViewPostUC" %>
<%@ Import Namespace="SPKTCore.Core.Domain"%>
<style type="text/css">
    .style1
    {
        height: 12px;
        width: 160px;
    }
    .style2
    {
        width: 210px;
    }
    .style3
    {
        width: 308px;
    }
</style>
<div class="divContainerUC" style="border-width:0px; border-color:White">
        <div class="divContainerBox" style="border-width:0px; border-color:White">
            <div class="divContainerRow" style="border-width:0px; border-color:White">
               <div style="">
                <div style=" margin-bottom:10px;">
                     <asp:Label ID="lblSubject" runat="server" style="font-weight:bold;font-size:20px; color: Blue"></asp:Label>
                </div>
                <div style="">
                    <div style="float:left; width:40px; height:30px;">
                         <asp:Image Width="30px"  Height="20px" ID="imgProfile" runat="server" />
                    </div>
                    <div style="float:none" >
                        <div style="font-size:small; width:80%;color:Gray">
                           <asp:HyperLink ID="linkUsername" runat="server"></asp:HyperLink>
                            Ngày tạo: <asp:Label Font-Size="Small" ID="lblCreateDate" runat="server"></asp:Label>
                           
                            Cập nhật cuối:<asp:Label Font-Size="Small" ID="lblUpdateDate" runat="server"></asp:Label>
                           
                        </div>
                        <div style=" margin-left:5px; margin-top:7px; color:Maroon">
                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
                  </div>
                    </div>
               </div>      
                
                <div>
                <div style="float:left"></div>
                 <div style="float:right">
                        <asp:HyperLink ID="linkReply" Text="Bình luận" runat="server"></asp:HyperLink>
                 </div>
                 </div>

            </div>
            <div style="margin-top:30px; margin-left:80px; color: Red; border-bottom-width:3px">
                Bình luận
            </div>
            <img width="100px" alt="k" height="2px" id="img" src="../../Image/bground2.gif" />
            <img width="100px" alt="k" height="2px" id="img1" src="../../Image/bground2.gif" />
            <asp:Panel ID="pnlComment" runat="server">
            <asp:Repeater ID="repPosts" runat="server" OnItemDataBound="repPosts_ItemDataBound">
                        <ItemTemplate>
            <div style=" margin-top: 10px;">
                <div style="">
                    <div style="float:left; width:45px; height:40px;">
                        <asp:Image Width="100%" Height="100%" ID="imgProfile" runat="server" ImageUrl='<%# "/image/ProfileAvatar.aspx?AccountID=" + ((BoardPost)Container.DataItem).AccountID %>' />
                    </div>
                    <div style="float:none" >
                        <div style=" font-size:small; width:70%;color:Gray">
                           <asp:HyperLink ID="linkUsername" NavigateUrl='<%# "/" + ((BoardPost)Container.DataItem).Username %>' runat="server" Text='<%#((BoardPost)Container.DataItem).Username %>'></asp:HyperLink>
                       
                            Ngày tạo:<asp:Label ID="lblCreateDate" runat="server" Text='<%#((BoardPost)Container.DataItem).CreateDate.ToShortDateString() %>'></asp:Label>
                            Cập nhật cuối cùng:<asp:Label ID="lblUpdateDate" runat="server" Text='<%#((BoardPost)Container.DataItem).UpdateDate.ToShortDateString() %>'></asp:Label>
                        </div>
                           <div style=" margin-left:5px; margin-bottom: 5px; margin-top:7px;">
                        <asp:Label ID="lblDescription" runat="server" Text='<%#((BoardPost)Container.DataItem).Post%>'></asp:Label></td>
                        </div>
                    </div>
                </div>
             
                <div>
                    <div style="float:left">
                    </div>
                    <div style="float:right; margin-bottom:20px;">
                        <asp:HyperLink runat="server" ID="hlkShowReply" NavigateUrl='<%#  "~/Groups/ViewGroupForumPost.aspx?PostID="+((BoardPost)Container.DataItem).PostID+"&GroupID="+((BoardPost)Container.DataItem).groupID%>' Text="Xem Bình Luận"></asp:HyperLink>
                        <asp:HyperLink runat="server" ID="linkReply" NavigateUrl='<%#  "/Groups/PostGroupforum.aspx?" + "IsThread=" + 0 + "&ForumID=" + ((BoardPost)Container.DataItem).ForumID + "&GroupID=" + ((BoardPost)Container.DataItem).groupID+"&PostID="+ ((BoardPost)Container.DataItem).PostID%>' Text="Bình Luận"></asp:HyperLink>
                    </div>
                </div>
               
            </div>
            
                    </ItemTemplate>
            </asp:Repeater>
            <img width="100%" alt="k" height="2px" id="img2" src="../../Image/bground2.gif" />
            </asp:Panel>
               <%-- <div style="width:100%">
                    <div style="float:left">
                       <asp:Label ID="lblSubject" runat="server" style="font-weight:bold;font-size:16px; color:GrayText"></asp:Label>
                    </div>
                   <div style="float:none">
                        <asp:Image Width="100"  Height="100" ID="imgProfile" runat="server" /><
                        by: <asp:HyperLink ID="linkUsername" runat="server"></asp:HyperLink>
                            <br />
                            on: <asp:Label ID="lblCreateDate0" runat="server"></asp:Label>
                            <br />
                            updated:<asp:Label ID="lblUpdateDate0" runat="server"></asp:Label></td>
                        
                        
                        <td style="float:right; width:10%;"><asp:HyperLink ID="linkReply" Text="Reply" runat="server"></asp:HyperLink></td>
                    </tr>
                    <tr>
                        <td colspan="4" valign="top"><asp:Label ID="lblDescription" runat="server"></asp:Label></td>
                    </div>
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
                                <td><asp:HyperLink runat="server" ID="linkReply" NavigateUrl='<%#  "/Groups/PostGroupforum.aspx?" + "IsThread=" + 0 + "&ForumID=" + ((BoardPost)Container.DataItem).ForumID + "&GroupID=" + ((BoardPost)Container.DataItem).groupID+"&PostID=0"%>' Text="Reply"></asp:HyperLink></td>
                            </tr>
                            <tr style="background-color:#dddddd;">
                                <td colspan="4" valign="top"><asp:Label ID="lblDescription" runat="server" Text='<%#((BoardPost)Container.DataItem).Post%>'></asp:Label></td>
                            </tr>
                        </ItemTemplate>
<%--                        <AlternatingItemTemplate>
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
                        </AlternatingItemTemplate>--%>
                 
            </div>
        </div>
    </div>