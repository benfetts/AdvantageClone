<%@ Page Title="Employee Utilization Report" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Reporting_EmployeeUtilization.aspx.vb" Inherits="Webvantage.Reporting_EmployeeUtilization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="telerik-aqua-body" style="margin-top: 5px!important">
        <table align="center" border="0" cellpadding="0" cellspacing="0"
                width="100%">
                <tr>
                    <td colspan="2">
                        <telerik:RadTabStrip ID="RadTabStrip" runat="server" MultiPageID="RadMultiPage"
                            SelectedIndex="0" Align="Left" Width="100%">
                            <Tabs>
                                <telerik:RadTab Text="Options">
                                </telerik:RadTab>
                                <telerik:RadTab Text="Printing">
                                </telerik:RadTab>
                            </Tabs>
                        </telerik:RadTabStrip>
                        <telerik:RadMultiPage ID="RadMultiPage" runat="server" SelectedIndex="0" Width="100%">
                            <telerik:RadPageView ID="RadPageViewOptions" runat="server">
                                <table align="left" border="0" cellpadding="0" cellspacing="0"
                                    width="100%">
                                    <tr>
                                        <td>
                                            <table width="500px" border="0" cellspacing="2" cellpadding="0"> 
                                                <tr>
                                                    <td width="10%">Report:
                                                    </td>
                                                    <td width="30%" colspan="3">
                                                        <telerik:RadComboBox ID="RadComboBoxReport" runat="server" Width="275"
                                                            AutoPostBack="true" DataTextField="Name" DataValueField="Value">
                                                        </telerik:RadComboBox>
                                                    </td>
                                                </tr>                                  
                                                <tr>
                                                    <td width="10%">From:
                                                    </td>
                                                    <td width="30%">
                                                        <telerik:RadDatePicker ID="RadDatePickerFrom" runat="server" AutoPostBack="true" SkinID="RadDatePickerStandard">
                                                        </telerik:RadDatePicker>
                                                    </td>
                                                    <td width="10%">
                                                        <telerik:RadButton ID="RadButtonYTD" runat="server" AutoPostBack="true" ButtonType="StandardButton"
                                                            Text="YTD">
                                                        </telerik:RadButton>
                                                    </td>
                                                    <td>
                                                        <telerik:RadButton ID="RadButton1Year" runat="server" AutoPostBack="true" ButtonType="StandardButton"
                                                            Text="1 Year">
                                                        </telerik:RadButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">To:
                                                    </td>
                                                    <td width="30%">
                                                        <telerik:RadDatePicker ID="RadDatePickerTo" runat="server" AutoPostBack="true" SkinID="RadDatePickerStandard">
                                                        </telerik:RadDatePicker>
                                                    </td>
                                                    <td width="10%">
                                                        <telerik:RadButton ID="RadButtonMTD" runat="server" AutoPostBack="true" ButtonType="StandardButton"
                                                            Text="MTD">
                                                        </telerik:RadButton>
                                                    </td>
                                                    <td>
                                                        <telerik:RadButton ID="RadButton2Years" runat="server" AutoPostBack="true" ButtonType="StandardButton"
                                                            Text="2 Year">
                                                        </telerik:RadButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="10%">
                                                        &nbsp;
                                                    </td>
                                                    <td width="30%" colspan="2">
                                                        <asp:CheckBox id="CheckboxLimitWIP" runat="server" Text="Limit WIP to End Date"/>
                                                    </td>
                                                    <td>     
                                                        &nbsp;                                           
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="1%">&nbsp;
                                        </td>
                                        <td>
                                            <table width="500px" border="0" cellspacing="2" cellpadding="0">
                                                <tr>
                                                    <td align="left" width="15%" valign="top">Group By:
                                                    </td>
                                                    <td width="30%">
                                                        <asp:RadioButton id="RadioButtonEmployee" runat="server" Text="Employee" GroupName="Group"/><br />
                                                        <asp:RadioButton id="RadioButtonEmployeeDate" runat="server" Text="Employee/Date" GroupName="Group"/><br />
                                                        <asp:RadioButton id="RadioButtonEmployeePeriod" runat="server" Text="Employee/Period" GroupName="Group" />
                                                    </td>
                                                    <td width="10%">
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <div class="no-float-menu">
                                    <telerik:RadToolBar ID="RadToolBarOptions" runat="server" AutoPostBack="true" Width="100%">
                                        <Items>
                                            <telerik:RadToolBarButton ID="RadToolBarButtonFourthSeparator" runat="server" IsSeparator="true" />
                                            <telerik:RadToolBarButton ID="RadToolBarButtonSave" runat="server" SkinID="RadToolBarButtonSave"
                                                Text="" Value="Save" CommandName="Save" ToolTip="Save Template" />
                                            <telerik:RadToolBarButton ID="RadToolBarButtonFifthSeparator" runat="server" IsSeparator="true" />
                                            <telerik:RadToolBarButton ID="RadToolBarButtonSaveAs" runat="server" Text="Save As"
                                                Value="SaveAs" CommandName="SaveAs" ToolTip="Save Template As..." />
                                            <telerik:RadToolBarButton ID="RadToolBarButtonSecondSeparator" runat="server" IsSeparator="true" />
                                            <telerik:RadToolBarButton ID="RadToolBarButtonCustomizeColumns" runat="server" Text="Customize Columns"
                                                Value="CustomizeColumns" CommandName="CustomizeColumns" ToolTip="Customize Columns" />
                                            <telerik:RadToolBarButton ID="RadToolBarButtonSeventhSeparator" runat="server" IsSeparator="true" />
                                            <telerik:RadToolBarButton ID="RadToolBarButtonShowViewCaption" runat="server" CheckOnClick="true"
                                                Text="Show View Caption" Value="ShowViewCaption" CommandName="ShowViewCaption"
                                                ToolTip="Show View Caption" AllowSelfUnCheck="true" Group="1" />
                                            <telerik:RadToolBarButton ID="RadToolBarButtonEightSeparator" runat="server" IsSeparator="true" />
                                            <telerik:RadToolBarButton ID="RadToolBarButtonShowGroupByBox" runat="server" CheckOnClick="true"
                                                Text="Show Group By Box" Value="ShowGroupByBox" CommandName="ShowGroupByBox"
                                                ToolTip="Show Group By Box" AllowSelfUnCheck="true" Group="2" />
                                            <telerik:RadToolBarButton ID="RadToolBarButtonNinthSeparator" runat="server" IsSeparator="true" />
                                            <telerik:RadToolBarButton ID="RadToolBarButtonShowFilterEditor" runat="server" Text="Show Filter Editor"
                                                Value="ShowFilterEditor" CommandName="ShowFilterEditor" ToolTip="Show Filter Editor" />
                                            <telerik:RadToolBarButton ID="RadToolBarButtonTenthSeparator" runat="server" IsSeparator="true" />
                                            <telerik:RadToolBarButton ID="RadToolBarButtonShowAutoFilterRow" runat="server" CheckOnClick="true"
                                                Text="Show Auto Filter Row" Value="ShowAutoFilterRow" CommandName="ShowAutoFilterRow"
                                                ToolTip="Show Auto Filter Row" AllowSelfUnCheck="true" Group="4" />
                                            <telerik:RadToolBarButton ID="RadToolBarButtonEleventhSeparator" runat="server" IsSeparator="true" />
                                            <telerik:RadToolBarButton ID="RadToolBarButtonRefresh" runat="server" Text="Load Data" Value="Refresh" CommandName="Refresh" ToolTip="Load Data" />
                                            <telerik:RadToolBarButton ID="RadToolBarButtonTwelvthSeparator" runat="server" IsSeparator="true" />
                                        </Items>
                                    </telerik:RadToolBar>
                                </div>
                                
                            </telerik:RadPageView>
                            <telerik:RadPageView ID="RadPageViewPrinting" runat="server">
                                <telerik:RadToolBar ID="RadToolBarPrinting" runat="server" AutoPostBack="true" Width="100%">
                                    <Items>
                                        <telerik:RadToolBarButton ID="RadToolBarButtonPrintingFirstSeparator" runat="server"
                                            IsSeparator="true" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonPrintToPDF" runat="server" Text="To PDF"
                                            Value="ToPDF" CommandName="ToPDF" ToolTip="Print To PDF" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonPrintingSecondSeparator" runat="server"
                                            IsSeparator="true" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonPrintToXLS" runat="server" Text="To XLS"
                                            Value="ToXLS" CommandName="ToXLS" ToolTip="Print To XLS" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonPrintToXLSValue" runat="server" Text="To XLS (Value)"
                                            Value="ToXLSValue" CommandName="ToXLSValue" ToolTip="Print To XLS (Value)" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonPrintingThirdSeparator" runat="server"
                                            IsSeparator="true" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonPrintToXLSX" runat="server" Text="To XLSX"
                                            Value="ToXLSX" CommandName="ToXLSX" ToolTip="Print To XLSX" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonPrintToXLSXValue" runat="server" Text="To XLSX (Value)"
                                            Value="ToXLSXValue" CommandName="ToXLSXValue" ToolTip="Print To XLSX (Value)" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonPrintingFourthSeparator" runat="server"
                                            IsSeparator="true" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonPrintToRTF" runat="server" Text="To RTF"
                                            Value="ToRTF" CommandName="ToRTF" ToolTip="Print To RTF" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonPrintingFifthSeparator" runat="server"
                                            IsSeparator="true" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonPrintToCSV" runat="server" Text="To CSV"
                                            Value="ToCSV" CommandName="ToCSV" ToolTip="Print To CSV" />
                                        <telerik:RadToolBarButton ID="RadToolBarButtonPrintingSixthSeparator" runat="server"
                                            IsSeparator="true" />
                                    </Items>
                                </telerik:RadToolBar>
                            </telerik:RadPageView>
                        </telerik:RadMultiPage>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <br />
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                            <dx:ASPxGridView ID="ASPxGridViewDynamicReport" runat="server" Width="100%" Settings-ShowHorizontalScrollBar="True"
                                Settings-ShowTitlePanel="False" Settings-ShowVerticalScrollBar="False" Settings-EnableFilterControlPopupMenuScrolling="True"
                                Settings-ShowGroupFooter="VisibleIfExpanded" EnableCallbackCompression="false" SettingsPager-PageSize="25" SettingsBehavior-AutoExpandAllGroups="false">

                                <ClientSideEvents ContextMenu="function(s, e) {if(e.objectType == 'header') 
                                                                                  headerMenu.ShowAtPos(ASPxClientUtils.GetEventX(e.htmlEvent), ASPxClientUtils.GetEventY(e.htmlEvent));}" />
                                <SettingsBehavior ColumnResizeMode="Control" />
                                <SettingsDetail ExportMode="All" />
                                <Styles AlternatingRow-Wrap="False" DetailCell-Wrap="False" DetailRow-Wrap="False" Row-Wrap="False" SelectedRow-Wrap="False" Table-Wrap="False">
                                    <Header Font-Names="Arial" />
                                </Styles>

                            </dx:ASPxGridView>
                            <dx:ASPxGridViewExporter ID="ASPxGridViewExporter" runat="server" GridViewID="ASPxGridViewDynamicReport">
                            </dx:ASPxGridViewExporter>
                </ContentTemplate>
            </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
    </div>
    

</asp:Content>
