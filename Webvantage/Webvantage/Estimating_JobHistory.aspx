<%@ Page AutoEventWireup="false" CodeBehind="Estimating_JobHistory.aspx.vb" Inherits="Webvantage.Estimating_JobHistory"
    MasterPageFile="~/ChildPage.Master" Title="" Language="vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div style="padding: 10px 0px 0px 0px">
        <asp:Label ID="lblMSG" runat="server" CssClass="warning" Text=""></asp:Label>
        <div>
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:HyperLink ID="HlClient" runat="server" href="">Client:</asp:HyperLink>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtClientCode" runat="server" MaxLength="6" TabIndex="1" Text=""
                        SkinID="TextBoxCodeSmall"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtClientDescription" runat="server" ReadOnly="true" TabIndex="-1"
                        Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:HyperLink ID="HlDivision" runat="server" href="">Division:</asp:HyperLink>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtDivisionCode" runat="server" MaxLength="6" TabIndex="2" Text=""
                        SkinID="TextBoxCodeSmall"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtDivisionDescription" runat="server" ReadOnly="true" TabIndex="-1"
                        Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:HyperLink ID="HlProduct" runat="server" href="">Product:</asp:HyperLink>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtProductCode" runat="server" MaxLength="6" TabIndex="3" Text=""
                        SkinID="TextBoxCodeSmall"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtProductDescription" runat="server" ReadOnly="true" TabIndex="-1"
                        Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    <asp:HyperLink ID="HlJobType" runat="server" TabIndex="-1" href="">Job Type:</asp:HyperLink>
                </div>
                <div class="code-description-code">
                    <asp:TextBox ID="TxtJobType" runat="server" CssClass="RequiredInput" TabIndex="4"
                        Text="" SkinID="TextBoxCodeSmall" MaxLength="10"></asp:TextBox>
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtJobTypeDescription" runat="server" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Job Cutoff Date:
                </div>
                <div class="code-description-description">
                    <telerik:RadDatePicker ID="RadDatePickerJobCutOffDate" runat="server"
                        SkinID="RadDatePickerStandard">
                        <DateInput DateFormat="d" EmptyMessage="">
                            <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                        </DateInput>
                        <Calendar ID="Calendar1" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                            <SpecialDays>
                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                </telerik:RadCalendarDay>
                            </SpecialDays>
                        </Calendar>
                    </telerik:RadDatePicker>
                    to
                        <telerik:RadDatePicker ID="RadDatePickerToDate" runat="server"
                            SkinID="RadDatePickerStandard">
                            <DateInput DateFormat="d" EmptyMessage="">
                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                            </DateInput>
                            <Calendar ID="Calendar2" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                <SpecialDays>
                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                    </telerik:RadCalendarDay>
                                </SpecialDays>
                            </Calendar>
                        </telerik:RadDatePicker>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                </div>
                <div class="code-description-description">
                    <asp:CheckBox ID="cbShowClosed" runat="server" Text="Closed/Archived Only" />
                    <asp:HiddenField ID="hfjobs" runat="server" />
                    <asp:HiddenField ID="hfcomps" runat="server" />
                    <asp:HiddenField ID="hfcount" runat="server" />
                    <asp:HiddenField ID="hfestclient" runat="server" />
                    <asp:HiddenField ID="hfestdivision" runat="server" />
                    <asp:HiddenField ID="hfestproduct" runat="server" />
                    <asp:HiddenField ID="hfestjob" runat="server" />
                    <asp:HiddenField ID="hfestcomp" runat="server" />
                    <asp:HiddenField ID="hfsalesclass" runat="server" />
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                </div>
                <div class="code-description-description">
                    <asp:Button ID="BtnRefresh" runat="server" Text="Refresh" />&nbsp;&nbsp;
                            <asp:Button ID="btnGetHistory" runat="server" Text="Get Job History" />
                    &nbsp;&nbsp;
                            <asp:Button ID="BtnCopy" runat="server" Text="Add Functions" CommandName="AddFunctions" />&nbsp;&nbsp;
                            <asp:ImageButton ID="butExport" runat="server" SkinID="ImageButtonExportExcel" />
                </div>
            </div>

        </div>

    </div>
    <div>
        <telerik:RadTabStrip ID="SummaryTabs" runat="server" AutoPostBack="True" CausesValidation="False"
            Width="100%">
            <Tabs>
                <telerik:RadTab ID="Tab1" runat="server" Text="Root Tab">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <asp:Panel ID="pnlJH" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td>
                        <telerik:RadGrid ID="RadGridJobHistory" runat="server" AllowMultiRowSelection="True"
                            AllowSorting="False" AutoGenerateColumns="False" EnableAJAX="False" GridLines="None"
                            Width="99%" Height="470px">
                            <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                            <ClientSettings EnablePostBackOnRowClick="False">
                                <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                                <Scrolling AllowScroll="True" ScrollHeight="100%" />
                            </ClientSettings>
                            <MasterTableView DataKeyNames="JOB_NUMBER,JOB_COMPONENT_NBR">
                                <Columns>
                                    <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                        <HeaderStyle HorizontalAlign="center" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </telerik:GridClientSelectColumn>
                                    <telerik:GridBoundColumn DataField="CL_NAME" HeaderText="Client" UniqueName="colCL_NAME"
                                        MaxLength="30">
                                        <HeaderStyle HorizontalAlign="left" />
                                        <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="JOB_NUMBER" HeaderText="Job" UniqueName="colJOB_NUMBER">
                                        <HeaderStyle HorizontalAlign="left" />
                                        <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="JOB_DESC" HeaderText="Description" UniqueName="colJOB_DESC">
                                        <HeaderStyle HorizontalAlign="left" />
                                        <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="JOB_COMPONENT_NBR" HeaderText="Component" UniqueName="colJOB_COMPONENT_NBR">
                                        <HeaderStyle HorizontalAlign="left" />
                                        <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="JOB_COMP_DESC" HeaderText="Description" UniqueName="colJOB_COMP_DESC">
                                        <HeaderStyle HorizontalAlign="left" />
                                        <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="JOB_COMP_DATE" HeaderText="Date Opened" UniqueName="colJOB_COMP_DATE">
                                        <HeaderStyle HorizontalAlign="left" />
                                        <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
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
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlQva" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td>
                        <telerik:RadGrid ID="RadGridQvASummary" runat="server" EnableAJAX="true" AutoGenerateColumns="False"
                            EnableOutsideScripts="True" FooterStyle- GridLines="None" GroupingSettings-GroupByFieldsSeparator="  "
                            Height="500px" PageSize="12" ShowFooter="true" UseEmbeddedScripts="false" Width="98%"
                            AllowMultiRowSelection="True">
                            <PagerStyle Mode="NextPrevAndNumeric" />
                            <ExportSettings FileName="QvA_Summary" IgnorePaging="True" OpenInNewWindow="True">
                                <Pdf PageTitle="QvA_Summary" Title="QvA_Summary" />
                            </ExportSettings>
                            <MasterTableView HorizontalAlign="Left" DataKeyNames="FNC_CODE">
                                <RowIndicatorColumn Visible="False">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn Visible="False" Resizable="False">
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect" Exportable="False">
                                        <HeaderStyle HorizontalAlign="center" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </telerik:GridClientSelectColumn>
                                    <telerik:GridBoundColumn DataField="FNC_DESC" FooterText="Total:" HeaderText="Function Description"
                                        UniqueName="FNC_DESC">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Left" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <FooterStyle />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FNC_TYPE" HeaderText="Function Type"
                                        UniqueName="FNC_TYPE">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="QuotedAmount" HeaderText=" Quote Amount"
                                        UniqueName="QuotedAmount" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="QuotedMarkup" HeaderText=" Quote Markup"
                                        UniqueName="QuotedMarkup" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="QuotedTax" HeaderText=" Quote Tax"
                                        UniqueName="QuotedTax" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="QuotedQtyHrs" HeaderText=" Quote Qty/Hrs"
                                        UniqueName="QuotedQtyHrs" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="QuotedTotal" HeaderText=" Quote Total"
                                        UniqueName="QuotedTotal" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ActualAmount" HeaderText=" Actual Amount"
                                        UniqueName="ActualAmount" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ActualMarkup" HeaderText=" Actual Markup"
                                        UniqueName="ActualMarkup" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ActualTax" HeaderText=" Actual Tax"
                                        UniqueName="ActualTax" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ActualHours" HeaderText=" Actual Qty/Hrs"
                                        UniqueName="ActualHours" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PERCENT_QUOTE" HeaderText=" % of Quote"
                                        UniqueName="PercentOfQuote" DataFormatString="{0:#,##0.00}%">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ActualTotal" HeaderText=" Actual Total"
                                        UniqueName="ActualTotal" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NBActualTotal" HeaderText=" Non-Billable Total"
                                        UniqueName="NBActualTotal" Display="False" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="OpenPONetAmt" HeaderText=" Open PO Net Amount"
                                        UniqueName="OpenPONetAmount" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" Width="50px" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="50px" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="APPROVED_AMT" HeaderText=" Billing Approved (Pending)"
                                        UniqueName="APPROVED_AMT" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" Width="50px" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="50px" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BilledToDate" HeaderText=" Billed To Date"
                                        UniqueName="BilledToDate" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="QuotedvsActualPO" HeaderText=" Quote vs Actual/PO"
                                        UniqueName="QuotevsActualPO" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ActualPOvsBilled" HeaderText=" Actual/PO vs Billed"
                                        UniqueName="ActualPOvsBilled" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Qva" UniqueName="Qva" Visible="False">
                                        <HeaderStyle VerticalAlign="Bottom" />
                                        <ItemStyle VerticalAlign="Middle" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Avb" UniqueName="Avb" Visible="False">
                                        <HeaderStyle VerticalAlign="Bottom" />
                                        <ItemStyle VerticalAlign="Middle" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="QvaPO" UniqueName="QvaPO" Visible="False">
                                        <HeaderStyle VerticalAlign="Bottom" />
                                        <ItemStyle VerticalAlign="Middle" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="AvbPO" UniqueName="AvbPO" Visible="False">
                                        <HeaderStyle VerticalAlign="Bottom" />
                                        <ItemStyle VerticalAlign="Middle" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="AdvBilled" UniqueName="AdvBilled" Visible="False">
                                        <HeaderStyle VerticalAlign="Bottom" />
                                        <ItemStyle VerticalAlign="Middle" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="POTotal" HeaderText="POTotal" UniqueName="POTotal"
                                        Visible="False">
                                        <HeaderStyle VerticalAlign="Bottom" />
                                        <ItemStyle VerticalAlign="Middle" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="POApplied" HeaderText="POApplied" UniqueName="POApplied"
                                        Visible="False">
                                        <HeaderStyle VerticalAlign="Bottom" />
                                        <ItemStyle VerticalAlign="Middle" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NBTax" UniqueName="NBTax" Visible="False">
                                        <HeaderStyle VerticalAlign="Bottom" />
                                        <ItemStyle VerticalAlign="Middle" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NBMarkup" UniqueName="NBMarkup" Visible="False">
                                        <HeaderStyle VerticalAlign="Bottom" />
                                        <ItemStyle VerticalAlign="Middle" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NBAmount" UniqueName="NBAmount" Visible="False">
                                        <HeaderStyle VerticalAlign="Bottom" />
                                        <ItemStyle VerticalAlign="Middle" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FNC_CODE" FooterText="Total:" HeaderText="" UniqueName="FNC_CODE"
                                        Visible="false">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Left" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <FooterStyle />
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <FilterItemStyle VerticalAlign="Middle" Wrap="False" />
                            </MasterTableView>
                            <AlternatingItemStyle VerticalAlign="Middle" />
                            <FilterItemStyle HorizontalAlign="Left" Wrap="False" />
                            <ClientSettings AllowColumnsReorder="false">
                                <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                                <Scrolling AllowScroll="True" ScrollHeight="100%" />
                            </ClientSettings>
                            <GroupingSettings GroupByFieldsSeparator=" " />
                            <FooterStyle />
                        </telerik:RadGrid>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlFilter" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td>
                        <table align="left" width="100%" cellspacing="0">
                            <tr>
                                <td align="left" valign="top" style="vertical-align: top; text-align: left; width: 35%;">
                                    <table id="Table3" align="left" cellpadding="2" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="center" class="sub-header sub-header-color">Job List
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table width="100%">
                                                    <tr>
                                                        <td align="left">
                                                            <telerik:RadGrid ID="QvaRadgridJob" runat="server" AllowMultiRowSelection="True"
                                                                AllowSorting="False" AutoGenerateColumns="False" EnableAJAX="False" GridLines="None"
                                                                Width="98%">
                                                                <StatusBarSettings LoadingText="Loading Data" ReadyText="Data Loaded." />
                                                                <ClientSettings EnablePostBackOnRowClick="False">
                                                                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                                                                </ClientSettings>
                                                                <MasterTableView DataKeyNames="JOB_NUMBER,JOB_COMPONENT_NBR">
                                                                    <Columns>
                                                                        <telerik:GridBoundColumn DataField="JOB_NUMBER" HeaderText="Job" UniqueName="colJOB_NUMBER">
                                                                            <HeaderStyle HorizontalAlign="left" />
                                                                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="JOB_COMPONENT_NBR" HeaderText="Component" UniqueName="colJOB_COMPONENT_NBR">
                                                                            <HeaderStyle HorizontalAlign="left" />
                                                                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="JOB_COMP_DESC" HeaderText="Description" UniqueName="colJOB_COMPONENT_NBR">
                                                                            <HeaderStyle HorizontalAlign="left" />
                                                                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="JOB_COMP_DATE" HeaderText="Date" UniqueName="colJOB_COMP_DATE">
                                                                            <HeaderStyle HorizontalAlign="left" />
                                                                            <ItemStyle HorizontalAlign="left" VerticalAlign="middle" />
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
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="vertical-align: top; text-align: left; width: 1%;"></td>
                                <td align="left" valign="top" style="vertical-align: top; text-align: left; width: 35%;">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                                        <table id="Table4" align="left" cellpadding="2" cellspacing="0" width="100%">
                                            <tr>
                                                <td align="center" class="sub-header sub-header-color">Non Billable Breakout Options
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="100%" id="filter-panel-breakout">
                                                        <tr>
                                                            <td>
                                                                <asp:RadioButton ID="rbIncludeNB" runat="server" AutoPostBack="true" GroupName="NonBillable"
                                                                    Text="Include Non Billable" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RadioButton ID="rbBreakoutAllNB" runat="server" AutoPostBack="true" GroupName="NonBillable"
                                                                    Text="Breakout All Non Billable" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RadioButton ID="rbBreakoutNBForFT" runat="server" AutoPostBack="true" GroupName="NonBillable"
                                                                    Text="Breakout Non Billable For Function Types" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbEmployeeTime"
                                                                runat="server" AutoPostBack="true" Text="Employee Time" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbIncomeOnly" runat="server"
                                                                AutoPostBack="true" Text="Income Only" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cbVendor" runat="server"
                                                                AutoPostBack="true" Text="Vendor" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                </ContentTemplate>
            </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <table id="Table9" align="center" cellpadding="2" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="center" colspan="3" valign="top">
                                                <br />
                                                <br />
                                                <asp:Button ID="butClear" runat="server" Text="Clear" />&nbsp;&nbsp;
                                                    <asp:Button ID="butOk" runat="server" Text="Save" /><br />
                                                <br />
                                                <br />
                                                <asp:Label ID="lblError" runat="server" CssClass="warning"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <asp:Literal ID="LitScript" runat="server"></asp:Literal>
</asp:Content>
