<%@ Page Title="Account Setup" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="AccountSetupForm.aspx.vb" Inherits="Webvantage.AccountSetupForm" %>

<%@ Register Src="UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">   
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">

            function stopRKey(evt) {
                var evt = (evt) ? evt : ((event) ? event : null);
                var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
                if ((evt.keyCode == 13) && (node.type == "text")) {
                    return false;
                    //evt.keyCode = 9;
                }
            }

            document.onkeypress = stopRKey;

            function deleteTimesheetRows() {
                var checkedRows = $(".rgSelectedRow");
                if (checkedRows.length == 0) {
                    ShowMessage("Please select a timesheet(s) to delete.");
                    // e.preventDefault();
                    return false;
                }

                if (confirm("Are you sure you want to delete the selected row(s)?") == false) {
                    return false;
                }

                return true;

            }

            $(document).ready(function () {
                $("#TextBox_ProductCategory").dblclick(function () {
                    OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=ts&control='
                         + $("#TextBox_ProductCategory").val() + "&type=productcategory&client="
                         + $("#TextBox_ClientCode").val()
                         + '&division=' + $("#TextBox_DivisionCode").val()
                         + '&product=' + $("#TextBox_ProductCode").val());
                    return false;
                });

                //$("input.timesheet-day-hours-textbox").kendoNumericTextBox({ min: -24, max: 24, step: 0.5 });
                $("input.timesheet-day-hours-textbox").focus(function() {
                    var input = $(this);
                    setTimeout(function() {
                        input.select();
                    });
                });

            });      // end of document.ready

            function processLookupSelection(selectedItem) {
                var clientCodeTextBox = $('#TextBox_ClientCode');
                var currentScope = angular.element(clientCodeTextBox).scope();
                currentScope.processLookupSelection(selectedItem);
                currentScope.$apply();
            }

            function validateNewTimesheetRow() {
                var clientCodeTextBox = $('#TextBox_ClientCode');
                var currentScope = angular.element(clientCodeTextBox).scope();

                currentScope.validateCurrentAccountSetupEntry();
                return false;
            }


            function refreshGridTotals(callingElement) {
                var clientCodeTextBox = $('#TextBox_ClientCode');
                var currentScope = angular.element(clientCodeTextBox).scope();

                currentScope.refreshGridTotals(callingElement);
                currentScope.$apply();
            }

        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <style type="text/css">
        .RadGrid_Bootstrap .rgHeader .timesheet-dialog-selector {
            color: -webkit-link;
            text-decoration: underline;
        }

        .rgHeader > a {
            white-space: nowrap;
        }

        input.k-formatted-value.timesheet-day-hours-textbox.k-input.rfdDecorated,
        input#sampleTextBox.timesheet-day-hours-textbox.k-input.rfdDecorated {
            width: 45px;
        }

        span.k-widget.k-numerictextbox.timesheet-day-hours-textbox span.k-numeric-wrap.k-state-default span.k-select span.k-link {
            display: none;
        }

        span.k-icon.k-i-arrow-n, span.k-icon.k-i-arrow-s {
            display: none;
        }

        .timesheet-day-hours-textbox.rfdDecorated {
            width: 64px !important;
            border-radius: 4px 4px 4px 4px !important;
        }


        div.timesheet-day-hours-textbox-container span.k-widget.k-numerictextbox.aspNetDisabled.timesheet-day-hours-textbox span.k-numeric-wrap.k-state-disabled span.k-select {
            display: none;
        }
    </style>
    <%--    
    THIS CSS IS MESSING UP THE TELERIK CSS
    <link rel="stylesheet" href="Content/kendo/2017.2.504/kendo.common.min.css" />
    <link rel="stylesheet" href="Content/kendo/2017.2.504/kendo.bootstrap.min.css" /> 
    <link href="Content/bootstrap.css" rel="stylesheet" />
   
    --%>
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
    <script type="text/javascript" src="Scripts/angular.min.js"></script>
    <script type="text/javascript" src="Scripts/angular-ui/ui-bootstrap-tpls.min.js"></script>
    <script type="text/javascript" src="Scripts/kendo/current/kendo.all.min.js"></script>
    <script type="text/javascript" src="app/js/app.js"></script>
    <script type="text/javascript" src="app/js/services.js"></script>
    <script type="text/javascript" src="app/js/controllers/accountSetup.js"></script>
    <script type="text/javascript" src="app/js/controllers/LookupModal.js"></script>
    <script type="text/javascript" src="app/js/controllers/purchaseOrderLookup.js"></script>
    <script type="text/javascript" src="app/js/controllers/kendoGridLookupModal.js"></script>

    <script type="text/javascript">       

        function cancelNewTimesheetRow() {
            var clientCodeTextBox = $('#TextBox_ClientCode');
            var employeeCode = $('#txtEmpCode').val();
            var currentScope = angular.element(clientCodeTextBox).scope();

            currentScope.EmployeeCode = employeeCode;
            currentScope.getEmployeeDefaultFunction();
            currentScope.ClientCode = '';
            currentScope.SundayComments = '';
            currentScope.MondayComments = '';
            currentScope.TuesdayComments = '';
            currentScope.WednesdayComments = '';
            currentScope.ThursdayComments = '';
            currentScope.FridayComments = '';
            currentScope.SaturdayComments = '';

            currentScope.SundayHours = 0;
            currentScope.MondayHours = 0;
            currentScope.TuesdayHours = 0;
            currentScope.WednesdayHours = 0;
            currentScope.ThursdayHours = 0;
            currentScope.FridayHours = 0;
            currentScope.SaturdayHours = 0;

            currentScope.$apply();

            $("input.timesheet-day-hours-textbox").kendoNumericTextBox().value = 0;

            currentScope.getTimesheetSettings();
            setTimeout(function () { $('#TextBox_JobCode').focus(); }, 250);

        };

        function showTimesheetDetails(url) {
            var browserWindow = GetRadWindow().BrowserWindow;
            setTimeout(function () {
                browserWindow.radopen(url, "Timesheet Details", 960, 610);
            }, 0)

            return false;
        };

        function showFakeSibling(callingElement) {
            var title = $(callingElement).attr('title');
            $(callingElement).parent().next().show();
            $(callingElement).parent().hide();
            if (title == 'Stop Stopwatch') {
                $($(callingElement).parent().next()).addClass('standard-red');
                $($(callingElement).parent().next().children()[0]).attr('src', $(callingElement).attr('src'));
            }
        };

        function disableTimesheetButtons() {
            $('.icon-background').hide();
        };

        function processAurLookupToAngular(args) {
            if (args) {
                console.log(args)
                var clientCodeTextBox = $('#TextBox_ClientCode');
                var currentScope = angular.element(clientCodeTextBox).scope();
                if (currentScope) {
                    currentScope.suppressDefaultDivision = true;
                    currentScope.suppressDefaultProduct = true;
                    if (args.ClientCode) {
                        currentScope.ClientCode = args.ClientCode;
                    }
                    if (args.DivisionCode) {
                        currentScope.DivisionCode = args.DivisionCode;
                    }
                    if (args.ProductCode) {
                        currentScope.ProductCode = args.ProductCode;
                    }
                    if (args.JobNumber) {
                        currentScope.JobNumber = args.JobNumber;
                    }
                    if (args.JobComponentNumber) {
                        currentScope.JobComponentNumber = args.JobComponentNumber;
                    }
                    currentScope.$apply();
                    currentScope.getJobComponentDescription();
                }
            }
        }

    </script>

    <style type="text/css">
        .radgrid-icon-column {
            max-width: none !important;
        }

        .larger-font {
            font-size: larger;
        }
         textarea { 
            resize: both !important; 
        }
   </style>
    <div ng-app="webvantageApp">
        <div id="content" ng-controller="accountsetupLookupController">
            <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
                <script type="text/javascript">
                    function RadToolbarAccountSetupButtonsOnClientButtonClicking(sender, args) {
                        var commandName = args.get_item().get_commandName();

                        if (commandName == "Delete") {
                            ////args.set_cancel(!confirm('Are you sure you want to delete the selected row?'));
                            radToolBarConfirm(sender, args, "Are you sure you want to delete the selected row?");
                        }
                        else if (commandName == "deleteselected") {
                            var checkedRows = $(".rgSelectedRow");
                            if (checkedRows.length == 0) {
                                ShowMessage("Please select a timesheet(s) to delete.");
                                args.set_cancel(true);
                                return false;
                            }

                            if (confirm("Are you sure you want to delete the selected row(s)?") == false) {
                                args.set_cancel(true);
                                return false;
                            }
                        }
                        else if (commandName == "ColumnPreferences") {
                            RadGridTimesheetColumnHeaderMenu();
                            return false;
                        }
                        else if (commandName == "CloseWindow") {
                            window.close();
                            return false;
                        }
                        else if (commandName == "TimesheetSettings") {
                            OpenRadWindow("", "Maintenance_Timesheet.aspx?my=1", 0, 0, false);
                            return false;
                        }
                        else if (commandName == "Search") {
                            OpenRadWindow("", "Timesheet_Search.aspx", 0, 0, false);
                            return false;
                        }
                        else if (commandName == "NoPostBack") {
                            args.set_cancel(true);
                        }
                    }
                    function RadGridTimesheetColumnHeaderMenu(ev) {
                        var grid = $find("<%= RadGridAccountSetupForm.ClientID %>");
                        grid.get_masterTableView().get_columns()[0].showHeaderMenu(ev, 30, 40);
                    }
                </script>
            </telerik:RadScriptBlock>
            <div style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
                <telerik:RadToolBar ID="RadToolbarAccountSetupButtons" runat="server" AutoPostBack="false"
                    OnClientButtonClicking="RadToolbarAccountSetupButtonsOnClientButtonClicking" Width="100%">
                    <Items>
                        <telerik:RadToolBarButton IsSeparator="true" Value="SaveSeparator" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonSaveAccountSetup" SkinID="RadToolBarButtonSave" ToolTip="Save" CommandName="save" Value="save" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonPrint" SkinID="RadToolBarButtonPrint"
                            Text="Print" Value="print" ToolTip="Print this timesheet" Visible="false" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonRefresh" SkinID="RadToolBarButtonRefresh" Value="refresh" ToolTip="Refresh the selected timesheet" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonDelete" SkinID="RadToolBarButtonDelete" ToolTip="Delete the selected records" CommandName="deleteselected" Value="DeleteSelected" />

                    </Items>
                </telerik:RadToolBar>
            </div>
            
            <div class="telerik-aqua-body">
                <telerik:RadGrid ID="RadGridAccountSetupForm" runat="server" InsertItemDisplay="Top" AllowMultiRowSelection="true" AllowAutomaticInserts="False"
                    AllowSorting="true" EnableHeaderContextMenu="true" EnableEmbeddedSkins="True"
                    AutoGenerateColumns="False" EnableAJAX="False" EnableAJAXLoadingTemplate="False"
                    GridLines="None" GroupingSettings-GroupByFieldsSeparator="&nbsp;&nbsp;|&nbsp;&nbsp;"
                    AllowPaging="True" PageSize="10" ShowFooter="True">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom"></PagerStyle>                    
                    <ClientSettings AllowColumnsReorder="False" EnablePostBackOnRowClick="False">
                        <Selecting AllowRowSelect="True" />
                        <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="ID,JobNumber, JobComponentNumber, Balanced" AllowMultiColumnSorting="true" EnableLinqGrouping="false" EditMode="InPlace">
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnViewDetails" HeaderAbbr="FIXED">
                                <HeaderStyle CssClass="radgrid-icon-column" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <ItemStyle CssClass="radgrid-icon-column" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <FooterStyle CssClass="radgrid-icon-column" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <HeaderTemplate>
                                    <asp:ImageButton ID="ImageButtonColumnPreferences" runat="server" ImageAlign="AbsMiddle" CssClass="column-prefs-icon"
                                        ImageUrl="~/Images/Icons/Grey/256/table_selection_column.png" ToolTip="Column Preferences" OnClientClick="RadGridTimesheetColumnHeaderMenu(event);" />
                                </HeaderTemplate>
                                <ItemTemplate>                                    
                                    <div>
                                    </div>
                                </ItemTemplate>
                                <EditItemTemplate></EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnClient" HeaderText="Client Code" HeaderAbbr="FIXED"
                                SortExpression="ClientCode" ShowSortIcon="true">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="100" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="100" />
                                <EditItemTemplate>
                                    <div>
                                        <asp:TextBox ID="TextBox_ClientCode" ClientIDMode="Static" runat="server" TabIndex="0" SkinID="TextBoxCodeSmall" ng-model="ClientCode" ng-keyup="suppressDefaultDivision = false; suppressDefaultProduct = false;" ng-dblclick="open('Client')" MaxLength="6"></asp:TextBox>                                        
                                        <asp:TextBox runat="server" ID="TextBox_JobCode" Value='<%# Eval("JobNumber") %>' Visible="false" SkinID="TextBoxStandard" ></asp:TextBox>
                                        <asp:TextBox runat="server" ID="TextBox_ComponentCode" Value='<%# Eval("JobComponentNumber") %>' Visible="false"  SkinID="TextBoxStandard"></asp:TextBox>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelClient" runat="server" Text='<%# Eval("ClientCode") %>' ToolTip='<%# "Client:  " & Eval("ClientName") %>'
                                        Visible="True">                                            
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDivision" HeaderText="Division Code"
                                SortExpression="DivisionCode" ShowSortIcon="true">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="30" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <EditItemTemplate>
                                    <div>
                                        <asp:TextBox ID="TextBox_DivisionCode" ClientIDMode="Static" runat="server" TabIndex="0" SkinID="TextBoxCodeSmall" ng-model="DivisionCode" ng-keyup="suppressDefaultDivision = false; suppressDefaultProduct = false; getDefaultProductCode();" ng-dblclick="open('Division')" MaxLength="6"></asp:TextBox>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelDivision" runat="server" Text='<%# Eval("DivisionCode") %>' ToolTip='<%# "Division:  " & Eval("DivisionName") %>'
                                        Visible="True">
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnProduct" HeaderText="Product Code"
                                SortExpression="ProductCode">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="30" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <EditItemTemplate>
                                    <div>
                                        <asp:TextBox ID="TextBox_ProductCode" ClientIDMode="Static" runat="server" TabIndex="0" SkinID="TextBoxCodeSmall" ng-model="ProductCode" ng-keyup="suppressDefaultDivision = false; suppressDefaultProduct = false; searchProductName();" ng-dblclick="open('Product')" MaxLength="6"></asp:TextBox>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelProduct" runat="server" Text='<%# Eval("ProductCode") %>' ToolTip='<%# "Product:  " & Eval("ProductName") %>'
                                        Visible="True">
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <%--<telerik:GridTemplateColumn UniqueName="GridTemplateColumnClientDesc" Visible="false"
                                SortExpression="ClientName" HeaderText="Client Name">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle CssClass="radgrid-description-column" />
                                <EditItemTemplate>
                                    <div>
                                        <span title="Client:  {{ClientName}}">{{ClientName}}</span>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelClientNameDisplay" runat="server" Text='<%# Eval("ClientName")%>' ToolTip='<%# "Client:  " & Eval("ClientName")%>'
                                        Visible="True">                                            
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDivisionDesc" Visible="false"
                                SortExpression="DivisionName" HeaderText="Division Name">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle CssClass="radgrid-description-column" />
                                <EditItemTemplate>
                                    <div>
                                        <span title="Division:  {{DivisionName}}">{{DivisionName}}</span>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelDivisionNameDisplay" runat="server" Text='<%# Eval("DivisionName")%>' ToolTip='<%# "Division:  " & Eval("DivisionName") %>'
                                        Visible="True">                                            
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnProductDesc" Visible="false"
                                SortExpression="ProductDescription" HeaderText="Product Name">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle CssClass="radgrid-description-column" />
                                <EditItemTemplate>
                                    <div>
                                        <span title="Product:  {{ProductName}}">{{ProductName}}</span>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelProductDescriptionDisplay" runat="server" Text='<%# Eval("ProductDescription")%>' ToolTip='<%# "Product:  " & Eval("ProductDescription") %>'
                                        Visible="True">                                            
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>--%>
                            <telerik:GridTemplateColumn DataField="AccountSetupCode1" HeaderStyle-HorizontalAlign="Center"
                                UniqueName="GridBoundColumnAccountSetupCode1" HeaderText="AccountSetupCode1">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="30" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <EditItemTemplate>
                                    <div>
                                        <asp:TextBox ID="TextBox_AccountSetupCode1" ClientIDMode="Static" runat="server" TabIndex="0" SkinID="TextBoxCodeLarge" ng-model="AccountSetupCode1" MaxLength="10"></asp:TextBox>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBoxAccountSetupCode1" ClientIDMode="Static" runat="server" TabIndex="0" SkinID="TextBoxCodeLarge" Text='<%# Eval("AccountSetupCode1") %>' MaxLength="10"></asp:TextBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="AccountSetupCode2" HeaderStyle-HorizontalAlign="Center"
                                UniqueName="GridBoundColumnAccountSetupCode2" HeaderText="AccountSetupCode2">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="30" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <EditItemTemplate>
                                    <div>
                                        <asp:TextBox ID="TextBox_AccountSetupCode2" ClientIDMode="Static" runat="server" TabIndex="0" SkinID="TextBoxCodeLarge" ng-model="AccountSetupCode2" MaxLength="10"></asp:TextBox>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBoxAccountSetupCode2" ClientIDMode="Static" runat="server" TabIndex="0" SkinID="TextBoxCodeLarge" Text='<%# Eval("AccountSetupCode2") %>' MaxLength="10"></asp:TextBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="AccountSetupCode3" HeaderStyle-HorizontalAlign="Center"
                                UniqueName="GridBoundColumnAccountSetupCode3" HeaderText="AccountSetupCode3">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="30" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <EditItemTemplate>
                                    <div>
                                        <asp:TextBox ID="TextBox_AccountSetupCode3" ClientIDMode="Static" runat="server" TabIndex="0" SkinID="TextBoxCodeLarge" ng-model="AccountSetupCode3" MaxLength="10"></asp:TextBox>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBoxAccountSetupCode3" ClientIDMode="Static" runat="server" TabIndex="0" SkinID="TextBoxCodeLarge" Text='<%# Eval("AccountSetupCode3") %>' MaxLength="10"></asp:TextBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="AccountSetupCode4" HeaderStyle-HorizontalAlign="Center"
                                UniqueName="GridBoundColumnAccountSetupCode4" HeaderText="AccountSetupCode4">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="30" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <EditItemTemplate>
                                    <div>
                                        <asp:TextBox ID="TextBox_AccountSetupCode4" ClientIDMode="Static" runat="server" TabIndex="0" SkinID="TextBoxCodeLarge" ng-model="AccountSetupCode4" MaxLength="10"></asp:TextBox>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBoxAccountSetupCode4" ClientIDMode="Static" runat="server" TabIndex="0" SkinID="TextBoxCodeLarge" Text='<%# Eval("AccountSetupCode4") %>' MaxLength="10"></asp:TextBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="" HeaderStyle-HorizontalAlign="Center"
                                UniqueName="GridBoundColumnPercentSplit" HeaderText="Percent">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="50" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="50" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="50" />
                                <EditItemTemplate>
                                    <div>
                                        <asp:TextBox ID="TextBox_PercentSplit" ClientIDMode="Static" runat="server" TabIndex="0" SkinID="TextBoxCodeSmall" MaxLength="30" Style="text-align: right;" Text="0.00"></asp:TextBox>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBoxPercentSplit" ClientIDMode="Static" runat="server" TabIndex="0" SkinID="TextBoxCodeSmall" Text='<%# Eval("PercentSplit") %>' MaxLength="30" Style="text-align: right;"></asp:TextBox>
                                    <%--<asp:Label ID="LabelPercentSplit" runat="server" Text='<%# Eval("PercentSplit") %>' ToolTip='<%# Eval("PercentSplit")%>'
                                        Visible="True">
                                    </asp:Label>--%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="" UniqueName="colTotalHours" HeaderAbbr="FIXED"
                                SortExpression="TotalHours">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="true" />
                                <EditItemTemplate>
                                    <div >
                                        <div class="icon-background background-color-sidebar" style="display: inline-block;" id="newRowButtons_Add">
                                            <asp:ImageButton ID="ImageButton_SaveNewRow" runat="server" AlternateText="Add new row"
                                                ToolTip="Add new row" ImageAlign="AbsMiddle" SkinID="ImageButtonAddWhite" TabIndex="0" ClientIDMode="Static" CommandName="NewRowCommitInsert" OnClientClick="return validateNewTimesheetRow()" />
                                        </div>
                                        <div class="icon-background background-color-sidebar" style="display: inline-block;">
                                            <asp:ImageButton ID="ImageButton_CancelNewRow" runat="server" AlternateText="Clear add new"
                                                ToolTip="Clear add new" SkinID="ImageButtonCancelWhite" TabIndex="0" CommandName="NewRowCancel" OnClientClick="cancelNewTimesheetRow(); return false;" />
                                        </div>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <div id="DivDelete" runat="server" class="icon-background background-color-delete">
                                        <asp:ImageButton ID="ImageButtonDelete" runat="server" CommandName="RowDelete" AlternateText="Delete row"
                                            ToolTip="Delete row" SkinID="ImageButtonDeleteWhite" />
                                        <asp:HiddenField ID="HiddenField_RowIsDeleteable" runat="server" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnAddToTemplate" Visible="False"
                                HeaderAbbr="FIXED">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div >
                                        <asp:ImageButton ID="ImageButtonAddToTemplate" runat="server" SkinID="ImageButtonNewWhite"
                                            ToolTip="Add to my Timesheet Template" CommandName="AddToTimesheetTemplate" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <ExpandCollapseColumn Resizable="False" Visible="False">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                    </MasterTableView>
                </telerik:RadGrid>
            </div>
            <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
        </div>
    </div>

</asp:Content>
