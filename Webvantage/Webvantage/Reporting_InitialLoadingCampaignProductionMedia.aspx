<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reporting_InitialLoadingCampaignProductionMedia.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.Reporting_InitialLoadingCampaignProductionMedia"
    Title="Set Initial Criteria" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlockRadWindow" runat="server">
        <script type="text/javascript">
            function returnValue() {
                //Get a reference to the parent (MDI) page 
                var oWnd = GetRadWindow();
                //get a reference to the second RadWindow
                var CallingWindowName = 'Create';
                var CallingWindow = oWnd.get_windowManager().getWindowByName(CallingWindowName);
                // Get a reference to the first RadWindow's content
                var CallingWindowContent = CallingWindow.get_contentFrame().contentWindow;
                //Call the predefined function in Dialog1
                //alert(CallingWindowName + '\n' + CallingWindow + '\n');
                CallingWindowContent.ReloadColumns(oWnd);
                //Close the second RadWindow
                oWnd.close();
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" border="0" cellpadding="0" cellspacing="0" 
        width="100%">
        <tr>
            <td runat="server" id="TdRadToolBarDynamicReportInitialLoading" align="left" valign="top"
                colspan="2">
                <telerik:RadToolBar ID="RadToolBarDynamicReportInitialLoading" runat="server" AutoPostBack="true"
                    Width="100%">
                    <Items>
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorFirstSeparator" runat="server" IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonOK" runat="server"
                            Text="OK" Value="OK" CommandName="OK" ToolTip="OK" />
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorSecondSeparator" runat="server"
                            IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonCancel" runat="server" SkinID="RadToolBarButtonCancel"
                            Text="Cancel" Value="Cancel" CommandName="Cancel" ToolTip="Cancel" />
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorThirdSeparator" runat="server" IsSeparator="true" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td>                
                <table width="99%" border="0" cellspacing="2" cellpadding="0">
                    <tr>
                        <td width="20%">
                            Client:
                        </td>
                        <td width="90%">
                            <telerik:RadComboBox ID="RadComboBoxClient" runat="server" AutoPostBack="true"
                                Width="500px" DataTextField="Name" DataValueField="Code">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                </table>           
            </td>
        </tr>
        <tr>
            <td>                
                <table width="99%" border="0" cellspacing="2" cellpadding="0">
                    <tr>
                        <td width="20%">
                            From Campaign:
                        </td>
                        <td width="90%">
                            <telerik:RadComboBox ID="RadComboBoxCampaignFrom" runat="server" AutoPostBack="false"
                                Width="500px" DataTextField="Name" DataValueField="ID" CssClass="RequiredInput">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                </table>           
            </td>
        </tr>
        <tr>
            <td>                
                <table width="99%" border="0" cellspacing="2" cellpadding="0">
                    <tr>
                        <td width="20%">
                            To Campaign:
                        </td>
                        <td width="90%">
                            <telerik:RadComboBox ID="RadComboBoxCampaignTo" runat="server" AutoPostBack="false"
                                Width="500px" DataTextField="Name" DataValueField="ID" CssClass="RequiredInput">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                </table>           
            </td>
        </tr>
        <tr>
            <td>
                <table width="99%" border="0" cellspacing="2" cellpadding="0">
                    <tr>
                        <td width="1%">
                            &nbsp;
                        </td>
                        <td colspan="2">
                            <asp:CheckBox id="CheckBoxIncludeClosed" runat="server" Text="Include Closed" AutoPostBack="True" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="99%" border="0" cellspacing="2" cellpadding="0">
                    <tr>
                        <td width="1%">
                            &nbsp;
                        </td>
                        <td colspan="2">
                            <asp:CheckBox id="CheckBoxCampaignMasterJob" runat="server" Text="Use Campaign Master Job Estimate" AutoPostBack="True" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
