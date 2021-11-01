<%@ Page Title="Search and Replace" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="TrafficSchedule_Replace.aspx.vb" Inherits="Webvantage.TrafficSchedule_Replace" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:Literal ID="LitScript" runat="server"></asp:Literal>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <table width="600" border="0" cellpadding="2" cellspacing="0" align="center">
            <tr>
                <td colspan="2">
                    <asp:Label   ID="LblMSG" runat="server" Text="" CssClass="warning"></asp:Label>&nbsp;
                </td>
            </tr>
            <tr id="TrGenDdl" runat="Server">
                <td width="115">
                    &nbsp;
                </td>
                <td>
                    <telerik:RadComboBox ID="DropFindAndReplaceType" runat="server" Width="450px" TabIndex="0" SkinID="RadComboBoxStandard"
                        AutoPostBack="true">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr id="TrText_SearchFor" runat="server">
                <td>
                    <asp:Label   ID="LblText_SearchFor" runat="server" Text="Search for:"></asp:Label>
                    <span>
                        <asp:HyperLink ID="HlText_SearchFor" runat="server" href="" TabIndex="-1"><span>Search for:</span></asp:HyperLink>
                    </span>
                </td>
                <td>
                    <asp:TextBox ID="TxtText_SearchFor" runat="server" CssClass="RequiredInput" TabIndex="6" SkinID="TextBoxStandard"
                        Text="" Width="447px"></asp:TextBox>
                    <asp:RadioButtonList ID="RblMatch" runat="server" CellPadding="0" CellSpacing="0"
                        RepeatDirection="Horizontal" RepeatLayout="Table" Visible="false">
                        <asp:ListItem Text="Exact" Value="exact"></asp:ListItem>
                        <asp:ListItem Text="Starts with" Value="starts_with"></asp:ListItem>
                        <asp:ListItem Text="Ends with" Value="ends_with"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr id="TrText_ReplaceWith" runat="server">
                <td>
                    <asp:Label   ID="LblText_ReplaceWith" runat="server" Text="Replace with:"></asp:Label>
                    <span>
                        <asp:HyperLink ID="HlText_ReplaceWith" runat="server" href="" TabIndex="-1"><span>Replace with:</span></asp:HyperLink>
                    </span>
                </td>
                <td>
                    <asp:TextBox ID="TxtText_ReplaceWith" runat="server" CssClass="RequiredInput" TabIndex="6" SkinID="TextBoxStandard"
                        Text="" Width="447px"></asp:TextBox>
                </td>
            </tr>
            <tr id="TrTask" runat="server">
                <td>
                    <span>
                        <asp:HyperLink ID="HlTask" runat="server" href="" TabIndex="-1"><span>Task:</span></asp:HyperLink>
                    </span>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxTask" runat="server" CssClass="RequiredInput" TabIndex="6" SkinID="TextBoxStandard"
                        Text="" Width="447px"></asp:TextBox>
                </td>
            </tr>
            <tr id="TrDate_SearchFor" runat="server">
                <td>
                    Search for:
                </td>
                <td>
                    <telerik:RadDatePicker ID="RadDatePickerSearchForStart" runat="server" 
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
                    </telerik:RadDatePicker>&nbsp;to&nbsp;
                    <telerik:RadDatePicker ID="RadDatePickerSearchForEnd" runat="server" 
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
            <tr id="TrDate_ReplaceWith" runat="server">
                <td>
                    Replace with:
                </td>
                <td>
                    <telerik:RadDatePicker ID="RadDatePickerReplaceWith" runat="server" 
                          SkinID="RadDatePickerStandard">
                        <DateInput DateFormat="d" EmptyMessage="">
                            <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                        </DateInput>
                        <Calendar ID="Calendar3" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                            <SpecialDays>
                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                </telerik:RadCalendarDay>
                            </SpecialDays>
                        </Calendar>
                    </telerik:RadDatePicker>
                </td>
            </tr>
            <tr id="TrTaskStatus_SearchFor" runat="server">
                <td>
                    <asp:Label   ID="LblTaskStatus_SearchFor" runat="server" Text="Search for:"></asp:Label>
                </td>
                <td>
                    <telerik:RadComboBox ID="DdlTaskStatus_SearchFor" runat="server" SkinID="RadComboBoxStandard">
                        <Items>
                            <telerik:RadComboBoxItem Value="P" Text="Projected"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Value="A" Text="Active"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Value="H" Text="High Priority"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Value="L" Text="Low Priority"></telerik:RadComboBoxItem>
                        </Items>
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr id="TrTaskStatus_ReplaceWith" runat="server">
                <td>
                    <asp:Label   ID="LblTaskStatus_ReplaceWith" runat="server" Text="Replace with:"></asp:Label>
                </td>
                <td>
                    <telerik:RadComboBox ID="DdlTaskStatus_ReplaceWith" runat="server" SkinID="RadComboBoxStandard">
                        <Items>
                            <telerik:RadComboBoxItem Value="P" Text="Projected"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Value="A" Text="Active"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Value="H" Text="High Priority"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Value="L" Text="Low Priority"></telerik:RadComboBoxItem>
                        </Items>
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" valign="middle">
                    <asp:HiddenField ID="HfContactCodeID_SearchFor" runat="server" />
                    <asp:HiddenField ID="HfContactCodeID_ReplaceWith" runat="server" />
                    <asp:Button ID="BtnFindAndReplace" runat="server" AccessKey="f" TabIndex="23" ToolTip="Replace all occurrences"
                        Text="Replace All" />
                    &nbsp;&nbsp;
                    <asp:Button ID="BtnClose" runat="server" AccessKey="c" TabIndex="24" ToolTip="Close this window" Visible="false"
                        Text="Close" /><br />
                    <asp:Label   ID="LblSQL" runat="server" Text="" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" valign="middle">
                    <asp:TextBox ID="TxtLog" runat="server" ReadOnly="true" TextMode="MultiLine" Width="540" SkinID="TextBoxStandard"
                        Height="100"></asp:TextBox>
                </td>
            </tr>
        </table>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
