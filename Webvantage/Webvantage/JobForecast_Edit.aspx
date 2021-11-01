<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="JobForecast_Edit.aspx.vb" Inherits="Webvantage.JobForecast_Edit" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="ContentJobForecastDetails" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">
    <style type="text/css">
        #budgetVsActual table, #budgetVsActual td, #budgetVsActual th {
            border: 1px solid silver;
            border-collapse: collapse;
        }
        #budgetVsActual td {
            padding: 5px;
        }
        input.riTextBox:disabled  {
            border: none !important;
            box-shadow: none !important;
            background: none !important;
            font-weight: normal !important;
        }
        .disp-month-actual {
            display: none;
            margin-top: 5px !important; 
            text-align: right;
            background: none !important;
            border: none !important;
            box-shadow: none !important;
        }
        .larger-font {
            font-size: larger;
        }
        .RadGrid input.riTextBox[id*=_Total]{
           font-weight: 600 !important;
        }
        .RadGrid_Bootstrap tbody tr.rgFooter td.radgrid-amount-column {
            padding-right: 7px;
        }
    </style>
    <telerik:RadScriptBlock ID="RadScriptBlock" runat="server">
        <script type="text/javascript">
            function imposeMaxLength(Object, MaxLen) {
                return (Object.value.length <= MaxLen);
            }
        </script>
    </telerik:RadScriptBlock>
    <script type="text/javascript" src="Scripts/kendo/current/kendo.all.min.js"></script>
    <telerik:RadScriptBlock ID="RadScriptBlockSub" runat="server">
        <script type="text/javascript">

            function JsOnClientButtonClicked(sender, args) {
                var CommandName = args.get_item().get_commandName();
                if (CommandName == "ActualsByMonth") {
                    //displayActuals();
                }
            }

            function JsOnClientButtonClicking(sender, args) {
                var CommandName = args.get_item().get_commandName();
                if (CommandName == "DeleteRevision") {
                    ////args.set_cancel(!confirm('Are you sure you want to delete this revision?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete this revision?");
                }
                if (CommandName == "Delete") {
                    ////args.set_cancel(!confirm('Are you sure you want to delete this forecast?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete this forecast?");
                }
                if (CommandName == "Unapprove") {
                    ////args.set_cancel(!confirm('Are you sure you want to unapprove this Forecast?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to unapprove this Forecast?");
                }
                if (CommandName == "ApproveConfirm") {
                    var currentRev = $find('<%= DropDownListJobForecastRevision.ClientID%>').get_text();
                    ////args.set_cancel(!confirm(args.get_item().get_commandArgument()));
                    radToolBarConfirm(sender, args, args.get_item().get_commandArgument());
                }
                if (CommandName == "DeleteJobComponent") {
                    ////args.set_cancel(!confirm('<%= AdvantageFramework.JobForecast.GetConfirmDeleteMessage(Me.HasMultipleRevisions)%>'));
                    radToolBarConfirm(sender, args, "<%= AdvantageFramework.JobForecast.GetConfirmDeleteMessage(Me.HasMultipleRevisions)%>");
                }
            }

            function RadContextMenuGridOnClientItemClicking(sender, args) {
                var value = args.get_item().get_value();
                if (value == 'Delete') {
                    ////args.set_cancel(!confirm('<%= AdvantageFramework.JobForecast.GetConfirmDeleteMessage(Me.HasMultipleRevisions)%>'));
                    radToolBarConfirm(sender, args, "<%= AdvantageFramework.JobForecast.GetConfirmDeleteMessage(Me.HasMultipleRevisions)%>");
                }
            }

            function getContextMenuDataItem() {
                var index = document.getElementById('<%= HiddenFieldContextMenuSelectedRow.ClientID%>').value;
                var dataItems = $find('<%= RadGridJobForecast.ClientID%>').get_masterTableView().get_dataItems();
                var dataItem;
                var counter = 0;
                while (counter <= dataItems.length && !dataItem) {
                    if (dataItems[counter].get_itemIndexHierarchical() == index) {
                        dataItem = dataItems[counter];
                        counter = dataItems.length + 1;
                    }
                    counter += 1;
                }
                return dataItem;
            }

            function updateComments(sender, args) {
                var dataItem = sender.get_parent();
                var jobForecastJobID = dataItem.getDataKeyValue('JobForecastJobID');
                var data = {
                    JobForecastJobID: jobForecastJobID,
                    Comments: args.get_newValue()
                };
                $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: '<%= Webvantage.Controllers.FinanceAndAccounting.JobForecastController.BaseRoute %>UpdateJobComments', 
                        dataType: "json",
                        data: JSON.stringify(data),
                        success: function (result) {
                            
                        },
                        error: function (msg) {
                            ShowMessage('Error updating comments!');
                        }
                    });
            }

            function updateAmount(sender, args) {
                var vals = sender.get_id().split("_");
                var gridColName = vals[vals.length - 1];
                var dataItem = sender.get_parent();
                var jobForecastJobID = dataItem.getDataKeyValue('JobForecastJobID');
                var gridCol = $find('<%= RadGridJobForecast.ClientID%>').get_masterTableView().getColumnByUniqueName(gridColName);
                if (gridCol) {
                    var dataField = gridCol.get_dataField().split("_");
                    var postPeriod = dataField[1];
                    var billOrRev = dataField[0].indexOf('Billing') > -1 ? 0 : 1;
                    var data = {
                        JobForecastJobID: jobForecastJobID,
                        PostPeriodCode: postPeriod,
                        Amount: !isNaN(parseFloat(sender.get_value())) ? parseFloat(sender.get_value()) : null,
                        BillingOrRevenue: billOrRev
                    };
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: '<%= Webvantage.Controllers.FinanceAndAccounting.JobForecastController.BaseRoute %>UpdatePostPeriodAmount', 
                        dataType: "json",
                        data: JSON.stringify(data),
                        success: function (result) {
                            if(result.Status === 200){
                                setDataItemBudget(dataItem, result.Budget);
                            } else if (result.Status === 400){
                                if(result.Message){
                                    ShowMessage(result.Message);
                                } else {
                                    ShowMessage('Error updating amount!');
                                }
                                $find('<%= RadGridJobForecast.ClientID%>').get_masterTableView().rebind();
                            }
                        },
                        error: function (msg) {
                            ShowMessage('Error updating amount!');
                        }
                    });
                }
            }

            function setDataItemBudget(dataItem, budget){
                if (dataItem) {
                    var values = dataItem.get_owner().extractValuesFromItem(dataItem.get_element());
                    var actual = values['Actual'];
                    var variance;
                    if (actual == '' || isNaN(actual)) {
                        actual = 0;
                    } else {
                        actual = Number(actual);
                    }
                    dataItem.findControl('RNTB_GridNumericColumnBudget').set_value(budget);
                    dataItem.findControl('RNTB_GridNumericColumnVariance').set_value(budget - actual);
                }
                calculateTotals();
            }

            function calculateTotals() {
                var masterTable = $find('<%= RadGridJobForecast.ClientID%>').get_masterTableView();
                var totals = [];
                var props = [];
                for (var i = 0; i < masterTable.get_dataItems().length; i++) {
                    var values = masterTable.extractValuesFromItem(i);
                    var dataItem = masterTable.get_dataItems()[i];
                    var grpIdx = $(dataItem.get_element()).attr('grpidx');
                    var grpItem;
                    for (var prop in values) {
                        var value = values[prop];
                        if (value == '' || isNaN(value)) {
                            value = 0;
                        }
                        var item = { FieldName: prop, GroupIndex: grpIdx, Value: value };
                        totals.push(item);
                        if (!props.includes(prop)) {
                            props.push(prop);
                        }
                    }
                }
                $.each(props, function (key, fieldName) {
                    var items = $.grep(totals, function (e) { return e.FieldName === fieldName });
                    var grpItems = [];
                    var total = 0;
                    var additionalVal = 0;
                    if (items && items.length > 0) {
                        $.each(items, function () {
                            if (!grpItems[this.GroupIndex]) {
                                grpItems[this.GroupIndex] = 0;
                            }
                            grpItems[this.GroupIndex] += this.Value;
                            total += this.Value;
                        });
                    }
                    additionalVal = $('input[id*=' + fieldName + '_Total][oItems]').attr('oItems');
                    if (additionalVal == '' || isNaN(additionalVal)) {
                        additionalVal = 0;
                    }
                    $('input[id*=' + fieldName + '_Total]').each(function () {
                        var radInput = $find($(this).attr('id'));
                        if (radInput) {
                            radInput.set_value(total + Number(additionalVal));
                        }
                    });
                    $.each(grpItems, function (groupIndex, groupValue) {
                        $('tr[grpidx=' + groupIndex + ']').find('input[id*=' + fieldName + '_Group_Total]').each(function () {
                            var radInput = $find($(this).attr('id'));
                            if (radInput) {
                                radInput.set_value(groupValue);
                            }
                        });
                    });
                });
            }

            var colorPickerInit = false;

            function updateRowColor(dataItem, color) {
                var jobForcastJobID = dataItem.getDataKeyValue('JobForecastJobID');
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "<%= Webvantage.Controllers.FinanceAndAccounting.JobForecastController.BaseRoute %>UpdateJobColor",
                    data: "{ 'JobForecastJobID' : " + jobForcastJobID + ", 'Color' : '" + color + "' }",
                    success: function (msg) {
                        dataItem.findElement('HiddenFieldRowColor').value = color;
                        $(dataItem.get_element()).addClass('rgRow').removeClass('rgAltRow').css('background-color', color);
                        dataItem.get_owner().deselectItem(dataItem.get_element());
                    },
                    error: function (msg) {
                        ShowMessage('Error changing row color!');
                    }
                });
            }

            function colorPickerChanged(sender, args) {
                if (colorPickerInit == false) {
                    var grid = $find('<%= RadGridJobForecast.ClientID%>').get_masterTableView();
                    var color = sender.get_selectedColor();
                    if (grid.get_selectedItems().length > 0) {
                        $(grid.get_selectedItems()).each(function () {
                            updateRowColor(this, color);
                        });
                    } else {
                        updateRowColor(getContextMenuDataItem(), color);
                    }
                }
            }
            
            function formatNumber(number, decimalPlaces) {
                return parseFloat(number).toFixed(decimalPlaces).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
            }

            function radGridOnRowContextMenu(sender, args) {
                var evt = args.get_domEvent();
                if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
                    return;
                }
                document.getElementById('<%= HiddenFieldContextMenuSelectedRow.ClientID%>').value = args.get_itemIndexHierarchical();
                var color = args.get_gridDataItem().findElement('HiddenFieldRowColor').value;
                var menu = $find('<%= RadContextMenuGrid.ClientID%>');
                var colorPicker = menu.findItemByValue('Color').findControl('RadColorPickerGrid');
                //if (args.get_tableView().get_selectedItems().length > 1) {
                    var isRightClickItemSelected = false;
                    for (var i = 0; i < args.get_tableView().get_selectedItems().length; i++) {
                        var di = args.get_tableView().get_selectedItems()[i];
                        if (di.findElement('HiddenFieldRowColor').value != color) {
                            color = null;
                        }
                        if (di.get_itemIndexHierarchical() === args.get_itemIndexHierarchical()) {
                            isRightClickItemSelected = true;
                        }
                    }
                    if (isRightClickItemSelected === false) {
                        var items = args.get_tableView().get_selectedItems();
                        for (var i = 0; i < items.length; i++) {
                            var di = items[i];
                            args.get_tableView().deselectItem(di.get_element());
                        }
                    }
                //} 
                colorPickerInit = true;
                colorPicker.set_selectedColor(color, true);
                colorPickerInit = false;
                menu.show(evt);
                evt.cancelBubble = true;
                evt.returnValue = false;
                if (evt.stopPropagation) {
                    evt.stopPropagation();
                    evt.preventDefault();
                }
            }

            function checkRowSelection() {
                var grid = $find('<%= RadGridJobForecast.ClientID%>').get_masterTableView();
                var menu = $find('<%= RadToolBarJobForecastRevision.ClientID%>');
                var hasSelectedRow = false;
                var hasRows = false;
                if (grid.get_selectedItems().length > 0) {
                    hasSelectedRow = true;
                }
                if (grid.get_dataItems().length > 0) {
                    hasRows = true;
                }
                var deleteItem = menu.findItemByValue('DeleteJobComponent');
                if (deleteItem) {
                    deleteItem.set_enabled(hasSelectedRow);
                }
            }

            function displayActuals() {
                var display = 'none';
                var button = $find('<%= RadToolBarJobForecastRevision.ClientID%>').findItemByValue('ActualsByMonth');
                if(button){
                    if(button.get_checked()){
                        display = 'block';
                    }
                }
                $('.disp-month-actual').css('display', display);
            }

            function setWindowNavigateUrl(url){
                var oWindow = GetRadWindow();
                if (oWindow) {
                    oWindow.set_navigateUrl(url);
                }
            }

            function calculateForecastVariance() {
                var varianceInput = $find('<%= RadNumericTextBoxBudgetForecastVariance.ClientID %>');
                var budgetInput = $find('<%= RadNumericTextBoxForecastBudget.ClientID %>');
                var forecastInput = $find('<%= RadNumericTextBoxForecast_Total.ClientID %>');
                var budget = budgetInput.get_value();
                var forecast = forecastInput.get_value();
                if (isNaN(budget)) {
                    budget = 0;
                }
                if (isNaN(forecast)) {
                    forecast = 0;
                }
                if (varianceInput) {
                    varianceInput.set_value(budget - forecast);
                }
            }

            function ActualizeClicking(sender, args) {
                ////args.set_cancel(!confirm('Are you sure you want to Actualize the monthly forecast amounts?'));
                radToolBarConfirm(sender, args, "Are you sure you want to Actualize the monthly forecast amounts?");
            }

            function RollForwardCheckedChanged(sender, args) {
                var nextMonthOnlyButton = $find('<%= RadButtonRollForwardToNextMonthOnly.ClientID %>');
                if (nextMonthOnlyButton) {
                    nextMonthOnlyButton.set_enabled(args.get_checked());
                }
            }

            function ShowActualizeToolTip(element) {
                var tooltip = $find("<%=RadToolTipActualize.ClientID%>");
                tooltip.set_targetControl(element);
                tooltip.show();
            }
            function ShowAllocateToolTip(element) {
                var tooltip = $find("<%=RadToolTipAllocate.ClientID%>");
                tooltip.set_targetControl(element);
                tooltip.show();
            }

            function OnClientMouseOver(sender, args) {
                var button = args.get_item();
                var sCommandName = button.get_commandName();
                if (sCommandName == 'Allocate') {
                    ShowAllocateToolTip(button.get_element());
                }
                if (sCommandName == 'Actualize') {
                    ShowActualizeToolTip(button.get_element());
                }
            }


            (function ($) {
                $.fn.center = function () {
                    this.css("position", "absolute");
                    this.css("top", (($(window).height() - this.outerHeight()) / 2) + $(window).scrollTop() + "px");
                    this.css("left", (($(window).width() - this.outerWidth()) / 2) + $(window).scrollLeft() + "px");
                    return this;
                }
            })($telerik.$);
        </script>
    </telerik:RadScriptBlock>
    <div class="no-float-menu">
        <telerik:RadToolBar ID="RadToolBarJobForecastRevision" runat="server" AutoPostBack="true"
            Width="100%" 
            OnClientButtonClicking="JsOnClientButtonClicking" 
            OnClientButtonClicked="JsOnClientButtonClicked" 
            OnClientMouseOver="OnClientMouseOver" 
            style="z-index: 999999">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonSave" runat="server" SkinID="RadToolBarButtonSave"
                    Text="" Value="Save" CommandName="Save" ToolTip="Save Job Forecast" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonGridJobComponents" runat="server" Text="Job Components" Value="JobComponents" CommandName="JobComponents" ToolTip="Add/Remove Job Components" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonCreateRevision" runat="server" 
                    Text="Create Revision" Value="CreateRevision" CommandName="CreateRevision" ToolTip="Create new revision" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonDeleteRevision" runat="server"
                    Text="Delete Revision" Value="DeleteRevision" CommandName="DeleteRevision" ToolTip="Delete revision" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonApprove" runat="server" 
                    Text="Approve" Value="Approve" CommandName="Approve" ToolTip="Approve revision" />
                <telerik:RadToolBarButton ID="RadToolBarButtonUnapprove" runat="server"
                    Text="Unapprove" Value="Unapprove" CommandName="Unapprove" Visible="false" ToolTip="Unapprove revision" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonActualsByMonth" runat="server"
                    Text="Actuals by Month" Value="ActualsByMonth" CommandName="ActualsByMonth" ToolTip="Display Actuals by Month" CheckOnClick="true" AllowSelfUnCheck="true" PostBack="true"  />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonActualize" runat="server" Text="Actualize" Value="Actualize" CommandName="Actualize" PostBack="false" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonAllocate" runat="server" Text="Allocate" Value="Allocate" CommandName="Allocate" PostBack="false" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonGroupOptions" runat="server">
                    <ItemTemplate>
                        <telerik:RadComboBox ID="RadComboBoxGroupOptions" runat="server" Label="Group by:" ZIndex="999999" OnSelectedIndexChanged="RadComboBoxGroupOptions_SelectedIndexChanged" AutoPostBack="true" SkinID="RadComboBoxStandard">
                            <Items>
                                <telerik:RadComboBoxItem Value="C" Text="Client" Selected="true" />
                                <telerik:RadComboBoxItem Value="S" Text="Sales Class" />
                                <telerik:RadComboBoxItem Value="CS" Text="Client/Sales Class" />
                            </Items>
                        </telerik:RadComboBox>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonSettings" runat="server" SkinID="RadToolBarButtonSettings"
                    Text="Settings" Value="Settings" ToolTip="Open Job Forecast Settings" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarDropDown ID="RadToolBarDropDownExport" runat="server" Text="Export">
                    <Buttons>
                        <telerik:RadToolBarButton ID="RadToolBarButtonExportToExcel" runat="server" Value="ExportToExcel" CommandName="ExportToExcel" Text="To Excel" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonExportOptions" runat="server" Value="ExportOptions" CommandName="ExportOptions" Text="Options" />
                    </Buttons>
                </telerik:RadToolBarDropDown>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinId="RadToolBarButtonBookmark" Text="" Value="Bookmark"
                    ToolTip="Bookmark" Visible="false" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolbarButtonRefresh" runat="server" SkinID="RadToolBarButtonRefresh" Value="Refresh" ToolTip="Refresh Forecast" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton ID="RadToolBarButtonGridDelete" runat="server" Value="DeleteJobComponent" CommandName="DeleteJobComponent" ToolTip="Remove Job Component(s) from Forecast"  SkinID="RadToolBarButtonDelete"/>
                <telerik:RadToolBarButton IsSeparator="true" />
                </Items>
        </telerik:RadToolBar>
    </div>
    <div class="telerik-aqua-body">
        <telerik:RadToolTip ID="RadToolTipActualize" runat="server" 
            SkinID="RadToolTipToolbarContentArea" Width="365" Height="225" style="z-index: 9999999">
                <div>
                    <div class="larger-font" style="width: 280px;">
                        Actualize Options
                    </div>
                    <div style="margin: 10px 0px 0px 0px !important;">
                        <asp:RadioButtonList ID="RadioButtonListActualizeType" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Entire Forecast" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Selected rows" Value="1"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div class="form-layout">
                        <ul>
                            <li>Post Period Cutoff:</li>
                            <li><telerik:RadComboBox ID="RadComboBoxPostPeriodCutoff" runat="server" SkinID="RadComboBoxPostPeriod" DataValueField ="Code" DataTextField="Description" ZIndex="999999999">
                                </telerik:RadComboBox></li>
                        </ul>
                        <ul>
                            <li></li>
                            <li><telerik:RadButton ID="RadButtonRollForwardBalances" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" Text="Roll Forward Balance" AutoPostBack="false" OnClientCheckedChanged="RollForwardCheckedChanged">
                                </telerik:RadButton></li>
                        </ul>
                        <ul>
                            <li></li>
                            <li><telerik:RadButton ID="RadButtonRollForwardToNextMonthOnly" runat="server" ToggleType="CheckBox" ButtonType="ToggleButton" Text="Next Post Period Only" AutoPostBack="false" ToolTip="Roll Forward Balance to Post Period after Selected Cutoff" Enabled="false"></telerik:RadButton></li>
                        </ul>
                        <ul>
                            <li style="text-align: left;"></li>
                            <li style="text-align: right;"><telerik:RadButton ID="RadButtonActualize" runat="server" ButtonType="StandardButton" Text="Actualize" OnClientClicking="ActualizeClicking"></telerik:RadButton></li>
                        </ul>
                    </div>
                </div>
            </telerik:RadToolTip>
        <telerik:RadToolTip ID="RadToolTipAllocate" runat="server"
            SkinID="RadToolTipToolbarContentArea" Width="245" Height="175" style="z-index: 9999999999">
            <div>
                <div class="larger-font" style="width: 280px;">
                    Allocate Options
                </div>
                <div style="margin: 10px 0px 0px 0px !important;">
                    <asp:RadioButtonList ID="RadioButtonListAllocateType" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Entire Forecast" Value="0" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Selected rows" Value="1"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div style="margin-top: 10px; margin-left: auto; margin-right: auto; text-align: center;">
                    <telerik:RadButton ID="RadButtonAllocate" runat="server" ButtonType="StandardButton" Text="Allocate"></telerik:RadButton>
                </div>
            </div>
        </telerik:RadToolTip>

            <div style="">
                <asp:Label ID="LabelApproved" runat="server" Font-Size="Medium" CssClass="warning" Text="" Visible="False" style="line-height: 40px; vertical-align: middle; text-transform: uppercase;"/>
            </div>
            <div class="grid-container" style="clear:both; white-space:nowrap;">
                <div style="display:inline-block;">
                    <div class="grid-container">
                        <div class="form-layout">
                            <ul>
                                <li>Description:</li>
                                <li style="width: 760px"><telerik:RadTextBox ID="RadTextBoxDescription" runat="server" Width="100%" AutoPostBack="false" MaxLength="100" CssClass="RequiredInput"></telerik:RadTextBox></li>
                            </ul>
                            <ul>
                                <li>Comment:</li>
                                <li style="width: 760px"><telerik:RadTextBox ID="RadTextBoxComment" runat="server" Width="100%" AutoPostBack="false" TextMode="MultiLine" Rows="3"></telerik:RadTextBox></li>
                            </ul>
                            <ul>
                                <li>Revision:</li>
                                <li><telerik:RadComboBox ID="DropDownListJobForecastRevision" runat="server" AutoPostBack="true" Width="100px" DataTextField="Number" DataValueField="ID" SkinID="RadComboBoxStandard"></telerik:RadComboBox></li>
                            </ul>
                            <div>
                                <div class="form-layout" style="float: left;">
                                    <ul>
                                        <li>Start/End:</li>
                                        <li><asp:Label ID="LabelMonthYear" runat="server" Text=""></asp:Label></li>
                                    </ul>
                                    <ul>
                                        <li>Assigned To:</li>
                                        <li><asp:Label ID="LabelAssignedEmployee" runat="server" Text=""></asp:Label></li>
                                    </ul>
                                    <ul>
                                        <li>Office:</li>
                                        <li><asp:Label ID="LabelOffice" runat="server" Text=""></asp:Label></li>
                                    </ul>
                                </div>
                                <div class="form-layout"  style="float: left; margin-left: 10px;">
                                    <ul>
                                        <li>Created By:</li>
                                        <li><asp:Label ID="LabelCreatedBy" runat="server" Text=""></asp:Label></li>
                                    </ul>
                                    <ul>
                                        <li>Modified By:</li>
                                        <li><asp:Label ID="LabelModifiedBy" runat="server" Text=""></asp:Label></li>
                                    </ul>
                                    <ul>
                                        <li>Approved By:</li>
                                        <li><asp:Label ID="LabelApprovedBy" runat="server" Text=""></asp:Label></li>
                                    </ul>
                                </div>
                                <div style="clear: both;"></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="display:inline-block; margin-left:20px;">
                    <table width="325px" border="0" cellspacing="0" cellpadding="0" id="budgetVsActual">
                        <tr>
                            <td style="text-align: center; font-weight: bold; background-color: LightGray;" valign="middle">Budget Total:</td>
                            <td style="text-align: right; width: 125px;" valign="middle">
                                <telerik:RadNumericTextBox ID="RadNumericTextBoxForecastBudget" runat="server" NumberFormat-DecimalDigits="2" 
                                    FocusedStyle-HorizontalAlign="Right" EnabledStyle-HorizontalAlign="Right" Width="100%" NumberFormat-KeepTrailingZerosOnFocus="true" MaxValue="9999999999999.99"
                                    ClientEvents-OnValueChanged="calculateForecastVariance">
                                </telerik:RadNumericTextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: center; font-weight: bold; background-color: LightGray;" valign="middle">Forecast:</td>
                            <td style="text-align: right; width: 125px;" valign="middle">
                                <telerik:RadNumericTextBox ID="RadNumericTextBoxForecast_Total" runat="server" NumberFormat-DecimalDigits="2" ReadOnly="true" Enabled="false"
                                    FocusedStyle-HorizontalAlign="Right" EnabledStyle-HorizontalAlign="Right" Width="100%" NumberFormat-KeepTrailingZerosOnFocus="true" MaxValue="9999999999999.99"
                                    ClientEvents-OnValueChanged="calculateForecastVariance">
                                </telerik:RadNumericTextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: center; font-weight: bold; background-color: LightGray;" valign="middle">Variance:</td>
                            <td style="text-align: right; width: 125px;" valign="middle"><telerik:RadNumericTextBox ID="RadNumericTextBoxBudgetForecastVariance" runat="server" NumberFormat-DecimalDigits="2" ReadOnly="true" Enabled="false"
                                    FocusedStyle-HorizontalAlign="Right" EnabledStyle-HorizontalAlign="Right" Width="100%" NumberFormat-KeepTrailingZerosOnFocus="true" MaxValue="9999999999999.99">
                                </telerik:RadNumericTextBox></td>
                        </tr>
                    </table>
                </div>
            </div>
            <telerik:RadGrid ID="RadGridJobForecast" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="10"
                ShowFooter="true" EnableLinqExpressions="false" AllowMultiRowEdit="true" ShowGroupPanel="false" GridLines="None" AllowMultiRowSelection="true" Width="100%">
                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" PageSizes="10,15,20" />
                <ClientSettings AllowKeyboardNavigation="true">
                    <Selecting AllowRowSelect="true" />
                    <Scrolling  />
                    <ClientEvents OnGridCreated="function(s, e) { OnGridCreated(s, e); calculateTotals(); }" OnRowContextMenu="radGridOnRowContextMenu" OnRowSelected="OnRowSelected" OnRowDeselected="OnRowSelected"/>
                </ClientSettings>
                <MasterTableView CommandItemDisplay="None" AllowSorting="true" EditMode="InPlace" GroupLoadMode="Client" DataKeyNames="JobForecastJobID, JobNumber, JobComponentNumber" ClientDataKeyNames="JobForecastJobID, Actual" 
                    Width="100%" EnableGroupsExpandAll="true" AllowMultiColumnSorting="true" ShowGroupFooter="true">
                    <PagerStyle PageSizes="10,15,20" />
                    <GroupByExpressions>
                        <telerik:GridGroupByExpression>
                            <SelectFields>
                                <telerik:GridGroupByField FieldName="ClientName" />
                            </SelectFields>
                            <GroupByFields>
                                <telerik:GridGroupByField FieldName="ClientName" />
                                <telerik:GridGroupByField FieldName="ClientCode" />
                            </GroupByFields>
                        </telerik:GridGroupByExpression>
                    </GroupByExpressions>
                    <SortExpressions>
                        <telerik:GridSortExpression FieldName="JobNumber" SortOrder="Descending" />
                        <telerik:GridSortExpression FieldName="JobComponentNumber" SortOrder="Ascending" />
                    </SortExpressions>
                    <ColumnGroups>
                        <telerik:GridColumnGroup Name="YearGroup1" HeaderText="" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="LightGray" HeaderStyle-Font-Bold="true"></telerik:GridColumnGroup>
                        <telerik:GridColumnGroup Name="YearGroup2" HeaderText="" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Silver"  HeaderStyle-Font-Bold="true"></telerik:GridColumnGroup>
                        <telerik:GridColumnGroup Name="PostPeriod1" HeaderText="" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Silver"  HeaderStyle-Font-Bold="true"></telerik:GridColumnGroup>
                        <telerik:GridColumnGroup Name="PostPeriod2" HeaderText="" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Silver"  HeaderStyle-Font-Bold="true"></telerik:GridColumnGroup>
                        <telerik:GridColumnGroup Name="PostPeriod3" HeaderText="" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Silver"  HeaderStyle-Font-Bold="true"></telerik:GridColumnGroup>
                        <telerik:GridColumnGroup Name="PostPeriod4" HeaderText="" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Silver"  HeaderStyle-Font-Bold="true"></telerik:GridColumnGroup>
                        <telerik:GridColumnGroup Name="PostPeriod5" HeaderText="" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Silver"  HeaderStyle-Font-Bold="true"></telerik:GridColumnGroup>
                        <telerik:GridColumnGroup Name="PostPeriod6" HeaderText="" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Silver"  HeaderStyle-Font-Bold="true"></telerik:GridColumnGroup>
                        <telerik:GridColumnGroup Name="PostPeriod7" HeaderText="" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Silver"  HeaderStyle-Font-Bold="true"></telerik:GridColumnGroup>
                        <telerik:GridColumnGroup Name="PostPeriod8" HeaderText="" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Silver"  HeaderStyle-Font-Bold="true"></telerik:GridColumnGroup>
                        <telerik:GridColumnGroup Name="PostPeriod9" HeaderText="" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Silver"  HeaderStyle-Font-Bold="true"></telerik:GridColumnGroup>
                        <telerik:GridColumnGroup Name="PostPeriod10" HeaderText="" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Silver"  HeaderStyle-Font-Bold="true"></telerik:GridColumnGroup>
                        <telerik:GridColumnGroup Name="PostPeriod11" HeaderText="" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Silver"  HeaderStyle-Font-Bold="true"></telerik:GridColumnGroup>
                        <telerik:GridColumnGroup Name="PostPeriod12" HeaderText="" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Silver"  HeaderStyle-Font-Bold="true"></telerik:GridColumnGroup>
                        <telerik:GridColumnGroup Name="PostPeriod13" HeaderText="" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Silver"  HeaderStyle-Font-Bold="true"></telerik:GridColumnGroup>
                        <telerik:GridColumnGroup Name="PostPeriod14" HeaderText="" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Silver"  HeaderStyle-Font-Bold="true"></telerik:GridColumnGroup>
                        <telerik:GridColumnGroup Name="PostPeriod15" HeaderText="" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Silver"  HeaderStyle-Font-Bold="true"></telerik:GridColumnGroup>
                        <telerik:GridColumnGroup Name="PostPeriod16" HeaderText="" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Silver"  HeaderStyle-Font-Bold="true"></telerik:GridColumnGroup>
                        <telerik:GridColumnGroup Name="PostPeriod17" HeaderText="" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Silver"  HeaderStyle-Font-Bold="true"></telerik:GridColumnGroup>
                        <telerik:GridColumnGroup Name="PostPeriod18" HeaderText="" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Silver"  HeaderStyle-Font-Bold="true"></telerik:GridColumnGroup>
                    </ColumnGroups>
                    <Columns>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnJobAndComponent" HeaderText="Job/Component">
                            <ItemStyle CssClass="radgrid-large-description-column" />
                            <Itemtemplate>
                                <asp:Label ID="LabelJobAndComponent" runat="server" style="white-space: nowrap;"/>
                                <asp:HiddenField ID="HiddenFieldRowColor" runat="server" Value="" />
                            </Itemtemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn UniqueName="GridBoundColumnSalesClass" HeaderText="Sales Class" DataField="SalesClassDescription" ReadOnly="true"></telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn UniqueName="GridTemplateColumnComments" HeaderText="Comments" DataField="Comments">
                            <ItemStyle CssClass="radgrid-textarea-column" />
                            <ItemTemplate>
                                <telerik:RadTextBox ID="RadTextBoxComments" runat="server" TextMode="MultiLine" ReadOnly="true" Text='<%# Eval("Comments")%>' Resize="Vertical" CssClass="radgrid-textarea" WrapperCssClass="radgrid-textarea"></telerik:RadTextBox>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <telerik:RadTextBox ID="RadTextBoxCommentsEdit" runat="server" TextMode="MultiLine" Text='<%# Eval("Comments")%>' Resize="Vertical" CssClass="radgrid-textarea" WrapperCssClass="radgrid-textarea" MaxLength="100" ReadOnly='<%#Not IsRevisionEditable %>'>
                                    <ClientEvents OnValueChanged="updateComments" />
                                </telerik:RadTextBox>
                            </EditItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnApprovedEstimateAmount" HeaderText="Estimate" DataField="ApprovedEstimateAmount" ItemStyle-CssClass="radgrid-amount-column" HeaderStyle-CssClass="radgrid-amount-column" DataFormatString="{0:N2}"></telerik:GridNumericColumn>
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnBudget" HeaderText="Forecast" DataField="Forecast" ItemStyle-CssClass="radgrid-amount-column" HeaderStyle-CssClass="radgrid-amount-column" FooterStyle-HorizontalAlign="Left" DataFormatString="{0:N2}"></telerik:GridNumericColumn>
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnActual" HeaderText="Actual" DataField="Actual" ItemStyle-CssClass="radgrid-amount-column" FooterStyle-HorizontalAlign="Left" DataFormatString="{0:N2}"></telerik:GridNumericColumn>
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnVariance" HeaderText="Variance" DataField="Variance" ItemStyle-CssClass="radgrid-amount-column" FooterStyle-HorizontalAlign="Left" DataFormatString="{0:N2}"></telerik:GridNumericColumn>      
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnBillingPostPeriod1" ItemStyle-CssClass="radgrid-amount-column" DataFormatString="{0:N2}"></telerik:GridNumericColumn>
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnRevenuePostPeriod1" ItemStyle-CssClass="radgrid-amount-column" DataFormatString="{0:N2}"></telerik:GridNumericColumn>
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnBillingPostPeriod2" ItemStyle-CssClass="radgrid-amount-column" DataFormatString="{0:N2}"></telerik:GridNumericColumn>
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnRevenuePostPeriod2" ItemStyle-CssClass="radgrid-amount-column" DataFormatString="{0:N2}"></telerik:GridNumericColumn>
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnBillingPostPeriod3" ItemStyle-CssClass="radgrid-amount-column" DataFormatString="{0:N2}"></telerik:GridNumericColumn>
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnRevenuePostPeriod3" ItemStyle-CssClass="radgrid-amount-column" DataFormatString="{0:N2}"></telerik:GridNumericColumn>
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnBillingPostPeriod4" ItemStyle-CssClass="radgrid-amount-column" DataFormatString="{0:N2}"></telerik:GridNumericColumn>
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnRevenuePostPeriod4" ItemStyle-CssClass="radgrid-amount-column" DataFormatString="{0:N2}"></telerik:GridNumericColumn>
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnBillingPostPeriod5" ItemStyle-CssClass="radgrid-amount-column" DataFormatString="{0:N2}"></telerik:GridNumericColumn>
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnRevenuePostPeriod5" ItemStyle-CssClass="radgrid-amount-column" DataFormatString="{0:N2}"></telerik:GridNumericColumn>
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnBillingPostPeriod6" ItemStyle-CssClass="radgrid-amount-column" DataFormatString="{0:N2}"></telerik:GridNumericColumn>
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnRevenuePostPeriod6" ItemStyle-CssClass="radgrid-amount-column" DataFormatString="{0:N2}"></telerik:GridNumericColumn>
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnBillingPostPeriod7" ItemStyle-CssClass="radgrid-amount-column" DataFormatString="{0:N2}"></telerik:GridNumericColumn>
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnRevenuePostPeriod7" ItemStyle-CssClass="radgrid-amount-column" DataFormatString="{0:N2}"></telerik:GridNumericColumn>
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnBillingPostPeriod8" ItemStyle-CssClass="radgrid-amount-column" DataFormatString="{0:N2}"></telerik:GridNumericColumn>
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnRevenuePostPeriod8" ItemStyle-CssClass="radgrid-amount-column" DataFormatString="{0:N2}"></telerik:GridNumericColumn>
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnBillingPostPeriod9" ItemStyle-CssClass="radgrid-amount-column" DataFormatString="{0:N2}"></telerik:GridNumericColumn>
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnRevenuePostPeriod9" ItemStyle-CssClass="radgrid-amount-column" DataFormatString="{0:N2}"></telerik:GridNumericColumn>
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnBillingPostPeriod10" ItemStyle-CssClass="radgrid-amount-column" DataFormatString="{0:N2}"></telerik:GridNumericColumn>
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnRevenuePostPeriod10" ItemStyle-CssClass="radgrid-amount-column" DataFormatString="{0:N2}"></telerik:GridNumericColumn>
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnBillingPostPeriod11" ItemStyle-CssClass="radgrid-amount-column" DataFormatString="{0:N2}"></telerik:GridNumericColumn>
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnRevenuePostPeriod11" ItemStyle-CssClass="radgrid-amount-column" DataFormatString="{0:N2}"></telerik:GridNumericColumn>
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnBillingPostPeriod12" ItemStyle-CssClass="radgrid-amount-column" DataFormatString="{0:N2}"></telerik:GridNumericColumn>
                        <telerik:GridNumericColumn UniqueName="GridNumericColumnRevenuePostPeriod12" ItemStyle-CssClass="radgrid-amount-column" DataFormatString="{0:N2}"></telerik:GridNumericColumn>          
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
            <telerik:RadContextMenu ID="RadContextMenuGrid" runat="server" OnClientItemClicking="RadContextMenuGridOnClientItemClicking">
                <Items>
                    <telerik:RadMenuItem Value="Color" PostBack="false">
                        <ItemTemplate>
                            <table cellspacing="0" cellpadding="0" border="0">
                                <tr>
                                    <td>Row Color:&nbsp;&nbsp;</td>
                                    <td><telerik:RadColorPicker ID="RadColorPickerGrid" runat="server" AutoPostBack="false" ShowIcon="true" OnClientColorChange="colorPickerChanged"></telerik:RadColorPicker></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </telerik:RadMenuItem>
                    <telerik:RadMenuItem IsSeparator="true" />
                    <telerik:RadMenuItem ID="RadContextMenuDelete" runat="server" Value="Delete" Text="Delete" />
                    <telerik:RadMenuItem IsSeparator="true" />
                </Items>
            </telerik:RadContextMenu>
            <asp:HiddenField ID="HiddenFieldContextMenuSelectedRow" runat="server" />
            <script type="text/javascript">

                var OnGridCreated = function (sender, args) {
                    var rowCount = 0;
                    $(sender.get_masterTableView().get_dataItems()).each(function () {
                        var element = this.get_element();
                        if ($(element).hasClass('rgEditRow') == true) {
                            $(element).removeClass('rgEditRow');
                            var cssClass = 'rgRow';
                            if (rowCount % 2) {
                                cssClass = 'rgAltRow';
                            }
                            $(element).addClass(cssClass);
                        }
                        var rowColor = $(element).find('[id*=HiddenFieldRowColor]').val();
                        if (rowColor) {
                            if ($(element).hasClass('rgAltRow') == true) {
                                $(element).removeClass('rgAltRow').addClass('rgRow');
                            }
                        }
                        rowCount += 1;
                    });
                    checkRowSelection();
                    $('input[monthactual]').each(function () {
                        $(this).parent('span').append('<div class="disp-month-actual riTextBox">' + $(this).attr('monthactual') + '</div>');
                    });
                    displayActuals();
                };

                var OnRowSelected = function () {
                    checkRowSelection();
                };

                var modifyColor = function (color, amount) {
                    var usePound = false;
                    if (color[0] == "#") {
                        color = color.slice(1);
                        usePound = true;
                    }
                    var num = parseInt(color, 16);
                    var r = (num >> 16) + amount;
                    if (r > 255) r = 255;
                    else if (r < 0) r = 0;
                    var b = ((num >> 8) & 0x00FF) + amount;
                    if (b > 255) b = 255;
                    else if (b < 0) b = 0;
                    var g = (num & 0x0000FF) + amount;
                    if (g > 255) g = 255;
                    else if (g < 0) g = 0;
                    return (usePound ? "#" : "") + (g | (b << 8) | (r << 16)).toString(16);
                }

            </script>
    </div>
    
</asp:Content>
