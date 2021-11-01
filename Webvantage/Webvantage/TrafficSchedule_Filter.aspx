<%@ Page Title="Project Schedule Filter" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="TrafficSchedule_Filter.aspx.vb" Inherits="Webvantage.TrafficSchedule_Filter" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
<asp:Literal ID="LitScript" runat="server"></asp:Literal>
    <div align="center">
                <asp:Label ID="lblMSG" runat="server" CssClass="warning" Text=""></asp:Label></div>
    <table align="center" border="0" cellpadding="2" cellspacing="2"  id="TblSchedHead" runat="server"
        width="100%">
        <tr>
            <td align="center" colspan="4" valign="middle">&nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle">
                <span>
                    <asp:HyperLink ID="HlManager" runat="server" TabIndex="-1" href="">Manager:</asp:HyperLink>
                </span>
            </td>
            <td>
                <asp:TextBox ID="TxtManager" runat="server"  MaxLength="6" TabIndex="1"
                    Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
            </td>
            <td align="right" valign="middle">
                <span>
                    <asp:HyperLink ID="HlJob" runat="server" TabIndex="-1" href=""><span>Job:</span></asp:HyperLink>
                </span>
            </td>
            <td>
                <asp:TextBox ID="TxtJobNum" runat="server"  MaxLength="6" TabIndex="6"
                    Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle" width="17%">
                <span>
                    <asp:HyperLink ID="HlClient" runat="server" TabIndex="-1" href=""><span>Client:</span></asp:HyperLink>
                </span>
            </td>
            <td width="21%">
                <asp:TextBox ID="TxtClientCode" runat="server"  MaxLength="6"
                    TabIndex="2" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
            </td>
            <td align="right" valign="middle" width="20%">
                <span>
                    <asp:HyperLink ID="HlComponent" runat="server" TabIndex="-1" href=""><span>Component:</span></asp:HyperLink>
                </span>
            </td>
            <td width="42%">
                <asp:TextBox ID="TxtJobCompNum" runat="server"  MaxLength="3"
                    TabIndex="7" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle">
                <span>
                    <asp:HyperLink ID="HlDivision" runat="server" TabIndex="-1" href=""><span>Division:</span></asp:HyperLink>
                </span>
            </td>
            <td>
                <asp:TextBox ID="TxtDivisionCode" runat="server"  MaxLength="6"
                    TabIndex="3" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                &nbsp;
            </td>
            <td align="right" valign="middle">
                <span>
                    <asp:HyperLink ID="HlAccountExecutive" runat="server" href="" TabIndex="-1"><span>Account Executive:</span></asp:HyperLink>
                </span>
            </td>
            <td>
                <asp:TextBox ID="TxtAccountExecutive" runat="server"  MaxLength="6"
                    TabIndex="8" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle">
                <span>
                    <asp:HyperLink ID="HlProduct" runat="server" TabIndex="-1" href=""><span>Product:</span></asp:HyperLink>
                </span>
            </td>
            <td>
                <asp:TextBox ID="TxtProductCode" runat="server"  MaxLength="6"
                    TabIndex="4" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
            </td>
            <td align="right" valign="middle">
                <asp:CheckBox ID="ChkIncludeCompletedSchedules" runat="server" Checked="True" 
                    TabIndex="9" Text="" />
            </td>
            <td>
                Exclude Completed Schedules
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle">
                <span>
                    <asp:HyperLink ID="HlCampaign" runat="server" TabIndex="-1" href=""><span>Campaign:</span></asp:HyperLink>
                </span>
            </td>
            <td>
                <asp:TextBox ID="TxtCampaign" runat="server"  MaxLength="6"
                    TabIndex="5" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
            </td>
            <td align="right" valign="middle">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td align="right" valign="middle">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <table align="center" border="0" cellpadding="2" cellspacing="2" 
        width="100%">
        <tr>
            <td align="right" valign="middle">
                <span >Phase:</span>
            </td>
            <td>
                <telerik:RadComboBox ID="DropPhaseFilter" runat="server" AppendDataBoundItems="true" SkinID="RadComboBoxStandard"
                    Visible="true" >
                    <Items>
                       <telerik:RadComboBoxItem Text="[No Filter]" Value="no_filter" SkinID="RadComboBoxStandard"></telerik:RadComboBoxItem>
                 </Items>
                </telerik:RadComboBox>
            </td>
            <td align="right" valign="middle">
                <asp:CheckBox ID="ChkOnlyPendingTasks" runat="server"  TabIndex="14"
                    Text="" />
            </td>
            <td>
                Only Pending Tasks</td>
        </tr>
        <tr>
            <td align="right" valign="middle" width="17%">
                <span>
                    <asp:HyperLink ID="HlRole" runat="server" TabIndex="-1" href=""><span>Role:</span></asp:HyperLink>
                </span>
            </td>
            <td width="21%">
                <asp:TextBox ID="TxtRole" runat="server"  MaxLength="6" TabIndex="10"
                    Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
            </td>
            <td align="right" valign="middle" width="20%">
                <asp:CheckBox ID="ChkExcludeProjectedTasks" runat="server" 
                    TabIndex="15" Text="" />
            </td>
            <td width="42%">
                Exclude Projected Tasks</td>
        </tr>
        <tr>
            <td align="right" valign="middle">
                <span>
                    <asp:HyperLink ID="HlTask" runat="server" TabIndex="-1" href=""><span>Task:</span></asp:HyperLink>
                </span>
            </td>
            <td>
                <asp:TextBox ID="TxtTaskCode" runat="server"  MaxLength="10"
                    TabIndex="11" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
            </td>
            <td align="right" valign="middle">
                <asp:CheckBox ID="ChkIncludeCompletedTasks" runat="server" Checked="True" 
                    TabIndex="16" Text="" />
            </td>
            <td>
                Include Completed Tasks</td>
        </tr>
        <tr>
            <td align="right" valign="middle">
                <span>
                    <asp:HyperLink ID="HlEmployee" runat="server" TabIndex="-1" href=""><span>Employee:</span></asp:HyperLink>
                </span>
            </td>
            <td>
                <asp:TextBox ID="TxtEmployee" runat="server"  MaxLength="6"
                    TabIndex="12" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
            </td>
            <td align="right" valign="middle">
                &nbsp;</td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" valign="middle">
                <span >Date Cutoff:</span>
            </td>
            <td>
                <telerik:RadDatePicker ID="RadDatePickerDateCutoff" runat="server" SkinID="RadDatePickerStandard">
                    <DateInput DateFormat="d" EmptyMessage="">
                        <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                    </DateInput>
                    <Calendar ID="CalendarDateCutoff" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                        <SpecialDays>
                            <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                            </telerik:RadCalendarDay>
                        </SpecialDays>
                    </Calendar>
                </telerik:RadDatePicker>
                <%--<asp:TextBox ID="TxtDateCutoff" runat="server"  MaxLength="10"
                    TabIndex="13" Text="" SkinID="TextBoxCodeSmall"></asp:TextBox>
                <asp:Literal ID="LitDateCutoff" runat="server"></asp:Literal>--%>
            </td>
            <td align="right" valign="middle">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr id="MultiOptions" runat="server">
            <td align="center" colspan="4" valign="middle">
                <asp:CheckBox ID="ChkEditHeaders" runat="server" Checked="true" 
                    TabIndex="-1" Text="Edit Headers Only" Visible="false" />
                <asp:CheckBox ID="ChkEditGrids" runat="server" Checked="true" 
                    TabIndex="-1" Text="Edit Grids" Visible="false" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" valign="middle">
                <asp:Button ID="BtnClear" runat="server" AccessKey="c"  TabIndex="18"
                    Text="Clear" />
                &nbsp;&nbsp;
                <asp:Button ID="BtnFilter" runat="server" AccessKey="f"  TabIndex="17"
                    Text="Apply Filter" />
            </td>
        </tr>
    </table>

</asp:Content>
