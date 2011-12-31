<%@ Register Src="~/Photo/UserControl/ShareFileItem.ascx" TagName="ShareFile" TagPrefix="uc1" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListFileShare.ascx.cs" Inherits="SPKTWeb.Photo.UserControl.ListFileShare" %>
<div style="width: 100%; height: auto; margin: 5px; margin-left: 0px; background-color: White;">
    
                <asp:Repeater ID="repFiles" runat="server" OnItemDataBound="repFiles_ItemDataBound">
                    <ItemTemplate>
                        <uc1:ShareFile ID="file1" runat="server"></uc1:ShareFile>
                    </ItemTemplate>
                </asp:Repeater>
            
       
</div>