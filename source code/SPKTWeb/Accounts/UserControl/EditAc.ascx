<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditAc.ascx.cs" Inherits="SPKTWeb.Accounts.UserControl.EditAc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="aspt" %>
<div style="border: 1px solid #666666; height: 287px; -moz-border-radius:5px;-webkit-border-radius:5px; background-color:White;">
    <div style="background-image: url('../../Image/lista.png'); background-repeat: repeat-x; height: 27px;">
    </div>
    <div style="height: 220px;">
        <div align="center" 
            style="background-image: url('../../Image/thead.gif'); background-repeat: repeat-x; height: 22px;">THAY ĐỔI THÔNG TIN TÀI KHOẢN</div>
        <div style=" background-color:White; height:200px; margin-top:10px;">
            <aspt:Accordion ID="Accordion1" runat="server" fadetransitions="True" selectedindex="2"
                            transitionduration="200" headercssclass="editac_header" 
                contentcssclass="editac_content" Height="195px">
                    <Panes>
                        <aspt:AccordionPane ID="AccordionPane1" runat="server" TabIndex="0">
                                 <Header>
                                    <div>Tên tài khoản: <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
                                    </div>
                                 </Header>
                                 <Content>
                                    <div>
                                         <asp:Label ID="lbluser" Text="Tên tài khoản không thể thay đổi" runat="server"></asp:Label>
                                    </div>
                                 </Content>
                        </aspt:AccordionPane>
                        <aspt:AccordionPane ID="AccordionPane2" runat="server">
                            <Header>
                                Tên Hiển Thị:
                                <asp:Label ID="lblOldTenHienThi" runat="server" Text=""></asp:Label>
                            </Header>
                            <Content>
                                <asp:Label ID="lblTenHienThi" Text="Tên hiển thị:" runat="server"></asp:Label>
                                <asp:TextBox ID="txtTenHienThi" runat="server"></asp:TextBox>
                                <br />
                                <asp:Button ID="btnSaveTenHienThi" runat="server" Text="Lưu thay đổi" OnClick=" btnSaveTenHienThi_Click" />
                            </Content>
                        </aspt:AccordionPane>
                        <aspt:AccordionPane ID="AccordionPane3" runat="server">
                            <Header>
                                Mật Khẩu</Header>
                            <Content>
                                <asp:Label ID="lblOldPass" Text="Mật khẩu cũ" runat="server"></asp:Label>
                                <asp:TextBox ID="txtOlaPass" TextMode="Password" runat="server"></asp:TextBox>
                                <br />
                                <asp:Label ID="lblNewPass" Text="Mật khẩu mới" runat="server"></asp:Label>
                                <asp:TextBox ID="txtNewPass" TextMode="Password" runat="server"></asp:TextBox>
                                <br />
                                <asp:Button ID="btnSavePass" runat="server" Text="Lưu thay đổi" />
                                <asp:Label ID="lblError" Text="" runat="server"></asp:Label>
                            </Content>
                        </aspt:AccordionPane>
                        <aspt:AccordionPane ID="AccordionPane4" runat="server">
                            <Header>
                                Email: <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></Header>
                            <Content>
                                <asp:Label ID="lblnewemail" Text="Sử dụng Email mới:" runat="server"></asp:Label>
                                <asp:TextBox ID="txtNewEmail"  runat="server"></asp:TextBox>
                                <br />
                                 <asp:Label ID="Label1" Text="Mật khẩu:" runat="server"></asp:Label>
                                 <asp:TextBox ID="txtVeriPass" TextMode="Password"  runat="server"></asp:TextBox>
                                <br />
                                <asp:Button ID="btnSaveNewEmail" runat="server" Text="Lưu thay đổi"/>
                                 <asp:Label ID="lblErrorpass" Text="" runat="server"></asp:Label>
                            </Content>
                        </aspt:AccordionPane>
                    </Panes> 
                </aspt:Accordion>    
        </div>
    <div style="background-image: url('../../Image/lista.png'); background-repeat: repeat-x; height: 27px;"></div>
  </div>
</div>
    
