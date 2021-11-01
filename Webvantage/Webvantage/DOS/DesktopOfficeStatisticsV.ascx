<%@ Control AutoEventWireup="false" CodeBehind="DesktopOfficeStatisticsV.ascx.vb"
    EnableViewState="True" Inherits="Webvantage.DesktopOfficeStatisticsV" Language="vb" %>
<div class="DO-ButtonHeader">
    <div style="float: left; width: 90%; text-align: left; vertical-align: middle">
        <asp:ImageButton ID="butExport" runat="server" SkinID="ImageButtonExportExcel" ToolTip="Export to Excel" />
        <asp:ImageButton ID="ImageButtonFilter" runat="server" SkinID="ImageButtonFilter" />
    </div>
    <div style="float: right; width: 10%; text-align: right;">
        <asp:ImageButton ID="butrefresh" runat="server" AlternateText="Refresh"
            SkinID="ImageButtonRefresh" ToolTip="Refresh" />
    </div>
</div>
<div class="DO-Container">
    <ew:CollapsablePanel ID="CollapsablePanelFilter" runat="server" SkinID="CollapsablePanelDesktopObjectFilter" Collapsed="true" Visible="false">
        <div style="font-size: larger; margin: -7px 0px 0px 0px !important;">
            Filter
        </div>
        <table id='TableFilterOfficeStatisticsV' align="center" border="0" cellpadding="0" cellspacing="2" width="100%">
            <tr>
                <td>
                    <asp:Label ID="Label9" runat="server">Start:</asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server">End:</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadDatePicker ID="RadDatePickerStartDate" runat="server" AutoPostBack="true"
                        SkinID="RadDatePickerStandard">
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
                <td>
                    <telerik:RadDatePicker ID="RadDatePickerEndDate" runat="server" AutoPostBack="true"
                        SkinID="RadDatePickerStandard">
                        <DateInput DateFormat="d" EmptyMessage="End Date">
                            <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                        </DateInput>
                        <Calendar ID="CalendarEndDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                            <SpecialDays>
                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                </telerik:RadCalendarDay>
                            </SpecialDays>
                        </Calendar>
                    </telerik:RadDatePicker>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server">Account Executive:</asp:Label>
                </td>
                <td>
                    <asp:Label ID="LabelManager" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadComboBox ID="ddEmployee" runat="server" AutoPostBack="true" width="220">
                    </telerik:RadComboBox>
                </td>
                <td>
                    <telerik:RadComboBox ID="ddManager" runat="server" AutoPostBack="true" width="220">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2" valign="middle">
                    <telerik:RadComboBox ID="DropTrafficFunctions" runat="server" width="220" AutoPostBack="true"
                        EnableViewState="true">
                    </telerik:RadComboBox>
                    <asp:CheckBox ID="ChkIsClosedStatus" runat="server" AutoPostBack="true" />Cancelled
                Status
                </td>
            </tr>
        </table>
    </ew:CollapsablePanel>
    <telerik:RadGrid ID="JobStatsRadGrid" runat="server" AllowSorting="True" AutoGenerateColumns="false" EnableViewState="false"
        GridLines="None" EnableEmbeddedSkins="True">
        <MasterTableView>
            <Columns>
                <telerik:GridBoundColumn DataField="OFFICE_DESCRIPT" HeaderText="Office" UniqueName="colClient">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JOBS_CREATED" HeaderText="Created" UniqueName="colCreated">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JOBS_COMPLETED" HeaderText="Completed" UniqueName="colCompleted">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JOBS_DUE" HeaderText="Due" UniqueName="colDue">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JOBS_IN_PROGRESS" HeaderText="In Progress"
                    UniqueName="colTotalInProgress">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="JOBS_CANCELLED" HeaderText="Cancelled" UniqueName="colCancelled">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                </telerik:GridBoundColumn>
            </Columns>
            <ExpandCollapseColumn Visible="False">
                <HeaderStyle Width="19px" />
            </ExpandCollapseColumn>
            <RowIndicatorColumn Visible="False">
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
        </MasterTableView>
    </telerik:RadGrid>
</div>