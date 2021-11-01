<%@ Page AutoEventWireup="false" CodeBehind="purchaseorder.aspx.vb" Inherits="Webvantage.purchaseorder"
    Language="vb" MasterPageFile="~/ChildPage.Master" %>

<%@ Register Src="purchaseordernav.ascx" TagName="purchaseordernav" TagPrefix="uc1" %>

<asp:Content ID="Contenthead" runat="server" ContentPlaceHolderID="ContentPlaceHolderHead">

</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">

            function stopRKey(evt) {
                var evt = (evt) ? evt : ((event) ? event : null);
                var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
                if ((evt.keyCode == 13) && (node.type != "textarea")) { return false; }
            }
            document.onkeypress = stopRKey;

            function JobSpecs(radWindowCaller) {
                __doPostBack('onclick#Refresh', 'JobSpecs');
            }
            function realPostBack(eventTarget, eventArgument) {
                __doPostBack(eventTarget, eventArgument);
            }

        </script>

        <script type="text/javascript">

            var voidPO = function (callback) {
                var confirmWindow = $('#kenWin').data('kendoWindow');
                $('#window-message').html('Are you sure you want to Void this Purchase Order? If yes, it will be marked as voided and will no longer be available for use.');
                confirmWindow.center().open();
                $('#yesButton').unbind('click').click(function () {
                    if (callback) {
                        callback();
                    }
                });
                $('#noButton').unbind('click').bind('click', function () {
                    confirmWindow.close();
                });
            };

            function RadContextMenuGridItemClicking(sender, args) {
                var itemValue = args.get_item().get_value();
                var masterTableView = $find('<%= RadGridPODetails.ClientID %>').get_masterTableView();
                args.set_cancel(true);
                if (itemValue == "DeleteItem") {
                    var confirmWindow = $('#kenWin').data('kendoWindow');
                    $('#window-message').html('Are you sure you want to delete?');
                    confirmWindow.center().open();
                    $('#yesButton').unbind('click').click(function () {
                        confirmWindow.close();
                        var foundItem = false;
                        $(masterTableView.get_dataItems()).each(function () {
                            if (this.get_itemIndexHierarchical() === document.getElementById('<%= HiddenFieldSelectedRow.ClientID %>').value) {
                                this.set_selected(true);
                                foundItem = true;
                            }
                        });
                        if (foundItem === true) {
                            masterTableView.fireCommand('DeleteItem');
                        }
                    }).end();
                    $('#noButton').unbind('click').bind('click', function () {
                        confirmWindow.close();
                    });
                } else {
                    var foundItem = false;
                    $(masterTableView.get_dataItems()).each(function () {
                        if (this.get_itemIndexHierarchical() === document.getElementById('<%= HiddenFieldSelectedRow.ClientID %>').value) {
                            this.set_selected(true);
                            foundItem = true;
                        }
                    });
                    if (foundItem === true) {
                        masterTableView.fireCommand(itemValue);
                    }
                }
            }

            function JsOnClientButtonClicking(sender, args) {
                var commandName = args.get_item().get_commandName();
                var masterTableView = $find('<%= RadGridPODetails.ClientID %>').get_masterTableView();
                if (commandName == "NoPostBack") {
                    args.set_cancel(true);
                } else if (commandName == "DeleteItem") {
                    args.set_cancel(true);
                    var confirmWindow = $('#kenWin').data('kendoWindow');
                    $('#window-message').html('Are you sure you want to delete?');
                    confirmWindow.center().open();
                    $('#yesButton').unbind('click').click(function () {
                        confirmWindow.close();
                        masterTableView.fireCommand('DeleteItem');
                    }).end();
                    $('#noButton').unbind('click').bind('click', function () {
                        confirmWindow.close();
                    });
                } else {
                    if (commandName !== 'CopyFrom') {
                        args.set_cancel(true);
                        masterTableView.fireCommand(commandName);
                    }
                }
            }

            function RadGridOnRowContextMenu(sender, args) {
                var evt = args.get_domEvent();
                if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
                    return;
                }
                document.getElementById('<%= HiddenFieldSelectedRow.ClientID %>').value = args.get_itemIndexHierarchical();
                var menu = $find('<%= RadContextMenuGridItem.ClientID %>');
                var items = menu.get_items();
                var gridDataItem = args.get_gridDataItem();
                enableOrDisableMenuOptions(menu, gridDataItem);
                menu.show(evt);
                evt.cancelBubble = true;
                evt.returnValue = false;
                if (evt.stopPropagation) {
                    evt.stopPropagation();
                    evt.preventDefault();
                }
            }

            function RadNumericTextBoxPreventDecimal(sender, args) {
                var keyCode = args.get_keyCode();
                if (keyCode == 46 || keyCode == 110) {
                    args.set_cancel(true);
                } else if (args.get_keyCode() == 13) {
                    args.set_cancel(true);
                }
            }

            function RadGridPODetailsOnRowSelected(sender, args) {
                var gridDataItem = args.get_gridDataItem();
                var menu = $find('<%= RadToolBarDetails.ClientID %>');
                enableOrDisableMenuOptions(menu, gridDataItem);
            }

            function enableOrDisableMenuOptions(menu, gridDataItem) {
                var selectedCount = $find('<%= RadGridPODetails.ClientID %>').get_selectedItems().length;
                if (selectedCount > 1) {
                    var menuItems = menu.get_items();
                    for (var i = 0; i < menuItems.get_count() ; i++) {
                        var item = menuItems.getItem(i);
                        if (item.get_value() == "DeleteItem" || item.get_value() == "CopyItem") {
                            item.set_enabled(true);
                        } else {
                            item.set_enabled(false);
                        }
                    }
                } else if (gridDataItem) {
                    var options = gridDataItem.findElement('HiddenFieldMenuOptions').value;
                    var optArray = options.split("|");
                    for (var i = 0; i < optArray.length; i++) {
                        var optValueArray = optArray[i].split("=");
                        var optionVal = optValueArray[0];
                        var optionEnabled = Number(optValueArray[1]);
                        var item = menu.findItemByValue(optionVal);
                        if (item) {
                            if (optionEnabled == 1) {
                                item.set_enabled(true);
                            } else {
                                item.set_enabled(false);
                            }
                        }
                    }
                } else {
                    //no row selected
                    var menuItems = menu.get_items();
                    for (var i = 0; i < menuItems.get_count() ; i++) {
                        var item = menuItems.getItem(i);
                        if (item.get_value() == "DeleteItem" || item.get_value() == "CopyItem" || item.get_value() == "APInfo" || item.get_value() == "Estimate") {
                            item.set_enabled(false);
                        } else {
                            item.set_enabled(true);
                        }
                    }
                }
            }

            $(document).ready(function () {
                $('#<%= RadDatePickerPODate.ClientID %>').dblclick(function () {
                    $find('<%= RadDatePickerPODate.ClientID %>').set_selectedDate(new Date());
                });
                $('#<%= RadDatePickerDueDate.ClientID %>').dblclick(function () {
                    $find('<%= RadDatePickerDueDate.ClientID %>').set_selectedDate(new Date());
                });
                $('#linkPopulatePODate').click(function () {
                    $('#<%= RadDatePickerPODate.ClientID %>').dblclick();
                });
                $('#linkPopulateDueDate').click(function () {
                    $('#<%= RadDatePickerDueDate.ClientID %>').dblclick();
                });
                $($find('<%= RadDatePickerPODate.ClientID %>').get_dateInput().get_element()).dblclick(function () {
                    $('#<%= RadDatePickerPODate.ClientID %>').dblclick();
                });
                $($find('<%= RadDatePickerDueDate.ClientID %>').get_dateInput().get_element()).dblclick(function () {
                    $('#<%= RadDatePickerDueDate.ClientID %>').dblclick();
                });
                var maxWidth = 0;
                $('.mod-lbl').each(function () {
                    var width = $(this).width();
                    if (width > maxWidth) {
                        maxWidth = width;
                    }
                }).css('width', maxWidth + 'px');

                var window = $('#kenWin').kendoWindow({
                    title: 'Confirm',
                    visible: false,
                    modal: true
                }).data('kendoWindow');

            });

            function quantityRateAmountCalculatorResult(obj) {
                //alert('');
            }

            function CloseActiveToolTip() {
                setTimeout(function () {
                    var controller = Telerik.Web.UI.RadToolTipController.getInstance();
                    var tooltip = controller.get_activeToolTip();
                    if (tooltip) tooltip.hide();
                }, 1000);
            }
            function ShowAddToolTip(element) {
                var tooltip = $find("<%=RadToolTipAddItems.ClientID%>");
                tooltip.set_targetControl(element);
                tooltip.show();
            }
            function OnClientMouseOver(sender, args) {
                var button = args.get_item();
                var sCommandName = button.get_commandName();
                if (sCommandName == 'NoPostBack') {
                    ShowAddToolTip(button.get_element());
                }
            }

        </script>

    </telerik:RadScriptBlock>    
    <telerik:RadToolTipManager ID="RadToolTipManagerPO" runat="server" Animation="None" RenderMode="Lightweight"
        Height="100px" ManualClose="false" Modal="false" OnAjaxUpdate="OnAjaxUpdate"
        Position="BottomRight" RelativeTo="Element" ShowEvent="OnMouseOver" Sticky="true"
        Width="200px" SkinID="RadToolTipManagerBase">
    </telerik:RadToolTipManager>

    <link rel="stylesheet" href="Content/kendo/current/kendo.common.min.css" />
    <link rel="stylesheet" href="Content/kendo/current/kendo.bootstrap.min.css" />
    
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
    <script type="text/javascript" src="Scripts/angular.min.js"></script>
    <script type="text/javascript" src="Scripts/angular-ui/ui-bootstrap-tpls.min.js"></script>
    <script type="text/javascript" src="Scripts/kendo/current/kendo.all.min.js"></script>
    <script type="text/javascript" src="app/js/app.js"></script>
    <script type="text/javascript" src="app/js/services.js"></script>
    <script type="text/javascript" src="app/js/controllers/purchaseOrderLookup.js"></script>
    <script type="text/javascript" src="app/js/controllers/kendoGridLookupModal.js"></script>


<div ng-app="webvantageApp" ng-controller="purchaseOrderLookupController">

    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td class="no-float-menu">
                <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                <uc1:purchaseordernav ID="Purchaseordernav1" runat="server" />                    
                </telerik:RadCodeBlock>                
            </td>            
        </tr>
        <tr>
            
        </tr>
    </table>
    <div class="telerik-aqua-body">
        <div valign="middle">
                <asp:Label ID="LabelApproval" runat="server" Font-Size="Medium" CssClass="warning" Text=""
                    Visible="False"></asp:Label>
            </div>
        <ew:CollapsablePanel ID="CollapsablePanel_GeneralInformation" runat="server" TitleText="General Information">
        
            <div>
                <div style="display: inline-block;">
                    <div class="form-layout" style="white-space: nowrap; vertical-align: top;">                        
                        <ul>  
                            
                    
                            <li>PO Number:</li>
                            <li><asp:TextBox ID="TextBoxPODisplayNumber" runat="server" BackColor="#F5F5F5" ReadOnly="True" SkinID="TextBoxCodeSmall"></asp:TextBox></li>
                            <li><asp:TextBox ID="TextBoxDescription" runat="server" CssClass="RequiredInput" MaxLength="40" TabIndex="1" SkinID="TextBoxText40"></asp:TextBox></li>
                            <li>Rev:</li>
                            <li><telerik:RadNumericTextBox ID="RadNumericTextBoxRevision" runat="server" ClientIDMode="Static" MaxValue="999" MinValue="0">
                                <NumberFormat DecimalDigits="0" />
                            </telerik:RadNumericTextBox></li>
                        </ul>
                        <ul>
                            <li>Issued By:</li>
                            <li><asp:TextBox ID="TextBoxEmployeeCode" runat="server" CssClass="RequiredInput" CausesValidation="True" MaxLength="6" TabIndex="2" SkinID="TextBoxCodeSmall" ClientIDMode="Static"></asp:TextBox>
                                <asp:HiddenField ID="HiddenFieldAllowGLAccountSelection" runat="server" ClientIDMode="Static" />
                                <asp:HiddenField ID="HiddenFieldLimitPOSelectionOffice" runat="server" ClientIDMode="Static" />
                                <asp:HiddenField ID="HiddenFieldEmployeeOfficeCode" runat="server" ClientIDMode="Static" />
                        </li>
                        <li><asp:TextBox ID="TextBoxEmployeeName" runat="server" ReadOnly="True" SkinID="TextBoxText40" ClientIDMode="Static" adv-desc="Employee"></asp:TextBox></li>
                        </ul>
                        <ul>
                            <li>Issued To:</li>
                            <li><asp:TextBox ID="TextBoxVendorCode" runat="server" CssClass="RequiredInput" CausesValidation="True" MaxLength="6" TabIndex="3" SkinID="TextBoxCodeSmall" ClientIDMode="Static"></asp:TextBox></li>
                            <li><asp:TextBox ID="TextBoxVendorName" runat="server" ReadOnly="True" SkinID="TextBoxText40" ClientIDMode="Static" adv-desc="Vendor"></asp:TextBox></li>
                        </ul>
                        <ul>
                            <li>Pay To:</li>
                            <li><asp:Label ID="LabelPayTo" runat="server" ClientIDMode="Static" /></li>
                        </ul>
                        <ul>
                            <li>Address 1:</li>
                            <li><asp:TextBox ID="TextBoxAddress1" runat="server" BackColor="#F5F5F5" ReadOnly="True" SkinID="TextBoxText50" ClientIDMode="Static"></asp:TextBox></li>
                        </ul>
                        <ul>
                            <li>Address 2:</li>
                            <li><asp:TextBox ID="TextBoxAddress2" runat="server" BackColor="#F5F5F5" ReadOnly="True" SkinID="TextBoxText50" ClientIDMode="Static"></asp:TextBox></li>
                        </ul>
                        <ul>
                            <li>City:</li>
                            <li><asp:TextBox ID="TextBoxCity" runat="server" BackColor="#F5F5F5" ReadOnly="True" SkinID="TextBoxText50" ClientIDMode="Static"></asp:TextBox></li>
                        </ul>
                        <ul>
                            <li>County:</li>
                            <li><asp:TextBox ID="TextBoxCounty" runat="server" BackColor="#F5F5F5" ReadOnly="True" SkinID="TextBoxText50" ClientIDMode="Static"></asp:TextBox></li>
                        </ul>
                        <ul>
                            <li>State:</li>
                            <li><asp:TextBox ID="TextBoxState" runat="server" BackColor="#F5F5F5" ReadOnly="True" SkinID="TextBoxText10" ClientIDMode="Static"></asp:TextBox></li>
                            <li>&nbsp;&nbsp;Zip:</li>
                            <li><asp:TextBox ID="TextBoxZip" runat="server" BackColor="#F5F5F5" ReadOnly="True" SkinID="TextBoxText10" ClientIDMode="Static"></asp:TextBox></li>
                        </ul>
                        <ul>
                            <li>Country:</li>
                            <li><asp:TextBox ID="TextBoxCountry" runat="server" BackColor="#F5F5F5" ReadOnly="True" SkinID="TextBoxText50" ClientIDMode="Static"></asp:TextBox></li>
                        </ul>
                    </div>
                </div>
                <div style="display: inline-block; vertical-align: top;">
                    <div class="form-layout" style="white-space: nowrap;">
                    <ul>
                        <li><a href="#" id="linkPopulatePODate">Order Date:</a></li>
                        <li><telerik:RadDatePicker ID="RadDatePickerPODate" runat="server" SkinID="RadDatePickerStandard" >
                                <DateInput runat="server" ID="DateInput123" DateFormat="d" EmptyMessage="" TabIndex="4">
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
                        <li><asp:Label ID="lbl_voidflag" runat="server" Font-Size="Large" CssClass="warning" Text="VOID" Visible="False"></asp:Label></li>
                    </ul>
                    <ul>
                        <li><a href="#" id="linkPopulateDueDate" >Due Date:</a></li>
                        <li><telerik:RadDatePicker ID="RadDatePickerDueDate" runat="server" SkinID="RadDatePickerStandard">
                                <DateInput runat="server" ID="di2" DateFormat="d" EmptyMessage="" TabIndex="5">
                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                </DateInput>
                                <Calendar ID="Calendar3" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                    <SpecialDays>
                                        <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                        </telerik:RadCalendarDay>
                                    </SpecialDays>
                                </Calendar>
                                </telerik:RadDatePicker></li>
                    </ul>
                    <ul>
                        <li>&nbsp;</li>
                        <li><asp:CheckBox ID="CheckBoxWorkComplete" runat="server" Text="Work Complete" TextAlign="Right" TabIndex="6"  /></li>
                    </ul>
                    <ul>
                        <li>Vendor Contact:</li>
                        <li><asp:TextBox ID="TextBoxVendorContactCode" runat="server" BackColor="Transparent" CausesValidation="True"
                                MaxLength="6" SkinID="TextBoxCodeSmall" ClientIDMode="Static"  TabIndex="7"></asp:TextBox></li>
                        <li><asp:TextBox ID="TextBoxVendorContactName" runat="server" BackColor="#F5F5F5" ReadOnly="True" SkinID="TextBoxText40" ClientIDMode="Static" adv-desc="VendorContact"></asp:TextBox></li>
                    </ul>
                    <ul>
                        <li>Email Address:</li>
                        <li><asp:TextBox ID="TextBoxVendorContactEmail" runat="server" BackColor="#F5F5F5" ReadOnly="True" SkinID="TextBoxText40" ClientIDMode="Static" adv-desc="VendorContactEmail"></asp:TextBox></li>
                    </ul>
                    <ul>
                        <li>Employee Limit:</li>
                        <li><telerik:RadNumericTextBox ID="RadNumericTextBoxPOLimit" runat="server" ClientIDMode="Static" ReadOnly="true" SkinID="RadNumericTextBoxAmount">
                                <NumberFormat DecimalDigits="2" />
                            </telerik:RadNumericTextBox></li>
                        <li style="margin-left: 10px;" class="mod-lbl">Modified By:</li>
                        <li><asp:Label ID="LabelModifiedBy" runat="server" Text=""></asp:Label></li>
                    </ul>
                    <ul>
                        <li>PO Total:</li>
                        <li><telerik:RadNumericTextBox ID="RadNumericTextBoxPOTotal" runat="server" ClientIDMode="Static" ReadOnly="true" SkinID="RadNumericTextBoxAmount">
                                <NumberFormat DecimalDigits="2" />
                            </telerik:RadNumericTextBox></li>
                        <li style="margin-left: 10px;" class="mod-lbl">Modified Date:</li>
                        <li><asp:Label ID="LabelModifiedDate" runat="server" Text=""></asp:Label></li>
                    </ul>
                    <ul>
                        <li>Message:</li>
                        <li><asp:TextBox ID="TextBoxMessage" runat="server" TextMode="MultiLine" ReadOnly="true" Width="360px" Height="70px" SkinID="TextBoxStandard"></asp:TextBox></li>
                    </ul>
                   <%-- <ul>
                        <li>&nbsp;</li>
                        <li><asp:CheckBox ID="CheckBoxCompleteEntirePO" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBoxCompleteEntirePO_CheckedChanged" Text="Mark Entire P.O. as Complete" 
                            TextAlign="Right" TabIndex="6"  /></li>
                    </ul>--%>
                </div>
                </div>
            </div>
        
        </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanel_Details" runat="server" TitleText="Details">

            <telerik:RadToolBar ID="RadToolBarDetails" runat="server" AutoPostBack="true" Width="100%" 
                OnClientButtonClicking="JsOnClientButtonClicking"
                OnClientMouseOver="OnClientMouseOver" >
                <Items>
                    <telerik:RadToolBarButton IsSeparator="true" Value="FirstSeparator" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonAdd" runat="server" Text="Add" Value="AddItem" CommandName="NoPostBack"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton IsSeparator="true" Value="SecondSeparator" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonCopy" runat="server" Text="Copy" Value="CopyItem" CommandName="CopyItem"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton IsSeparator="true" Value="ThirdSeparator" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonCopyFrom" runat="server" Text="Copy From" Value="CopyFrom" CommandName="CopyFrom"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton IsSeparator="true" Value="FourthSeparator" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonDelete" runat="server" Text="Delete" Value="DeleteItem" CommandName="DeleteItem"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton IsSeparator="true" Value="FifthSeparator" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonEstimate" runat="server" Text="Estimate" Value="Estimate" CommandName="Estimate" Visible="false"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton IsSeparator="true" Value="SixthSeparator" Visible="false" />
                    <telerik:RadToolBarButton ID="RadToolBarButtonAPInfo" runat="server" Text="AP Info" Value="APInfo" CommandName="APInfo"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton IsSeparator="true" Value="SeventhSeparator" />                    
                </Items>
            </telerik:RadToolBar>
            <telerik:RadToolTip ID="RadToolTipAddItems" runat="server" SkinID="RadToolTipToolbarContentArea" Width="300" Height="220" 
                TargetControlID="RadToolBarButtonAdd">
                <div style="width: 275px; float: left; position: relative;">
                    <div style="font-size: larger;">
                        Add Items
                    </div>
                    <div>
                        <div style="padding: 11px 0px 0px 0px;">
                            <asp:Button ID="ButtonAddItem" runat="server" Text="Manually" ToolTip="Add item manually" Width="250" />
                        </div>
                        <div style="padding: 6px 0px 0px 0px;">
                            <asp:Button ID="ButtonAddItemsFromEstimate" runat="server" Text="Job/Campaign Estimate Details" ToolTip="Add item(s) from estimate" Width="250" />
                        </div>
                    </div>
                </div>
            </telerik:RadToolTip>    
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <div id="purchaseOrderGridContainer" style="max-width:3897px; width: 100%;">
                        <telerik:RadGrid ID="RadGridPODetails" runat="server" AutoGenerateColumns="false" AllowPaging="true" AllowSorting="true" PageSize="10"
                             ShowFooter="true" AllowMultiRowEdit="true" ShowGroupPanel="false" GridLines="None" Width="100%" Style=" border: 1px solid transparent; float: left;" AllowMultiRowSelection="true" EnableHeaderContextMenu="true">
                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" />
                            <ClientSettings AllowKeyboardNavigation="true">
                                <Selecting AllowRowSelect="true" />
                                <ClientEvents OnRowContextMenu="RadGridOnRowContextMenu" OnRowSelected="RadGridPODetailsOnRowSelected" OnGridCreated="onGridCreated" OnColumnHidden="function(sender, args) { OnColumnHidden(sender, args); sender.repaint(); }" OnColumnShown="OnColumnShown" />
                            </ClientSettings>
                            <MasterTableView CommandItemDisplay="None" AllowSorting="true" EditMode="InPlace" DataKeyNames="LineNumber" Width="100%" Style="border-color: transparent!important; float: left;">
                                <Columns>                        
                                    <telerik:GridTemplateColumn UniqueName="ColumnSelect" Visible="true" HeaderAbbr="FIXED" HeaderStyle-CssClass="text-center" ItemStyle-cssClass="text-center">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="middle" Width="16px"/>
                                        <HeaderTemplate>
                                            <input id="CheckBoxSelectAllRows" type="checkbox" name="CheckBoxSelectAllRows" onclick="SelectAllRows(this.checked)" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                  
                                  
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnPreferences" HeaderAbbr="FIXED">
                                        <HeaderTemplate>
                                            <asp:ImageButton ID="ImageButtonColumnPreferences" runat="server" ImageAlign="AbsMiddle" CssClass="column-prefs-icon"
                                                    ImageUrl="~/Images/Icons/Grey/256/table_selection_column.png" ToolTip="Column Preferences" OnClientClick="RadGridPODetailsColumnHeaderMenu(event);" />
                                        </HeaderTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnLineNumber" HeaderAbbr="FIXED" HeaderText="Line<br/>Number" DataField="LineNumber" ItemStyle-HorizontalAlign="Center" ReadOnly="true"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnDescription" HeaderText="Description" DataField="LineDescription"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnDetailDescription" HeaderText="Detail Description" DataField="DetailDescription" Visible="true"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnInstructions" HeaderText="Instructions" DataField="Instructions"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnClientCode" HeaderText="Client" DataField="ClientCode" MaxLength="6" ItemStyle-Width="30"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnDivisionCode" HeaderText="Division" DataField="DivisionCode" MaxLength="6" ItemStyle-Width="30"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnProductCode" HeaderText="Product" DataField="ProductCode" MaxLength="6" ItemStyle-Width="30"></telerik:GridBoundColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnJobNumber" HeaderAbbr="FIXED" HeaderText="Job" DataField="JobNumber"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnJobComponentNumber" HeaderAbbr="FIXED" HeaderText="Component" DataField="JobComponentNumber"></telerik:GridNumericColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnFunctionCode" HeaderAbbr="FIXED" HeaderText="Function" DataField="FunctionCode" MaxLength="6"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnGeneralLedgerCode" HeaderAbbr="FIXED" HeaderText="GL<br/>Account" DataField="GeneralLedgerCode"></telerik:GridBoundColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnQuantity" HeaderAbbr="FIXED" HeaderText="Quantity" DataField="Quantity" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N0}" ItemStyle-Width="80"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnRate" HeaderAbbr="FIXED" HeaderText="Rate" DataField="Rate" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N3}" ItemStyle-Width="80"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnExtendedAmount" HeaderAbbr="FIXED" HeaderText="Extended<br/>Amount" DataField="ExtendedAmount" DataType="System.Decimal" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" ItemStyle-Width="80"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnCommissionPercent" HeaderAbbr="FIXED" HeaderText="Markup<br/>Percent" DataField="CommissionPercent" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N3}" ItemStyle-Width="80"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnExtendedMarkupAmount" HeaderAbbr="FIXED" HeaderText="Markup<br/>Amount" DataField="ExtendedMarkupAmount" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" ItemStyle-Width="80"></telerik:GridNumericColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnLineTotal" HeaderAbbr="FIXED" HeaderText="Line<br/>Total" DataField="LineTotal" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" ItemStyle-Width="80"></telerik:GridNumericColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnEstimateBudgetNet" HeaderAbbr="FIXED" HeaderText="Estimate/<br/>Budget(Net)" DataField="EstimateBudgetNet" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="80">
                                        <InsertItemTemplate>
                                            <div class="icon-background background-color-sidebar" style="margin: 0 auto;">
                                                <asp:ImageButton ID="ImageButtonAddItem" runat="server" AlternateText="Add Item" CommandName="PerformInsert" ToolTip="Add Item" SkinID="ImageButtonNewWhite" />
                                            </div>
                                        </InsertItemTemplate>
                                        <ItemTemplate>
                                            <%# Eval("EstimateBudgetNet", "{0:N2}") %>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnPOUsed" HeaderAbbr="FIXED" HeaderText="PO Used(Net)" DataField="POUsed" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="80">
                                        <InsertItemTemplate>
                                            <div class="icon-background background-color-delete" style="margin: 0 auto;">
                                                <asp:ImageButton ID="ImageButtonCancel" runat="server" AlternateText="Cancel" CommandName="Cancel" ToolTip="Cancel add row" SkinID="ImageButtonCancelWhite" />
                                            </div>
                                        </InsertItemTemplate>
                                        <ItemTemplate>
                                            <%# Eval("POUsed", "{0:N2}") %>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridNumericColumn UniqueName="GridNumericColumnBalanceNet" HeaderText="Balance(Net)" DataField="BalanceNet" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" ItemStyle-Width="80" ReadOnly="true"></telerik:GridNumericColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnUseCPM" HeaderText="CPM" DataField="UseCPM">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div id="divCPM" runat="server" class="icon-background standard-green" style='<%# If(Eval("UseCPM") = True, "display:inline-block;", "display:none;")%>'>
                                                <asp:Image ID="ImageCPM" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" />
                                            </div>
                                            <div style="display: none;">
                                                <asp:TextBox ID="HiddenTextBoxCPM" runat="server" SkinID="TextBoxStandard" />
                                            </div>
                                        </ItemTemplate>
                                        <InsertItemTemplate>
                                            <div id="divCPM" runat="server" class="icon-background standard-green" style="display:none;">
                                                <asp:Image ID="ImageCPM" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" />
                                            </div>
                                        </InsertItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnIsAttachedToAP" HeaderText="AP" DataField="IsAttachedToAP">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div class="icon-background standard-green" style='<%# If(Eval("IsAttachedToAP") = True, "display:inline-block;", "display:none;")%>'>
                                                <asp:ImageButton ID="ImageButtonAttachedToAP" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" CommandName="APInfo" ToolTip="Yes" />
                                            </div>
                                            <div style="display: none;">
                                                <asp:CheckBox ID="CheckBoxAP" runat="server" Checked='<%#Eval("IsAttachedToAP")%>' Enabled="false" Visible="false" />
                                            </div>
                                        </ItemTemplate>
                                        <InsertItemTemplate>

                                        </InsertItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn UniqueName="GridTemplateColumnComplete" HeaderText="Complete">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div>
                                                <asp:CheckBox ID="CheckBoxLineItemComplete" runat="server" AutoPostBack="true" Checked='<%#Eval("IsComplete")%>' 
                                                            Enabled="true" Visible="true" LineNumber='<%#Eval("LineNumber")%>' OnCheckedChanged="CheckBoxLineItemComplete_CheckedChanged"  />
                                            </div>
                                            <%--<div class="icon-background standard-green" style='<%# If(Eval("IsComplete") = 1, "display:inline-block;", "display:none;")%>'>
                                                <asp:Image ID="ImageIsComplete" runat="server" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image" ToolTip="Yes" />
                                            </div>--%>
                                            <asp:HiddenField ID="HiddenFieldMenuOptions" runat="server" Value="" />
                                        </ItemTemplate>
                                        <InsertItemTemplate>
                                
                                        </InsertItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <FilterItemStyle VerticalAlign="Top" Wrap="False" />
                            </MasterTableView>
                            <SortingSettings SortedAscToolTip="Sorted ascending" SortedDescToolTip="Sorted descending" />
                            <FilterItemStyle HorizontalAlign="Left" Wrap="False" />            
                        </telerik:RadGrid>
                        <telerik:RadContextMenu ID="RadContextMenuGridItem" runat="server" OnClientItemClicking="RadContextMenuGridItemClicking">
                            <Items>
                                <telerik:RadMenuItem Text="View Details" Value="ItemDetails"></telerik:RadMenuItem>
                                <telerik:RadMenuItem IsSeparator="true"></telerik:RadMenuItem>
                                <telerik:RadMenuItem Text="Copy" Value="CopyItem"></telerik:RadMenuItem>
                                <telerik:RadMenuItem IsSeparator="true"></telerik:RadMenuItem>
                                <telerik:RadMenuItem Text="Delete" Value="DeleteItem"></telerik:RadMenuItem>
                                <telerik:RadMenuItem IsSeparator="true"></telerik:RadMenuItem>
                                <telerik:RadMenuItem Text="AP Info" Value="APInfo"></telerik:RadMenuItem>
                            </Items>
                        </telerik:RadContextMenu>
                    </div>        
                </ContentTemplate>
            </asp:UpdatePanel>
        </ew:CollapsablePanel>
        <ew:CollapsablePanel ID="CollapsablePanel_POInstructions" runat="server" TitleText="P.O. Instructions" Collapsed="true">
        
            <div style="padding: 10px;">
                <telerik:RadTextBox runat="server" ID="RadTextBox_POInstructions" TextMode="MultiLine" Width="100%" Resize="Both" TabIndex="9"></telerik:RadTextBox>
            </div>

        </ew:CollapsablePanel>

        <ew:CollapsablePanel ID="CollapsablePanel_ShippingInstructions" runat="server" TitleText="Shipping Instructions" Collapsed="true">
        
            <div style="padding: 10px;">
                <telerik:RadTextBox runat="server" ID="RadTextBox_ShippingInstructions" TextMode="MultiLine" Width="100%" Resize="Both" TabIndex="10"></telerik:RadTextBox>
            </div>

        </ew:CollapsablePanel>

        <ew:CollapsablePanel ID="CollapsablePanel_FooterComments" runat="server" TitleText="Footer Comments" Collapsed="true">
        
            <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                <div style="padding: 10px">
                    <asp:RadioButtonList runat="server" ID="RadioButtonList_FooterComments" AutoPostBack="true" RepeatDirection="Horizontal" TabIndex="11">
                        <asp:ListItem ID="ListItemAgency" runat="server" Text="Use Agency Defined Text"  style="padding-right:20px;" />
                        <asp:ListItem ID="ListItemStandard" runat="server" Text="Use Standard Comment Text"  style="padding-right:20px;" />
                        <asp:ListItem ID="ListItemCustom" runat="server" Text="Use Customized Text"  style="padding-right:20px;" />
                    </asp:RadioButtonList>
                    <telerik:RadTextBox runat="server" ID="RadTextBox_FooterComments" TextMode="MultiLine" Width="100%" Resize="Both" Height="100px" ClientIDMode="Static" TabIndex="12"></telerik:RadTextBox>
                </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </ew:CollapsablePanel>
    </div>


    <asp:HiddenField ID="HiddenFieldSelectedRow" runat="server" Value="" />
    <asp:HiddenField ID="HiddenFieldSecMod" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="HiddenFieldSelectAll" runat="server" Value="0" />

</div>


    <div id="kenWin">
        <div id="window-message" style="max-width: 500px; min-width: 200px;"></div>
        <div style="">
        <div style="float:right; margin-top: 10px;">
            <button type="button" id="yesButton" class="k-primary" style="width: 50px; margin-right: 5px;">Yes</button>
            <button type="button" id="noButton" class="k-primary" style="width: 50px;">No</button>
        </div>
        </div>
    </div>

    <script type="text/javascript">

        $(document).ready(function () {
            $('#yesButton').kendoButton();
            $('#noButton').kendoButton();            
        });

        (function () {
            $('body')
                .on('click', 'a[adv-lookup]', function () {
                    var currentScope = getCurrentScope($(this));
                    var input, cancel;
                    var type = $(this).attr('adv-lookup');
                    input = currentScope.getInput(type);
                    if (input) {
                        if ($(input).attr('disabled') === 'disabled') {
                            cancel = true;
                        }
                    }else{
                        cancel = true;
                    }
                    if (!cancel) {
                        currentScope.open(type);
                    }
                })
                .on('dblclick', 'input[adv-lookup]', function () {
                    if ($(this).is(":enabled")) {
                        getCurrentScope($(this)).openFilterDialog($(this));
                    }
                })
                .on('change', 'input[adv-lookup]', function () {
                    var currentScope = getCurrentScope($(this))
                    var newVal = null;
                    var lookupType = $(this).attr('adv-lookup');
                    var jobComponent = {};
                    newVal = currentScope.getInputValue(lookupType);
                    if (lookupType === 'Client' || lookupType === 'Division' || lookupType === 'Product' || lookupType === 'Job' || lookupType === 'JobComponent') {
                        JobComponent = currentScope.getSearchCriteria().JobComponent
                        if (lookupType === 'Client') {
                            JobComponent.ClientName = null;
                            JobComponent.DivisionCode = null;
                            JobComponent.DivisionName = null;
                            JobComponent.ProductCode = null;
                            JobComponent.ProductName = null;
                            JobComponent.JobNumber = null;
                            JobComponent.JobDescription = null;
                            JobComponent.JobComponentNumber = null;
                            JobComponent.JobComponentDescription = null;
                        } else if (lookupType === 'Division') {
                            JobComponent.DivisionName = null;
                            JobComponent.ProductCode = null;
                            JobComponent.ProductName = null;
                            JobComponent.JobNumber = null;
                            JobComponent.JobDescription = null;
                            JobComponent.JobComponentNumber = null;
                            JobComponent.JobComponentDescription = null;
                        } else if (lookupType === 'Product') {
                            JobComponent.ProductName = null;
                            JobComponent.JobNumber = null;
                            JobComponent.JobDescription = null;
                            JobComponent.JobComponentNumber = null;
                            JobComponent.JobComponentDescription = null;
                        } else if (lookupType === 'Job') {
                            JobComponent.JobDescription = null;
                            JobComponent.JobComponentNumber = null;
                            JobComponent.JobComponentDescription = null;
                        } else if (lookupType === 'JobComponent') {
                            JobComponent.JobComponentDescription = null;
                        }
                        currentScope.jobComponentValuesChanged(JobComponent, newVal);
                    }
                    if (lookupType === 'Function') {
                        currentScope.functionValuesChanged(currentScope.getSearchCriteria().Function, newVal);
                    }
                    if (lookupType === 'GeneralLedgerAccount') {
                        currentScope.glAccountValuesChanged(currentScope.getSearchCriteria().GeneralLedgerAccount, newVal);
                    }
                    if (lookupType === 'Employee') {
                        currentScope.employeeValuesChanged(currentScope.getSearchCriteria().Employee, newVal);
                    }
                    if (lookupType === 'Vendor') {
                        currentScope.vendorValuesChanged(currentScope.getSearchCriteria().Vendor, newVal);
                    }
                    if (lookupType === 'VendorContact') {
                        currentScope.vendorContactValuesChanged(currentScope.getSearchCriteria().VendorContact, newVal);
                    }
                })
                .on('focus', 'input[adv-calc]', function () {
                    getCurrentScope($(this)).parentRow = $(this).closest('tr');
                })
                .on('focus', '.RadGrid input[adv-lookup]', function () {
                    getCurrentScope($(this)).parentRow = $(this).closest('tr');
                });
        })();

        var getCurrentScope = function (element) {
            return angular.element(element).scope();
        };

        var RadAjaxPanelGridOnResponseEnd = function (sender, args) {
            $('input[adv-calc]').each(function () {
                $(this).removeClass('rfdDecorated').removeClass('rfdInputDisabled');
            });
        }

        function SelectAllRows(checked) {
                    var radgrid = $find('<%= RadGridPODetails.ClientID %>');
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

        var onGridCreated = function (sender, args) {
            var radGrid = sender;
            if (radGrid) {
                var masterTableView = radGrid.get_masterTableView();
                if (masterTableView) {
                    var selectedItems = masterTableView.get_selectedItems();
                    var menu = $find('<%= RadToolBarDetails.ClientID %>');
                    var gridDataItem;
                    if (selectedItems.length > 0) {
                        gridDataItem = selectedItems[0];
                    }
                    enableOrDisableMenuOptions(menu, gridDataItem);
                    $('tbody > tr.rgEditRow').each(function (i) {
                        var cssClass = 'rgRow';
                        if (i % 2) {
                            cssClass = 'rgAltRow';
                        }
                        $(this).removeClass('rgEditRow').addClass(cssClass);
                    });
                    $('input[adv-calc]').each(function () {
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
                var scope = getCurrentScope($('#purchaseOrderGridContainer'));
                if (scope) {
                    scope.initActions();
                }
            }
        };
        function RadGridPODetailsColumnHeaderMenu(ev) {
            var grid = $find("<%= RadGridPODetails.ClientID %>");
            grid.get_masterTableView().get_columns()[1].showHeaderMenu(ev, 30, 40);
        }
        
    </script>
    
</asp:Content>
