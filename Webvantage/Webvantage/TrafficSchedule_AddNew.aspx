<%@ Page AutoEventWireup="false" CodeBehind="TrafficSchedule_AddNew.aspx.vb" Inherits="Webvantage.TrafficSchedule_AddNew"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="New Project Schedule" %>

<asp:Content ID="ContentMain" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function clearcomp() {
                document.forms[0].<%=Me.TxtJobCompNum.ClientID %>.value = '';
                document.forms[0].<%=Me.TxtJobCompDescription.ClientID %>.value = '';
            }
            function clearjob(){
                document.forms[0].<%=Me.TxtJobNum.ClientID %>.value = '';
                document.forms[0].<%=Me.TxtJobCompNum.ClientID %>.value = '';
                document.forms[0].<%=Me.TxtJobDescription.ClientID %>.value = '';
                document.forms[0].<%=Me.TxtJobCompDescription.ClientID %>.value = '';
            }
        </script>
    </telerik:RadScriptBlock>
    <style type="text/css">
        .no-left-padding, .no-left-padding tbody, no-left-padding tbody td {
            padding: 0;
            margin: 0;
            border-spacing: 0;
        }
    </style>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <asp:Panel ID="PnlAddNewSchedule" runat="server" DefaultButton="BtnCreateSchedule"
            Width="100%">
            <div>
                <div>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="LblMSG" runat="server" Text="&nbsp;"></asp:Label></div>
                <div class="form-layout">
                    <ul style="display:none;">
                        <li>Template:</li>
                        <li><telerik:RadComboBox ID="RadComboBoxTemplate" runat="server" SkinID="RadComboBoxStandard"></telerik:RadComboBox></li>
                    </ul>
                    <ul>
                        <li><asp:HyperLink ID="HlClient" runat="server" href="" TabIndex="-1">Client:</asp:HyperLink></li>
                        <li><asp:TextBox ID="TxtClientCode" runat="server" MaxLength="6" TabIndex="1" Text="" Width="100px" SkinID="TextBoxStandard"></asp:TextBox></li>
                    </ul>
                    <ul>
                        <li><asp:HyperLink ID="HlDivision" runat="server" href="" TabIndex="-1">Division:</asp:HyperLink></li>
                        <li><asp:TextBox ID="TxtDivisionCode" runat="server" MaxLength="6" TabIndex="2" Text="" Width="100px" SkinID="TextBoxStandard"></asp:TextBox></li>
                    </ul>
                    <ul>
                        <li><asp:HyperLink ID="HlProduct" runat="server" href="" TabIndex="-1">Product:</asp:HyperLink></li>
                        <li><asp:TextBox ID="TxtProductCode" runat="server" MaxLength="6" TabIndex="2" Text="" Width="100px" SkinID="TextBoxStandard"></asp:TextBox></li>
                    </ul>
                    <ul>
                        <li><asp:HyperLink ID="HlJob" runat="server" TabIndex="-1" href="">Job:</asp:HyperLink></li>
                        <li><asp:TextBox ID="TxtJobNum" runat="server" CssClass="RequiredInput" MaxLength="6" TabIndex="4" Text="" Width="100px" SkinID="TextBoxStandard"></asp:TextBox></li>
                        <li><asp:TextBox ID="TxtJobDescription" runat="server" ReadOnly="true" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox></li>
                        <li>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorJobNumber" runat="server" ControlToValidate="TxtJobNum"
                                CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                ErrorMessage="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Job Number is required."></asp:RequiredFieldValidator>
                        </li>
                    </ul>
                    <ul>
                        <li><asp:HyperLink ID="HlComponent" runat="server" TabIndex="-1" href="">Component:</asp:HyperLink></li>
                        <li><asp:TextBox ID="TxtJobCompNum" runat="server" CssClass="RequiredInput" MaxLength="3" TabIndex="5" Text="" Width="100px" SkinID="TextBoxStandard"></asp:TextBox></li>
                        <li><asp:TextBox ID="TxtJobCompDescription" runat="server" ReadOnly="true" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox></li>
                        <li>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorJobComponentNumber" runat="server" ControlToValidate="TxtJobCompNum"
                                CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                ErrorMessage="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Component Number is required."></asp:RequiredFieldValidator>
                        </li>
                    </ul>
                    <ul>
                        <li><asp:HyperLink ID="HlTrafficStatus" runat="server" href="" TabIndex="-1">Traffic Status:</asp:HyperLink></li>
                        <li><asp:TextBox ID="TxtTrafficStatusCode" runat="server" CssClass="RequiredInput" MaxLength="10" TabIndex="6" Text="" Width="100px" SkinID="TextBoxStandard"></asp:TextBox></li>
                        <li><asp:TextBox ID="TxtTrafficStatusDescription" runat="server" ReadOnly="true" TabIndex="-1" Text="" Visible="false" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox></li>
                        <li>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtTrafficStatusCode"
                                CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                                ErrorMessage="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Traffic Status is required."></asp:RequiredFieldValidator>
                        </li>
                    </ul>
                    <ul>
                        <li><asp:HyperLink ID="HyperLinkTrafficManager" runat="server" TabIndex="-1" href=""></asp:HyperLink></li>
                        <li>
                            <asp:TextBox ID="TextBoxTrafficManager" runat="server" MaxLength="6" Width="100px" TabIndex="7" SkinID="TextBoxStandard"></asp:TextBox></li>
                        <li>
                            <asp:RequiredFieldValidator ID="RequiredfieldvalidatorTrafficManager" runat="server" ControlToValidate="TextBoxTrafficManager"
                                CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="false"
                                ErrorMessage="Manager is required."></asp:RequiredFieldValidator>
                        </li>
                    </ul>
                    <div style="display: none;">
                        <asp:ImageButton ID="ImgBtnGetPresetData_AddNew" runat="server" SkinID="ImageButtonRefresh" ToolTip="Refresh descriptions and get default dates" />
                    </div>
                    <ul style="display: none;">
                        <li>Start Date:</li>
                        <li><telerik:RadDatePicker ID="RadDatePickerStartDate" runat="server" 
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
                            </telerik:RadDatePicker></li>
                    </ul>
                    <ul style="display: none;">
                        <li>Due Date:</li>
                        <li><telerik:RadDatePicker ID="RadDatePickerDueDate" runat="server" 
                                  SkinID="RadDatePickerStandard">
                                <DateInput DateFormat="d" EmptyMessage="Due Date" runat="server">
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
                    <ul style="margin-top: 20px; margin-bottom: 20px;">
                        <li>&nbsp;</li>
                        <li><asp:Button ID="BtnCreateSchedule" runat="server" CausesValidation="True" TabIndex="7" Text="Create Schedule" />&nbsp;&nbsp;
                            <asp:Button ID="BtnCancel" runat="server" CausesValidation="False" TabIndex="8" Text="Cancel" /></li>
                    </ul>
                </div>
            </div>
        </asp:Panel>
        <h4>
            <asp:CheckBox ID="CheckBoxShowCopyFromExistingSchedule" runat="server" Style="vertical-align: top !important;"
                AutoPostBack="true" />
            Copy From Existing Schedule?
        </h4>
        <asp:Panel ID="PnlCopySchedule" runat="server" DefaultButton="btnCopyPS" Width="100%">
            <div>
                <div>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="&nbsp;"></asp:Label></div>
                <div class="form-layout">
                    <ul>
                        <li><asp:HyperLink ID="HlClientSource" runat="server" TabIndex="-1" href="">Client:</asp:HyperLink></li>
                        <li><asp:TextBox ID="TxtClientSource" runat="server" MaxLength="6" TabIndex="11" Text="" Width="100px"></asp:TextBox></li>
                        <li><asp:TextBox ID="TxtClientSourceDesc" runat="server" ReadOnly="true" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox></li>
                    </ul>
                    <ul>
                        <li><asp:HyperLink ID="HlDivisionSource" runat="server" TabIndex="-1" href="">Division:</asp:HyperLink></li>
                        <li><asp:TextBox ID="TxtDivisionSource" runat="server" MaxLength="6" TabIndex="12" Text="" Width="100px"></asp:TextBox></li>
                        <li><asp:TextBox ID="TxtDivisionSourceDesc" runat="server" ReadOnly="true" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox></li>
                    </ul>
                    <ul>
                        <li><asp:HyperLink ID="HlProductSource" runat="server" href="" TabIndex="-1">Product:</asp:HyperLink></li>
                        <li><asp:TextBox ID="TxtProductSource" runat="server" MaxLength="6" TabIndex="13" Text="" Width="100px"></asp:TextBox></li>
                        <li><asp:TextBox ID="TxtProductSourceDesc" runat="server" ReadOnly="true" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox></li>
                    </ul>
                    <ul>
                        <li><asp:HyperLink ID="HlJobSource" runat="server" TabIndex="-1" href="">Job:</asp:HyperLink></li>
                        <li><asp:TextBox ID="TxtJobSource" runat="server" MaxLength="6" TabIndex="15" Text="" Width="100px" CssClass="RequiredInput"></asp:TextBox></li>
                        <li><asp:TextBox ID="TxtJobSourceDesc" runat="server" ReadOnly="true" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox></li>
                    </ul>
                    <ul>
                        <li><asp:HyperLink ID="HlJobCompSource" runat="server" TabIndex="-1" href="">Component:</asp:HyperLink></li>
                        <li><asp:TextBox ID="TxtJobCompSource" runat="server" MaxLength="6" TabIndex="14" Text="" Width="100px" CssClass="RequiredInput"></asp:TextBox></li>
                        <li><asp:TextBox ID="TxtJobCompSourceDesc" runat="server" ReadOnly="true" TabIndex="-1" Text="" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox></li>
                    </ul>
                    <ul>
                        <li>&nbsp;</li>
                        <li><asp:CheckBox ID="cbShowClosed" runat="server" Text="Show Closed/Archived Jobs?" AutoPostBack="true" /></li>
                    </ul>                
                    <ul>
                        <li>&nbsp;</li>
                        <li><asp:CheckBoxList ID="CheckboxListCopyOptions" runat="server" style="border-spacing: 0; padding:0; margin: 0;">
                            </asp:CheckBoxList></li>
                    </ul>
                    <ul style="margin-top: 20px; margin-bottom: 20px;">
                        <li>&nbsp;</li>
                        <li><asp:Button ID="btnCopyPS" runat="server" CausesValidation="True" TabIndex="17" Text="Copy Project Schedule" /></li>
                    </ul>
                </div>
                
            </div>
        </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
</asp:Content>
