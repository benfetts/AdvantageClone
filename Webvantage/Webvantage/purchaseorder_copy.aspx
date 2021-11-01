<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="purchaseorder_copy.aspx.vb" Inherits="Webvantage.purchaseorder_copy" 
    title="Copy Purchase Order" %>

<%@ Register Src="purchaseorder_base_info.ascx" TagName="purchaseorder_base_info"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" cellpadding="0" cellspacing="0"  width="95%">
        <tr >
            <td colspan="2" align="right" >
                                   <!--Place buttons here.-->
                                <asp:Button ID="btn_copy" runat="server"  Text="Copy" />
                                &nbsp; &nbsp;
                                <asp:Button ID="btn_cancel" runat="server"  Text="Cancel" />
                                &nbsp;&nbsp;
        
            </td>
        </tr>
        <tr>
            <td style="height: 199px">
                <table style="width: 650px; height: 136px;">
                    <tr>
                        <td style="width: 400px" align="right">
                          <span  style="font-weight:bold">New PO Date:</span>&nbsp;
                        </td>
                        <td style="width: 500px">
                            <telerik:RadDatePicker ID="RadDatePickerPODate" runat="server"  
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
                        <td style="width: 400px" align="right">
                            <span  style="font-weight:bold">New PO Due Date:</span>&nbsp;
                      </td>
                        <td style="width: 500px">
                            <telerik:RadDatePicker ID="RadDatePickerPODue" runat="server"  
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
                        <td style="width: 200px; height: 35px;" align="right">
                         <span  style="font-weight:bold">Use my Employee Code:</span>&nbsp;</td> 
                        <td style="width: 116px; height: 35px;">
                            <asp:CheckBox ID="ck_New_Emp_Code" runat="server" Checked="True" Width="151px" /></td>
                    </tr>                    
                    <tr>
                        <td style="width: 400px" align="right">
                             <span  style="font-weight:bold">Copy PO Header Instructions:</span>&nbsp;</td>
                        <td style="width: 1500px">
                            <asp:CheckBox ID="ck_Copy_Instruct" runat="server" Checked="True" /></td>
                    </tr>
                </table>
                <br />
                <asp:Label   ID="lbl_msg" runat="server" CssClass="warning"></asp:Label>
                </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 15px; text-align: center;" class="sub-header sub-header-color">
               Original Purchase Order Information</td>
        </tr>
        <tr>
            <td>
                <uc1:purchaseorder_base_info ID="Purchaseorder_base_info1" runat="server" />
                &nbsp;
            </td>
        </tr>
    </table>
    <asp:Label   ID="lbl_CallingPage" runat="server" Visible="False"></asp:Label>
        &nbsp;&nbsp;&nbsp;
</asp:Content>
