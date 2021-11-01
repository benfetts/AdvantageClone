<%@ Page AutoEventWireup="false" CodeBehind="VendorQuote_PrintSetup.aspx.vb" MasterPageFile="~/ChildPage.Master" ValidateRequest="false"
    Title="Email/Print Setup" Inherits="Webvantage.VendorQuote_PrintSetup" Language="vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="left" border="0" cellpadding="2" cellspacing="2">
        <tr>
            <td>
                <asp:Panel ID="PanelDetailComments" runat="server" Width="100%">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label   ID="Label3" runat="server" Text="Location ID:"></asp:Label>&nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <telerik:RadComboBox ID="ddLocation" runat="server" Width="329px" SkinID="RadComboBoxStandard">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:CheckBox ID="cbUsePrintedDate" runat="server" Text="Use Printed Date" AutoPostBack="true" />   
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <asp:Panel ID="pnlDate" runat="server">
                        <tr>
                            <td align="left">
                                <asp:Label   ID="Label1" runat="server" Text="Date:"></asp:Label>&nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <telerik:RadDatePicker ID="RadDatePickerPrintDate" runat="server" 
                                          SkinID="RadDatePickerStandard">
                                        <DateInput DateFormat="d" EmptyMessage="">
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
                        </asp:Panel>
                        <tr>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                               Subject*:&nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="txtSubject" runat="server" AutoCompleteType="Disabled" BorderStyle="Inset" SkinID="TextBoxStandard"
                                    MaxLength="200" Width="565px" CausesValidation="True" TabIndex="4"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                               Body:&nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <telerik:RadEditor ID="Radeditor1" runat="server" ToolsFile="~/RadEditorToolbars.xml" NewLineBr="true" NewLineMode="Br" OnClientLoad="RadEditorOnClientLoad" StripFormattingOptions="MsWord"
                                    ContentAreaCssFile="~/CSS/RadEditorContentArea.min.css" Height="265" Width="571" OnClientCommandExecuted="RadEditorOnClientCommandExecuted"
                                    EditModes="Design" TabIndex="5">
                                    <CssFiles>
                                        <telerik:EditorCssFile Value="~/CSS/RadEditorContentArea.css" />
                                    </CssFiles>
                                </telerik:RadEditor>
                                <script type="text/javascript">
                                    Telerik.Web.UI.Editor.Utils.containsHtmlAtClipboard = function (event) {
                                        return false;
                                    }
                                </script>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="3">
                                <asp:CheckBox ID="cbAddcc" runat="server" Text="Check to Add CC" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <div align="center">
                    <br />
                    <asp:Literal ID="LitSpellScript" runat="server"></asp:Literal>
                    <asp:Button ID="BtnSave" runat="server" TabIndex="0" Text="Save" />
                    &nbsp; &nbsp;
                    <asp:Button ID="BtnCancel" runat="server" TabIndex="0" Text="Cancel" /><br />
                    <br />
                    <asp:Label ID="lblMSG" runat="server" CssClass="warning" Text=""></asp:Label>
                </div>
            </td>
        </tr>
    </table>
    <asp:Literal ID="LitScript" runat="server"></asp:Literal>
</asp:Content>
