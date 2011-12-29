<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_E.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SPKTWeb.Homes.Home" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="aspt" %>
<%@ Register Src="~/UserControl/Comments.ascx" TagName="Comment" TagPrefix="uc2" %>
<%@ Register Src="~/Styles/LEFT_MENU.ascx" TagName="menu" TagPrefix="uc4" %>
<%@ Register Src="~/Styles/RIGHT_MENU1.ascx" TagName="rightmenu" TagPrefix="uc5" %>
<%@ Register src="../Profiles/UserControls/NotifycationControl.ascx" tagname="NotifycationControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="content6" ContentPlaceHolderID="right1" runat="server">
   <div style="background-color: #CC0000; font-family: Verdana; font-weight: bold; color: #FFFFFF; font-size: small; margin-bottom:3px; padding-left:10px;">
    <asp:LinkButton ID="lbt" Text="Tin mới" runat="server" Font-Underline="false" ForeColor="White"></asp:LinkButton>
       
   </div>
   <div style="margin: 10px; -moz-border-radius: 10px; -webkit-border-radius: 10px;">
            <asp:Panel ID="pnregist" runat="server" Width="500px" ForeColor="White">
                <div align="center" style="width: 100%; height: 86%; margin-top:10px;">
                    <div style="float: left; margin-left: 0%; height: 100%; width: 96%; margin-top: 0px;">
                        
                        <uc1:NotifycationControl ID="NotifycationControl1" runat="server" />
                        
                    </div>
                    <div style="float: left; margin-left:23%; margin-top:-10px; width: 58px; height: 22px;">
                        <asp:Button ID="bt" Text="X" runat="server" BackColor="White" 
                            ForeColor="Black" Height="16px" Font-Bold="True" 
                            Font-Names="Times New Roman" Font-Size="8px" />
                    </div>
                </div>
            </asp:Panel>
            <aspt:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lbt"
                PopupControlID="pnregist" BackgroundCssClass="modalBackground" DropShadow="false"
                OkControlID="bt" OnOkScript="onOk()" />
        </div>
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Main" runat="server">
<div class="box" style="width:100%; height:100%;">
        <div>
            <asp:Label ID="lblXinChao" runat="server" Visible="false"></asp:Label>
            <asp:LinkButton Visible="false" ID="lbtnProfile" runat="server" OnClick="lbtnProfile_Click"></asp:LinkButton>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                <asp:Panel ID="pnlStatusUpdate" runat="server" Width="100%" Height="91px">
                 <div style="height: 85px; width: 91%; margin-left:4%; margin-top:2%">
                    Bạn đang nghĩ gì?
                    <br />
                        <asp:TextBox ID="txtStatus" runat="server" Height="31px" Style="margin-top: 2px"
                        Width="100%" TextMode="MultiLine" BorderColor="#33CCFF" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                    <br />
                    <asp:DropDownList ID="ddlRange" runat="server">
                    </asp:DropDownList>
                    <asp:Button ID="btnUpdate" runat="server" Text="Gửi" OnClick="btnUpdate_Click" BackColor="#0066FF"
                        BorderColor="#99CCFF" BorderStyle="Solid" BorderWidth="1px" ForeColor="White" />
                </div>
                </asp:Panel>
                      <asp:Timer ID="Timer1" runat="server" Interval="20000" ontick="Timer1_Tick" >
                    </asp:Timer>
                <asp:Panel ID="Panel1"  runat="server" >
                    <div id="Div1"  runat="server">
                        <div id="Div2"   runat="server" style="width:91%; margin-left:4%;">
                              <asp:GridView ID="gvStatus" CssClass="mGrid-boder" runat="server" AutoGenerateColumns="False"
                Width="100%" Style="margin-right: 30px"
                CellPadding="4" GridLines="Horizontal" PageSize="10" 
                                AllowSorting="True" ForeColor="Black" ShowHeader="False" 
                BackColor="White" BorderColor="#ffccff" BorderStyle="None" BorderWidth="0px">
                          
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                  <asp:TemplateField>
                                        <ItemTemplate>
                                <div style="margin-bottom: 7px; margin-top: 15px ">
                                    <div style="float:left; width: 10%">

                                            <img width="50" height="50" alt="avatar" src='../image/ProfileAvatar.aspx?AccountID=<%#Eval("SenderID")%>&w=50&h=50'
                                                align="top" style="margin-top: 1px;" />
                                     
                                    </div>
                                    <div style="float:right; width: 90%">
                               
                                            <div class="AlertHeader">
                                                <a href='../Profiles/UserProfile2.aspx?AccountID=<%# Eval("SenderID")%>'>
                                                    <%#Eval("SenderName")%></a><a style="color:Black;"> trên tường nhà</a> <a href='../Profiles/UserProfile2.aspx?AccountID=<%# Eval("AccountID")%>'>
                                                        <%#Eval("AccountName")%></a><a>:</a>
                                                     
                                                <a style="color: Blue"> " <%#Eval("Status") %>"</a>
                                               
                                            </div>

                                            <div style="color:#c0c0c0; font-size:smaller">
                                                Ngày:
                                                <%#((DateTime)Eval("CreateDate")).ToString("dd/MM/yyyy  HH:mm:ss") %>
                                            </div>
                                            <div style="margin-bottom: 5px; margin-top: 15px ">
                                                <uc2:Comment ID="ucComment1" runat="server" SystemObjectID="1" SystemObjectRecordID='<%#Eval("StatusUpdateID")%>' />
                                            </div>
                              
                                    </div>
                                </div>
                                          </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BorderColor="#ffccff" BorderStyle="Solid" BorderWidth="0px" />
                                <EmptyDataRowStyle BorderColor="#ffccff" BorderStyle="Solid" BorderWidth="0px" />
                                <FooterStyle BackColor="#ffccff" ForeColor="Black" />
                                <HeaderStyle BackColor="#ffccff" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right"  />
                                <SelectedRowStyle BackColor="#c0c0c0" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#c0c0c0" />
                                <SortedAscendingHeaderStyle BackColor="#c0c0c0" />
                                <SortedDescendingCellStyle BackColor="#c0c0c0" />
                                <SortedDescendingHeaderStyle BackColor="#c0c0c0" />
                            </asp:GridView>
                        </div>
                    </div>
                </asp:Panel>
                
</ContentTemplate></asp:UpdatePanel>
</div>
 </asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="right" runat="server">
<div style="width: 100%; height: 30px; margin-bottom: 0px; background-image: url('/Image/2a.jpg');
        background-repeat: no-repeat;">
        <asp:Image ID="im1" runat="server" Width="100%" Height="100%" ImageUrl="/Image/2d.jpg" />
    </div>
    <div style="width: 100%; height: auto; padding:10px; margin-top: 0px;">
        <div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="Panel2" runat="server">
                        <asp:GridView ID="gvAlert" runat="server" AutoGenerateColumns="False" BorderColor="#9999FF"
                            BorderWidth="0px" PageSize="20" AllowPaging="true" CellPadding="2" ForeColor="Black"
                            GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div style="color: Blue">
                                            <%#Eval("Message") %>
                                        </div>
                                        <div style="color: Gray; font-size: small">
                                            Ngày:
                                            <%#((DateTime)Eval("CreateDate")).ToString("dd:MM:yyy HH:mm:ss") %>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle />
                            <EmptyDataRowStyle />
                            <FooterStyle />
                            <HeaderStyle />
                            <PagerStyle />
                            <SelectedRowStyle />
                            <SortedAscendingCellStyle BackColor="#FAFAE7" />
                            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                            <SortedDescendingCellStyle BackColor="#E1DB9C" />
                            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                        </asp:GridView>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">
    <div>
        <uc4:menu ID="menu" runat="server" />
    </div>
</asp:Content>

