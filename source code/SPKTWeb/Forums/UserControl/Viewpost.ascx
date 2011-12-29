<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Viewpost.ascx.cs" Inherits="SPKTWeb.Forums.UserControl.Viewpost" %>
<%@ Import Namespace="SPKTCore.Core.Domain"%>
<div class="divContainerUC" style="border-width:0px; border-color:White; margin-top:2%;">
        <div class="divContainerBox" style="border-width:0px; border-color:White">
            <div class="divContainerRow" style="border-width:0px; border-color:White">
               <div style="">
                <div style=" margin-bottom:10px;">
                     <asp:Label ID="lblSubject" runat="server" style="font-weight:bold;font-size:20px; color: Blue"></asp:Label>
                </div>
                <div style="">
                    <div style="float:left; width:60px; height:50px;">
                         <asp:Image Width="60px"  Height="100%" ID="imgProfile" runat="server" />
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
                        <asp:HyperLink ID="linkReply" Text="Trả Lời" runat="server"></asp:HyperLink>
                 </div>
                 </div>

            </div>
            <div style="margin-top:30px; margin-left:80px; color: Red; border-bottom-width:3px">
               Trả Lời
            </div>
            <img width="100px" alt="k" height="2px" id="img" src="../../Image/bground2.gif" />
            <img width="100px" alt="k" height="2px" id="img1" src="../../Image/bground2.gif" />
            <asp:Panel ID="pnlComment" runat="server">
            <asp:Repeater ID="repPosts" runat="server">
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
                    <div style="float:right; margin-bottom:30px;">
                        <asp:HyperLink runat="server" ID="hlkShowReply" NavigateUrl='<%#  "/Forums/Viewpost1.aspx?PostID="+((BoardPost)Container.DataItem).PostID%>' Text="Xem"></asp:HyperLink>
                        <asp:HyperLink runat="server" ID="linkReply" NavigateUrl='<%#  "/Forums/Post.aspx?" + "IsThread=" + 0 + "&ForumID=" + ((BoardPost)Container.DataItem).ForumID +"&PostID="+ ((BoardPost)Container.DataItem).PostID%>' Text="Trả Lời"></asp:HyperLink>
                    </div>
                </div>
               
            </div>
            
                    </ItemTemplate>
            </asp:Repeater>
            <img width="100%" alt="k" height="2px" id="img2" src="../../Image/bground2.gif" />
            </asp:Panel>
            </div>
        </div>
    </div>