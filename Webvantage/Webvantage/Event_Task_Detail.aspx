<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Event_Task_Detail.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="Event Task - Detail" Inherits="Webvantage.Event_Task_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" border="0" cellpadding="2" cellspacing="0" 
        width="580">
        <tr>
            <td align="center" colspan="2">
                &nbsp;<asp:Label   ID="LblMSG" runat="server" CssClass="CssRequired" Text=""></asp:Label>&nbsp;
            </td>
        </tr>
        <tr>
            <td  valign="top">
                &nbsp;&nbsp;<strong>Office:</strong>
            </td>
            <td width="413" valign="top">
                <asp:Label   ID="LblOffice" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  valign="top">
                &nbsp;&nbsp;<strong>Client:</strong>
            </td>
            <td valign="top">
                <asp:Label   ID="LblClient" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  valign="top">
                &nbsp;&nbsp;<strong>Division:</strong>
            </td>
            <td valign="top">
                <asp:Label   ID="LblDivision" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  valign="top">
                &nbsp;&nbsp;<strong>Product:</strong>
            </td>
            <td valign="top">
                <asp:Label   ID="LblProduct" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  valign="top" width="175">
                &nbsp;&nbsp;<strong>Job:</strong>
            </td>
            <td valign="top">
                <asp:Label   ID="LblJob" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  valign="top">
                &nbsp;&nbsp;<strong>Job Comp:</strong>
            </td>
            <td valign="top">
                <asp:Label   ID="LblJobComp" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  valign="top">
                &nbsp;&nbsp;<strong>Event:</strong>
            </td>
            <td valign="top">
                <asp:Label   ID="LblEvent" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  valign="top">
                &nbsp;&nbsp;<strong>Task:</strong>
            </td>
            <td valign="top">
                <asp:Label   ID="LblTrfFncCode" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="TxtTrfFncCode" runat="server"  MaxLength="10" SkinID="TextBoxStandard"
                    ReadOnly="true" TabIndex="-1" Text="" Width="83px"></asp:TextBox>
                <asp:TextBox ID="TxtTrfFncDescription" runat="server"  ReadOnly="true"
                    TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  valign="top">
                &nbsp;&nbsp;<strong>Task Date:</strong>
            </td>
            <td valign="top">
                <asp:Label   ID="LblEventTaskDate" runat="server" Text=""></asp:Label>
                <telerik:RadDatePicker ID="RadDatePickerEventTaskDate" runat="server"  
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
            <td  valign="top">
                &nbsp;&nbsp;<strong>Task Start:</strong>
            </td>
            <td valign="top">
                <asp:Label   ID="LblStartTime" runat="server" Text=""></asp:Label>
                <telerik:RadMaskedTextBox ID="RadMaskedTxtStartTime" runat="server" Mask="##:##  <AM|PM>"
                    Label="" Button ZeroPadNumericRanges="true" Width="75" 
                    DisplayMask="" TabIndex="4">
                </telerik:RadMaskedTextBox>
            </td>
        </tr>
        <tr>
            <td  valign="top">
                &nbsp;&nbsp;<strong>Task End:</strong>
            </td>
            <td valign="top">
                <asp:Label   ID="LblEndTime" runat="server" Text=""></asp:Label>
                <telerik:RadMaskedTextBox ID="RadMaskedTxtEndTime" runat="server" Mask="##:##  <AM|PM>"
                    Label="" Button ZeroPadNumericRanges="true" Width="75" 
                    DisplayMask="" TabIndex="5">
                </telerik:RadMaskedTextBox>
            </td>
        </tr>
        <tr>
            <td  valign="top">
                &nbsp;&nbsp;<strong>Task Employee:</strong>
            </td>
            <td valign="top">
                <asp:Label   ID="LblEmpCode" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="TxtEmpCode" runat="server"  MaxLength="6" ReadOnly="true" SkinID="TextBoxStandard"
                    TabIndex="7" Text="" Width="83px"></asp:TextBox>
                <asp:TextBox ID="TxtEmpFML" runat="server"  ReadOnly="true"
                    TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  valign="top">
                &nbsp;&nbsp;<strong>Task Hours Allowed:</strong>
            </td>
            <td valign="top">
                <asp:Label   ID="LblHours" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="TxtHours" runat="server"  TabIndex="6" Width="37" SkinID="TextBoxStandard"
                    ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  colspan="2" valign="bottom">
                &nbsp;&nbsp;<strong>Task Comment:</strong>
            </td>
        </tr>
        <tr>
            <td  colspan="2">
                &nbsp;&nbsp;
                <asp:Label   ID="LblComments" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="TxtComments" runat="server"  Height="60px" SkinID="TextBoxStandard"
                    ReadOnly="true" TextMode="multiLine" Width="450px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  valign="top">
                &nbsp;&nbsp;<strong>Completed Date:</strong>
            </td>
            <td valign="top">
                <telerik:RadDatePicker ID="RadDatePickerCompletedDate" runat="server"  
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
            <td  colspan="2" valign="bottom">
                &nbsp;&nbsp;<strong>Task Completed Comment:</strong>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;&nbsp;<asp:TextBox ID="TxtCompletedComments" runat="server"  SkinID="TextBoxStandard"
                    Height="60px" TextMode="multiLine" Width="450px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="BtnSave" runat="server"  Text="Save" />&nbsp;&nbsp;&nbsp;
                <input  onclick="window.close()" type="button" value="Cancel" />
            </td>
        </tr>
    </table>
</asp:Content>
