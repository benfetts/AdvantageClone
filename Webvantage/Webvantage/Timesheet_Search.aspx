<%@ Page Title="Find Time" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Timesheet_Search.aspx.vb" Inherits="Webvantage.Timesheet_Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="no-float-menu">
        <telerik:RadToolBar ID="RadToolbarTimesheetSearch" runat="server" AutoPostBack="true"
            Width="100%">
            <Items>
                <telerik:RadToolBarButton Value="Status">
                    <ItemTemplate>
                        &nbsp;&nbsp;Show
                        <telerik:RadComboBox ID="RadComboBoxStatus" runat="server" Width="135" AutoPostBack="true">
                        </telerik:RadComboBox>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Value="StartDate">
                    <ItemTemplate>
                        From
                        <telerik:RadDatePicker ID="RadDatePickerStartDate" runat="server" SkinID="RadDatePickerStandard"
                            AutoPostBack="true">
                            <DateInput DateFormat="d" EmptyMessage="Start Date">
                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                            </DateInput>
                            <Calendar ID="CalendarStartDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                            </Calendar>
                        </telerik:RadDatePicker>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Value="EndDate">
                    <ItemTemplate>
                        To
                        <telerik:RadDatePicker ID="RadDatePickerEndDate" runat="server" SkinID="RadDatePickerStandard"
                            AutoPostBack="true">
                            <DateInput DateFormat="d" EmptyMessage="End Date">
                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                            </DateInput>
                            <Calendar ID="CalendarEndDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                            </Calendar>
                        </telerik:RadDatePicker>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolbarButtonSearch" SkinID="RadToolBarButtonFind"
                    Text="" Value="Search" ToolTip="Search" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <telerik:RadGrid ID="RadGridTimesheetSearch" runat="server" ShowFooter="False" AutoGenerateColumns="False"
                        AllowSorting="true" GridLines="None" EnableEmbeddedSkins="True">
                        <MasterTableView AutoGenerateColumns="False" DataKeyNames="Date,Status" AllowMultiColumnSorting="true">
                            <Columns>
                                <telerik:GridTemplateColumn DataField="Date" DataType="System.DateTime" HeaderText="Day"
                                    SortExpression="Date" UniqueName="ColDayDisplay">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButtonDayDisplay" runat="server" Text='<%# CType(Eval("Date"), Date).ToLongDateString() %>'
                                            CommandName="OpenTimesheetDay" CommandArgument='<%# CType(Eval("Date"), Date).ToShortDateString() %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="left" Width="200" />
                                    <ItemStyle HorizontalAlign="left" Width="200" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="StatusText" DataType="System.String" HeaderText="Status"
                                    ReadOnly="True" SortExpression="StatusText" UniqueName="GridBoundColumnStatusText">
                                    <HeaderStyle HorizontalAlign="left" Width="90" />
                                    <ItemStyle HorizontalAlign="left" Width="90" />
                                    <ItemTemplate>
                                        <asp:Label ID="LabelStatus" runat="server" Text='<%# Eval("StatusText") %>'></asp:Label>
                                        <asp:LinkButton ID="LinkButtonStatus" runat="server" Text='<%# Eval("StatusText") %>'
                                            CommandArgument='<%# CType(Eval("Date"), Date).ToShortDateString() %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="TotalHours" DataType="System.Decimal" HeaderText="Hours"
                                    ReadOnly="True" SortExpression="TotalHours" UniqueName="ColHours">
                                    <HeaderStyle HorizontalAlign="right" Width="70" />
                                    <ItemStyle HorizontalAlign="right" Width="70" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PercentCompletedOfDailyHours" DataType="System.Decimal" DataFormatString="{0:p}" 
                                    HeaderText="%" ReadOnly="True" SortExpression="PercentCompletedOfDailyHours"
                                    UniqueName="GridBoundColumnPercentCompletedOfDailyHours">
                                    <HeaderStyle HorizontalAlign="right" Width="70" />
                                    <ItemStyle HorizontalAlign="right" Width="70" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="DailyHours" DataType="System.Decimal" HeaderText="Daily Hrs." Visible="false"
                                    ReadOnly="True" SortExpression="DailyHours" UniqueName="GridBoundColumnDailyHours">
                                    <HeaderStyle HorizontalAlign="right" Width="70" />
                                    <ItemStyle HorizontalAlign="right" Width="70" />
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </div>
    
</asp:Content>
