<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Security_ClientPortal_Settings.aspx.vb" Title="Client Portal - General Settings"
    Inherits="Webvantage.securityClientPortalSettings" MasterPageFile="~/ChildPage.Master" %>

<asp:Content ID="Content" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <div  style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
        <telerik:RadToolBar ID="RadToolbarEventScheduler" runat="server" Width="900px">
                <Items>
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton Text="Save" Value="Save" SkinID="RadToolBarButtonSave" ToolTip=""></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton Text="Clear" Value="Clear" SkinID="RadToolBarButtonClear" ToolTip="Clear"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton Text="Client Portal Customization" Value="CustomizeClientPortalClients" ToolTip="Customize individual Client Portals"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton Text="Setup Workspace Template" Value="SetupWorkspaceTemplate" ToolTip="Setup Workspace Template" Visible="false"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton IsSeparator="true" />
                </Items>
            </telerik:RadToolBar>
    </div>
    <div class="">
        <table cellpadding="2" cellspacing="2" width="900px" align="center" border="0">
                <tr>
                    <td colspan="2">
                        <h4>Host/Folder Name</h4>
                    </td>
                </tr>
                <tr>
                    <td style="width: 130px; padding-top: 10px" align="right">Webvantage:&nbsp;
                    </td>
                    <td style="padding-top: 10px">
                        <asp:TextBox ID="txtWVFolder" runat="server" Width="400px" SkinID="TextBoxStandard"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                    <td>Current:
                        <asp:Label ID="lblWVFolder" runat="server" ForeColor="DarkRed"></asp:Label>
                    </td>
                </tr>
                <tr>
                </tr>
                <tr>
                    <td style="width: 130px" align="right">Client Portal:&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtCPFolder" runat="server" Width="400px" SkinID="TextBoxStandard"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                    <td>Current:
                        <asp:Label ID="lblCPFolder" runat="server" ForeColor="DarkRed"></asp:Label>
                    </td>
                </tr>
            </table>
    </div>
    
</asp:Content>
