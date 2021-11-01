<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Event_Generator.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="Event Generator" Inherits="Webvantage.Event_Generator" %>

<%@ Register Src="Event_Type.ascx" TagName="EventType" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <asp:Literal ID="LitScript" runat="server"></asp:Literal>
        <table width="670" border="0" cellpadding="2" cellspacing="0" align="center">
            <tr>
                <td colspan="2">
                    <asp:Label   ID="LblMSG" runat="server" Text="" CssClass="warning"></asp:Label>&nbsp;
                </td>
            </tr>
            <tr id="TrGenDdl" runat="Server">
                <td width="150">
                    &nbsp;
                </td>
                <td width="480">
                    <telerik:RadComboBox ID="DropEventGenerators" runat="server" Width="450px" TabIndex="0" SkinID="RadComboBoxStandard"
                        AppendDataBoundItems="true" AutoPostBack="true">
                    </telerik:RadComboBox>
                    <asp:ImageButton ID="ImageButtonDeleteGenerator" runat="server" ImageAlign="AbsMiddle"
                        SkinID="ImageButtonDelete" />
                </td>
            </tr>
            <tr id="TrLastGen" runat="Server">
                <td>
                    Last generated:
                </td>
                <td>
                    <asp:Label   ID="LblLastGen" runat="server" Text="&nbsp;"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Event Description:
                </td>
                <td>
                    <asp:TextBox ID="TxtShortDesc" runat="server" Width="450px" MaxLength="50" CssClass="RequiredInput" SkinID="TextBoxStandard"
                        TabIndex="1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left" valign="top">
                    Event Comment:
                </td>
                <td align="left" valign="top">
                    <asp:TextBox ID="TxtLongDesc" runat="server" Height="66px" TextMode="MultiLine" Width="450px" SkinID="TextBoxStandard"
                        TabIndex="2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left" valign="top">
                    Event Type:
                </td>
                <td align="left" valign="top">
                    <uc1:EventType runat="server" ID="UcEventType" TabIndex="3" />
                </td>
            </tr>
            <tr>
                <td>
                    <span>
                        <asp:HyperLink ID="HlFunctionCode" runat="server" href="" TabIndex="-1"><span>Function Code:</span></asp:HyperLink>
                    </span>
                </td>
                <td>
                    <asp:TextBox ID="TxtFunctionCode" runat="server" MaxLength="6" CssClass="RequiredInput" SkinID="TextBoxStandard"
                        TabIndex="4" Text="" Width="63px"></asp:TextBox>
                    <asp:TextBox ID="TxtFunctionCodeDescription" runat="server" ReadOnly="true" TabIndex="-1"
                        Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left" valign="top">
                    <span>
                        <asp:HyperLink ID="HlAdNumber" runat="server" TabIndex="-1" href=""><span>Ad Number:</span></asp:HyperLink>
                    </span>
                </td>
                <td align="left" valign="top">
                    <asp:TextBox ID="TxtAdNumber" runat="server" TabIndex="5" Text="" Width="275px" MaxLength="30" SkinID="TextBoxStandard"></asp:TextBox>
                    <asp:TextBox ID="TxtAdNumberColor" runat="server" ReadOnly="true" Visible="False" SkinID="TextBoxStandard"
                        Width="15px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left" valign="top">
                    Ad Number Description:
                </td>
                <td align="left" valign="top">
                    <asp:TextBox ID="TxtAdNumberDescription" runat="server" ReadOnly="true" TextMode="MultiLine"
                        Height="45px" TabIndex="-1" Width="275px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Quantity Type:
                </td>
                <td>
                    <asp:RadioButtonList ID="RblQuantityType" runat="server" RepeatDirection="Horizontal"
                        TabIndex="6" RepeatColumns="2" RepeatLayout="Flow">
                        <asp:ListItem Text="Event" Value="0" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Hours" Value="1"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="IWalkTheLine">
                   Dates:
                </td>
            </tr>
            <tr>
                <td>
                    Start Date:
                </td>
                <td>
                    <telerik:RadDatePicker ID="RadDatePickerStartDate" runat="server" 
                          SkinID="RadDatePickerStandard">
                        <DateInput DateFormat="d" EmptyMessage="Start Date" CssClass="RequiredInput">
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
                <td>
                    <asp:RadioButton ID="RbEndDate_Occur" runat="server" GroupName="RbGrpEndDate" AutoPostBack="true"
                        TabIndex="8" />End After:
                </td>
                <td>
                    <asp:TextBox ID="TxtOccur" runat="server" Width="37px" TabIndex="9" MaxLength="3" SkinID="TextBoxStandard"
                        Style="text-align: right;"></asp:TextBox>&nbsp;&nbsp;Occurrences
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton ID="RbEndDate_Date" runat="server" GroupName="RbGrpEndDate" Checked="true"
                        TabIndex="10" AutoPostBack="true" />End Date:
                </td>
                <td>
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
                <td colspan="2" class="IWalkTheLine">
                   Days to Include:
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:RadioButton ID="RbDaysToInclude_Checkboxes" runat="server" AutoPostBack="true"
                        GroupName="RbGrpDaysToInclude" Checked="true" TabIndex="12" />Days:
                    <asp:CheckBox ID="ChkAllDay" runat="server" TabIndex="13" AutoPostBack="true" Text="All Days" />
                    <asp:CheckBoxList ID="ChkListDays" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                        AutoPostBack="True" TabIndex="14">
                        <asp:ListItem Text="Sunday" Value="SUN"></asp:ListItem>
                        <asp:ListItem Text="Monday" Value="M"></asp:ListItem>
                        <asp:ListItem Text="Tuesday" Value="TU"></asp:ListItem>
                        <asp:ListItem Text="Wednesday" Value="W"></asp:ListItem>
                        <asp:ListItem Text="Thursday" Value="TH"></asp:ListItem>
                        <asp:ListItem Text="Friday" Value="F"></asp:ListItem>
                        <asp:ListItem Text="Saturday" Value="SA"></asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:RadioButton ID="RbDaysToInclude_Increment" runat="server" GroupName="RbGrpDaysToInclude"
                        Checked="false" AutoPostBack="true" TabIndex="15" />Every:&nbsp;
                    <asp:TextBox ID="TxtDayIncrement" runat="server" Width="37px" MaxLength="3" Style="text-align: right;"
                        TabIndex="16" SkinID="TextBoxStandard"></asp:TextBox>&nbsp;&nbsp;Days
                </td>
            </tr>
            <tr>
                <td colspan="2" class="IWalkTheLine">
                   Times:
                </td>
            </tr>
            <tr>
                <td>
                    Start Time:
                </td>
                <td>
                    <telerik:RadTimePicker ID="RadTimePickerStartTime" runat="server" SharedTimeViewID="RadTimeViewShared"
                        Width="110px" TabIndex="17">
                        <DateInput onfocus="this.select();">
                        </DateInput>
                    </telerik:RadTimePicker>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton ID="RbEndTime_Hours" runat="server" GroupName="RbGrpEndTime" AutoPostBack="true"
                        TabIndex="18" />Hours:
                </td>
                <td>
                    <asp:TextBox ID="TxtHours" runat="server" TabIndex="19" Width="37" MaxLength="6" SkinID="TextBoxStandard"
                        Style="text-align: right;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton ID="RbEndTime_Time" runat="server" GroupName="RbGrpEndTime" Checked="true"
                        TabIndex="20" AutoPostBack="true" />End Time:
                </td>
                <td>
                    <telerik:RadTimePicker ID="RadTimePickerEndTime" runat="server" SharedTimeViewID="RadTimeViewShared"
                        Width="110px" TabIndex="21">
                        <DateInput onfocus="this.select();">
                        </DateInput>
                    </telerik:RadTimePicker>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" valign="middle">
                    <asp:Button ID="BtnSaveAsNew" runat="server" AccessKey="s" TabIndex="22" ToolTip="Save a new generator instead of updating the current one"
                        Text="Save As New" />
                    &nbsp;&nbsp;
                    <asp:Button ID="BtnSave" runat="server" AccessKey="s" TabIndex="23" ToolTip="Save/update generator details"
                        Text="Save" />
                    &nbsp;&nbsp;
                    <asp:Button ID="BtnGenerate" runat="server" AccessKey="f" TabIndex="24" ToolTip="Generate events using generator details"
                        Text="Generate" />
                    &nbsp;&nbsp;
                    <asp:Button ID="BtnClose" runat="server" AccessKey="c" TabIndex="25" ToolTip="Close this window"
                        OnClientClick="CloseThisWindow();" Text="Close" />
                </td>
            </tr>
        </table>
        <telerik:RadTimeView ID="RadTimeViewShared" runat="server" Interval="00:30:00" HeaderText="Time Selector">
        </telerik:RadTimeView>
</asp:Content>
