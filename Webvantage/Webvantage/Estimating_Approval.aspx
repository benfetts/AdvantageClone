<%@ Page Title="Estimate Approval" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Estimating_Approval.aspx.vb" Inherits="Webvantage.Estimating_Approval" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <asp:Label   ID="lblMSG" runat="server" CssClass="CssRequired"></asp:Label><tr>
            <td align="left" valign="top">
                <asp:Panel ID="pnlApproved" runat="server">
                    <table width="100%" border="0" cellspacing="2" cellpadding="0">
                        <tr>
                            <td width="85">
                                Approved By:
                            </td>
                            <td>
                                <asp:TextBox ID="txtApprovedBy" runat="server" CssClass="RequiredInput" Width="300" SkinID="TextBoxStandard"
                                    MaxLength="40" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Approval Date:
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="RadDatePickerApprovalDate" runat="server" 
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
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Client P.O.:
                            </td>
                            <td>
                                <asp:TextBox ID="txtClientPO" runat="server" TabIndex="3" Width="300" SkinID="TextBoxStandard"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                Notes:
                            </td>
                            <td>
                                <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Rows="4" Width="300" SkinID="TextBoxStandard"
                                    TabIndex="4"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlApprovedInternal" runat="server">
                    <table width="100%" border="0" cellspacing="2" cellpadding="0">
                        <tr>
                            <td width="85">
                                Approved By:
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtApprovedByInternal" runat="server" CssClass="RequiredInput" Width="300" SkinID="TextBoxStandard"
                                    MaxLength="40" TabIndex="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Approval Date:
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="RadDatePickerApprovalDateInternal" runat="server" 
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
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                Notes:
                            </td>
                            <td>
                                <asp:TextBox ID="txtNotesInternal" runat="server" TextMode="MultiLine" Rows="4" Width="300" SkinID="TextBoxStandard"
                                    TabIndex="3"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <div class="centered">
                    <asp:Button ID="SaveButton" runat="server" Text="Save" TabIndex="5" />&nbsp;
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" TabIndex="6" />&nbsp;
                    <asp:Button ID="CancelButton2" runat="server" Text="Cancel" />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
