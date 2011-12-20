<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewMemberUC.ascx.cs" Inherits="SPKTWeb.Groups.UserControl.ViewMemberUC" %>
            Danh sách thành viên
            <br />
            <asp:Repeater ID="reMember" runat="server" >
                <ItemTemplate>               
                    <a href='/Profiles/UserProfile2.aspx?AccountID= <%# ((SPKTCore.Core.Domain.Account)Container.DataItem).AccountID %>'>
                        <img alt='avatar' style="padding: 5px; margin-top: 4px;" id="imgAvatar" width="40px" height="40px"  class="img" src='/image/ProfileAvatar.aspx?AccountID=<%# ((SPKTCore.Core.Domain.Account)Container.DataItem).AccountID %>' />
                    </a>
                    <br />
                    <a style="margin-bottom:35px;" href='/Profiles/UserProfile2.aspx?AccountID=<%# ((SPKTCore.Core.Domain.Account)Container.DataItem).AccountID %>'>
                        <%# ((SPKTCore.Core.Domain.Account)Container.DataItem).UserName %>
                    </a>
                   
                    <br />
                </ItemTemplate>
            </asp:Repeater>