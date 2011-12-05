<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MENU.ascx.cs" Inherits="MENU" %>
<div>
<div id="box_menu_top" align="center" 
                style="border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #999999">
                <div id="box_menu_top_1">
                    <div class="menu_ngang">
                       <asp:LinkButton  ID="lb_info" runat="server" Font-Underline="False" 
                            ForeColor="#666666" Height="100%" Width="100%">Thông tin mới</asp:LinkButton>
                    </div>
                    <div class="menu_ngang">
                        <asp:LinkButton ID="lb_account" runat="server" Font-Underline="False" 
                            ForeColor="#666666" Height="100%" Width="100%">Thông tin tài khoản</asp:LinkButton>
                    </div>
                    <div class="menu_ngang">
                        <asp:LinkButton ID="lb_profile" runat="server" Font-Underline="False" 
                            ForeColor="#666666" Height="100%" Width="100%">Thông tin cá nhân</asp:LinkButton>
                    </div>
                    <div class="menu_ngang">
                        <asp:LinkButton ID="lb_Friend" runat="server" Font-Underline="False" 
                            ForeColor="#666666" Height="100%" Width="100%">Kết bạn</asp:LinkButton>
                    </div>
                    <div class="menu_ngang_timkiem">
                        <input id="timkiem" type="text" />
                    </div>
                    <div class="menu_ngang_timkiem_nut">
                        <asp:Image ID="Image1" runat="server" 
                            ImageUrl="~/Image/button-search-header.jpg" Width="57px" />
                    </div>
                </div>
            </div>
 </div>
