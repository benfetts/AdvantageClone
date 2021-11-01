<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Campaign_Print.aspx.vb"
    Inherits="Webvantage.Campaign_Print" MasterPageFile="~/ChildPage.Master" Title="Campaign Print" %>

<asp:Content ID="ContentMain" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <script type="text/javascript">
        function showhide(id) {
            if (document.getElementById) {
                obj = document.getElementById(id);
                if (obj.style.display == "none") {
                    obj.style.display = "";
                } else {
                    obj.style.display = "none";
                }
            }
        } 
    </script>
    <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
        <tr>
            <td>
                <div style="width: 100%;" id="DivToolbar" runat="server">
                    <telerik:RadToolBar ID="RadToolbarCampaignPrint" runat="server" AutoPostBack="True"
                        Width="100%">
                        <Items>
                            <telerik:RadToolBarButton IsSeparator="true" />
                            <telerik:RadToolBarButton SkinID="RadToolBarButtonPrint" Value="Print" ToolTip="Print" />
                            <telerik:RadToolBarButton SkinID="RadToolBarButtonNewAlert" Value="SendAlert" ToolTip="Send Alert" />
                            <telerik:RadToolBarButton SkinID="RadToolBarButtonNewAssignment" Value="SendAssignment" ToolTip="Send Assignment" />
                            <telerik:RadToolBarButton SkinID="RadToolBarButtonEmail" Value="SendEmail" ToolTip="Send Email" />
                            <telerik:RadToolBarButton Value="Save" ToolTip="Save Settings" SkinID="RadToolBarButtonSave" />
                            <telerik:RadToolBarButton IsSeparator="true" />
                        </Items>
                    </telerik:RadToolBar>
                </div>
            </td>
        </tr>
        <tr>
            <td class="sub-header sub-header-color">
               &nbsp;&nbsp;&nbsp;Campaign to Print
            </td>
        </tr>
        <tr>
            <td style="height: 130px">
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" valign="top" width="50%">
                            <table align="center" border="0" cellpadding="2" cellspacing="0" width="100%">
                                <tr>
                                    <td align="right" valign="middle" width="28%">
                                        <span>
                                            <asp:Label   ID="lblOffice" runat="server">Office:</asp:Label></span>
                                    </td>
                                    <td width="70%">
                                        <asp:TextBox ID="TxtOffice" runat="server" TabIndex="3" Text="" SkinID="TextBoxCodeSmall" ReadOnly="true"></asp:TextBox>&nbsp;
                                        <asp:TextBox ID="TxtOfficeDescription" runat="server" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="middle" width="28%">
                                        <span>
                                            <asp:Label   ID="lblClient" runat="server">Client:</asp:Label>
                                        </span>
                                    </td>
                                    <td width="70%">
                                        <asp:TextBox ID="TxtClientCode" runat="server" TabIndex="1" Text="" SkinID="TextBoxCodeSmall"
                                            ReadOnly="true"></asp:TextBox>&nbsp;
                                        <asp:TextBox ID="TxtClientDescription" runat="server" ReadOnly="true" TabIndex="-1"
                                            Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="middle">
                                        <span>
                                            <asp:Label   ID="lblDivision" runat="server">Division:</asp:Label></span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtDivisionCode" runat="server" TabIndex="1" Text="" SkinID="TextBoxCodeSmall"
                                            ReadOnly="true"></asp:TextBox>&nbsp;
                                        <asp:TextBox ID="TxtDivisionDescription" runat="server" ReadOnly="true" TabIndex="-1"
                                            Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="middle">
                                        <span>
                                            <asp:Label   ID="lblProduct" runat="server">Product:</asp:Label></span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TxtProductCode" runat="server" TabIndex="2" Text="" SkinID="TextBoxCodeSmall"
                                            ReadOnly="true"></asp:TextBox>&nbsp;
                                        <asp:TextBox ID="TxtProductDescription" runat="server" ReadOnly="true" TabIndex="-1"
                                            Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="middle" width="28%">
                                        <span>
                                            <asp:Label   ID="lblCampaign" runat="server">Campaign:</asp:Label></span>
                                    </td>
                                    <td width="70%">
                                        <asp:TextBox ID="TxtCmpNum" runat="server" TabIndex="5" Text="" SkinID="TextBoxCodeSmall" ReadOnly="true"></asp:TextBox>&nbsp;
                                        <asp:TextBox ID="TxtCmpDescription" runat="server" ReadOnly="true" TabIndex="-1"
                                            Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="sub-header sub-header-color">
               &nbsp;&nbsp;&nbsp;Output Format
            </td>
        </tr>
        <tr>
            <td valign="middle" style="height: 45px">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 159px;" align="right">
                            <asp:Label   ID="Label2" runat="server" Text="Report Format:"></asp:Label>
                        </td>
                        <td style="width: 432px;">
                            &nbsp;
                            <telerik:RadComboBox ID="ddReportFormat" runat="server" AutoPostBack="true" SkinID="RadComboBoxStandard">
                                <Items>
                                    <telerik:RadComboBoxItem Text="001 - Campaign Budget vs. Actual - Summary by Job with Budget Variance"
                                        Value="001"></telerik:RadComboBoxItem>
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="sub-header sub-header-color">
               &nbsp;&nbsp;&nbsp;Location
            </td>
        </tr>
        <tr>
            <td style="height: 45px">
                <table width="100%" border="0" cellpadding="2" cellspacing="0">
                    <tr>
                        <td style=" width: 200px;" align="right">
                            <asp:Label   ID="Label3" runat="server" Text="Location ID:"></asp:Label>
                        </td>
                        <td style="">
                            &nbsp;<telerik:RadComboBox ID="dl_location" runat="server" DataTextField="LOC_NAME" SkinID="RadComboBoxStandard"
                                DataValueField="LOCATION_ID">
                            </telerik:RadComboBox>
                        </td>
                        <td style=" width: 130px;" align="right">
                            <asp:Label   ID="Label6" runat="server" Text="File Format:"></asp:Label>
                        </td>
                        <td>
                            &nbsp;<telerik:RadComboBox ID="ddlFormat" runat="server" SkinID="RadComboBoxStandard">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <asp:Panel ID="pnlOptions" runat="server">
            <tr>
                <td class="sub-header sub-header-color">
                   &nbsp;&nbsp;&nbsp;Print Options
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%" border="0">
                        <tr>
                            <td align="right" valign="middle" width="300px">
                                <span>Start Posting Period:</span> &nbsp;
                            </td>
                            <td width="200px">
                                <asp:TextBox ID="TxtStartPeriod" runat="server" Width="75px" MaxLength="10" SkinID="TextBoxStandard"></asp:TextBox>
                            </td>
                            <td align="right" valign="middle" width="150px">
                                <span>Start Date:</span> &nbsp;
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="RadDatePickerStartDate" runat="server" SkinID="RadDatePickerStandard">
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
                        <tr>
                            <td align="right" valign="middle">
                                <span>End Posting Period:</span> &nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="TxtEndPeriod" runat="server" Width="75px" MaxLength="10" SkinID="TextBoxStandard"></asp:TextBox>
                            </td>
                            <td align="right" valign="middle">
                                <span>End Date:</span> &nbsp;
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="RadDatePickerEndDate" runat="server" SkinID="RadDatePickerStandard">
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
                    </table>
                </td>
            </tr>
        </asp:Panel>
        <tr>
            <td>
                <asp:Label   ID="lbl_msg" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
