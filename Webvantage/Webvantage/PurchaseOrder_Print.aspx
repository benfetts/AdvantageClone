<%@ Page AutoEventWireup="false" CodeBehind="PurchaseOrder_Print.aspx.vb"
    Inherits="Webvantage.PurchaseOrder_Print" Language="vb" MasterPageFile="~/ChildPage.Master"
    Title="Print Purchase Order" %>

<%@ Register Src="ReportTypeUC.ascx" TagName="reporttype" TagPrefix="uc2" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    
    <link rel="stylesheet" href="Content/kendo/current/kendo.common.min.css" />
    <link rel="stylesheet" href="Content/kendo/current/kendo.bootstrap.min.css" />
    <script type="text/javascript" src="Scripts/kendo/current/kendo.all.min.js"></script>
    
    <telerik:RadScriptBlock ID="RadScriptBlockContent" runat="server">
        <script type="text/javascript">

            $(document).ready(function () {

                <%--var datePicker = $find('<%= RadDatePickerPODateToPrint.ClientID%>');
                datePicker.set_selectedDate(new Date());--%>

                initWindow();

            });

            function initWindow() {
                var datePicker = $find('<%= RadDatePickerPODateToPrint.ClientID%>');
                $('#CheckBoxDateToPrint').change(function () {
                    datePicker.set_enabled($(this).is(":checked"));
                });
            }

            function overrideLocationDefaults(sender, args) {
                var manager = GetRadWindow().GetWindowManager();
                var oWin = manager.open('LocationOverride.aspx');
                if (oWin) {
                    oWin.set_modal(true);
                    oWin.center();
                    setTimeout(function () {
                        oWin.autoSize();
                    }, 200);
                }
            }

            function overrideLocationDefaults(sender, args) {
                OpenRadWindow('', 'LocationOverride.aspx', 250, 400, true, 100, null, true, '')
            }

            function RadAjaxPanelContentOnResponseEnd(sender, args) {
                initWindow();
            }

        </script>
    </telerik:RadScriptBlock>
    <div class="telerik-aqua-body">
        <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
            <tr>
                <td id="TdToolbar" runat="server">
                    <telerik:RadToolBar ID="RadToolBarPOPrintOptions" runat="server" AutoPostBack="True"
                        Width="100%">
                        <Items>
                            <telerik:RadToolBarButton IsSeparator="true" />
                            <telerik:RadToolBarButton SkinID="RadToolBarButtonPrint" Value="Print" ToolTip="Print" />
                            <telerik:RadToolBarButton SkinID="RadToolBarButtonNewAlert" Value="SendAlert" ToolTip="Send Alert" />
                            <telerik:RadToolBarButton SkinID="RadToolBarButtonNewAssignment" Value="SendAssignment" ToolTip="Send Assignment" />
                            <telerik:RadToolBarButton SkinID="RadToolBarButtonEmail" Value="SendEmail" ToolTip="Send Email" />
                            <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" ToolTip="Save Settings"
                                Value="Save" />
                            <telerik:RadToolBarButton IsSeparator="true" />
                            <telerik:RadToolBarButton SkinID="RadToolBarButtonClear" Text="Back" Value="Back" Visible="false"/>
                            <telerik:RadToolBarButton IsSeparator="true" Visible="false"/>
                        </Items>
                    </telerik:RadToolBar>
                </td>
            </tr>
        </table>

            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
            <div style="margin-top: 10px;">
                <div>
                    <div class="sub-header sub-header-color">
                        Purchase Order to Print
                    </div>
                    <div class="form-layout" style="float:left; margin-top:10px;">
                        <ul>
                            <li>PO Number:</li>
                            <li><asp:TextBox ID="TextBoxPODisplayNumber" runat="server" SkinID="TextBoxCodeSmall" ReadOnly="True" Enabled="false"></asp:TextBox></li>
                            <li><asp:TextBox ID="TextBoxDescription" runat="server" SkinID="TextBoxText40" ReadOnly="true" Enabled="false"></asp:TextBox></li>
                        </ul>
                        <ul>
                            <li>Issued By:</li>
                            <li><asp:TextBox ID="TextBoxEmployeeCode" runat="server" SkinID="TextBoxCodeSmall" ReadOnly="True" Enabled="false"></asp:TextBox></li>
                            <li><asp:TextBox ID="TextBoxEmployeeName" runat="server" SkinID="TextBoxText40" ReadOnly="True" Enabled="false"></asp:TextBox></li>
                        </ul>
                        <ul>
                            <li>Issued To:</li>
                            <li><asp:TextBox ID="TextBoxVendorCode" runat="server" SkinID="TextBoxCodeSmall" ReadOnly="True" Enabled="false"></asp:TextBox></li>
                            <li><asp:TextBox ID="TextBoxVendorName" runat="server" SkinID="TextBoxText40" ReadOnly="True" Enabled="false"></asp:TextBox></li>
                        </ul>
                    </div>
                    <div class="form-layout" style="float:left; margin-top:10px;">
                        <ul>
                            <li>Date Issued:</li>
                            <li><asp:Label ID="LabelDateIssued" runat="server" /></li>
                        </ul>
                        <ul>
                            <li>Due Date:</li>
                            <li><asp:Label ID="LabelDueDate" runat="server" /></li>
                        </ul>
                        <ul>
                            <li>PO Total:</li>
                            <li><asp:Label ID="LabelPOTotal" runat="server" /></li>
                        </ul>
                    </div>
                </div>
                <div style="clear:both;">
                    <div class="sub-header sub-header-color">
                        Options
                    </div>
                    <div class="form-layout" style="margin-top:10px;">
                        <ul>
                            <li>Report Format:</li>
                            <li><telerik:RadComboBox ID="RadComboBoxReportFormat" runat="server" DataTextField="Description" DataValueField="Code" SkinID="RadComboBoxText40" AutoPostBack="true">
                                </telerik:RadComboBox></li>
                        </ul>
                        <ul>
                            <li>Location:</li>
                            <li><telerik:RadComboBox ID="RadComboBoxLocation" runat="server" DataTextField="Name" DataValueField="ID" SkinID="RadComboBoxText40" AutoPostBack="true">
                                </telerik:RadComboBox></li>
                            <li><telerik:RadButton ID="RadButtonOverrideLocation" runat="server" Text="..." AutoPostBack="false" OnClientClicked="overrideLocationDefaults"></telerik:RadButton></li>
                        </ul>
                        <ul>
                            <li>Use Printed Date:</li>
                            <li><asp:CheckBox ID="CheckBoxDateToPrint" runat="server" AutoPostBack="false" ClientIDMode="Static"  />
                                <telerik:RadDatePicker ID="RadDatePickerPODateToPrint" runat="server" SkinID="RadDatePickerStandard">
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
                            </li>
                        </ul>
                    </div>
                </div>
                <div style="margin-top: 10px;">
                    <div style="float:left;">
                        <div class="sub-header sub-header-color">
                            Comment Options
                        </div>
                        <div>
                            <asp:CheckBox ID="CheckboxPOInstructions" runat="server" Text="PO Instructions" /><br />
                            <asp:CheckBox ID="CheckboxDeliveryInstructions" runat="server" Text="Shipping Instructions" /><br />
                            <asp:CheckBox ID="CheckboxDetailDescription" runat="server" Text="Detail Description" /><br />
                            <asp:CheckBox ID="CheckboxDetailInstruction" runat="server" Text="Detail Instructions" /><br />
                            <asp:CheckBox ID="CheckboxFooterComment" runat="server" Text="Footer Comment" />
                        </div>
                    </div>
                    <div style="float:left; margin-left: 20px;">
                        <div class="sub-header sub-header-color">
                            Other
                        </div>
                        <div>
                            <asp:CheckBox ID="CheckboxVendorCode" runat="server" Text="Vendor Code" /><br />
                            <asp:CheckBox ID="CheckboxVendorContact" runat="server" Text="Vendor Contact" /><br />
                            <asp:CheckBox ID="CheckboxClientName" runat="server" Text="Client Name" /><br />
                            <asp:CheckBox ID="CheckboxProductName" runat="server" Text="Product Name" /><br />
                            <asp:CheckBox ID="CheckboxJobComponent" runat="server" Text="Job Number / Component" /><br />
                            <asp:CheckBox ID="CheckboxJobDescription" runat="server" Text="Job Description" /><br />
                            <asp:CheckBox ID="CheckboxJobComponentDescription" runat="server" Text="Job Component Description" /><br />
                            <asp:CheckBox ID="CheckboxFunctionDescription" runat="server" Text="Function Description" /><br />
                            <asp:CheckBox ID="CheckboxExcludeEmployeeSignature" runat="server" Text="Exclude Employee Signature" AutoPostBack="true" /><br />
                            <asp:CheckBox ID="CheckBoxUseUserSignature" runat="server" Text="Use Logged In User Signature" /><br />
                            <asp:CheckBox ID="CheckBoxUseLocationName" runat="server" Text="Use Location Name in Signature" AutoPostBack="true" /><br />
                            <asp:CheckBox ID="CheckBoxUseClientName" runat="server" Text="Use Client Name in Signature" AutoPostBack="true" />
                        </div>
                    </div>
                    <div style="clear:both"></div>
                </div>
            </div>
            <asp:Label ID="LabelCallingPageMode" runat="server" Text="edit" Visible="False"></asp:Label>
        
                </ContentTemplate>
                <Triggers>
                    <asp:asyncPostBackTrigger ControlID="CheckBoxUseLocationName"/>
                    <asp:asyncPostBackTrigger ControlID="CheckBoxUseClientName"/>
                    <asp:asyncPostBackTrigger ControlID="RadComboBoxReportFormat"/>
                </Triggers>
            </asp:UpdatePanel>
    </div>              


    

</asp:Content>
