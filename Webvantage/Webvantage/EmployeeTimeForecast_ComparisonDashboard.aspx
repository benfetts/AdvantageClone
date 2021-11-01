<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="EmployeeTimeForecast_ComparisonDashboard.aspx.vb" Inherits="Webvantage.EmployeeTimeForecast_ComparisonDashboard"
    Title="Employee Time Forecast Comparison Dashboard" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="ContentEmployeeTimeForecastComparisonDashboard" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock" runat="server">
        <script type="text/javascript">
            function RefreshPage(radWindowCaller) {
                __doPostBack('onclick#Refresh', 'Refresh');
            };
            function SaveFromPopUp(radWindowCaller) {
                __doPostBack('onclick#Save', 'Save');
            };
            function RealPostBack(eventTarget, eventArgument) {
                __doPostBack(eventTarget, eventArgument);
            };
            function HidePopUpWindows(radWindowCaller) {
                __doPostBack('onclick#Refresh', 'HidePopups');
            };
            function OnClientClose(sender, EventArgs) {
                __doPostBack('onclick#Refresh', 'Refresh');
            };
        </script>
    </telerik:RadScriptBlock>
    <style type="text/css">
        ul.inline-list {
            list-style: none;
            padding: 0;
            margin: 0;
        }
        ul.inline-list li {
            display:inline-block;
            margin-right: 5px;
        }
        ul.inline-list li:last-child {
            margin-right: 0;
        }
         .RadToolBar {
            max-width: 1600px!important;
            margin: 0 auto;
        }
    </style>
    <div class="no-float-menu">
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
             <td runat="Server" id="TdRadToolBarEmployeeTimeForecastComparisonDashboard" align="middle"
                valign="top" colspan="2">
                <telerik:RadToolBar ID="RadToolBarEmployeeTimeForecastComparisonDashboard" runat="server"
                    AutoPostBack="true" Width="100%">
                    <Items>
                        <telerik:RadToolBarButton ID="RadToolBarButtonFirstSeparator" runat="server" IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonBack" runat="server" SkinID="RadToolBarButtonClear"
                            Text="Back" Value="Back" ToolTip="Back to Employee Time Forecast" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonSecondSeparator" runat="server" IsSeparator="true" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </table>
    </div>
    <div class="telerik-aqua-body" style="margin-top: 5px!important;">
    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr class="ContentHeader">
            <td align="left" class="TableBorderMenuDarkGrayBottom ContentHeaderText" valign="middle"
                colspan="2">
            </td>
        </tr>
        <tr>
           
        </tr>
        <tr>
            <td colspan="2">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td>
                                <br />
                                <table align="left" border="0" cellpadding="0" cellspacing="0" width="99%">
                                    <tr>
                                        <td>
                                            <ul class="inline-list">
                                                <li>Year:</li>
                                                <li><telerik:RadComboBox ID="DropDownListYear" runat="server" AutoPostBack="true" SkinID="RadComboBoxText15"
                                                        DataTextField="Year" DataValueField="Year">
                                                    </telerik:RadComboBox></li>
                                                <li>Actualize prior to:</li>
                                                <li><telerik:RadComboBox ID="DropDownListMonth" runat="server" AutoPostBack="true" Width="100" SkinID="RadComboBoxText15"
                                                        DataTextField="Value" DataValueField="Key">
                                                    </telerik:RadComboBox></li>
                                                <li><asp:CheckBox ID="CheckBoxShowForecastedUtilization" runat="server" Checked="false"
                                                        AutoPostBack="true" Text="When actualized, show Forecasted Utilization" /></li>
                                                <li><asp:CheckBox ID="CheckBoxShowResultsForForecastedProjectsOnly" runat="server" Checked="false"
                                                        AutoPostBack="true" Text="Show results for Forecasted Projects only" /></li>
                                            </ul>
                                        </td>
                                        <td align="right" valign="middle">
                                            <asp:Label ID="LabelActualizedMonth" runat="server" Text="Actualized"></asp:Label>
                                            &nbsp;
                                            <asp:Label ID="LabelForecastedMonth" runat="server" CssClass="RequiredInput" Text="Forecasted"></asp:Label>
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
                                <br />
                                <asp:PlaceHolder ID="PlaceHolderEmployeeTimeForecastOffice" runat="server" EnableViewState="true">
                                </asp:PlaceHolder>
                                <br />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    </div>
    <telerik:RadWindowManager ID="RadWindowManager" runat="server"  >
    </telerik:RadWindowManager>
</asp:Content>
