<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SupervisorApproval_Timesheet.aspx.vb"
    Inherits="Webvantage.SupervisorApproval_Timesheet" MasterPageFile="~/ChildPage.Master"
    Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <style type="text/css">
   </style>
</asp:Content>
<asp:Content ID="ContentSuperAppr" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <telerik:RadScriptBlock ID="RadScriptBlock3" runat="server">
        <script type="text/javascript">
            function RadToolbarSuperApprOnClientButtonClicking(sender, args) {
                var comandName = args.get_item().get_commandName();
                if (comandName == "Search") {
                    //////args.set_cancel(!confirm('Are you sure you want to delete selected user row(s)?'));
                }
            }
        </script>
    </telerik:RadScriptBlock>
    <div class="no-float-menu">
        <telerik:RadToolBar ID="RadToolbarSuperAppr" runat="server" AutoPostBack="True" Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" Text="" Value="Save"
                    CommandName="Save" ToolTip="Save" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonFind" Text="Search" Value="Search"
                    CommandName="Search" ToolTip="Search" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="Bookmark" Value="Bookmark" ToolTip="Bookmark" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Text="Alert" Value="Alert" CommandName="Alert" ToolTip="Alert" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Value="RadToolBarButtonDropMarkAllINSTR">
                    <ItemTemplate>
                        <telerik:RadComboBox ID="DropMarkAllINSTR" runat="server" SelectedValue='<%#Eval("INSTR")%>'>
                            <Items>
                                <telerik:RadComboBoxItem Text="Approved" Value="1"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Text="Pending" Value="2"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Text="Denied" Value="3"></telerik:RadComboBoxItem>
                            </Items>
                        </telerik:RadComboBox>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Text="Mark All" Value="MarkAll" ToolTip="Mark all items with the selected approval status"
                    CommandName="MarkAll" />
                <telerik:RadToolBarButton Text="Mark Checked" Value="MarkChecked" ToolTip="Mark only checked items with the selected approval status"
                    CommandName="MarkChecked" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Text="Expand" Value="Expand" CheckOnClick="true" AllowSelfUnCheck="true" ToolTip="Expand" />
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                <div class="more-info">
                    <span>Start Date:</span>
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
                    <span>End Date:</span>
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
                    <span>Employee:</span>
                    <telerik:RadComboBox ID="ddEmployee" runat="server" AutoPostBack="true">
                    </telerik:RadComboBox>
                    <div style="padding: 8px 0px 0px 0px;">
                        Include:
                        <asp:CheckBox ID="ChkPending" runat="server" Checked="true" AutoPostBack="true" Text="Pending" />
                        <asp:CheckBox ID="ChkDenied" runat="server" Checked="true" AutoPostBack="true" Text="Denied" />
                        <asp:CheckBox ID="ChkApproved" runat="server" Checked="false" AutoPostBack="true"
                            Text="Approved" />
                        <asp:CheckBox ID="CheckBoxNotSubmitted" runat="server" Checked="false" AutoPostBack="true"
                            Text="Not Submitted" />
                    </div>

                </div>
                <div style="display:block;">
                    <telerik:RadGrid ID="RadGridTimesheetApproval" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                        TabIndex="10" AllowMultiRowEdit="True" AllowMultiRowSelection="True" AllowSorting="true">
                        <ExportSettings IgnorePaging="true" OpenInNewWindow="true" ExportOnlyData="true" HideStructureColumns="true">
                            <Pdf PageHeight="210mm" PageWidth="297mm" DefaultFontFamily="Arial Unicode MS" PageBottomMargin="20mm"
                                PageTopMargin="20mm" PageLeftMargin="20mm" PageRightMargin="20mm" />
                        </ExportSettings>
                        <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                        <ClientSettings AllowColumnHide="True" AllowExpandCollapse="True">
                            <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" UseClientSelectColumnOnly="true" />
                        </ClientSettings>
                        <MasterTableView CommandItemDisplay="Bottom" DataKeyNames="ET_ID, EMP_CODE, STATUS, EMP_DATE" Width="100%">
                            <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" ShowRefreshButton="false" ShowExportToExcelButton="true" ShowExportToWordButton="true" ShowAddNewRecordButton="false" ShowExportToPdfButton="true" />
                            <Columns>
                                <telerik:GridClientSelectColumn UniqueName="ColumnSelect">
                                    <HeaderStyle HorizontalAlign="Center" Width="5px" />
                                    <ItemStyle HorizontalAlign="Center" Width="5px" />
                                </telerik:GridClientSelectColumn>
                                <telerik:GridBoundColumn DataField="EMPLOYEE" HeaderText="Employee Name" ItemStyle-Width="200px" SortExpression="EMPLOYEE"
                                    UniqueName="colemp">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EMP_DATE" HeaderText="Date" UniqueName="colempdate" SortExpression="EMP_DATE" DataFormatString="{0:d}">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" Width="125" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="DAYOFWEEK" HeaderText="Day" UniqueName="dayofweek" SortExpression="DAYOFWEEK">
                                    <HeaderStyle />
                                    <ItemStyle Width="65" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="STATUS" Visible="false" HeaderText="Status" UniqueName="colstatus">
                                    <HeaderStyle />
                                    <ItemStyle Width="40" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="Status" UniqueName="STATUSDD">
                                    <HeaderStyle />
                                    <ItemStyle Width="100" />
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="DDSTATUS" runat="server" Width="105" InputCssClass="no-border">
                                            <Items>
                                                <telerik:RadComboBoxItem Text="Approved" Value="1"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Text="Pending" Value="2"></telerik:RadComboBoxItem>
                                                <telerik:RadComboBoxItem Text="Denied" Value="3"></telerik:RadComboBoxItem>
                                            </Items>
                                        </telerik:RadComboBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="STDHOURS" HeaderText="Standard Hours" UniqueName="colsthours">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" Width="125" />
                                     <FooterStyle HorizontalAlign="Right" />
                               </telerik:GridBoundColumn>
                                <telerik:GridNumericColumn DataField="HOURS" HeaderText="Hours" 
                                    UniqueName="colhours" SortExpression="HOURS" DataType="System.Decimal">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" Width="70" />
                                    <FooterStyle HorizontalAlign="Right" />
                                </telerik:GridNumericColumn>
                                <telerik:GridTemplateColumn DataField="APPR_NOTES" HeaderText="Approval Comments"
                                    UniqueName="APPR_NOTES">
                                    <HeaderStyle width="200" />
                                    <ItemStyle width="200" />
                                    <FooterStyle width="200" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="TxtAPPR_NOTES" runat="server" Width="200" MaxLength="254" TextMode="MultiLine" SkinID="TextBoxStandard"
                                            Wrap="true" Text='<%# Eval("APPR_NOTES") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="ET_ID" UniqueName="coletid" Visible="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EMP_CODE" UniqueName="empcode" Visible="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn DataField="MISSING_COMMENTS" HeaderText="Comments" SortExpression="MISSING_COMMENTS"
                                    UniqueName="GridBoundColumnMissingComments">
                                    <HeaderStyle width="50" />
                                    <ItemStyle width="50" />
                                    <FooterStyle width="50" />
                                    <ItemTemplate>
                                        <div id="DivMissingCommentsIndicator" class="icon-background background-color-sidebar" runat="server">
                                            <asp:Image ID="ImageMissingCommentsIndicator" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <RowIndicatorColumn Visible="False">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Resizable="true">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <DetailTables>
                                <telerik:GridTableView AllowSorting="True" runat="server">
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="CDP" HeaderText="C/D/P" UniqueName="column2">
                                            <ItemStyle HorizontalAlign="Left" Width="175" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="JOBCOMPDESC" HeaderText="Job/Component" UniqueName="column4">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="300" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="FNC_DESCRIPTION" HeaderText="Function/Category"
                                            UniqueName="column5">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="120" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="EMP_HOURS" HeaderText="Hours" UniqueName="column6">
                                            <HeaderStyle HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" Width="75" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn DataField="COMMENT" HeaderText="Time Comments" UniqueName="column6">
                                            <ItemStyle HorizontalAlign="Left" Width="120" />
                                            <ItemTemplate>
                                                <div class="ScrollArea">
                                                    <%# Eval("COMMENT") %>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                    <RowIndicatorColumn Visible="False">
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn Resizable="False" Visible="False">
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                </telerik:GridTableView>
                            </DetailTables>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
                </ContentTemplate>
            </asp:UpdatePanel>
    </div>
    
</asp:Content>
