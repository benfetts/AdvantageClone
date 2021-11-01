<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Campaign_ChangeCode.aspx.vb" Inherits="Webvantage.Campaign_ChangeCode"
    MasterPageFile="~/ChildPage.Master" %>
<asp:Content ID="ContentCampaignChangeCode" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <table align="center" border="0" cellpadding="0" cellspacing="0" 
        width="100%">
        <tr>
            <td runat="server" id="TdRadToolBarCampaign" align="left" valign="top"
                colspan="2">
                <telerik:RadToolBar ID="RadToolBarCampaign" runat="server" AutoPostBack="true"
                    Width="100%">
                    <Items>
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorFirstSeparator" runat="server" IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonSave" runat="server" Text="" Value="Save"
                            CommandName="Save" ToolTip="Save" SkinID="RadToolBarButtonSave" />
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorSecondSeparator" runat="server"
                            IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonCancel" runat="server" Text="Cancel" Value="Cancel"
                            CommandName="Cancel" ToolTip="Cancel" SkinID="RadToolBarButtonCancel" />
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorThirdSeparator" runat="server" IsSeparator="true" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td width="1%">&nbsp;
            </td>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td width="1%">&nbsp;
            </td>
            <td>
                <table id="TableDescription" runat="server" width="100%" border="0" cellspacing="2"
                    cellpadding="0">
                    <tr>
                        <td width="40%">
                            <asp:Label ID="LabelReportType" runat="server" Text="Enter new campaign code: " Font-Bold="True"
                                Width="100%"></asp:Label>
                        </td>
                        <td width="60%">
                            <asp:TextBox ID="TextBoxCode" runat="server" Text="" CssClass="CssTextBox" MaxLength="6" SkinID="TextBoxStandard"
                                Width="97%">
                            </asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
