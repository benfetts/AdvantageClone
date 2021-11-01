<%@ Page Title="Resources Report" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Resources_Report.aspx.vb" Inherits="Webvantage.Resources_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <div class="telerik-aqua-body" style="margin-top: 5px!important;">
            <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
            <tr>
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                        <tr>
                            <td align="center" colspan="2" class="sub-header sub-header-color">Resource Types
                            </td>
                        </tr>
                        <tr>
                            <td width="150">&nbsp;
                            </td>
                            <td width="500">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                            <td>
                                <asp:RadioButtonList ID="RblResourceTypes" runat="server" RepeatDirection="Horizontal"
                                    TabIndex="0" AutoPostBack="True" RepeatLayout="Flow">
                                    <asp:ListItem Text="All Resource Types" Value="all"
                                        Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Choose Resource Types" Value="select"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                            <td>
                                <telerik:RadListBox ID="LbResourceTypes" runat="server" AutoPostBack="True" AppendDataBoundItems="true"
                                    Height="75px" SelectionMode="Multiple" TabIndex="1" Width="445px">
                                </telerik:RadListBox>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                            <td>&nbsp;
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
                        <tr>
                            <td align="center" colspan="2" class="sub-header sub-header-color">Resources
                            </td>
                        </tr>
                        <tr>
                            <td width="150">&nbsp;
                            </td>
                            <td width="500">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                            <td>
                                <asp:RadioButtonList ID="RblResources" runat="server" RepeatDirection="Horizontal"
                                    TabIndex="2" AutoPostBack="True" RepeatLayout="Flow">
                                    <asp:ListItem Text="All Resources&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="all"></asp:ListItem>
                                    <asp:ListItem Text="Choose Resources&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Value="select"
                                        Selected="True"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                            <td>
                                <telerik:RadListBox ID="LbResourcesList" runat="server" AutoPostBack="False" AppendDataBoundItems="true"
                                    Height="75px" SelectionMode="Multiple" TabIndex="3" Width="445px">
                                </telerik:RadListBox>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                            <td>&nbsp;
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="2" align="center">
                        <tr>
                            <td align="center" colspan="2" class="sub-header sub-header-color">Date
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;
                                    <asp:Label ID="LblMSG" runat="server" Text="" CssClass="warning"></asp:Label>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="150">&nbsp;
                            </td>
                            <td width="500">
                                <span>Start Date:</span>&nbsp;
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
                                &nbsp;&nbsp; <span>End Date:</span>&nbsp;
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
                            <td colspan="2">&nbsp;
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="2" align="center">
                        <tr>
                            <td align="center" colspan="2" class="sub-header sub-header-color">Event Type Colors
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;
                                    <asp:Label ID="Label1" runat="server" Text="" CssClass="warning"></asp:Label>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td width="150">&nbsp;
                            </td>
                            <td width="600">
                                <div>
                                    <div class="code-description-container" style="display:none !important;">
                                        <div class="code-description-label">
                                            No Event Type:
                                        </div>
                                        <div class="code-description-code">
                                            <telerik:RadColorPicker ID="RadColorPickerNoEventType" runat="server" Columns="12" Width="400px">
                                                <%-- Yellows --%>
                                                <telerik:ColorPickerItem Value="#Fefac9" />
                                                <telerik:ColorPickerItem Value="#Fff39d" />
                                                <telerik:ColorPickerItem Value="#Ffe834" />
                                                <telerik:ColorPickerItem Value="#F1d925" />
                                                <telerik:ColorPickerItem Value="#Ccb400" />
                                                <telerik:ColorPickerItem Value="#9f8700" />
                                                <%--  Browns --%>
                                                <telerik:ColorPickerItem Value="#A89a80" />
                                                <telerik:ColorPickerItem Value="#C19859" />
                                                <telerik:ColorPickerItem Value="#Ab8243" />
                                                <telerik:ColorPickerItem Value="#D19049" />
                                                <telerik:ColorPickerItem Value="#Bb7a33" />
                                                <%-- Taupe  --%>
                                                <telerik:ColorPickerItem Value="#A26A2D" />
                                                <telerik:ColorPickerItem Value="#Ebddc3" />
                                                <telerik:ColorPickerItem Value="#D7c6bb" />
                                                <telerik:ColorPickerItem Value="#B1a095" />
                                                <telerik:ColorPickerItem Value="#C0b9c8" />
                                                <telerik:ColorPickerItem Value="#C2aaa0" />
                                                <telerik:ColorPickerItem Value="#9c95a4" />
                                                <telerik:ColorPickerItem Value="#9c847a" />
                                                <telerik:ColorPickerItem Value="#A57474" />
                                                <%-- Orange  --%>
                                                <telerik:ColorPickerItem Value="#Ffca54" />
                                                <telerik:ColorPickerItem Value="#Ffb33d" />
                                                <telerik:ColorPickerItem Value="#Ffa42e" />
                                                <telerik:ColorPickerItem Value="#F07f09" />
                                                <telerik:ColorPickerItem Value="#F79646" />
                                                <telerik:ColorPickerItem Value="#E18030" />
                                                <telerik:ColorPickerItem Value="#Da6900" />
                                                <telerik:ColorPickerItem Value="#C35200" />
                                                <telerik:ColorPickerItem Value="#Ca6919" />
                                                <%-- Reds  --%>
                                                <telerik:ColorPickerItem Value="#C0504d" />
                                                <telerik:ColorPickerItem Value="#C40912" />
                                                <telerik:ColorPickerItem Value="#C44e5b" />
                                                <telerik:ColorPickerItem Value="#D16349" />
                                                <telerik:ColorPickerItem Value="#A4361c" />
                                                <telerik:ColorPickerItem Value="#Ea7481" />
                                                <telerik:ColorPickerItem Value="#Ff6a73" />
                                                <telerik:ColorPickerItem Value="#Ff444d" />
                                                <telerik:ColorPickerItem Value="#E8b7b7" />
                                                <telerik:ColorPickerItem Value="#D2a1a1" />
                                                <%-- Blues  --%>
                                                <telerik:ColorPickerItem Value="#D2ecf0" />
                                                <telerik:ColorPickerItem Value="#A9bfd2" />
                                                <telerik:ColorPickerItem Value="#94b6d2" />
                                                <telerik:ColorPickerItem Value="#A8cdd7" />
                                                <telerik:ColorPickerItem Value="#7c92a5" />
                                                <telerik:ColorPickerItem Value="#738ac8" />
                                                <telerik:ColorPickerItem Value="#4be8ff" />
                                                <telerik:ColorPickerItem Value="#5abaff" />
                                                <telerik:ColorPickerItem Value="#43a3fa" />
                                                <telerik:ColorPickerItem Value="#25c2fe" />
                                                <telerik:ColorPickerItem Value="#0087c3" />
                                                <%-- Greens  --%>
                                                <telerik:ColorPickerItem Value="#9cb084" />
                                                <telerik:ColorPickerItem Value="#869a6e" />
                                                <telerik:ColorPickerItem Value="#99d08d" />
                                                <telerik:ColorPickerItem Value="#73aa67" />
                                                <telerik:ColorPickerItem Value="#8fb08c" />
                                                <telerik:ColorPickerItem Value="#799a76" />
                                                <telerik:ColorPickerItem Value="#7ba79d" />
                                                <telerik:ColorPickerItem Value="#7cca62" />
                                                <telerik:ColorPickerItem Value="#66b44c" />
                                                <telerik:ColorPickerItem Value="#39871f" />
                                                <telerik:ColorPickerItem Value="#A5c249" />
                                                <telerik:ColorPickerItem Value="#8fac33" />
                                                <telerik:ColorPickerItem Value="#627f06" />
                                                <telerik:ColorPickerItem Value="#B0ccb0" />
                                                <telerik:ColorPickerItem Value="#839f83" />
                                                <telerik:ColorPickerItem Value="#B2b5a0" />
                                                <telerik:ColorPickerItem Value="#3fd8c4" />
                                                <telerik:ColorPickerItem Value="#55a157" />
                                                <telerik:ColorPickerItem Value="#D2da7a" />
                                                <telerik:ColorPickerItem Value="#A5ad4d" />
                                                <telerik:ColorPickerItem Value="#8f9871" />
                                                <telerik:ColorPickerItem Value="#Cff57e" />
                                                <telerik:ColorPickerItem Value="#A9cf58" />
                                                <%--  Purples --%>
                                                <telerik:ColorPickerItem Value="#A379bb" />
                                                <telerik:ColorPickerItem Value="#Eb98ee" />
                                                <telerik:ColorPickerItem Value="#D481d7" />
                                                <telerik:ColorPickerItem Value="#E74bca" />
                                                <telerik:ColorPickerItem Value="#B34bca" />
                                                <telerik:ColorPickerItem Value="#9c85c0" />
                                                <telerik:ColorPickerItem Value="#866faa" />
                                                <telerik:ColorPickerItem Value="#Cf6da4" />
                                                <%--  Grays --%>
                                                <telerik:ColorPickerItem Value="#Eaebde" />
                                                <telerik:ColorPickerItem Value="#Bdbeb1" />
                                                <telerik:ColorPickerItem Value="#D8d8d8" />
                                            </telerik:RadColorPicker>
                                        </div>
                                    </div>
                                    <div class="code-description-container">
                                        <div class="code-description-label">
                                            Fixed:
                                        </div>
                                        <div class="code-description-code">
                                            <telerik:RadColorPicker ID="RadColorPickerFixed" runat="server" Columns="12" Width="400px">
                                                <%-- Yellows --%>
                                                <telerik:ColorPickerItem Value="#Fefac9" />
                                                <telerik:ColorPickerItem Value="#Fff39d" />
                                                <telerik:ColorPickerItem Value="#Ffe834" />
                                                <telerik:ColorPickerItem Value="#F1d925" />
                                                <telerik:ColorPickerItem Value="#Ccb400" />
                                                <telerik:ColorPickerItem Value="#9f8700" />
                                                <%--  Browns --%>
                                                <telerik:ColorPickerItem Value="#A89a80" />
                                                <telerik:ColorPickerItem Value="#C19859" />
                                                <telerik:ColorPickerItem Value="#Ab8243" />
                                                <telerik:ColorPickerItem Value="#D19049" />
                                                <telerik:ColorPickerItem Value="#Bb7a33" />
                                                <%-- Taupe  --%>
                                                <telerik:ColorPickerItem Value="#A26A2D" />
                                                <telerik:ColorPickerItem Value="#Ebddc3" />
                                                <telerik:ColorPickerItem Value="#D7c6bb" />
                                                <telerik:ColorPickerItem Value="#B1a095" />
                                                <telerik:ColorPickerItem Value="#C0b9c8" />
                                                <telerik:ColorPickerItem Value="#C2aaa0" />
                                                <telerik:ColorPickerItem Value="#9c95a4" />
                                                <telerik:ColorPickerItem Value="#9c847a" />
                                                <telerik:ColorPickerItem Value="#A57474" />
                                                <%-- Orange  --%>
                                                <telerik:ColorPickerItem Value="#Ffca54" />
                                                <telerik:ColorPickerItem Value="#Ffb33d" />
                                                <telerik:ColorPickerItem Value="#Ffa42e" />
                                                <telerik:ColorPickerItem Value="#F07f09" />
                                                <telerik:ColorPickerItem Value="#F79646" />
                                                <telerik:ColorPickerItem Value="#E18030" />
                                                <telerik:ColorPickerItem Value="#Da6900" />
                                                <telerik:ColorPickerItem Value="#C35200" />
                                                <telerik:ColorPickerItem Value="#Ca6919" />
                                                <%-- Reds  --%>
                                                <telerik:ColorPickerItem Value="#C0504d" />
                                                <telerik:ColorPickerItem Value="#C40912" />
                                                <telerik:ColorPickerItem Value="#C44e5b" />
                                                <telerik:ColorPickerItem Value="#D16349" />
                                                <telerik:ColorPickerItem Value="#A4361c" />
                                                <telerik:ColorPickerItem Value="#Ea7481" />
                                                <telerik:ColorPickerItem Value="#Ff6a73" />
                                                <telerik:ColorPickerItem Value="#Ff444d" />
                                                <telerik:ColorPickerItem Value="#E8b7b7" />
                                                <telerik:ColorPickerItem Value="#D2a1a1" />
                                                <%-- Blues  --%>
                                                <telerik:ColorPickerItem Value="#D2ecf0" />
                                                <telerik:ColorPickerItem Value="#A9bfd2" />
                                                <telerik:ColorPickerItem Value="#94b6d2" />
                                                <telerik:ColorPickerItem Value="#A8cdd7" />
                                                <telerik:ColorPickerItem Value="#7c92a5" />
                                                <telerik:ColorPickerItem Value="#738ac8" />
                                                <telerik:ColorPickerItem Value="#4be8ff" />
                                                <telerik:ColorPickerItem Value="#5abaff" />
                                                <telerik:ColorPickerItem Value="#43a3fa" />
                                                <telerik:ColorPickerItem Value="#25c2fe" />
                                                <telerik:ColorPickerItem Value="#0087c3" />
                                                <%-- Greens  --%>
                                                <telerik:ColorPickerItem Value="#9cb084" />
                                                <telerik:ColorPickerItem Value="#869a6e" />
                                                <telerik:ColorPickerItem Value="#99d08d" />
                                                <telerik:ColorPickerItem Value="#73aa67" />
                                                <telerik:ColorPickerItem Value="#8fb08c" />
                                                <telerik:ColorPickerItem Value="#799a76" />
                                                <telerik:ColorPickerItem Value="#7ba79d" />
                                                <telerik:ColorPickerItem Value="#7cca62" />
                                                <telerik:ColorPickerItem Value="#66b44c" />
                                                <telerik:ColorPickerItem Value="#39871f" />
                                                <telerik:ColorPickerItem Value="#A5c249" />
                                                <telerik:ColorPickerItem Value="#8fac33" />
                                                <telerik:ColorPickerItem Value="#627f06" />
                                                <telerik:ColorPickerItem Value="#B0ccb0" />
                                                <telerik:ColorPickerItem Value="#839f83" />
                                                <telerik:ColorPickerItem Value="#B2b5a0" />
                                                <telerik:ColorPickerItem Value="#3fd8c4" />
                                                <telerik:ColorPickerItem Value="#55a157" />
                                                <telerik:ColorPickerItem Value="#D2da7a" />
                                                <telerik:ColorPickerItem Value="#A5ad4d" />
                                                <telerik:ColorPickerItem Value="#8f9871" />
                                                <telerik:ColorPickerItem Value="#Cff57e" />
                                                <telerik:ColorPickerItem Value="#A9cf58" />
                                                <%--  Purples --%>
                                                <telerik:ColorPickerItem Value="#A379bb" />
                                                <telerik:ColorPickerItem Value="#Eb98ee" />
                                                <telerik:ColorPickerItem Value="#D481d7" />
                                                <telerik:ColorPickerItem Value="#E74bca" />
                                                <telerik:ColorPickerItem Value="#B34bca" />
                                                <telerik:ColorPickerItem Value="#9c85c0" />
                                                <telerik:ColorPickerItem Value="#866faa" />
                                                <telerik:ColorPickerItem Value="#Cf6da4" />
                                                <%--  Grays --%>
                                                <telerik:ColorPickerItem Value="#Eaebde" />
                                                <telerik:ColorPickerItem Value="#Bdbeb1" />
                                                <telerik:ColorPickerItem Value="#D8d8d8" />
                                            </telerik:RadColorPicker>
                                        </div>
                                    </div>
                                    <div class="code-description-container">
                                        <div class="code-description-label">
                                            Flex:
                                        </div>
                                        <div class="code-description-code">
                                            <telerik:RadColorPicker ID="RadColorPickerFlex" runat="server" Columns="12" Width="400px">
                                                <%-- Yellows --%>
                                                <telerik:ColorPickerItem Value="#Fefac9" />
                                                <telerik:ColorPickerItem Value="#Fff39d" />
                                                <telerik:ColorPickerItem Value="#Ffe834" />
                                                <telerik:ColorPickerItem Value="#F1d925" />
                                                <telerik:ColorPickerItem Value="#Ccb400" />
                                                <telerik:ColorPickerItem Value="#9f8700" />
                                                <%--  Browns --%>
                                                <telerik:ColorPickerItem Value="#A89a80" />
                                                <telerik:ColorPickerItem Value="#C19859" />
                                                <telerik:ColorPickerItem Value="#Ab8243" />
                                                <telerik:ColorPickerItem Value="#D19049" />
                                                <telerik:ColorPickerItem Value="#Bb7a33" />
                                                <%-- Taupe  --%>
                                                <telerik:ColorPickerItem Value="#A26A2D" />
                                                <telerik:ColorPickerItem Value="#Ebddc3" />
                                                <telerik:ColorPickerItem Value="#D7c6bb" />
                                                <telerik:ColorPickerItem Value="#B1a095" />
                                                <telerik:ColorPickerItem Value="#C0b9c8" />
                                                <telerik:ColorPickerItem Value="#C2aaa0" />
                                                <telerik:ColorPickerItem Value="#9c95a4" />
                                                <telerik:ColorPickerItem Value="#9c847a" />
                                                <telerik:ColorPickerItem Value="#A57474" />
                                                <%-- Orange  --%>
                                                <telerik:ColorPickerItem Value="#Ffca54" />
                                                <telerik:ColorPickerItem Value="#Ffb33d" />
                                                <telerik:ColorPickerItem Value="#Ffa42e" />
                                                <telerik:ColorPickerItem Value="#F07f09" />
                                                <telerik:ColorPickerItem Value="#F79646" />
                                                <telerik:ColorPickerItem Value="#E18030" />
                                                <telerik:ColorPickerItem Value="#Da6900" />
                                                <telerik:ColorPickerItem Value="#C35200" />
                                                <telerik:ColorPickerItem Value="#Ca6919" />
                                                <%-- Reds  --%>
                                                <telerik:ColorPickerItem Value="#C0504d" />
                                                <telerik:ColorPickerItem Value="#C40912" />
                                                <telerik:ColorPickerItem Value="#C44e5b" />
                                                <telerik:ColorPickerItem Value="#D16349" />
                                                <telerik:ColorPickerItem Value="#A4361c" />
                                                <telerik:ColorPickerItem Value="#Ea7481" />
                                                <telerik:ColorPickerItem Value="#Ff6a73" />
                                                <telerik:ColorPickerItem Value="#Ff444d" />
                                                <telerik:ColorPickerItem Value="#E8b7b7" />
                                                <telerik:ColorPickerItem Value="#D2a1a1" />
                                                <%-- Blues  --%>
                                                <telerik:ColorPickerItem Value="#D2ecf0" />
                                                <telerik:ColorPickerItem Value="#A9bfd2" />
                                                <telerik:ColorPickerItem Value="#94b6d2" />
                                                <telerik:ColorPickerItem Value="#A8cdd7" />
                                                <telerik:ColorPickerItem Value="#7c92a5" />
                                                <telerik:ColorPickerItem Value="#738ac8" />
                                                <telerik:ColorPickerItem Value="#4be8ff" />
                                                <telerik:ColorPickerItem Value="#5abaff" />
                                                <telerik:ColorPickerItem Value="#43a3fa" />
                                                <telerik:ColorPickerItem Value="#25c2fe" />
                                                <telerik:ColorPickerItem Value="#0087c3" />
                                                <%-- Greens  --%>
                                                <telerik:ColorPickerItem Value="#9cb084" />
                                                <telerik:ColorPickerItem Value="#869a6e" />
                                                <telerik:ColorPickerItem Value="#99d08d" />
                                                <telerik:ColorPickerItem Value="#73aa67" />
                                                <telerik:ColorPickerItem Value="#8fb08c" />
                                                <telerik:ColorPickerItem Value="#799a76" />
                                                <telerik:ColorPickerItem Value="#7ba79d" />
                                                <telerik:ColorPickerItem Value="#7cca62" />
                                                <telerik:ColorPickerItem Value="#66b44c" />
                                                <telerik:ColorPickerItem Value="#39871f" />
                                                <telerik:ColorPickerItem Value="#A5c249" />
                                                <telerik:ColorPickerItem Value="#8fac33" />
                                                <telerik:ColorPickerItem Value="#627f06" />
                                                <telerik:ColorPickerItem Value="#B0ccb0" />
                                                <telerik:ColorPickerItem Value="#839f83" />
                                                <telerik:ColorPickerItem Value="#B2b5a0" />
                                                <telerik:ColorPickerItem Value="#3fd8c4" />
                                                <telerik:ColorPickerItem Value="#55a157" />
                                                <telerik:ColorPickerItem Value="#D2da7a" />
                                                <telerik:ColorPickerItem Value="#A5ad4d" />
                                                <telerik:ColorPickerItem Value="#8f9871" />
                                                <telerik:ColorPickerItem Value="#Cff57e" />
                                                <telerik:ColorPickerItem Value="#A9cf58" />
                                                <%--  Purples --%>
                                                <telerik:ColorPickerItem Value="#A379bb" />
                                                <telerik:ColorPickerItem Value="#Eb98ee" />
                                                <telerik:ColorPickerItem Value="#D481d7" />
                                                <telerik:ColorPickerItem Value="#E74bca" />
                                                <telerik:ColorPickerItem Value="#B34bca" />
                                                <telerik:ColorPickerItem Value="#9c85c0" />
                                                <telerik:ColorPickerItem Value="#866faa" />
                                                <telerik:ColorPickerItem Value="#Cf6da4" />
                                                <%--  Grays --%>
                                                <telerik:ColorPickerItem Value="#Eaebde" />
                                                <telerik:ColorPickerItem Value="#Bdbeb1" />
                                                <telerik:ColorPickerItem Value="#D8d8d8" />
                                            </telerik:RadColorPicker>
                                        </div>
                                    </div>
                                    <div class="code-description-container">
                                        <div class="code-description-label">
                                            Pre-emptable:
                                        </div>
                                        <div class="code-description-code">
                                            <telerik:RadColorPicker ID="RadColorPickerPreEmptable" runat="server" Columns="12" Width="400px">
                                                <%-- Yellows --%>
                                                <telerik:ColorPickerItem Value="#Fefac9" />
                                                <telerik:ColorPickerItem Value="#Fff39d" />
                                                <telerik:ColorPickerItem Value="#Ffe834" />
                                                <telerik:ColorPickerItem Value="#F1d925" />
                                                <telerik:ColorPickerItem Value="#Ccb400" />
                                                <telerik:ColorPickerItem Value="#9f8700" />
                                                <%--  Browns --%>
                                                <telerik:ColorPickerItem Value="#A89a80" />
                                                <telerik:ColorPickerItem Value="#C19859" />
                                                <telerik:ColorPickerItem Value="#Ab8243" />
                                                <telerik:ColorPickerItem Value="#D19049" />
                                                <telerik:ColorPickerItem Value="#Bb7a33" />
                                                <%-- Taupe  --%>
                                                <telerik:ColorPickerItem Value="#A26A2D" />
                                                <telerik:ColorPickerItem Value="#Ebddc3" />
                                                <telerik:ColorPickerItem Value="#D7c6bb" />
                                                <telerik:ColorPickerItem Value="#B1a095" />
                                                <telerik:ColorPickerItem Value="#C0b9c8" />
                                                <telerik:ColorPickerItem Value="#C2aaa0" />
                                                <telerik:ColorPickerItem Value="#9c95a4" />
                                                <telerik:ColorPickerItem Value="#9c847a" />
                                                <telerik:ColorPickerItem Value="#A57474" />
                                                <%-- Orange  --%>
                                                <telerik:ColorPickerItem Value="#Ffca54" />
                                                <telerik:ColorPickerItem Value="#Ffb33d" />
                                                <telerik:ColorPickerItem Value="#Ffa42e" />
                                                <telerik:ColorPickerItem Value="#F07f09" />
                                                <telerik:ColorPickerItem Value="#F79646" />
                                                <telerik:ColorPickerItem Value="#E18030" />
                                                <telerik:ColorPickerItem Value="#Da6900" />
                                                <telerik:ColorPickerItem Value="#C35200" />
                                                <telerik:ColorPickerItem Value="#Ca6919" />
                                                <%-- Reds  --%>
                                                <telerik:ColorPickerItem Value="#C0504d" />
                                                <telerik:ColorPickerItem Value="#C40912" />
                                                <telerik:ColorPickerItem Value="#C44e5b" />
                                                <telerik:ColorPickerItem Value="#D16349" />
                                                <telerik:ColorPickerItem Value="#A4361c" />
                                                <telerik:ColorPickerItem Value="#Ea7481" />
                                                <telerik:ColorPickerItem Value="#Ff6a73" />
                                                <telerik:ColorPickerItem Value="#Ff444d" />
                                                <telerik:ColorPickerItem Value="#E8b7b7" />
                                                <telerik:ColorPickerItem Value="#D2a1a1" />
                                                <%-- Blues  --%>
                                                <telerik:ColorPickerItem Value="#D2ecf0" />
                                                <telerik:ColorPickerItem Value="#A9bfd2" />
                                                <telerik:ColorPickerItem Value="#94b6d2" />
                                                <telerik:ColorPickerItem Value="#A8cdd7" />
                                                <telerik:ColorPickerItem Value="#7c92a5" />
                                                <telerik:ColorPickerItem Value="#738ac8" />
                                                <telerik:ColorPickerItem Value="#4be8ff" />
                                                <telerik:ColorPickerItem Value="#5abaff" />
                                                <telerik:ColorPickerItem Value="#43a3fa" />
                                                <telerik:ColorPickerItem Value="#25c2fe" />
                                                <telerik:ColorPickerItem Value="#0087c3" />
                                                <%-- Greens  --%>
                                                <telerik:ColorPickerItem Value="#9cb084" />
                                                <telerik:ColorPickerItem Value="#869a6e" />
                                                <telerik:ColorPickerItem Value="#99d08d" />
                                                <telerik:ColorPickerItem Value="#73aa67" />
                                                <telerik:ColorPickerItem Value="#8fb08c" />
                                                <telerik:ColorPickerItem Value="#799a76" />
                                                <telerik:ColorPickerItem Value="#7ba79d" />
                                                <telerik:ColorPickerItem Value="#7cca62" />
                                                <telerik:ColorPickerItem Value="#66b44c" />
                                                <telerik:ColorPickerItem Value="#39871f" />
                                                <telerik:ColorPickerItem Value="#A5c249" />
                                                <telerik:ColorPickerItem Value="#8fac33" />
                                                <telerik:ColorPickerItem Value="#627f06" />
                                                <telerik:ColorPickerItem Value="#B0ccb0" />
                                                <telerik:ColorPickerItem Value="#839f83" />
                                                <telerik:ColorPickerItem Value="#B2b5a0" />
                                                <telerik:ColorPickerItem Value="#3fd8c4" />
                                                <telerik:ColorPickerItem Value="#55a157" />
                                                <telerik:ColorPickerItem Value="#D2da7a" />
                                                <telerik:ColorPickerItem Value="#A5ad4d" />
                                                <telerik:ColorPickerItem Value="#8f9871" />
                                                <telerik:ColorPickerItem Value="#Cff57e" />
                                                <telerik:ColorPickerItem Value="#A9cf58" />
                                                <%--  Purples --%>
                                                <telerik:ColorPickerItem Value="#A379bb" />
                                                <telerik:ColorPickerItem Value="#Eb98ee" />
                                                <telerik:ColorPickerItem Value="#D481d7" />
                                                <telerik:ColorPickerItem Value="#E74bca" />
                                                <telerik:ColorPickerItem Value="#B34bca" />
                                                <telerik:ColorPickerItem Value="#9c85c0" />
                                                <telerik:ColorPickerItem Value="#866faa" />
                                                <telerik:ColorPickerItem Value="#Cf6da4" />
                                                <%--  Grays --%>
                                                <telerik:ColorPickerItem Value="#Eaebde" />
                                                <telerik:ColorPickerItem Value="#Bdbeb1" />
                                                <telerik:ColorPickerItem Value="#D8d8d8" />
                                            </telerik:RadColorPicker>
                                        </div>
                                    </div>
                                    <div class="code-description-container">
                                        <div class="code-description-label">
                                            Hold:
                                        </div>
                                        <div class="code-description-code">
                                            <telerik:RadColorPicker ID="RadColorPickerHold" runat="server" Columns="12" Width="400px">
                                                <%-- Yellows --%>
                                                <telerik:ColorPickerItem Value="#Fefac9" />
                                                <telerik:ColorPickerItem Value="#Fff39d" />
                                                <telerik:ColorPickerItem Value="#Ffe834" />
                                                <telerik:ColorPickerItem Value="#F1d925" />
                                                <telerik:ColorPickerItem Value="#Ccb400" />
                                                <telerik:ColorPickerItem Value="#9f8700" />
                                                <%--  Browns --%>
                                                <telerik:ColorPickerItem Value="#A89a80" />
                                                <telerik:ColorPickerItem Value="#C19859" />
                                                <telerik:ColorPickerItem Value="#Ab8243" />
                                                <telerik:ColorPickerItem Value="#D19049" />
                                                <telerik:ColorPickerItem Value="#Bb7a33" />
                                                <%-- Taupe  --%>
                                                <telerik:ColorPickerItem Value="#A26A2D" />
                                                <telerik:ColorPickerItem Value="#Ebddc3" />
                                                <telerik:ColorPickerItem Value="#D7c6bb" />
                                                <telerik:ColorPickerItem Value="#B1a095" />
                                                <telerik:ColorPickerItem Value="#C0b9c8" />
                                                <telerik:ColorPickerItem Value="#C2aaa0" />
                                                <telerik:ColorPickerItem Value="#9c95a4" />
                                                <telerik:ColorPickerItem Value="#9c847a" />
                                                <telerik:ColorPickerItem Value="#A57474" />
                                                <%-- Orange  --%>
                                                <telerik:ColorPickerItem Value="#Ffca54" />
                                                <telerik:ColorPickerItem Value="#Ffb33d" />
                                                <telerik:ColorPickerItem Value="#Ffa42e" />
                                                <telerik:ColorPickerItem Value="#F07f09" />
                                                <telerik:ColorPickerItem Value="#F79646" />
                                                <telerik:ColorPickerItem Value="#E18030" />
                                                <telerik:ColorPickerItem Value="#Da6900" />
                                                <telerik:ColorPickerItem Value="#C35200" />
                                                <telerik:ColorPickerItem Value="#Ca6919" />
                                                <%-- Reds  --%>
                                                <telerik:ColorPickerItem Value="#C0504d" />
                                                <telerik:ColorPickerItem Value="#C40912" />
                                                <telerik:ColorPickerItem Value="#C44e5b" />
                                                <telerik:ColorPickerItem Value="#D16349" />
                                                <telerik:ColorPickerItem Value="#A4361c" />
                                                <telerik:ColorPickerItem Value="#Ea7481" />
                                                <telerik:ColorPickerItem Value="#Ff6a73" />
                                                <telerik:ColorPickerItem Value="#Ff444d" />
                                                <telerik:ColorPickerItem Value="#E8b7b7" />
                                                <telerik:ColorPickerItem Value="#D2a1a1" />
                                                <%-- Blues  --%>
                                                <telerik:ColorPickerItem Value="#D2ecf0" />
                                                <telerik:ColorPickerItem Value="#A9bfd2" />
                                                <telerik:ColorPickerItem Value="#94b6d2" />
                                                <telerik:ColorPickerItem Value="#A8cdd7" />
                                                <telerik:ColorPickerItem Value="#7c92a5" />
                                                <telerik:ColorPickerItem Value="#738ac8" />
                                                <telerik:ColorPickerItem Value="#4be8ff" />
                                                <telerik:ColorPickerItem Value="#5abaff" />
                                                <telerik:ColorPickerItem Value="#43a3fa" />
                                                <telerik:ColorPickerItem Value="#25c2fe" />
                                                <telerik:ColorPickerItem Value="#0087c3" />
                                                <%-- Greens  --%>
                                                <telerik:ColorPickerItem Value="#9cb084" />
                                                <telerik:ColorPickerItem Value="#869a6e" />
                                                <telerik:ColorPickerItem Value="#99d08d" />
                                                <telerik:ColorPickerItem Value="#73aa67" />
                                                <telerik:ColorPickerItem Value="#8fb08c" />
                                                <telerik:ColorPickerItem Value="#799a76" />
                                                <telerik:ColorPickerItem Value="#7ba79d" />
                                                <telerik:ColorPickerItem Value="#7cca62" />
                                                <telerik:ColorPickerItem Value="#66b44c" />
                                                <telerik:ColorPickerItem Value="#39871f" />
                                                <telerik:ColorPickerItem Value="#A5c249" />
                                                <telerik:ColorPickerItem Value="#8fac33" />
                                                <telerik:ColorPickerItem Value="#627f06" />
                                                <telerik:ColorPickerItem Value="#B0ccb0" />
                                                <telerik:ColorPickerItem Value="#839f83" />
                                                <telerik:ColorPickerItem Value="#B2b5a0" />
                                                <telerik:ColorPickerItem Value="#3fd8c4" />
                                                <telerik:ColorPickerItem Value="#55a157" />
                                                <telerik:ColorPickerItem Value="#D2da7a" />
                                                <telerik:ColorPickerItem Value="#A5ad4d" />
                                                <telerik:ColorPickerItem Value="#8f9871" />
                                                <telerik:ColorPickerItem Value="#Cff57e" />
                                                <telerik:ColorPickerItem Value="#A9cf58" />
                                                <%--  Purples --%>
                                                <telerik:ColorPickerItem Value="#A379bb" />
                                                <telerik:ColorPickerItem Value="#Eb98ee" />
                                                <telerik:ColorPickerItem Value="#D481d7" />
                                                <telerik:ColorPickerItem Value="#E74bca" />
                                                <telerik:ColorPickerItem Value="#B34bca" />
                                                <telerik:ColorPickerItem Value="#9c85c0" />
                                                <telerik:ColorPickerItem Value="#866faa" />
                                                <telerik:ColorPickerItem Value="#Cf6da4" />
                                                <%--  Grays --%>
                                                <telerik:ColorPickerItem Value="#Eaebde" />
                                                <telerik:ColorPickerItem Value="#Bdbeb1" />
                                                <telerik:ColorPickerItem Value="#D8d8d8" />
                                            </telerik:RadColorPicker>
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top">
                    <asp:Button ID="BtnViewReport" runat="server" Text="View" TabIndex="6" />
                </td>
            </tr>
        </table>
        </div>
        
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
