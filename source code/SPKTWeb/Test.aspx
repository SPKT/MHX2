<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="SPKTWeb.Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <style type="text/css">
        .accordion
        {
            width: 50%;
            height: 40%;
        }
        .accordionHeader
        {
            border: 1px solid #2F4F4F;
            color: white;
            background-color: #5078B3;
            font-family: Arial, Sans-Serif;
            font-size: 12px;
            font-weight: bold;
            padding: 5px;
            margin-top: 5px;
            cursor: pointer;
            text-align:left;
        }
        .accordionHeaderSelected
        {
            border: 1px solid #2F4F4F;
            color: white;
            background-color: #5078B3;
            font-family: Arial, Sans-Serif;
            font-size: 12px;
            font-weight: bold;
            padding: 5px;
            margin-top: 5px;
            cursor: pointer;
            text-align:center;
        }
        .accordionContent
        {
            background-color: #D3DEEF;
            text-align:left;
            border-top: none;
            padding: 5px;
            padding-top: 10px;
            padding-left:100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="Div1"  style="background-color:Green; margin-top:30px; height:20px" runat="server">
                            <asp:Menu ID="Menu2" runat="server" DataSourceID="HorisontalMenu" DynamicHorizontalOffset="2"
                            Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" Height="100%" Orientation="Horizontal"
                            StaticSubMenuIndent="15px" Width="100%">
                            <DynamicHoverStyle BackColor="YellowGreen" ForeColor="White" />
                            <DynamicMenuItemStyle HorizontalPadding="15px" VerticalPadding="2px" />
                            <DynamicMenuStyle BackColor="#B5C7DE" />
                            <DynamicSelectedStyle BackColor="#507CD1" />
                            <StaticHoverStyle BackColor="#660066" ForeColor="White" />
                            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                            <StaticSelectedStyle BackColor="#9966ff" />
                        </asp:Menu>
                        <asp:SiteMapDataSource ID="HorisontalMenu" runat="server" ShowStartingNode="False" SiteMapProvider="HorisontalMenu" />
    </div>
        <asp:Button ID="Button1" runat="server" Text="Button"  />
    </div>
    \\\

       <div  style="width:50%; margin-top:10px; height: 400px; margin-right: 0px; margin-bottom: 0px;">
     
                    <div class="accordionHeader">
                        Tên tài khoản
                        <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="accordionContent">
                            <asp:Label ID="lbluser" Text="Tên tài khoản không thể thay đổi" runat="server"></asp:Label>
                    </div>
                    <div class="accordionHeader">
                        Tên hiển thị mới
                        <asp:Label ID="lblOldTenHienThi" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="accordionContent">
                        <asp:Label ID="lblTenHienThi" Text="Tên hiển thị:" runat="server"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtTenHienThi" runat="server" Height="18px" Width="205px"></asp:TextBox>
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                        <asp:Button ID="btnSaveTenHienThi" runat="server" Text="Lưu thay đổi"  />
                   </div>
                    <div class="accordionHeader">
                        Mật khẩu
                        </div>
                    <div class="accordionContent">
                        <asp:label ID="lblAuthentication" runat="server" />
                        <br />
                        <asp:Label ID="lblOldPass" Text="Mật khẩu cũ" runat="server"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtOlaPass" TextMode="Password" runat="server" Height="18px" 
                            Width="200px"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblNewPass" Text="Mật khẩu mới" runat="server"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtNewPass" TextMode="Password" runat="server" Height="18px" 
                            Width="200px"></asp:TextBox>
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnSavePass" runat="server" Text="Lưu thay đổi" />
                 </div>
                <div class="accordionHeader">
                        Email <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                    </div>
                <div class="accordionContent">
                        <asp:Label ID="lblnewemail" Text="Sử dụng Email mới" runat="server"></asp:Label>
                        &nbsp;<asp:TextBox ID="txtNewEmail"  runat="server" Height="18px" Width="185px"></asp:TextBox>
                        <br />
                         <asp:Label ID="Label1" Text="Mật khẩu" runat="server"></asp:Label>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:TextBox ID="txtVeriPass" TextMode="Password"  runat="server" 
                            Height="18px" Width="185px" style="margin-left: 0px"></asp:TextBox>
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnSaveNewEmail" runat="server" Text="Lưu thay đổi"  />
                    </div>
                
                
                <asp:Panel ID="pnlUseAuthen" runat="server" Visible="true">
                    <div class="accordionHeader">
                        Thay đổi cách sử dụng chứng thực (chỉ chọn được quyền chứng thực bằng tài khoản website mạng xã hội khi đã đổi mật khẩu một lần) </asp:Label></Header>
                    </div>
                    <div class="accordionContent">
                        <asp:Label ID="lbl1" Text="Bạn đang sử dụng quyền chứng thực:" runat="server"></asp:Label><br />
                        <asp:RadioButton ID="rdbUseDKMH" GroupName="use" Text="Sử dụng chứng thực bằng tài khoản đăng ký môn học" runat="server" /><br />
                        <asp:RadioButton ID="rdbUseMXH" GroupName="use" Text="Sử dụng chứng thực bằng tài khoản website Mạng xã hội" runat="server" /><br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnSave" runat="server" Text="Lưu thay đổi"  />
                        
                  </div>
                  </asp:Panel>
                  ////

 <div style="border: 1px solid #CCCCCC; height: 225px; background-color:White;-moz-border-radius:5px; -webkit-border-radius:5px; width:60%">
    <div align="center" 
        
        style="height: 25px; background-image: url('../../Image/htitle.gif'); background-repeat: repeat-x; color: #333333;">
        ĐĂNG NHẬP</div>
    <div style="background-image: url('../../Image/thead.gif'); background-repeat: repeat-x; height: 27px;"></div>
    <div style="height: 30px;">
        <div style="float:left; margin-left:5%; height:100%; width:45%; margin-top:1px; vertical-align:middle; font-size: 14px; color: #666666;">
            Tên đăng nhập :</div>
        <div style="float:left; margin-left:1%; height:100%; width:45%; margin-top:1px; vertical-align:middle;">
            <asp:TextBox ID="txtUserName" runat="server" BorderColor="#999999" 
                BorderStyle="Solid" BorderWidth="1px" Height="16px" Width="100%"></asp:TextBox>
        </div>
    </div>
    <div style="height: 30px">
        <div style="float:left; margin-left:5%; height:100%; width:45%; margin-top:1px; vertical-align:middle; font-size: 14px; color: #666666;">
            Mật khẩu :</div>
        <div style="float:left; margin-left:1%; height:100%; width:45%; margin-top:1px; vertical-align:middle;">
            <asp:TextBox ID="txtPassword" runat="server" BorderColor="#999999" 
                BorderStyle="Solid" BorderWidth="1px" Height="16px" Width="100%" 
                TextMode="Password"></asp:TextBox>
        </div>
    </div>
    <div style="height: 23px" align="center">
						<asp:CheckBox ID="CheckBox1" Font-Bold="True" Font-Italic="True" ForeColor="Gray" Text="Đăng nhập bằng tài khoản ĐKMH" runat="server" />
    </div>
    <div align="center" style="height: 53px">
						<asp:Button id="btnLogin" runat="server" BackColor="#0066FF" BorderColor="Blue" 
                                BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" ForeColor="White" 
                                Height="25px" Text="Đăng nhập" Width="30%"  
                            Font-Size="X-Small" style="margin-top: 2px" />
                        <br />
						<asp:LinkButton id="lbRecoverPassword" runat="server" Font-Size="Small">Quên mật 
						khẩu</asp:LinkButton>
                        <br />
    </div>
    <div align="center" style="margin-top: 8px">
						<asp:CheckBox id="ckbAutoLogin" runat="server" TextAlign="Left" />
						<asp:Label id="Label3" runat="server" Font-Bold="True" Font-Italic="True" ForeColor="Gray" Text="Duy trì trạng thái đăng nhập" Font-Size="Small"></asp:Label>
	</div>
    <div style="background-image: url('../../Image/thead.gif'); background-repeat: repeat-x; height: 15px;"></div>
</div>

    </div>
    </form>
</body>
</html>
