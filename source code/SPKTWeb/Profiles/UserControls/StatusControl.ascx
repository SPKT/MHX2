<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StatusControl.ascx.cs" Inherits="SPKTWeb.Profiles.UserControls.StatusControl" %>
<div>
    <p>
         <asp:Label ID="Label1" runat="server" Text="Status"></asp:Label>
    </p>
    <div>
    <asp:TextBox  ID="txtStatus" runat="server" Height="20px" style="margin-top: 0px" 
         Width="600px" TextMode="MultiLine" BorderColor="#9999FF" BorderStyle="Solid" 
            BorderWidth="1px"></asp:TextBox>
        <asp:DropDownList ID="ddlRange" runat="server">
        </asp:DropDownList>
    </div>
    <asp:Button ID="btnUpdate" runat="server" Text="OK" onclick="btnUpdate_Click" 
        BackColor="#0066FF" BorderColor="#66CCFF" BorderStyle="Solid" BorderWidth="1px" 
        ForeColor="White" />
</div>
