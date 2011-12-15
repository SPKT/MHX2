<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Comments.ascx.cs" Inherits="SPKTWeb.UserControl.Comments" %>

       <asp:UpdatePanel runat="server">
           
          
       <ContentTemplate>

        <asp:Panel runat="server" ID="pnlComment" DefaultButton="btnAddComment"  ondatabinding="pnlComment_DataBinding">
            <asp:HiddenField ID="hidenSystemObjectRecordID" Value="0" runat="server" />
            <asp:HiddenField ID="hidenSystemObjectID" Value="0" runat="server" />

        <asp:Timer ID="Timer1" runat="server" Interval="20000" ontick="Timer1_Tick" >
       </asp:Timer>
            <asp:PlaceHolder ID="phComments" runat="server"></asp:PlaceHolder>
                    <div style="margin-bottom:5px;">
            <asp:TextBox ID="txtComment" runat="server" Width= "400px"></asp:TextBox>
                        <asp:Button Text="Gửi lời bình" ID="btnAddComment" runat="server" 
                            OnClick="btnAddComment_Click"  BackColor="#0066FF"
                        BorderColor="#99CCFF" BorderStyle="Solid" BorderWidth="1px" ForeColor="White" />
            </div>
<!--<asp:GridView ID="gvComment" runat="server" 
                AutoGenerateColumns="False" Width="100%" Style="margin-right: 0px" 
                CellPadding="4" GridLines="None" PageSize="25" BackColor="White"
                                AllowSorting="True" ForeColor="#333333" ShowHeader="False">

                                <AlternatingRowStyle BackColor="White" />

                                <Columns>
                                  <asp:TemplateField>
                                        <ItemTemplate>
                                <div style="margin-top: 3px; margin-bottom: 3px;">
                                    <div style="float:left; width: 8%">

                                            <img width="25" height="25" alt="avatar" src='../image/ProfileAvatar.aspx?AccountID=<%#Eval("CommentByAccountID")%>&w=50&h=50'
                                                align="top" style="margin-top: 1px;" />
                                     
                                    </div>
                                    <div style="float:right; width: 92%">
                               
                                            <div >
                                                <a href='UserProfile2.aspx?AccountID=<%# Eval("CommentByAccountID")%>'>
                                                    <%#Eval("CommentByUserName")%></a>
                                             </div>
                                            <div style="color: Fuchsia">
                                                <%#Eval("Body") %>
                                            </div>
                                            <div>
                                                Ngày:
                                                <%#((DateTime)Eval("CreateDate")).ToString("dd/MM/yyyy  HH:mm:ss") %>
                                            </div>
                                         
                              
                                    </div>
                                </div>
                                          </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BorderColor="#ff66ff" BorderStyle="Solid" BorderWidth="0px" />
                                <EmptyDataRowStyle BorderColor="#ff66ff" BorderStyle="Solid" BorderWidth="0px" />
                                <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#333333" HorizontalAlign="Center" />
                                <RowStyle BackColor="White" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                <SortedDescendingHeaderStyle BackColor="#820000" />
                            </asp:GridView>
            -->
        </asp:Panel>
     
    </ContentTemplate>
    </asp:UpdatePanel>
    