<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopEmployeeIndirectTimeAll.ascx.vb"
    Inherits="Webvantage.DesktopEmployeeIndirectTimeAll" %>
<div class="telerik-aqua-body" style="margin-top: 5px!important">
    <table border="0" cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td >
                    <asp:ImageButton ID="ImageButtonPrint" runat="server" SkinID="ImageButtonPrint"
                        OnClientClick="window.open('dtp_np_time_emp_all.aspx', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=600,height=400,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;" />
                    <asp:ImageButton ID="ImageButtonBookmark" runat="server" ToolTip="Bookmarks" SkinID="ImageButtonBookmark"/>
                <asp:ImageButton ID="butRefresh" runat="server"  ImageAlign="AbsMiddle"
                     SkinID="ImageButtonRefresh" ToolTip="Refresh"   TabIndex="4" />
            </td>
            <td>
                <span>Start Date:</span>
                <telerik:RadDatePicker ID="RadDatePickerStartDate" runat="server"  AutoPostBack="true"
                      SkinID="RadDatePickerStandard">
                    <DateInput runat="server" DateFormat="d" EmptyMessage="Start Date">
                        <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                    </DateInput>
                    <Calendar ID="CalendarStartDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                        <SpecialDays>
                            <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                            </telerik:RadCalendarDay>
                        </SpecialDays>
                    </Calendar>
                </telerik:RadDatePicker>
                <span>End Date:</span>
                <telerik:RadDatePicker ID="RadDatePickerEndDate" runat="server"  AutoPostBack="true"
                      SkinID="RadDatePickerStandard">
                    <DateInput runat="server" DateFormat="d" EmptyMessage="End Date">
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
            <td colspan="3" align="left">
                [For Other Indirect Time]
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" GridLines="None"
                    EnableViewState="true" BorderStyle="None" EnableEmbeddedSkins="True">
                    <MasterTableView DataKeyNames="Code">
                        <Columns>
                            <telerik:GridBoundColumn DataField="Description" HeaderText="Employee Name" UniqueName="column11">
                            </telerik:GridBoundColumn>
                        </Columns>
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Resizable="False">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <DetailTables>
                            <telerik:GridTableView BorderWidth="1" AllowSorting="True" DataKeyNames="DESCRIPTION,CATEGORY,VAC_SICK_FLAG"
                                Width="100%" runat="server">
                                <Columns>
                                    <telerik:GridTemplateColumn UniqueName="colDetails">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="ImageButtonViewDetails" runat="server" ImageAlign="AbsMiddle" CssClass="icon-image" CommandName="Detail"
                                                    SkinID="ImageButtonViewWhite" ToolTip="Details" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="DESCRIPTION" HeaderText="Category" UniqueName="column2">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="DATE_STRING" HeaderText="Dates" UniqueName="column3">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="AVAIL_HRS" HeaderText="Hours Available" UniqueName="column4">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="HRS_USED" HeaderText="Hours Used" UniqueName="column5">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="VARIANCE" HeaderText="Variance" UniqueName="column6">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CATEGORY" HeaderText="" UniqueName="column7" Visible="false">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <RowIndicatorColumn Visible="False">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn Resizable="False" Visible="False">
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <EditFormSettings>
                                    <PopUpSettings ScrollBars="None" />
                                </EditFormSettings>
                            </telerik:GridTableView>
                        </DetailTables>
                        <EditFormSettings>
                            <PopUpSettings ScrollBars="None" />
                        </EditFormSettings>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
</div>

