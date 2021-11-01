<%@ Page AutoEventWireup="false" CodeBehind="JobTemplate_Print.aspx.vb" Inherits="Webvantage.JobTemplate_Print"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Print Job" %>

<%@ Register Src="ReportTypeUC.ascx" TagName="Report_Type" TagPrefix="uc2" %>
<%@ Register Src="UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>
<asp:Content ID="ContentMain" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
    <div class="telerik-aqua-body">

            <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
                <tr>
                    <td>
                        <div id="DivToolBar" runat="server" style="width: 100%;">
                            <telerik:RadToolBar ID="ToolbarRadToolbar" runat="server" AutoPostBack="True" Width="100%">
                                <Items>
                                    <telerik:RadToolBarButton SkinID="RadToolBarButtonPrint" Value="Print" ToolTip="Print" />
                                    <telerik:RadToolBarButton SkinID="RadToolBarButtonNewAlert" Value="SendAlert" ToolTip="Send Alert" />
                                    <telerik:RadToolBarButton SkinID="RadToolBarButtonNewAssignment" Value="SendAssignment" ToolTip="Send Assignment" />
                                    <telerik:RadToolBarButton SkinID="RadToolBarButtonEmail" Value="SendEmail" ToolTip="Send Email" />
                                    <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" ToolTip="Save Settings" Value="Save" />
                                    <telerik:RadToolBarButton IsSeparator="true" />
                                    <telerik:RadToolBarButton SkinID="RadToolBarButtonClear" Text="Back" Value="Back" Visible="false" />
                                    <telerik:RadToolBarButton IsSeparator="true" />
                                </Items>
                            </telerik:RadToolBar>
                        </div>
                    </td>
                </tr>
                <asp:Panel ID="PanelHeader" runat="server">
                    <tr>
                        <td class="sub-header sub-header-color">&nbsp;&nbsp;&nbsp;Job to Print
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td align="right" style="width: 72px;">Client:
                                    </td>
                                    <td style="">
                                        <asp:Label ID="lblClient" runat="server"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 133px;">Job:
                                    </td>
                                    <td style="">
                                        <asp:Label ID="lblJobNum" runat="server"></asp:Label>&nbsp;-&nbsp;
                                    <asp:Label ID="LabelJobDescription" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 72px">Division:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDivision" runat="server"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 133px">Job Component:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblJobCompNum" runat="server"></asp:Label>&nbsp;-&nbsp;
                                    <asp:Label ID="LabelJobComponentDescription" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 72px">Product:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblProduct" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </asp:Panel>
                <tr>
                    <td class="sub-header sub-header-color">&nbsp;&nbsp;&nbsp;Location
                    </td>
                </tr>
                <tr>
                    <td style="height: 45px">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="right" style="width: 159px;">
                                    <asp:Label ID="Label3" runat="server" Text="Location ID:"></asp:Label>
                                </td>
                                <td>&nbsp;<telerik:RadComboBox ID="dl_location" runat="server" DataTextField="LOC_NAME" SkinID="RadComboBoxStandard"
                                    DataValueField="LOCATION_ID" Width="329px">
                                </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="sub-header sub-header-color">&nbsp;&nbsp;&nbsp;Output Format
                    </td>
                </tr>
                <tr>
                    <td style="height: 210px">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="right" style="width: 159px;">
                                    <asp:Label ID="Label5" runat="server" Text="Report Format:"></asp:Label>&nbsp;
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="ddReportFormat" runat="server" AutoPostBack="true" Width="329px" SkinID="RadComboBoxStandard">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="001 - Standard Job Order Form" Value=""></telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="002 - Job Order with Budget Total" Value="002"></telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="003 - Job Order with Budget by Type" Value="003"></telerik:RadComboBoxItem>
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 159px;">
                                    <asp:Label ID="Label6" runat="server" Text="Signature Format:"></asp:Label>&nbsp;
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="ddSignature" runat="server" Width="329px" SkinID="RadComboBoxStandard">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="001 - Client Approval" Value="1"></telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="002 - Agency Approval" Value="2"></telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="003 - Agency/Client Approval" Value="3"></telerik:RadComboBoxItem>
                                            <telerik:RadComboBoxItem Text="004 - None" Value="4"></telerik:RadComboBoxItem>
                                        </Items>
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 159px;">
                                    <asp:Label ID="Label1" runat="server" Text="Format:"></asp:Label>&nbsp;
                                </td>
                                <td>
                                    <uc2:Report_Type ID="Reporttype1" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 159px;">
                                    <asp:Label ID="Label7" runat="server" Text="Report Title:"></asp:Label>&nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxJobOrderTitle" runat="server" Width="526px" MaxLength="30" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 159px;">&nbsp;
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbUsePrintedDate" runat="server" Text="Use Printed Date" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 159px;">&nbsp;
                                </td>
                                <td>
                                    <asp:Panel ID="pnlDate" runat="server">
                                        <table cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>Date:&nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="RadDatePickerPODate" runat="server" SkinID="RadDatePickerStandard">
                                                        <DateInput DateFormat="d" EmptyMessage="Start Date">
                                                            <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                        </DateInput>
                                                        <Calendar ID="CalendarStartDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                                            <SpecialDays>
                                                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                                                </telerik:RadCalendarDay>
                                                            </SpecialDays>
                                                        </Calendar>
                                                    </telerik:RadDatePicker>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="sub-header sub-header-color">&nbsp;&nbsp;&nbsp;Print Options
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%">
                            <tr>
                                <td style="width: 50px">&nbsp;
                                </td>
                                <td class="sub-header sub-header-color" colspan="2">
                                    <asp:Label ID="lbJobOF" runat="server" Text="Report Title Placement:"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px"></td>
                                <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rbReportLeft" runat="server" GroupName="Report"
                                    Text="Left" />
                                    &nbsp;<asp:RadioButton ID="rbReportRight" runat="server" GroupName="Report" Text="Right" />
                                    &nbsp;<asp:RadioButton ID="rbReportCenter" runat="server" GroupName="Report" Text="Center" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px"></td>
                                <td class="sub-header sub-header-color" colspan="2">
                                    <asp:Label ID="lblJobOrderForm" runat="server" Text="Job Order Form:"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px"></td>
                                <td colspan="2">
                                    <asp:CheckBox ID="cbJobOrderForm" runat="server" Text="Include Job Order Form" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px"></td>
                                <td colspan="2">
                                    <asp:CheckBox ID="cbOmitEmptyFields" runat="server"
                                        Text="Omit Empty Fields" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px"></td>
                                <td class="sub-header sub-header-color" colspan="2">
                                    <asp:Label ID="Label2" runat="server" Text="Traffic Assignments:"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px"></td>
                                <td align="left" colspan="2">
                                    <asp:CheckBox ID="cbTrafficAssignments" runat="server"
                                        Text="Traffic Assignments (Include on Job Order Form)" Width="336px" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px"></td>
                                <td align="right" style="width: 145px">Section Title:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTrafficAssignmentsTitle" runat="server" MaxLength="30" Width="526px" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px"></td>
                                <td class="sub-header sub-header-color" colspan="2">
                                    <asp:Label ID="Label4" runat="server" Text="Schedule:"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px"></td>
                                <td align="left" colspan="2">
                                    <asp:CheckBox ID="cbTrafficSchedule" runat="server"
                                        Text="Schedule (Include on Job Order Form)" Width="336px" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px"></td>
                                <td align="right" style="width: 145px">Section Title:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTrafficScheduleTitle" runat="server" MaxLength="30" SkinID="TextBoxStandard"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px"></td>
                                <td colspan="2">
                                    <asp:CheckBox ID="cbScheduleComments" runat="server"
                                        Text="Schedule Comments" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px"></td>
                                <td colspan="2">
                                    <asp:CheckBox ID="cbDueDatesOnly" runat="server" Text="Due Dates Only" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px"></td>
                                <td colspan="2">
                                    <asp:CheckBox ID="cbMilestonesOnly" runat="server"
                                        Text="Milestones Only" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px"></td>
                                <td align="right" style="width: 145px">Title:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMilestoneTitle" runat="server" MaxLength="30" SkinID="TextBoxStandard"
                                        Width="472px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50px"></td>
                                <td colspan="2">
                                    <asp:CheckBox ID="cbEmployeeAssignments" runat="server"
                                        Text="Employee Assignments" />
                                </td>
                            </tr>
                            <asp:Panel ID="PanelCB" runat="server">
                                <tr>
                                    <td colspan="3" class="sub-header sub-header-color">&nbsp;&nbsp;&nbsp;Creative Brief:
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px"></td>
                                    <td colspan="2">
                                        <asp:CheckBox ID="cbPrintCreativeBrief" runat="server" Text="Print Creative Brief"
                                            Width="162px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px"></td>
                                    <td colspan="2">
                                        <asp:CheckBox ID="CBOmitEmptyFieldsCB" runat="server" Text="Omit Empty Fields" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px"></td>
                                    <td colspan="2">
                                        <asp:CheckBox ID="cbApproveOnlyCB" runat="server" Text="Approved Only" Width="153px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px"></td>
                                    <td align="right" style="width: 145px">Report Title:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtReportTitleCB" runat="server" Width="526px" MaxLength="30" SkinID="TextBoxStandard"></asp:TextBox>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <asp:Panel ID="PanelJS" runat="server">
                                <tr>
                                    <td colspan="3" class="sub-header sub-header-color">&nbsp;&nbsp;&nbsp;Job Specifications:
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px"></td>
                                    <td colspan="2">
                                        <asp:CheckBox ID="cbPrintJobSpecs" runat="server" Text="Print Job Specifications"
                                            Width="229px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px"></td>
                                    <td colspan="2">
                                        <asp:CheckBox ID="CBOmitEmptyFieldsJS" runat="server" Text="Omit Empty Fields" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px"></td>
                                    <td colspan="2">
                                        <asp:CheckBox ID="cbApprovedOnlyJS" runat="server" Text="Approved Only" Width="153px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px"></td>
                                    <td colspan="2">
                                        <asp:CheckBox ID="cbIncludeVendorSpecs" runat="server" Text="Include Vendor Section"
                                            Width="153px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px"></td>
                                    <td colspan="2">
                                        <asp:CheckBox ID="cbIncludeMediaSpecs" runat="server" Text="Include Media Specifications"
                                            Width="187px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px"></td>
                                    <td align="right" style="width: 145px">Report Title:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtReportTitleJS" runat="server" Width="526px" MaxLength="30" SkinID="TextBoxStandard"></asp:TextBox>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <asp:Panel ID="PanelJV" runat="server">
                                <tr>
                                    <td colspan="3" class="sub-header sub-header-color">&nbsp;&nbsp;&nbsp;Job Versions:
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px"></td>
                                    <td colspan="2">
                                        <asp:CheckBox ID="cbPrintJobVersions" runat="server" Text="Print Job Versions" Width="229px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 50px"></td>
                                    <td colspan="2">
                                        <asp:CheckBox ID="CBOmitEmptyFieldsJV" runat="server" Text="Omit Empty Fields" />
                                    </td>
                                </tr>
                            </asp:Panel>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_msg" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
    </div>
    
</asp:Content>
