<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CreativeBrief_Approved.aspx.vb"
    Inherits="Webvantage.CreativeBrief_Approved" MasterPageFile="~/ChildPage.Master"
    Title="Approve Creative Brief" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    
    <telerik:RadToolBar ID="RadToolBarCreativeBrief" runat="server" AutoPostBack="true" Width="100%">
        <Items>
            <telerik:RadToolBarButton IsSeparator="True" Value="Sep1" />
            <telerik:RadToolBarButton Value="Save" ToolTip="Save" SkinID="RadToolBarButtonSave" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonCancel" Value="Cancel" ToolTip="Cancel" />
            <telerik:RadToolBarButton IsSeparator="True" Value="Sep2" />
        </Items>
    </telerik:RadToolBar>

    <div style="margin-top: 10px;">
        <div class="form-layout">
            <ul>
                <li>Approved By:</li>
                <li><asp:TextBox ID="TextBoxApprovedBy" runat="server" TabIndex="10" CssClass="RequiredInput" SkinID="TextBoxStandard"></asp:TextBox></li>
            </ul>
            <ul>
                <li>Approval Date:</li>
                <li><telerik:RadDatePicker ID="RadDatePickerApprovalDate" runat="server" 
                          SkinID="RadDatePickerStandard">
                        <DateInput DateFormat="d" EmptyMessage="" TabIndex="11">
                            <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                        </DateInput>
                        <Calendar ID="Calendar1" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                            <SpecialDays>
                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                </telerik:RadCalendarDay>
                            </SpecialDays>
                        </Calendar>
                    </telerik:RadDatePicker></li>
            </ul>
            <ul>
                <li style="vertical-align: top;">Comment:</li>
                <li><asp:TextBox ID="TextBoxComment" Width="350px" runat="server" TextMode="MultiLine" Rows="4" TabIndex="12" SkinID="TextBoxStandard"></asp:TextBox></li>
            </ul>
        </div>
    </div>

</asp:Content>
