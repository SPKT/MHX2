<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShareFileItem.ascx.cs" Inherits="SPKTWeb.Photo.UserControl.ShareFileItem" %>
<div id="div1" runat="server" style="padding: 20px; height: 40%">
    <div style="float: left; height: 100%;">
        <asp:Image ID="Image1" runat="server" Height="20%" Width="20%" />
        <br />
        <asp:Label ID="Name" runat="server"></asp:Label>
        <asp:Label ID="Date" runat="server"></asp:Label>
        <asp:Label ID="FileID" runat="server" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="Desc" runat="server">Mô tả</asp:Label>
        <br />
        <asp:CheckBox ID="Ispublic" runat="server" Text="IsPublic" />
        <br />
    </div>
    <div style="float: right; height: 100%; width: 70%; margin-right: 5%">
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Chia sẻ</asp:LinkButton>
        <br />
        <div style="padding-left:20px;">
            <asp:Panel ID="pnm" runat="server" Visible="false" style="margin-left: 36px" 
                BorderColor="Maroon" BorderStyle="Solid" BorderWidth="1px">
                <div style="margin-left: 20px;">
                    <asp:Label ID="Label1" runat="server" Font-Italic="True" Font-Names="Verdana" Font-Size="X-Small"
                        ForeColor="#666666" Font-Bold="True"></asp:Label><br />
                    <asp:DropDownList ID="friend" runat="server" style="margin-left: 0px" 
                        Width="200px">
                    </asp:DropDownList>
                    <br />
                    <asp:Label ID="Label2" runat="server" Font-Italic="True" Font-Names="Verdana" 
                        Font-Size="X-Small" ForeColor="#666666">Thông điệp</asp:Label>
                    <asp:TextBox ID="tb_comment" runat="server" AutoPostBack="true" 
                        BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1" Height="19px" 
                        Width="79%" style="margin-left: 60px"></asp:TextBox>
                    <br />
                    <asp:Button ID="Button1" runat="server" Font-Names="Tahoma" 
                        Font-Size="10px" ForeColor="Maroon" Height="19px" OnClick="Button1_Click" 
                        Text="Chia sẻ" Width="58px" Font-Bold="True" />
                </div>
            </asp:Panel>
        </div>
    </div>
</div>
