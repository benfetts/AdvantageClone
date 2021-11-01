<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="InOutBoard.ascx.vb" Inherits="Webvantage.InOutBoard" %>
<asp:Panel ID="PanelInOutBoard" runat="server" DefaultButton="ImageButtonInOutBoardSave">
    <div id="DivInOutBoard" style="padding: 0px 0px 0px 8px;">
        <div style="display: inline-block; vertical-align: top; cursor: pointer !important;">
            <div class="icon-background background-color-sidebar" runat="server" id="DivCurrentStatusFlagColor" style="display: inline-block; cursor:pointer !important;">
                <asp:LinkButton ID="LinkButtonCurrentStatus" runat="server" CssClass="icon-text-two" Style="cursor: pointer !important;"></asp:LinkButton>
            </div>
        </div>
        <div style="display: inline-block;">
            <div id="DivSelectEmployee" runat="server" class="code-description-container">
                <div class="code-description-label">
                    Employee:
                </div>
                <div class="code-description-description">
                    <telerik:RadComboBox ID="RadComboBoxEmployees" runat="server" AutoPostBack="true" TabIndex="-1" width="220">
                    </telerik:RadComboBox>
                </div>
            </div>
            <div id="DivInOutBoardEntryForm" runat="server">
                <div class="code-description-container">
                    <div class="code-description-label">
                        Comment:
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TextBoxInOutBoardReason" runat="server" MaxLength="50" TabIndex="13">
                        </asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Expected Return:
                    </div>
                    <div class="code-description-code">
                        <telerik:RadDatePicker ID="RadDatePickerInOutBoardExpectedReturn" runat="server"
                            SkinID="RadDatePickerStandard">
                            <DateInput runat="server" DateFormat="d" EmptyMessage="">
                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                            </DateInput>
                            <Calendar ID="Calendar1" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                <SpecialDays>
                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                    </telerik:RadCalendarDay>
                                </SpecialDays>
                            </Calendar>
                        </telerik:RadDatePicker>
                        <asp:ImageButton ID="ImageButtonInOutBoardSave" runat="server" CausesValidation="False" SkinID="ImageButtonSave" />
                        <asp:ImageButton ID="ImageButtonInOutBoardCancel" runat="server" CausesValidation="False" SkinID="ImageButtonCancel" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Panel>
