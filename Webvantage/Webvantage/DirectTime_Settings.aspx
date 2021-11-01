<%@ Page Title="Direct Time Report Settings" Language="vb" AutoEventWireup="false"
    MasterPageFile="~/ChildPage.Master" CodeBehind="DirectTime_Settings.aspx.vb"
    Inherits="Webvantage.DirectTime_Settings" %>



    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <style type="text/css">
            .rlbItem
            {
                text-align: left !important;
                
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" cssClass="" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="telerik-aqua-body" style="margin-top: 5px !important;">
            <div >
                    <telerik:RadTabStrip ID="RadTabStripDirectTime" runat="server" AutoPostBack="True"
                    CausesValidation="False" MultiPageID="RadMPDirectTime" Width="100%">
                    <Tabs>
                        <telerik:RadTab ID="TabSel" runat="server" PageViewID="RadPVSelection" Text="Selection">
                        </telerik:RadTab>
                        <telerik:RadTab ID="TabFilter" runat="server" PageViewID="RadPVFilter" Text="Filter">
                        </telerik:RadTab>
                        <telerik:RadTab ID="TabDisplay" runat="server" PageViewID="RadPVDisplay" Text="Display">
                        </telerik:RadTab>
                        <telerik:RadTab ID="TabSorting" runat="server" PageViewID="RadPVSort" Text="Sort">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="RadMPDirectTime" runat="server" SelectedIndex="0" Width="100%"> 
                    <telerik:RadPageView ID="RadPVSelection" runat="server" Width="100%">            
                        <table id="Table1" align="center" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="center" class="sub-header sub-header-color ">
                                    Selection Options
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:RadioButtonList ID="optCDP" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="a">All</asp:ListItem>
                                        <asp:ListItem Value="c">Client</asp:ListItem>
                                        <asp:ListItem Value="d">Division</asp:ListItem>
                                        <asp:ListItem Value="p">Product</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <br />
                                    <asp:Panel ID="pnlClient" runat="server" HorizontalAlign="Center" Width="">
                                        <telerik:RadListBox ID="lstClient" runat="server" Height="300px" SelectionMode="Multiple"
                                            Width="550px">
                                        </telerik:RadListBox>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlDivision" runat="server" HorizontalAlign="Center" Width="">
                                        <telerik:RadListBox ID="lstDivision" runat="server" Height="300px" SelectionMode="Multiple"
                                            Width="550px">
                                        </telerik:RadListBox>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlProduct" runat="server" HorizontalAlign="Center" Width="">
                                        <telerik:RadListBox ID="lstProduct" runat="server" Height="300px" SelectionMode="Multiple"
                                            Width="550px">
                                        </telerik:RadListBox>
                                    </asp:Panel>
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPVFilter" runat="server" Width="100%">            
                        <table id="Table2" align="center" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="center" class="sub-header sub-header-color ">
                                    Filter Options
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="right" style="width: 147px; height: 14px;" valign="top">
                                                &nbsp;
                                            </td>
                                            <td align="right" valign="top">
                                                &nbsp;
                                            </td>
                                            <td align="right" valign="top">
                                                &nbsp;
                                            </td>
                                            <td align="right" valign="top">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 147px; height: 100px" valign="top">
                                                Product Category:
                                            </td>
                                            <td align="left" style="height: 100px" valign="top">
                                                <telerik:RadListBox ID="lstProdCat" runat="server" DisableTextboxEntry="False" Height="100px"
                                                    SelectionMode="Multiple" Width="250px">
                                                </telerik:RadListBox>
                                            </td>
                                            <td align="right" style="height: 100px" valign="top">
                                                Function:
                                            </td>
                                            <td align="left" style="height: 100px" valign="top">
                                                <telerik:RadListBox ID="lstFunctions" runat="server" DisableTextboxEntry="False"
                                                    Height="100px" SelectionMode="Multiple" Width="250px">
                                                </telerik:RadListBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 147px" valign="top">
                                                &nbsp;
                                            </td>
                                            <td align="left" valign="top">
                                            </td>
                                            <td align="right" valign="top">
                                            </td>
                                            <td align="left" valign="top">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 147px" valign="top">
                                                Employee:
                                            </td>
                                            <td align="left" valign="top">
                                                <telerik:RadListBox ID="lstEmployee" runat="server" DisableTextboxEntry="False" Height="100px"
                                                    SelectionMode="Multiple" Width="250px">
                                                </telerik:RadListBox><br />
                                                <asp:CheckBox ID="CheckboxShowTerminatedEmployees" runat="server" Text="Show Terminated Employees" AutoPostBack="true" />
                                            </td>
                                            <td align="right" valign="top">
                                                Job Number:
                                            </td>
                                            <td align="left" valign="top">
                                                <telerik:RadListBox ID="lstJobNumber" runat="server" DisableTextboxEntry="False"
                                                    Height="100px" SelectionMode="Multiple" Width="250px">
                                                </telerik:RadListBox><br />
                                                <asp:CheckBox ID="CheckboxShowClosedJobs" runat="server" Text="Show Closed Jobs" AutoPostBack="true" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 147px" valign="top">
                                                &nbsp;
                                            </td>
                                            <td>
                                            </td>
                                            <td align="right" valign="top">
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 147px" valign="top">
                                                Billable:
                                            </td>
                                            <td align="left">
                                                <telerik:RadComboBox ID="ddBillable" runat="server" Width="200px" SkinID="RadComboBoxStandard">
                                                    <Items>
                                                        <telerik:RadComboBoxItem Value="a" Text="All"></telerik:RadComboBoxItem>
                                                        <telerik:RadComboBoxItem Value="b" Text="Billable"></telerik:RadComboBoxItem>
                                                        <telerik:RadComboBoxItem Value="n" Text="Non Billable"></telerik:RadComboBoxItem>
                                                    </Items>
                                                </telerik:RadComboBox>
                                            </td>
                                            <td align="right" valign="top">
                                                Billed:
                                            </td>
                                            <td align="left">
                                                <telerik:RadComboBox ID="ddBilled" runat="server" Width="200px" SkinID="RadComboBoxStandard">
                                                    <Items>
                                                        <telerik:RadComboBoxItem Value="a" Text="All"></telerik:RadComboBoxItem>
                                                        <telerik:RadComboBoxItem Value="b" Text="Billed"></telerik:RadComboBoxItem>
                                                        <telerik:RadComboBoxItem Value="n" Text="Not Billed"></telerik:RadComboBoxItem>
                                                    </Items>
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4">
                                                Start Date:
                                                <telerik:RadDatePicker ID="RadDatePickerStartDate" runat="server" 
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
                                                &nbsp;End Date:
                                                <telerik:RadDatePicker ID="RadDatePickerEndDate" runat="server" 
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
                                            <td align="center" colspan="4">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPVDisplay" runat="server" Width="100%">
                        <table id="Table3" align="center" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="center" class="sub-header sub-header-color ">
                                    Display Options
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                            <td align="left" width="370">
                                                Available Fields
                                                <br />
                                                <telerik:RadListBox ID="RadListBoxDisplayAvailableFields" runat="server" Height="200px"
                                                    SelectionMode="Multiple" AllowTransfer="true" AutoPostBackOnTransfer="true" TransferMode="Copy"
                                                    TransferToID="RadListBoxDisplayFieldsToDisplay" Width="250px">
                                                </telerik:RadListBox>
                                            </td>
                                            <td align="left" width="326">
                                                Fields to Display
                                                <br />
                                                <telerik:RadListBox ID="RadListBoxDisplayFieldsToDisplay" runat="server" Height="200px"
                                                    SelectionMode="Multiple" AllowReorder="true" TransferMode="Copy" Width="250px">
                                                </telerik:RadListBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <asp:CheckBox ID="chkSaveSettings" runat="server" AutoPostBack="True" Checked="True"
                                        Text="Save My Display Options" />
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPVSort" runat="server" Width="100%">
                        <table id="Table4" align="center" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="center" class="sub-header sub-header-color ">
                                    Sort Options
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                            <td align="left" width="369">
                                                Available Sort Fields<br />
                                                <telerik:RadListBox ID="RadListBoxSortAvailableFields" runat="server" Height="200px"
                                                    SelectionMode="Multiple" AllowTransfer="true" TransferToID="RadListBoxSortFieldsToSort"
                                                    Width="250px">
                                                </telerik:RadListBox>
                                            </td>
                                            <td align="left" width="327">
                                                Fields to Sort By
                                                <telerik:RadListBox ID="RadListBoxSortFieldsToSort" runat="server" Height="200px"
                                                    SelectionMode="Multiple" AllowReorder="true" Width="250px">
                                                </telerik:RadListBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
                <table id="Table5" align="center" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="center" class="sub-header sub-header-color" >
                            Run Report
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <br />Format:&nbsp;
                            <telerik:RadComboBox ID="RadComboBoxFormat" runat="server" Width="110" SkinID="RadComboBoxMonth">
                                <Items>
                                    <telerik:RadComboBoxItem Text="XLS" Value="XLS" Selected="true"/>
                                    <telerik:RadComboBoxItem Text="XLSX" Value="XLSX" />
                                    <telerik:RadComboBoxItem Text="CSV" Value="CSV" />                        
                                </Items>
                            </telerik:RadComboBox>
                            <br />
                            <br />
                            <asp:Button ID="butExport" runat="server" Text="Export" />
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
                <asp:LinkButton ID="blank" runat="server" CausesValidation="false"></asp:LinkButton>
                <asp:TextBox ID="txtCurrentTab" runat="server" Visible="False" SkinID="TextBoxStandard"></asp:TextBox>
                <asp:TextBox ID="txtCDPCompareString" runat="server" Visible="False" SkinID="TextBoxStandard"></asp:TextBox>
                <asp:Panel ID="pnlSelection" runat="server" HorizontalAlign="Center" Width="100%">
                </asp:Panel>
                <asp:Panel ID="pnlFilter" runat="server" HorizontalAlign="Center" Width="100%">
                </asp:Panel>
                <asp:Panel ID="pnlDisplay" runat="server" HorizontalAlign="Center" Width="100%">
                </asp:Panel>
                <asp:Panel ID="pnlSort" runat="server" HorizontalAlign="Center" Width="100%">
                </asp:Panel>
                </div>    
    </div>
    
</asp:Content>

