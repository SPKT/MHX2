<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_1.master" AutoEventWireup="true"
    CodeBehind="UserProfile2.aspx.cs" Inherits="SPKTWeb.Profiles.UserProfile2" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="aspt" %>
<%@ Register Src="UserControls/StatusControl.ascx" TagName="StatusControl" TagPrefix="uc1" %>
<%@ Register Src="~/UserControl/Comments.ascx" TagName="Comment" TagPrefix="uc2" %>
<%@ Register Src="../Friends/UserControl/BoxInvite.ascx" TagName="BoxInvite" TagPrefix="uc3" %>
<%@ Register Src="../Friends/UserControl/ListFriendSimple.ascx" TagName="ListFriendSimple"
    TagPrefix="uc4" %>
    <%@ Register Src="~/Styles/LEFT_MENU.ascx" TagName="menu" TagPrefix="uc4" %>
    <%@ Register Src="~/Styles/RIGHT_MENU1.ascx" TagName="menu1" TagPrefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        
        .winzard
        {
            display: run-in;
            margin: 0;
            padding: 0;
        }
        #scroll_box
        {
            height: 400px;
            display: auto;
            border: 1px solid #CCCCCC;
            margin: 1em 0;
            overflow: scroll;
        }
        .divShow
        {
        }
        .divAlert
        {
            width: 30%;
            float: right;
        }
        
        #Div1
        {
            height: 823px;
            -moz-border-radius:5px;
	        -webkit-border-radius:5px;
        }
        
            .divname { width: 200px; height: 25px; background-color: #F2F7FE;margin:5px; }
            .txtbox { width: 180px; height: 20px; background-color: transparent; position: relative; top: 5px; left: 10px; border-style: none; }
        
    </style>

</asp:Content>
<asp:Content ID="content6" ContentPlaceHolderID="right1" runat="server">
<div style="width:100%;background-color:White; margin-top:0px;">
    <uc5:menu1 ID="mu" runat="server" />
 </div>
</asp:Content>
<asp:Content ID="content5" ContentPlaceHolderID="left" runat="server">
    <div>
        <uc4:menu ID="menu" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="right" runat="server">
<div style="width:100%; height:100%; background-color:Black; margin-top:0px;">
    <div >
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
            <ContentTemplate>
                <asp:Panel ID="Panel2" runat="server">
                    <asp:GridView ID="gvAlert" runat="server" AutoGenerateColumns="False" BorderColor="#9999FF"
                        BorderWidth="1px" BackColor="White" PageSize="20" AllowPaging="true" CellPadding="2" ForeColor="Black"
                        GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
  
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div class="AlertHeader">
                                        <a href='UserProfile2.aspx?AccountID=<%# Eval("AccountID")%>'>
                                            <%#Eval("SenderName") %></a>
                                    </div>
                                    <div style="color:Blue";">
                                        <%#Eval("Message") %>
                                    </div>
                                    <div>
                                        Ngày:
                                        <%#((DateTime)Eval("CreateDate")).ToString("dd:MM:yyy HH:mm:ss") %>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle  />
                        <EmptyDataRowStyle  />
                        <FooterStyle  />
                        <HeaderStyle  />
                        <PagerStyle />
                        <SelectedRowStyle  />
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
<asp:Content ID="Content4" ContentPlaceHolderID="Main" runat="server">
    <div class="box" style="width:100%; height:100%;">
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                <asp:Panel ID="pnlStatusUpdate" runat="server" Width="100%" Height="91px">
                 <div style="height: 85px; width: 91%; margin-left:4%; margin-top:2%; margin-bottom:3%;">
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
                    <asp:Timer ID="Timer1" runat="server" Interval="10000" ontick="Timer1_Tick" >
                    </asp:Timer>
                <asp:Panel ID="Panel1"  runat="server" >
                    <div>
                        <div  runat="server" style="width:91%; margin-left:4%;">
                            <asp:GridView ID="gvStatus" CssClass="mGrid-boder" AllowPaging="true" runat="server" AutoGenerateColumns="False"
                Width="100%" Style="margin-right: 0px" 
                CellPadding="4" GridLines="Horizontal" PageSize="25" 
                                AllowSorting="True" ForeColor="Black" ShowHeader="False" 
                BackColor="White" BorderColor="#c0c0c0" BorderStyle="None" BorderWidth="0px">
                          
                                <AlternatingRowStyle BackColor="White" />
                                      <Columns>
                                  <asp:TemplateField>
                                        <ItemTemplate>
                                <div style="margin-bottom: 7px; margin-top: 7px ">
                                    <div style="float:left; width: 10%">

                                            <img width="50" height="50" alt="avatar" src='../image/ProfileAvatar.aspx?AccountID=<%#Eval("SenderID")%>&w=50&h=50'
                                                align="top" style="margin-top: 1px;" />
                                     
                                    </div>
                                    <div style="float:right; width: 90%">
                               
                                            <div class="AlertHeader">
                                                <a href='../Profiles/UserProfile2.aspx?AccountID=<%# Eval("SenderID")%>'>
                                                    <%#Eval("SenderName")%></a><a style="color:Black;"> trên tường nhà</a> <a href='UserProfile2.aspx?AccountID=<%# Eval("AccountID")%>'>
                                                        <%#Eval("AccountName")%></a><a>:</a>
                                                <a style="color:Blue"> " <%#Eval("Status") %>"</a>
                                               
                                            </div>

                                            <div style="color:#cc00cc; font-size:smaller">
                                                Ngày:
                                                <%#((DateTime)Eval("CreateDate")).ToString("dd/MM/yyyy  HH:mm:ss") %>
                                            </div>
                                            <div style="margin-bottom: 5px; margin-top: 5px ">
                                                <uc2:Comment ID="ucComment1" runat="server" SystemObjectID="1" SystemObjectRecordID='<%#Eval("StatusUpdateID")%>' />
                                            </div>
                              
                                    </div>
                                </div>
                                          </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BorderColor="#c0c0c0" BorderStyle="Solid" BorderWidth="0px" />
                                <EmptyDataRowStyle BorderColor="#c0c0c0" BorderStyle="Solid" BorderWidth="0px" />
                                <FooterStyle BackColor="#c0c0c0" ForeColor="Black" />
                                <HeaderStyle BackColor="#c0c0c0" Font-Bold="True" ForeColor="White" />
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
