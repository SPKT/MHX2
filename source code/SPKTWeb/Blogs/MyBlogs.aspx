<%@ Page Title="" Language="C#" MasterPageFile="~/MXH_PE.Master" AutoEventWireup="true" CodeBehind="MyBlogs.aspx.cs" Inherits="SPKTWeb.Blogs.MyBlogs" %>
<%@ Register src="../Styles/LEFT_MENU.ascx" tagname="LEFT_MENU" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="left" runat="server">

    <uc1:LEFT_MENU ID="LEFT_MENU1" runat="server" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">
    <div>
        <asp:UpdatePanel runat="server" ID="uppnl">
            <ContentTemplate>
                <asp:GridView ID="gvBlogs" CssClass="mGrid-boder" runat="server" AutoGenerateColumns="False"
                    Width="100%" Style="margin-right: 30px" CellPadding="4" GridLines="Horizontal"
                    PageSize="10" AllowSorting="True" ForeColor="Black" ShowHeader="False" BackColor="White"
                    BorderColor="#ffccff" BorderStyle="None" BorderWidth="0px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div style="margin-bottom: 7px; margin-top: 15px">
                                    <div style="float: left; width: 30%">
                                        <a href='/Blogs/ViewPost.aspx?BlogID=<%# Eval("BlogID")%>'>
                                            <%#Eval("Title")%></a>
                                    </div>
                                    <div style="float: right; width: 70%">
                                        <div class="AlertHeader">
                                        Tạo bởi: <a href='/Profiles/UserProfiles.aspx?AccountID=<%# Eval("AccountID")%>'>
                                            <%#Eval("AccountName")%></a>
                                        </div>
                                        <div style="color: #c0c0c0; font-size: smaller">
                                            Ngày:
                                            <%#((DateTime)Eval("CreateDate")).ToString("dd/MM/yyyy  HH:mm:ss") %>
                                        </div>
                                        <div style="margin-bottom: 5px; margin-top: 15px">
                              
                                        <%#Eval("Post").ToString()%><a href='/Blogs/ViewPost.aspx?BlogID=<%# Eval("BlogID")%>'>
                                            xem</a>
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
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#c0c0c0" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#c0c0c0" />
                    <SortedAscendingHeaderStyle BackColor="#c0c0c0" />
                    <SortedDescendingCellStyle BackColor="#c0c0c0" />
                    <SortedDescendingHeaderStyle BackColor="#c0c0c0" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
