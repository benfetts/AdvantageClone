<%@ Page Title="Employee Time Analysis" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="EmployeeTimeForecast_EmployeeTimeAnalysis.aspx.vb" Inherits="Webvantage.EmployeeTimeForecast_EmployeeTimeAnalysis" %>

<asp:Content ID="ContentEmployeeTimeForecastEmployeeTimeAnalysis" ContentPlaceHolderID="ContentPlaceHolderMain"
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
    <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
            <tr>
            <td runat="Server" id="TdRadToolbarEmployeeTimeForecastEmployeeTimeAnalysis" align="left"
                valign="top" colspan="2">
                <telerik:RadToolbar ID="RadToolbarEmployeeTimeForecastEmployeeTimeAnalysis" runat="server"
                    AutoPostBack="True" width="100%">
                    <Items>
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolbarButton  SkinID="RadToolBarButtonClear"
                            Text="Back" Value="Back"  />
                        <telerik:RadToolBarButton IsSeparator="true" />
                    </Items>
                </telerik:RadToolbar>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <table align="center" border="0" cellpadding="0" cellspacing="0" 
                        width="100%">
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td>
                                <br />
                               Year:
                                &nbsp;
                                <telerik:RadComboBox ID="DropDownListYear" runat="server" AutoPostBack="true" Width="100" SkinID="RadComboBoxStandard"
                                    DataTextField="Year" DataValueField="Year" >
                                </telerik:RadComboBox>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td width="1%">
                                &nbsp;
                            </td>
                            <td>
                                <br />
                                <asp:PlaceHolder ID="PlaceHolderEmployeeTimeForecastEmployeeTimeAnalysis" runat="server" EnableViewState="true">
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
    <telerik:RadWindowManager ID="RadWindowManager" runat="server"  >
    </telerik:RadWindowManager>
</asp:Content>
