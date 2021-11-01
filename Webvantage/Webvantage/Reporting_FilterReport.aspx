<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reporting_FilterReport.aspx.vb"
    Inherits="Webvantage.Reporting_FilterReport" Title="Filter Report" MasterPageFile="~/ChildPage.Master" %>

<asp:Content ID="ContentFilterReport" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">
    <table align="center" border="0" cellpadding="0" cellspacing="0" 
        width="100%">
        <tr>
            <td runat="server" id="TdContentFilterReport" align="left" valign="top" colspan="2">
                <telerik:RadToolBar ID="RadToolBarContentFilterReport" runat="server" AutoPostBack="true"
                    Width="100%">
                    <Items>
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorFirstSeparator" runat="server" IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonOK" runat="server" Text="OK" Value="OK"
                            CommandName="OK" ToolTip="Filter Report" />
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorSecondSeparator" runat="server"
                            IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonCancel" runat="server" Text="Cancel"
                            Value="Cancel" CommandName="Cancel" ToolTip="Cancel" />
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorThirdSeparator" runat="server" IsSeparator="true" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td width="1%">
                &nbsp;
            </td>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td width="1%">
                &nbsp;
            </td>
            <td>
                <dx:ASPxFilterControl ID="ASPxFilterControl" runat="server" ClientInstanceName="filter" EnableCallbackCompression="false" EnablePopupMenuScrolling="true">
                </dx:ASPxFilterControl>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
