<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SupervisorApproval_Expense.aspx.vb"
    Inherits="Webvantage.SupervisorApproval_Expense" MasterPageFile="~/ChildPage.Master"
    Title="" %>

<asp:Content ID="ContentSuperAppr" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <script type="text/javascript">

        function realPostBack(eventTarget, eventArgument) {
            __doPostBack(eventTarget, eventArgument);
        }

        function HidePopUpWindows(radWindowCaller) {
            __doPostBack('onclick#Refresh', 'HidePopups');
        }

    </script>
    <style>
        .RadForm input[type="checkbox"], .RadForm input[type="radio"], .RadForm input[type="checkbox"][checked], .RadForm input[type="radio"][checked] {
            height: 16px!important;
        }
    </style>
    <div class="no-float-menu">
        <telerik:RadToolBar ID="RadToolbarSuperAppr" runat="server" AutoPostBack="True" Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" Text="" Value="Save"
                    ToolTip="Save" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonFind" Text="Search" Value="Search"
                    ToolTip="Search" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Text="Alert" Value="Alert" ToolTip="Alert" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Value="RadToolbarButtonDropMarkAllINSTR">
                    <ItemTemplate>
                        <telerik:RadComboBox ID="DropMarkAllINSTR" runat="server" SelectedValue='<%#Eval("INSTR")%>'>
                            <Items>
                                <telerik:RadComboBoxItem Text="Approved" Value="2"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Text="Pending" Value="0"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Text="Denied" Value="1"></telerik:RadComboBoxItem>
                            </Items>
                        </telerik:RadComboBox>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Text="Mark All" Value="MarkAll" ToolTip="Mark all items with the selected approval status" />
                <telerik:RadToolBarButton Text="Mark Checked" Value="MarkChecked" ToolTip="Mark only checked items with the selected approval status" />
                <telerik:RadToolBarButton IsSeparator="true" />
                 <telerik:RadToolBarButton Text="Expand" Value="Expand"
                    ToolTip="Expand" CheckOnClick="true" AllowSelfUnCheck="true" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="Bookmark" Value="Bookmark" ToolTip="Bookmark" />

               
            </Items>
        </telerik:RadToolBar>
    </div>
  
    <div class="telerik-aqua-body">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
            <div class="more-info">
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
                &nbsp;&nbsp; <span>End Date:</span>
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
                &nbsp;&nbsp;<span>Employee:</span>
                <telerik:RadComboBox ID="ddEmployee" runat="server" TabIndex="5" AutoPostBack="true" Width="300">
                </telerik:RadComboBox>
                &nbsp;&nbsp;
            <asp:CheckBox ID="ChkPending" runat="server" Checked="true" AutoPostBack="true"
                TabIndex="6" />Pending&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="ChkDenied" runat="server" Checked="true" AutoPostBack="true" TabIndex="7" />Denied
            &nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="ChkApproved" runat="server" Checked="false" AutoPostBack="true"
                TabIndex="8" />Approved
            </div>
            <telerik:RadGrid ID="RadGridExpenseApproval" runat="server" AutoGenerateColumns="False" TabIndex="10"
                AllowMultiRowEdit="True" AllowMultiRowSelection="True" GridLines="None" BorderStyle="None">
                <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                <ClientSettings AllowColumnHide="True" AllowExpandCollapse="True">
                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" UseClientSelectColumnOnly="true" />
                </ClientSettings>
                <MasterTableView DataKeyNames="INV_NBR, STATUS, APPROVED_FLAG,EMP_CODE">
                    <Columns>
                        <telerik:GridClientSelectColumn UniqueName="ColumnSelect">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5px" />
                        </telerik:GridClientSelectColumn>
                        <telerik:GridBoundColumn DataField="EMPLOYEE" HeaderText="Employee" UniqueName="EMPLOYEE">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="150"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="150"></ItemStyle>
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="INV_NBR" HeaderText="Invoice Number" UniqueName="INV_NBR">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="70" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="70" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="INV_DATE" HeaderText="Report Date" UniqueName="INV_DATE" DataFormatString="{0:d}">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="70" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="70" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="EXP_DESC" Visible="true" ItemStyle-Wrap="true"
                            HeaderText="Description" UniqueName="EXP_DESC">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="colComments">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div id="DivShowComments" runat="server" class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImageButtonShowComments" runat="server" SkinID="ImageButtonCommentWhite" CommandArgument='<%#Eval("INV_NBR")%>' CommandName="ShowComments" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="TOTALEXPENSE" HeaderText="Total<br />Expense"
                            UniqueName="TOTALEXPENSE" DataFormatString="{0:n}">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="70" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="70" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TOTALPAYABLE" HeaderText="Total<br />Payable"
                            UniqueName="TOTALPAYABLE" DataFormatString="{0:n}">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="70" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="70" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="STATUS" Visible="false" UniqueName="STATUS">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="APPROVED_FLAG" Visible="false" UniqueName="APPROVED_FLAG">
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn HeaderText="Status" UniqueName="STATUSDD">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="70" />
                            <ItemTemplate>
                                <telerik:RadComboBox ID="DDSTATUS" runat="server" Width="110" InputCssClass="no-border">
                                    <Items>
                                        <telerik:RadComboBoxItem Text="Approved" Value="2"></telerik:RadComboBoxItem>
                                        <telerik:RadComboBoxItem Text="Pending" Value="0"></telerik:RadComboBoxItem>
                                        <telerik:RadComboBoxItem Text="Denied" Value="1"></telerik:RadComboBoxItem>
                                    </Items>
                                </telerik:RadComboBox>
                                <asp:Label ID="LabelPendingInAccounting" runat="server" Text="Pending Approval in Accounting" Visible="false" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="DocumentLink">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div id="DivDocuments" class="icon-background background-color-sidebar">
                                    <asp:LinkButton ID="LinkButtonDocuments" runat="server" CssClass="icon-text" CommandArgument='<%#Eval("INV_NBR")%>' CommandName="ShowDocs" ToolTip="Download receipts">D</asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="DocumentLink">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div id="DivViewDocuments" class="icon-background background-color-sidebar">
                                    <asp:LinkButton ID="LinkButtonViewDocuments" runat="server" CssClass="icon-text" CommandArgument='<%#Eval("INV_NBR")%>' CommandName="ViewDocs" ToolTip="View receipts">V</asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn DataField="APPR_NOTES" HeaderText="Approval Comments"
                            UniqueName="APPR_NOTES">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="200" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="200" />
                            <ItemTemplate>
                                <asp:TextBox ID="TxtAPPR_NOTES" runat="server" Width="200" MaxLength="254" TextMode="MultiLine" SkinID="TextBoxStandard"
                                    Wrap="true" Text='<%# Eval("APPR_NOTES") %>'></asp:TextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="EMP_CODE" UniqueName="EMP_CODE" Visible="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="DOC_COUNT" UniqueName="DOC_COUNT" Visible="false">
                        </telerik:GridBoundColumn>
                    </Columns>
                    <RowIndicatorColumn Visible="False">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Resizable="true">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <DetailTables>
                        <telerik:GridTableView BorderWidth="1" AllowSorting="false" Width="100%" runat="server">
                            <Columns>
                                <telerik:GridBoundColumn DataField="ITEM_DATE" HeaderText="Item Date" UniqueName="ITEM_DATE">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="70" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="70" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CDP" HeaderText="C/D/P" UniqueName="column2">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="JOBCOMPDESC" HeaderText="Job/Component" UniqueName="column4">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FNC_DESCRIPTION" HeaderText="Function/Category"
                                    UniqueName="column5">
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="QTY" HeaderText="Quantity" UniqueName="QTY" DataFormatString="{0:n}">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="70" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="70" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="RATE" HeaderText="Rate" UniqueName="RATE" DataFormatString="{0:n}">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="70" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="70" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="AMOUNT" HeaderText="Amount" UniqueName="AMOUNT"
                                    DataFormatString="{0:n}">
                                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="70" />
                                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="70" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CC_FLAG" Visible="false" UniqueName="CC_FLAG">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="CC" UniqueName="CCCheckbox2">
                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                    <ItemStyle CssClass="radgrid-icon-column" />
                                    <FooterStyle CssClass="radgrid-icon-column" />
                                    <ItemTemplate>
                                        <div class="icon-background standard-green" style='<%# If(Eval("CC_FLAG") = True, "display:block;", "display:none;")%>'>
                                            <asp:Image ID="ImageCC" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="CCBillable" ItemStyle-HorizontalAlign="Center"
                                    HeaderText="Non<br />Billable">
                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                    <ItemStyle CssClass="radgrid-icon-column" />
                                    <FooterStyle CssClass="radgrid-icon-column" />
                                    <ItemTemplate>
                                        <div id="DivCCBillable" runat="server" class="icon-background standard-green">
                                            <asp:Image ID="ImageCCBillable" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="PAYABLE" HeaderText="Total Payable" UniqueName="PAYABLE">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Right" Width="75px" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ITEM_DESC" HeaderText="Description" UniqueName="ITEM_DESC">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
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
                </ContentTemplate>
            </asp:UpdatePanel>
    </div>
    
</asp:Content>
