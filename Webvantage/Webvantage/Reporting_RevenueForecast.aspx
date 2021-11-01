<%@ Page Title="Revenue Forecast Report" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Reporting_RevenueForecast.aspx.vb" Inherits="Webvantage.Reporting_RevenueForecast" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="ContentJobDetailAnalysis" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">
        <div >
            <telerik:RadToolBar ID="RadToolBarJobDetailAnalysis" runat="server" AutoPostBack="true"
                Width="100%">
                <Items>
                    <telerik:RadToolBarButton ID="RadToolBarButtonFirstSeparator" runat="server" IsSeparator="true" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonView" runat="server" SkinID="RadToolBarButtonPrint"
                        Text="View" Value="View" ToolTip="View Report" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonThirdSeparator" runat="server" IsSeparator="true" />
                </Items>
            </telerik:RadToolBar>
        </div>
        <div >
        </div>
        <ew:CollapsablePanel ID="CollapsablePanelReportOptions" runat="server" TitleText="Report Options">
        <div style="margin-top: 10px;">
        <div class="form-layout label-left label-l">
            <ul>
                <li>Starting Post Period:</li>
                <li><telerik:RadComboBox ID="RadComboBoxStart" runat="server" AutoPostBack="false" SkinID="RadComboBoxPostPeriod"></telerik:RadComboBox></li>
                <li style="margin-left: 20px;"><telerik:RadButton ID="RadButtonYTD" runat="server" AutoPostBack="true" ButtonType="StandardButton" Text="YTD"></telerik:RadButton></li>
                <li><telerik:RadButton ID="RadButton1Year" runat="server" AutoPostBack="true" ButtonType="StandardButton" Text="1 Year"></telerik:RadButton></li>
            </ul>
            <ul>
                <li>Ending Post Period:</li>
                <li><telerik:RadComboBox ID="RadComboBoxEnd" runat="server" AutoPostBack="false" SkinID="RadComboBoxPostPeriod"></telerik:RadComboBox></li>
                <li style="margin-left: 20px;"><telerik:RadButton ID="RadButtonMTD" runat="server" AutoPostBack="true" ButtonType="StandardButton" Text="MTD"></telerik:RadButton></li>
            </ul>
            <ul>
                <li>Current Period:</li>
                <li><telerik:RadComboBox ID="RadComboBoxCurrent" runat="server" AutoPostBack="false" SkinID="RadComboBoxPostPeriod"></telerik:RadComboBox></li>
            </ul>
            <ul>
                <li>Display Option:</li>
                <li><asp:RadioButton id="RadioButtonWeek" runat="server" Text="Report by Week" GroupName="Display" AutoPostBack="true"/>
                                <asp:RadioButton id="RadioButtonMonth" runat="server" Text="Report by Month" GroupName="Display" AutoPostBack="true"/>
                                <asp:RadioButton id="RadioButtonActualize" runat="server" Text="Actualize as of date" GroupName="Display" AutoPostBack="true"/>
                                <telerik:RadDatePicker ID="RadDatePickerActual" runat="server" AutoPostBack="true" SkinID="RadDatePickerStandard"></telerik:RadDatePicker></li>
            </ul>
            <ul>
                <li>Location:</li>
                <li><telerik:RadComboBox ID="RadComboBoxLocation" runat="server" DataTextField="Name" DataValueField="ID" SkinID="RadComboBoxText40" AutoPostBack="true">
                    </telerik:RadComboBox></li>
            </ul>
        </div> 
    </div>
        </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanelSelectOffice" runat="server" 
                        TitleText="Select Office">
                        <table width="99%" border="0" cellspacing="2" cellpadding="0">
                            <tr>
                                <td align="left" valign="bottom">
                                    <telerik:RadButton ID="RadButtonAllOffices" runat="server" ToggleType="Radio" ButtonType="ToggleButton"
                                        Checked="true" GroupName="Office" AutoPostBack="true" Text="All Offices" Font-Underline="false">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="RadButtonChooseOffices" runat="server" ToggleType="Radio"
                                        ButtonType="ToggleButton" Checked="false" GroupName="Office" AutoPostBack="true"
                                        Text="Choose Offices" Font-Underline="false">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    <telerik:RadListBox ID="RadListBoxOffices" runat="server" Width="100%" AutoPostBack="false"
                                        Height="200" SelectionMode="Multiple" AllowReorder="False" EnableDragAndDrop="false"
                                        DataValueField="Code" DataTextField="Name" Enabled="false">
                                    </telerik:RadListBox>
                                </td>
                            </tr>
                        </table>
         </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanelSelectSalesClass" runat="server" 
                        TitleText="Select Sales Class" >
                        <table width="99%" border="0" cellspacing="2" cellpadding="0">
                            <tr>
                                <td align="left" valign="bottom">
                                    <telerik:RadButton ID="RadButtonAllSalesClasses" runat="server" ToggleType="Radio"
                                        ButtonType="ToggleButton" Checked="true" GroupName="SalesClasses" AutoPostBack="true"
                                        Text="All Sales Classes" Font-Underline="false">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="RadButtonChooseSalesClasses" runat="server" ToggleType="Radio"
                                        ButtonType="ToggleButton" Checked="false" GroupName="SalesClasses" AutoPostBack="true"
                                        Text="Choose Sales Classes" Font-Underline="false">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top">
                                    <telerik:RadListBox ID="RadListBoxSalesClasses" runat="server" Width="100%" AutoPostBack="false"
                                        Height="200" SelectionMode="Multiple" AllowReorder="False" EnableDragAndDrop="false"
                                        DataValueField="Code" DataTextField="Description" Enabled="false">
                                    </telerik:RadListBox>
                                </td>
                            </tr>
                        </table>
                    </ew:CollapsablePanel>
    
</asp:Content>
