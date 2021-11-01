<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopTrafficStatistics.ascx.vb"
    Inherits="Webvantage.DesktopTrafficStatistics" %>
<table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td width="33%">
            Start:
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
        </td>
        <td width="33%">
            &nbsp;End:
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
        <td width="33%">
            <telerik:RadComboBox ID="DropTrafficFunctions" runat="server" AutoPostBack="true" width="220">
            </telerik:RadComboBox>
        </td>
        <td align="right" valign="middle" width="1%">
            &nbsp;&nbsp;
            <asp:ImageButton ID="butrefresh" runat="server" AlternateText="Refresh" ImageAlign="AbsMiddle"
                 SkinID="ImageButtonRefresh" ToolTip="Refresh"  />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
        <td>
            <asp:CheckBox ID="ChkIsClosedStatus" runat="server" AutoPostBack="true" />Cancelled
            Status
        </td>
        <td align="right" valign="middle">
            &nbsp;
        </td>
    </tr>
</table> 
<div class="centered" style="padding-top: 11px">
    <telerik:RadCodeBlock ID="RadCodeBlockFlashObject" runat="server" EnableViewState="false">
        <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://fpdownload.adobe.com/pub/shockwave/cabs/flash/swflash.cab"
            height="350" width="500" id="MSColumn3D">
            <param name="movie" value="Flash/MSColumn3D.swf?chartWidth=500&chartHeight=350" />
            <param name="FlashVars" value="&dataXML=<%= WriteXML %>">
            <param name="quality" value="high" />
            <embed src="Flash/MSColumn3D.swf" flashvars="&dataXML=<%= WriteXML %>" quality="high"
                height="350" width="500" name="MSColumn3D" pluginspage="http://get.adobe.com/flashplayer/"
                type="application/x-shockwave-flash" wmode="transparent" />
        </object>
    </telerik:RadCodeBlock>
</div>
