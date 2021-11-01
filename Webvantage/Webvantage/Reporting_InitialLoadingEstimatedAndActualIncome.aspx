<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reporting_InitialLoadingEstimatedAndActualIncome.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.Reporting_InitialLoadingEstimatedAndActualIncome"
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
                <table width="99%" border="0" cellspacing="2" cellpadding="0">
                    <tr>
                        <td width="10%">
                            Criteria:
                        </td>
                        <td width="90%">
                            <telerik:RadComboBox ID="RadComboBoxCriteria" runat="server" AutoPostBack="false"
                                Width="100%" DataTextField="Name" DataValueField="Value">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="1%">
                &nbsp;
            </td>
            <td>
                <table width="99%" border="0" cellspacing="2" cellpadding="0">
                    <tr>
                        <td runat="server" id="tdFrom" width="10%">
                            From:
                        </td>
                        <td width="50%">
                            <telerik:RadDatePicker ID="RadDatePickerFrom" runat="server" AutoPostBack="true"
                                SkinID="RadDatePickerStandard">
                            </telerik:RadDatePicker>
                        </td>
                        <td width="20%">
                            <telerik:RadButton ID="RadButtonYTD" runat="server" AutoPostBack="true" ButtonType="StandardButton"
                                Text="YTD" Width="70">
                            </telerik:RadButton>
                        </td>
                        <td width="20%">
                            <telerik:RadButton ID="RadButton1Year" runat="server" AutoPostBack="true" ButtonType="StandardButton"
                                Text="1 Year" Width="70">
                            </telerik:RadButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr runat="server" id="trTo">
            <td width="1%">
                &nbsp;
            </td>
            <td>
                <table width="99%" border="0" cellspacing="2" cellpadding="0">
                    <tr>
                        <td width="10%">
                            To:
                        </td>
                        <td width="50%">
                            <telerik:RadDatePicker ID="RadDatePickerTo" runat="server" AutoPostBack="true" SkinID="RadDatePickerStandard">
                            </telerik:RadDatePicker>
                        </td>
                        <td width="20%">
                            <telerik:RadButton ID="RadButtonMTD" runat="server" AutoPostBack="true" ButtonType="StandardButton"
                                Text="MTD" Width="70">
                            </telerik:RadButton>
                        </td>
                        <td width="20%">
                            <telerik:RadButton ID="RadButton2Years" runat="server" AutoPostBack="true" ButtonType="StandardButton"
                                Text="2 Year" Width="70">
                            </telerik:RadButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>        
        <tr>
            <td width="1%">
                &nbsp;
            </td>
            <td>
                <table width="99%" border="0" cellspacing="2" cellpadding="0">
                    <tr>                        
                        <td width="10%">
                            Type:
                        </td>
                        <td width="90%" align="left">
                            <asp:RadioButton id="RadioButtonStandard" runat="server" Text="Standard" GroupName="Cost"/>
                            <asp:RadioButton id="RadioButtonAlternate" runat="server" Text="Alternate Direct Cost" GroupName="Cost"/>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="1%">
                &nbsp;
            </td>
            <td>
                <asp:CheckBox ID="CheckBoxShowJobsWithNoDetails" runat="server" AutoPostBack="false"
                    Checked="false" Text="Show Jobs With No Details" Visible="false" />
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
