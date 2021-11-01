<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="TrafficSchedule_TaskSettings2.ascx.vb"
    Inherits="Webvantage.TrafficSchedule_TaskSettings2" %>
<style type="text/css">
    .rcbHeader ul,
    .rcbFooter ul,
    .rcbItem ul,
    .rcbHovered ul,
    .rcbDisabled ul {
        margin: 0;
        padding: 0;
        width: 100%;
        display: inline-block;
        list-style-type: none;
    }
    .col1,
    .col2 {
        margin: 0;
        padding: 0 5px 0 0;
        line-height: 14px;
        float: left;
        overflow: hidden;
    }
    .col1
    {
        width: 80px;
    }
    .col2
    {
        width: 200px;
    }
</style>

<script type="text/javascript">

    function isNumberKey(evt) {
        //alert(" Key " + evt.keyCode + " Entered");
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode < 96 || charCode > 105))
            return false;

        return true;
    }
   function BlockEntry(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 0)
            return false;

        return true;
    }
   
      
</script>

<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <table border="0" cellpadding="0" cellspacing="2" width="810">
                <tr>
                    <td align="right" valign="middle" width="28%">
                        <span>Order:</span>
                    </td>
                    <td width="2%">
                        &nbsp;
                    </td>
                    <td width="70%">
                        <asp:TextBox ID="TxtOrder" runat="server" onkeydown="return isNumberKey(event)" 
                            MaxLength="4" TabIndex="1" Width="30px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle" width="28%">
                        <span>Days (Duration):</span>
                    </td>
                    <td width="2%">
                        &nbsp;
                    </td>
                    <td width="70%">
                        <asp:TextBox ID="TxtDays" runat="server" onkeydown="return isNumberKey(event)" 
                            Width="30px" MaxLength="3"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle" width="28%">
                        <span>Default Hours Allowed:</span>
                    </td>
                    <td width="2%">
                        &nbsp;
                    </td>
                    <td width="70%">
                        <asp:TextBox ID="TxtHoursAllowed" runat="server"
                             Width="50px" MaxLength="6"></asp:TextBox>
                        <asp:HiddenField ID="HiddenFieldHoursAllowed" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle" width="28%">
                        <span>Milestone?:</span>
                    </td>
                    <td width="2%">
                        &nbsp;
                    </td>
                    <td width="70%">
                        <asp:CheckBox ID="ChkMilestone" runat="server"  />
                        <asp:TextBox runat="server" ID="txtMileStone" Visible="false" ReadOnly="true" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle" width="28%">
                        <span>Estimate Function:</span>
                    </td>
                    <td width="2%">
                        &nbsp;
                    </td>
                    <td width="70%">
                        <telerik:RadComboBox ID="dropEstFnc" runat="server" DropDownWidth="350px" HighlightTemplatedItems="true" Width="300px" >
                            <HeaderTemplate>
                                    <ul>
                                        <li class="col1">Code</li>
                                        <li class="col2">Description</li>
                                    </ul>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <ul>
                                        <li class="col1"><%# If(String.IsNullOrWhiteSpace(DataBinder.Eval(Container.DataItem, "Code")), "&nbsp;", DataBinder.Eval(Container.DataItem, "Code"))%></li>
                                        <li class="col2"><%# DataBinder.Eval(Container.DataItem, "Description")%></li>
                                    </ul>
                                </ItemTemplate>
                        </telerik:RadComboBox>
                        <asp:TextBox runat="server" ID="txtEstFnc" Visible="false" ReadOnly="true" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle" width="28%">
                        <span>Original Due Date:</span>
                    </td>
                    <td width="2%">
                        &nbsp;
                    </td>
                    <td width="70%">
                        <telerik:RadDatePicker ID="RadDatePickerOriginalDueDate" runat="server"  
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
                    <td align="right" valign="middle" width="28%">
                        <span>Locked?:</span>
                    </td>
                    <td width="2%">
                    </td>
                    <td width="70%">
                        <asp:CheckBox ID="ChkLocked" runat="server"  />
                        <asp:TextBox runat="server" ID="txtLocked" Visible="false" ReadOnly="true" ></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
