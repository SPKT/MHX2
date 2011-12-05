<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InviteFriends.ascx.cs" Inherits="SPKTWeb.Friends.InviteFriends" %>
<div class="divContainer" id="com" 
    style="border: 1px solid #999999; width: 621px; -moz-border-radius:5px; -webkit-border-radius:5px; background-color:White;">
        <div class="divContainerBox">
            <div style="width: 621px; background-image: url('../../Image/bground1.gif'); background-repeat: repeat-x; height: 22px;"></div>
            <div class="divContainerTitle" 
                
                style="border: 0px none #000066; font-family: 'Times New Roman', Times, serif; font-weight: bold; color: #3366FF; width: 621px; height: 33px; background-image: url('../../Image/thead.gif'); font-size: 22px; background-repeat: repeat-x;" 
                align="center">
                MỜI BẠN<br /></div>
                
            <asp:Panel ID="pnlInvite" runat="server" Width="619px" BorderColor="#CCCCFF" 
                BorderStyle="Solid" BorderWidth="1px">
                <div class="divContainerRow">
                    <div class="divContainerCellHeader" 
                        style="font-style: normal; font-size: 14px; color: #666666; margin-left:15px;">Đến từ:&nbsp;&nbsp;
                        <asp:Label ID="lblFrom" runat="server" Font-Italic="True" ForeColor="Blue"></asp:Label>
                    </div>
                </div>
                <div class="divContainerRow">
                    <div class="divContainerCellHeader" 
                        style="font-size: 14px; color: #666666; margin-left:15px; width: 598px;">Gửi đến:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
                        <div  
                         class="divContainerHelpText" style="font-style: italic; width: 599px;">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtTo" runat="server" Columns="40" Font-Italic="True" 
                                ForeColor="#0000CC" Height="45px" Rows="5" TextMode="MultiLine" 
                                Width="495px"></asp:TextBox>
                            <br />
                            (Ban co the gui cho nhieu mail, moi mail cach nhau boi dau &quot;,&quot;)</div></div>
                </div>
                <div class="divContainerRow">
                    <div  
                        class="divContainerCellHeader" style="font-size: 12px">
                        <div class="divContainerCell" 
                            
                            style="font-size: 14px; width: 599px; height: 74px; color: #666666; margin-left:15px;">
                            Thông điệp:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtMessage" runat="server" Columns="40" Height="39px" 
                                Rows="10" TextMode="MultiLine" Width="495px" style="margin-left: 75px" 
                                ForeColor="#333333"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="divContainerFooter" 
                    style="height: 31px; margin-top: 8px; background-repeat: repeat-x;" 
                    align="center">
                    <asp:Button ID="btnInvite" runat="server"  
                           Text="Gửi Lời mời" OnClick="btnInvite_Click" BackColor="#0066FF" 
                        BorderColor="#FFCC00" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" 
                        Font-Names="Constantia" ForeColor="White" />
                </div>
            </asp:Panel>
            <div class="divContainerRow">
                <div class="divContainerCell" 
                    style="border: thin none #000066; width: 621px; height: 42px; background-color: #CCCCCC; font-size: 11px; background-image: url('../Image/page_top_bkgr.gif');">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:Label  
                        ID="lblMessage" runat="server" ForeColor="Maroon"></asp:Label><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br /><br /></div>
                </div>
            </div>
    </div>