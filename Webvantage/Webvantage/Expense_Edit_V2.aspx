<%@ Page Title="Edit Expense Report" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Expense_Edit_V2.aspx.vb" Inherits="Webvantage.Expense_Edit_V2" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <style type="text/css">
        textarea.allowResize {
            resize: both;
        }

        .DisabledImageButton {
            filter: alpha(opacity=30);
            opacity: .30;
        }

        .code-input-column {
            width: 95px;
        }

            .code-input-column input[type=text], .code-input-column span.RadInput {
                width: 95px !important;
            }
    </style>
    <telerik:RadScriptBlock ID="RadScriptBlockCSS" runat="server">
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
        <script type="text/javascript">


            //st: what i replaced it with:
            function Multiply(text1, text2, textResult) {
                var x = document.getElementById(text1).value;
                var y = document.getElementById(text2).value;
                var z = 0.000;
                x = Number.parseLocale(x);
                y = Number.parseLocale(y);
                if (isNaN(x) == false && isNaN(y) == false) {
                    z = (x) * (y)
                    //z = z.toFixed(2)
                    if (isNaN(z) == true) {
                        document.getElementById(textResult).value = String.localeFormat("{0:n}", 0);
                    }
                    else {
                        document.getElementById(textResult).value = String.localeFormat("{0:n}", z);
                    }
                }
                else {
                    document.getElementById(textResult).value = String.localeFormat("{0:n}", 0);
                }
            }
            function limitText(limitField, limitCount, limitNum) {
                if (limitField.value.length > limitNum) {
                    limitField.value = limitField.value.substring(0, limitNum);
                } else {
                    limitCount.value = limitNum - limitField.value.length;
                }
            }
            function radGridOnGridCreated(sender, args) {
                var cols = sender.get_masterTableView().get_columns();
                $(cols).each(function () {
                    if (this.get_uniqueName() === 'GridTemplateColumn_JobDescription' || this.get_uniqueName() === 'GridTemplateColumn_JobCompDescription') {
                        this.set_resizable(true);
                        this.resizeToFit(false, true);
                    }
                    this.set_resizable(false);
                });
                $('.RadGrid input[adv-calc]').each(function () {
                    var radInput = $find($(this).attr('id'));
                    if (radInput) {
                        radInput.add_valueChanged(function (sender, args) {
                            var element = sender.get_element();
                            var changed = $(element).attr('adv-calc');
                            getCurrentScope(element).quantityRateAmountChanged(changed);
                        });
                    }
                });
            }

        </script>
        <script type="text/javascript">

            function stopRKey(evt) {
                var evt = (evt) ? evt : ((event) ? event : null);
                var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
                if ((evt.keyCode == 13) && (node.type == "text")) {
                    return false;
                }
            }

            document.onkeypress = stopRKey;
            document.onkeydown = KeyDownHandler;

            var activeDD;

            function KeyDownHandler(sender, eventArgs) {
                if (activeDD) {
                    if (sender.keyCode == 9) {
                        activeDD.hideDropDown();
                    }
                }
            }
            function ForceValue(sender, eventArgs) {
                var val = sender.get_value();
                if (!val) {
                    var combobitem = new Telerik.Web.UI.RadComboBoxItem();
                    combobitem.set_text(activeDD.get_text());
                    combobitem.set_value(activeDD.get_value());
                    activeDD.get_items().add(combobitem);
                    combobitem.select();
                }

            }
            function getItems(sender, eventArgs) {
                activeDD = sender;
                sender.requestItems(null, false);
            }
            function clearFilter(sender, eventArgs) {
                sender._filterText = null;
            }
            function CloseDropDown(sender, eventArgs) {
                sender.hideDropDown();
                activeDD = null;
            }
            function ForceClose(sender, eventArgs) {
                var keyCode = eventArgs.get_domEvent().keyCode;
                if (keyCode == 9) {
                    sender.hideDropDown();
                }
            }

            function SetDefaultPaymentType(ComboBox, Value) {
                var combo = $find(ComboBox);
                var items = combo.get_items();
                var item;
                if (combo.get_value() == "") {
                    for (var i = 0; i < items.get_count(); i++) {
                        item = items.getItem(i);
                        if (item.get_value() == Value) {
                            item.select();
                        }
                    }
                }
            }

            function SetDefaultItemDate(DatePickerInput, Value) {
                var DatePicker = $find(DatePickerInput);
                var selectedDate = DatePicker.get_selectedDate();
                if (selectedDate == null || selectedDate == "") {
                    DatePicker.set_selectedDate(new Date(Value));
                }
            }

        </script>
        <script type="text/javascript">

            function RefreshPage(radWindowCaller) {
                //__doPostBack('onclick#Refresh', 'HidePopUpRefresh');
                var invnum = $('#ctl00_ContentPlaceHolderMain_Label_InvoiceNumber').text();

                location.replace("expense_edit_v2.aspx?invoice=" + $('#ctl00_ContentPlaceHolderMain_Label_InvoiceNumber').text());
            }

            function realPostBack(eventTarget, eventArgument) {
                __doPostBack(eventTarget, eventArgument);
            }

            function RefreshFileGrid(radWindowCaller) {
                __doPostBack('onclick#Refresh', 'Refresh');
            }

            function HidePopUpWindows(radWindowCaller) {
                __doPostBack('onclick#Refresh', 'HidePopups');
            }
            function HidePopUpRefresh(radWindowCaller) {
                __doPostBack('onclick#Refresh', 'HidePopUpRefresh');
            }
            function SelectAllRows(checked) {
                var radgrid = $find('<%= RadGridExpenseItems.ClientID %>');
                var masterTableView = radgrid.get_masterTableView()
                var detailTables = radgrid.get_detailTables();
                var allTables = new Array();

                allTables = allTables.concat(detailTables);
                allTables.splice(0, 0, masterTableView);

                for (var t = 0; t < allTables.length; t++) {
                    if (checked == true) {
                        allTables[t].selectAllItems();
                    } else {
                        allTables[t].clearSelectedItems();
                    }
                }
                var HiddenFieldSelectAll = document.getElementById('<%= HiddenFieldSelectAll.ClientID%>');
                if (checked == true) {
                    HiddenFieldSelectAll.value = '1';
                } else {
                    HiddenFieldSelectAll.value = '0';
                }
            }

        </script>

    </telerik:RadScriptBlock>
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function JsOnClientButtonClicking(sender, args) {
                var comandName = args.get_item().get_commandName();
                if (comandName == "Delete") {
                    ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                } else if (comandName == "DeleteSelectedRows") {
                    ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                } else if (comandName == "Save") {
                    var rptdate = $find('<%= RadDatePickerReportDate.ClientID%>');
                    var seldate = rptdate.get_selectedDate();
                    if (seldate) {
                        try {
                            var hfmindate = document.getElementById('<%= HiddenFieldMinDate.ClientID%>');
                            var hfmaxdate = document.getElementById('<%= HiddenFieldMaxDate.ClientID%>');
                            var mindate = new Date(hfmindate.value);
                            var maxdate = new Date(hfmaxdate.value);
                            if (seldate < mindate || seldate > maxdate) {
                                ////args.set_cancel(!confirm('The report date is outside of the acceptable date range. You will no longer be able to access this expense report if you close this window. Are you sure you want to continue?'));
                                radToolBarConfirm(sender, args, "The report date is outside of the acceptable date range. You will no longer be able to access this expense report if you close this window. Are you sure you want to continue?");
                            };
                        } catch (err) {

                        };
                    };
                };
                //if (comandName == "Print") {
                //    GetRadWindow().BrowserWindow.OpenRadWindow('', '');
                //}
            }
        </script>
    </telerik:RadScriptBlock>

    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
    <script type="text/javascript" src="Scripts/angular.min.js"></script>
    <script type="text/javascript" src="Scripts/angular-ui/ui-bootstrap-tpls.min.js"></script>
    <script type="text/javascript" src="Scripts/kendo/current/kendo.all.min.js"></script>
    <script type="text/javascript" src="app/js/app.js"></script>
    <script type="text/javascript" src="app/js/services.js"></script>
    <script type="text/javascript" src="app/js/controllers/expenseReport.js"></script>
    <script type="text/javascript" src="app/js/controllers/kendoGridLookupModal.js"></script>

    <div ng-app="webvantageApp" ng-controller="expenseReportController">

    <div style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
        <telerik:RadToolBar ID="RadToolbarExpenseEdit" runat="server" AutoPostBack="true"
            OnClientButtonClicking="JsOnClientButtonClicking" Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolbarButtonSave" runat="server" SkinID="RadToolBarButtonSave"
                    Text="" CommandName="Save" Value="Save" ToolTip="Save the current expense report" />
                <telerik:RadToolBarButton ID="RadToolbarButtonCopy" runat="server" SkinID="RadToolBarButtonCopy"
                    Text="Copy" Value="Copy" ToolTip="Copy the current expense report" />
                <telerik:RadToolBarButton ID="RadToolbarButtonDelete" runat="server" SkinID="RadToolBarButtonDelete" Value="Delete" ToolTip="Delete the current expense report" CommandName="Delete" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolbarButtonSubmit" runat="server" Text="Submit"
                    Value="Submit" Hidden="False" ToolTip="Submit the current expense report" />
                <telerik:RadToolBarButton ID="RadToolbarButtonUnsubmit" runat="server" Text="Un-submit"
                    Value="Unsubmit" Hidden="False" ToolTip="Un-submit the expense report list" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolbarButtonPrint" runat="server" SkinID="RadToolBarButtonPrint"
                    Text="Print" Value="Print" ToolTip="Print the current expense report" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolbarButtonUpload" runat="server"
                    Text="Upload Receipts" Value="Upload" ToolTip="Upload a receipt" />
                <telerik:RadToolBarButton ID="RadToolbarButtonViewDocs" runat="server"
                    Text="Download Receipts" Value="ViewDocs" ToolTip="Download Receipts" />
                <telerik:RadToolBarButton ID="RadToolbarButtonViewAllDocs" runat="server"
                    Text="View Receipts" Value="ViewAllDocs" ToolTip="View Receipts" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton runat="server" ID="RadToolBarRefresh" SkinID="RadToolBarButtonRefresh" Value="Refresh"
                    ToolTip="Refresh" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="" Value="Bookmark"
                    ToolTip="Bookmark" Visible="false" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolbarButtonDeleteSelectedRows" runat="server" CommandName="DeleteSelectedRows"
                    Text="Delete Selected Rows" Value="DeleteSelectedRows" ToolTip="Delete Selected Rows" />
            </Items>
        </telerik:RadToolBar>
    </div>

        <div class="">
            <div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Invoice Number:
                    </div>
                    <div class="code-description-description-text">
                        <asp:Label ID="Label_InvoiceNumber" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Employee:
                    </div>
                    <div class="code-description-description-text">
                        <asp:Label ID="Label_EmployeeName" runat="server"></asp:Label>&nbsp;(<asp:Label ID="Label_EmployeeCode" runat="server"></asp:Label>)<asp:Label ID="Label_VendorCode" runat="server" Visible="False"></asp:Label>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Status:
                    </div>
                    <div class="code-description-description-text">
                        <asp:Image ID="Image_Status" runat="server" Visible="false" />
                        <asp:Label ID="Label_Status" runat="server"></asp:Label>
                        <telerik:RadToolTip ID="RadToolTipExpenseStatus" runat="server" TargetControlID="Image_Status" ShowEvent="OnMouseOver" RelativeTo="Element">
                            <asp:Label ID="LabelStatusInfo" runat="server"></asp:Label>
                        </telerik:RadToolTip>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Report Date:
                    </div>
                    <div class="code-description-description">
                        <telerik:RadDatePicker ID="RadDatePickerReportDate" runat="server" SkinID="RadDatePickerStandard" TabIndex="1">
                            <DateInput DateFormat="d" EmptyMessage="Report Date" CssClass="RequiredInput">
                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                            </DateInput>
                            <Calendar ID="CalendarStartDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                <SpecialDays>
                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                    </telerik:RadCalendarDay>
                                </SpecialDays>
                            </Calendar>
                        </telerik:RadDatePicker>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Created Date:
                    </div>
                    <div class="code-description-description-text">
                        <asp:Label ID="Label_CreatedDate" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Description:
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TextBox_ExpenseDescription" runat="server" MaxLength="30" Width="250px" CssClass="RequiredInput"
                            TabIndex="2"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        Detail:
                    </div>
                    <div class="code-description-description">
                        <telerik:RadTextBox ID="RadTextBox_ExpenseDetailDescription" runat="server" Height="75px" MaxLength="300" TextMode="MultiLine"
                            Width="500px" TabIndex="3" Resize="Both">
                        </telerik:RadTextBox>
                    </div>
                </div>

            </div>
            <div style="text-align: right; display: none !important;" class="RUSH">
                <asp:Label ID="Label_Approval" runat="server" Text="" Visible="true"></asp:Label>
            </div>
            <telerik:RadGrid ID="RadGridExpenseItems" runat="server" AllowPaging="True"
                AllowSorting="True" GridLines="None" PageSize="10" Width="100%"
                ShowFooter="True" AutoGenerateColumns="False" EnableAJAX="False" EnableAJAXLoadingTemplate="False" AllowMultiRowSelection="true" OnNeedDataSource="RadGridExpenseItems_NeedDataSource">
                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom"></PagerStyle>
                <ClientSettings AllowKeyboardNavigation="true">
                    <Selecting AllowRowSelect="true" />
                    <KeyboardNavigationSettings AllowSubmitOnEnter="false" />
                    <Resizing AllowColumnResize="true" AllowResizeToFit="true" ClipCellContentOnResize="false" />
                    <ClientEvents OnGridCreated="radGridOnGridCreated" OnRowContextMenu="OnRowContextMenu" />
                </ClientSettings>
                <MasterTableView CommandItemDisplay="None" AllowSorting="false" EditMode="InPlace" DataKeyNames="ID, ItemDate, Description, ClientCode, DivisionCode, ProductCode, JobNumber, JobComponentNumber, FunctionCode, Quantity, Amount, Rate" InsertItemDisplay="Top">
                    <CommandItemSettings AddNewRecordText="Add" RefreshText="Refresh" />
                    <Columns>
                        <telerik:GridTemplateColumn UniqueName="ColumnSelect" Visible="true">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="16px" />
                            <HeaderTemplate>
                                <input id="CheckBoxSelectAllRows" type="checkbox" name="CheckBoxSelectAllRows" onclick="SelectAllRows(this.checked)" />
                            </HeaderTemplate>
                            <ItemTemplate>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumn_ItemDate" HeaderText="Date" SortExpression="ItemDate" Resizable="false">
                            <ItemTemplate>
                                <telerik:RadDatePicker ID="RadDatePickerItemTemplate_ItemDate" runat="server" SkinID="RadDatePickerStandard">
                                    <DateInput ID="DateInput1" runat="server" DateFormat="d" EmptyMessage="Expense Date" CssClass="RequiredInput">
                                        <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                    </DateInput>
                                    <Calendar ID="CalendarDueDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                        <SpecialDays>
                                            <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                            </telerik:RadCalendarDay>
                                        </SpecialDays>
                                    </Calendar>
                                </telerik:RadDatePicker>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumn_ItemDescription" HeaderText="Description" SortExpression="Description" Resizable="false">
                            <ItemTemplate>
                                <telerik:RadTextBox ID="RadTextBox_ItemDescription" runat="server" Text='<%#Eval("Description") %>'
                                    MaxLength="600" CssClass="RequiredInput" TextMode="MultiLine" InputType="Text" Resize="Both" SkinID="RadTextBoxMultilineInGrid">
                                </telerik:RadTextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumn_Client" HeaderText="Client" SortExpression="ClientCode" Resizable="false">
                            <ItemStyle CssClass="code-input-column" />
                            <ItemTemplate>
                                <asp:TextBox ID="TextBoxClient" runat="server" MaxLength="6" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumn_Division" HeaderText="Division" SortExpression="DivisionCode" Resizable="false">
                            <ItemStyle CssClass="code-input-column" />
                            <ItemTemplate>
                                <asp:TextBox ID="TextBoxDivision" runat="server" MaxLength="6" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumn_Product" HeaderText="Product" SortExpression="ProductCode" Resizable="false">
                            <ItemStyle CssClass="code-input-column" />
                            <ItemTemplate>
                                <asp:TextBox ID="TextBoxProduct" runat="server" MaxLength="6" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumn_Job" HeaderText="Job Number" SortExpression="JobNumber" Resizable="false">
                            <ItemStyle CssClass="code-input-column" />
                            <ItemTemplate>
                                <telerik:RadNumericTextBox ID="RadNumericTextBoxJob" runat="server" NumberFormat-DecimalDigits="0" EnabledStyle-HorizontalAlign="Right">
                                    <NumberFormat GroupSeparator="" />
                                    <IncrementSettings InterceptMouseWheel="false" />
                                </telerik:RadNumericTextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumn_JobDescription" HeaderText="Job<br/>Description" SortExpression="JobDescription">
                            <ItemStyle CssClass="radgrid-description-column" />
                            <ItemTemplate>
                                <asp:Label ID="Label_JobDescription" runat="server" Text="" Style="white-space: nowrap;" adv-desc="Job"></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumn_JobComp" HeaderText="Job Comp" SortExpression="JobComponentNumber" Resizable="false">
                            <ItemStyle CssClass="code-input-column" />
                            <ItemTemplate>
                                <telerik:RadNumericTextBox ID="RadNumericTextBoxJobComponent" runat="server" NumberFormat-DecimalDigits="0" EnabledStyle-HorizontalAlign="Right">
                                    <NumberFormat GroupSeparator="" />
                                    <IncrementSettings InterceptMouseWheel="false" />
                                </telerik:RadNumericTextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumn_JobCompDescription" HeaderText="Comp<br/>Description" SortExpression="JobCompDescription">
                            <ItemStyle CssClass="radgrid-description-column" />
                            <ItemTemplate>
                                <asp:Label ID="Label_JobCompDescription" runat="server" Text="" Style="white-space: nowrap;" adv-desc="JobComponent"></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumn_Function" HeaderText="Function" SortExpression="FunctionCode" Resizable="false">
                            <ItemStyle CssClass="code-input-column" />
                            <ItemTemplate>
                                <asp:TextBox ID="TextBoxFunction" runat="server" MaxLength="6" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumn_Quantity" HeaderText="Quantity" SortExpression="Quantity" Resizable="false">
                            <ItemStyle CssClass="radgrid-amount-column" />
                            <ItemTemplate>
                                <telerik:RadNumericTextBox ID="RadNumericTextBoxQuantity" runat="server" DbValue='<%#Eval("Quantity")%>' CssClass="radgrid-amount-input" WrapperCssClass="radgrid-amount-input" adv-calc="Quantity">
                                    <NumberFormat DecimalDigits="0" KeepTrailingZerosOnFocus="true" />
                                    <EnabledStyle HorizontalAlign="Right" />
                                    <IncrementSettings InterceptMouseWheel="false" />
                                </telerik:RadNumericTextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumn_Rate" HeaderText="Rate" SortExpression="Rate" Resizable="false">
                            <ItemStyle CssClass="radgrid-amount-column" />
                            <ItemTemplate>
                                <telerik:RadNumericTextBox ID="RadNumericTextBoxRate" runat="server" DbValue='<%#Eval("Rate")%>' CssClass="radgrid-amount-input" WrapperCssClass="radgrid-amount-input" adv-calc="Rate">
                                    <NumberFormat DecimalDigits="4" KeepTrailingZerosOnFocus="true" />
                                    <EnabledStyle HorizontalAlign="Right" />
                                    <IncrementSettings InterceptMouseWheel="false" />
                                </telerik:RadNumericTextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumn_Amount" HeaderText="Amount" SortExpression="Amount" Resizable="false">
                            <ItemStyle CssClass="radgrid-amount-column" />
                            <ItemTemplate>
                                <telerik:RadNumericTextBox ID="RadNumericTextBoxAmount" runat="server" DbValue='<%#Eval("Amount")%>' CssClass="radgrid-amount-input" WrapperCssClass="radgrid-amount-input" adv-calc="Amount">
                                    <NumberFormat DecimalDigits="2" KeepTrailingZerosOnFocus="true" />
                                    <EnabledStyle HorizontalAlign="Right" />
                                    <IncrementSettings InterceptMouseWheel="false" />
                                </telerik:RadNumericTextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumn_PaymentType" HeaderText="Payment Type" Resizable="false">
                            <ItemTemplate>
                                <telerik:RadComboBox ID="RadComboboxItemTemplate_PaymentType" runat="server" CssClass="RequiredInput" DataTextField="Name" DataValueField="Value" InputCssClass="no-border"
                                    EmptyMessage="Payment..." SkinID="RadComboBoxText20">
                                </telerik:RadComboBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="CCBillable" ItemStyle-HorizontalAlign="Center" HeaderText="Non Billable" Resizable="false">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div class="icon-background standard-green" runat="server" id="DivFlagColor">
                                    <asp:Image ID="ImageCheck" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" />
                                </div>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="ItemDocuments" Resizable="false">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div id="DivDocuments" runat="server" class="icon-background background-color-sidebar">
                                    <asp:LinkButton ID="LinkButtonDocuments" runat="server" CssClass="icon-text" CommandName="Documents" CommandArgument='<%#Eval("ID")%>' ToolTip="Documents">D</asp:LinkButton>
                                </div>
                            </ItemTemplate>
                            <EditItemTemplate>
                            </EditItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSave" Resizable="false">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImageButton_SaveExpenseItem" runat="server" AlternateText="Save" CommandName="Save"
                                        CommandArgument='<%#Eval("ID")%>' ToolTip="Save" ImageAlign="AbsMiddle"
                                        SkinID="ImageButtonSaveWhite" />
                                </div>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <div class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImageButton_AddExpenseItem" runat="server" AlternateText="Add Item" CommandName="AddItem"
                                        ToolTip="Add Item" SkinID="ImageButtonNewWhite" />
                                </div>
                            </EditItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnCopy" Resizable="false">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div class="icon-background background-color-sidebar">
                                    <asp:ImageButton ID="ImageButton_CopyExpenseItem" runat="server" AlternateText="Copy" CommandName="Copy"
                                        CommandArgument='<%#Eval("ID")%>' ToolTip="Copy" SkinID="ImageButtonCopyWhite" />
                                </div>
                            </ItemTemplate>
                            <EditItemTemplate>
                            </EditItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDelete" Resizable="false">
                            <HeaderStyle CssClass="radgrid-icon-column" />
                            <ItemStyle CssClass="radgrid-icon-column" />
                            <FooterStyle CssClass="radgrid-icon-column" />
                            <ItemTemplate>
                                <div class="icon-background background-color-delete">
                                    <asp:ImageButton ID="ImageButton_DeleteExpenseItem" runat="server" AlternateText="Delete" CommandName="Delete"
                                        CommandArgument='<%#Eval("ID")%>' ToolTip="Delete" SkinID="ImageButtonDeleteWhite" />
                                </div>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <div class="icon-background background-color-delete">
                                    <asp:ImageButton ID="ImageButton_CancelExpenseItem" runat="server" AlternateText="Cancel" CommandName="CancelItem"
                                        ToolTip="Cancel add row" SkinID="ImageButtonCancelWhite" />
                                </div>
                            </EditItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                    <DetailItemTemplate>
                        <!-- Do Not Remove -->
                    </DetailItemTemplate>
                </MasterTableView>
            </telerik:RadGrid>
            <br />
            <telerik:RadContextMenu ID="RadContextMenuGridItem" runat="server" OnItemClick="RadContextMenuGridItem_ItemClick" OnClientItemClicking="RadContextMenuGridItemClicking">
                <Items>
                    <telerik:RadMenuItem Text="Copy Item" Value="CopyItem"></telerik:RadMenuItem>
                    <telerik:RadMenuItem IsSeparator="true"></telerik:RadMenuItem>
                    <telerik:RadMenuItem Text="Delete Item" Value="DeleteItem"></telerik:RadMenuItem>
                </Items>
            </telerik:RadContextMenu>
            <asp:HiddenField ID="HiddenFieldSelectedRow" runat="server" />
            <asp:HiddenField ID="HiddenFieldMinDate" runat="server" Value="" />
            <asp:HiddenField ID="HiddenFieldMaxDate" runat="server" Value="" />
            <asp:HiddenField ID="HiddenFieldSelectAll" runat="server" Value="0" />
        </div>

    </div>

    <telerik:RadScriptBlock ID="RadScriptBlockFooter" runat="server">
        <script type="text/javascript">

            function RadContextMenuGridItemClicking(sender, args) {
                var itemValue = args.get_item().get_value();
                if (itemValue == "DeleteItem") {
                    ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                };
            };

            function OnRowContextMenu(sender, args) {
                var evt = args.get_domEvent();
                if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
                    return;
                }

                document.getElementById('<%= HiddenFieldSelectedRow.ClientID %>').value = args.get_itemIndexHierarchical();

                var menu = $find('<%= RadContextMenuGridItem.ClientID %>');
                menu.show(evt);
                evt.cancelBubble = true;
                evt.returnValue = false;

                if (evt.stopPropagation) {
                    evt.stopPropagation();
                    evt.preventDefault();
                }

            }


            (function () {
                $('body')
                    .on('dblclick', 'input[adv-lookup]', function () {
                        if ($(this).is(":enabled")) {
                            getCurrentScope($(this)).openFilterDialog($(this));
                        }
                    })
                    .on('change', 'input[adv-lookup]', function () {
                        var currentScope = getCurrentScope($(this));
                        var lookuptype = $(this).attr('adv-lookup');
                        var jobComponent = {};
                        newVal = currentScope.getInputValue(lookuptype);
                        jobComponent = currentScope.getSearchCriteria().JobComponent;
                        if (lookuptype === 'Client') {
                            jobComponent.ClientName = null;
                            jobComponent.DivisionCode = null;
                            jobComponent.DivisionName = null;
                            jobComponent.ProductCode = null;
                            jobComponent.ProductName = null;
                            jobComponent.JobNumber = null;
                            jobComponent.JobDescription = null;
                            jobComponent.JobComponentNumber = null;
                            jobComponent.JobComponentDescription = null;
                            currentScope.jobComponentValuesChanged(jobComponent, newVal);
                        } else if (lookuptype === 'Division') {
                            jobComponent.DivisionName = null;
                            jobComponent.ProductCode = null;
                            jobComponent.ProductName = null;
                            jobComponent.JobNumber = null;
                            jobComponent.JobDescription = null;
                            jobComponent.JobComponentNumber = null;
                            jobComponent.JobComponentDescription = null;
                            currentScope.jobComponentValuesChanged(jobComponent, newVal);
                        } else if (lookuptype === 'Product') {
                            jobComponent.ProductName = null;
                            jobComponent.JobNumber = null;
                            jobComponent.JobDescription = null;
                            jobComponent.JobComponentNumber = null;
                            jobComponent.JobComponentDescription = null;
                            currentScope.jobComponentValuesChanged(jobComponent, newVal);
                        } else if (lookuptype === 'Job') {
                            jobComponent.JobDescription = null;
                            jobComponent.JobComponentNumber = null;
                            jobComponent.JobComponentDescription = null;
                            currentScope.jobComponentValuesChanged(jobComponent, newVal);
                        } else if (lookuptype === 'JobComponent') {
                            jobComponent.JobComponentDescription = null;
                            currentScope.jobComponentValuesChanged(jobComponent, newVal);
                        } else if (lookuptype === 'Function') {
                            currentScope.functionValuesChanged(currentScope.getSearchCriteria().Function, newVal);
                        }
                    })
                    .on('focus', 'input[adv-calc]', function () {
                        getCurrentScope($(this)).parentRow = $(this).closest('tr');
                    })
                    .on('focus', '.RadGrid input[adv-lookup]', function () {
                        getCurrentScope($(this)).parentRow = $(this).closest('tr');
                    });
            })();

            function getCurrentScope(element) {
                return angular.element(element).scope();
            }

        </script>
    </telerik:RadScriptBlock>

    <asp:HiddenField ID="HiddenFieldSecMod" runat="server" ClientIDMode="Static" />

</asp:Content>
