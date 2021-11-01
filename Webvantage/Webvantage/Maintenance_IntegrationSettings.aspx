<%@ Page Title="Integration Settings" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Maintenance_IntegrationSettings.aspx.vb" Inherits="Webvantage.Maintenance_IntegrationSettings" %>

<asp:Content ID="ContentProductionSettings" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">
    
    
    <script type="text/javascript">
        function NumericInputOnValueChanging(sender, eventArgs) {

            if (eventArgs.get_newValue() > sender.get_maxValue())
                eventArgs.set_cancel(true);
            else if (eventArgs.get_newValue() < sender.get_minValue())
                eventArgs.set_cancel(true);

        }

    </script>
    <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="75%">
                            <telerik:RadTabStrip ID="RadTabStripIntegrationSettings" runat="server" 
                                AutoPostBack="true" Width="100%">
                            </telerik:RadTabStrip>
                        </td>
                        <td align="right" valign="middle">
                            <asp:ImageButton ID="ImageButtonLoadDefaults" runat="server" SkinID="ImageButtonClear" ToolTip="Load Default Integration Settings" />&nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="10">
                            &nbsp;
                        </td>
                        <td width="740">
                            <asp:PlaceHolder ID="PlaceHolderSettings" runat="server" EnableViewState="false">
                            </asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
