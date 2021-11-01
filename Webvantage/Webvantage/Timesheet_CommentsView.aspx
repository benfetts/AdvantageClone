<%@ Page Title="Timesheet Entry" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Timesheet_CommentsView.aspx.vb" Inherits="Webvantage.Timesheet_CommentsView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <link rel="stylesheet" href="Content/kendo/current/kendo.common.min.css" />
    <link rel="stylesheet" href="Content/kendo/current/kendo.bootstrap.min.css" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
    <script type="text/javascript" src="Scripts/angular.min.js"></script>
    <script type="text/javascript" src="Scripts/angular-ui/ui-bootstrap-tpls.min.js"></script>
    <script type="text/javascript" src="Scripts/kendo/current/kendo.all.min.js"></script>
    <script type="text/javascript" src="app/js/app.js"></script>
    <script type="text/javascript" src="app/js/services.js"></script>
    <script type="text/javascript" src="app/js/controllers/timeSheetLookup.js"></script>
    <script type="text/javascript" src="app/js/controllers/functionCategoryLookupModal.js"></script>
    <script type="text/javascript" src="app/js/controllers/purchaseOrderLookup.js"></script>
    <script type="text/javascript" src="app/js/controllers/kendoGridLookupModal.js"></script>

    <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
        <script type="text/javascript">
            function RadToolBarTimesheetCommentsViewOnClientButtonClicking(sender, args) {
                var commandName = args.get_item().get_commandName();

                if (commandName === "Save") {
                    validateTimesheetRow();
                    args.set_cancel(true);

                }

                if (commandName == "SpellCheck") {
                    spellCheck();
                }
            }
        </script>
    </telerik:RadScriptBlock>
    <telerik:RadCodeBlock ID="RadCodeBlockSpellChecker" runat="server">
        <script type="text/javascript">
            function MultipleTextSource(sources) {
                this.sources = sources;
                this.get_text = function () {
                    var texts = [];
                    for (var i = 0; i < this.sources.length; i++) {
                        texts[texts.length] = this.sources[i].get_text();
                    }
                    return texts.join("<controlSeparator><br/></controlSeparator>");
                }
                this.set_text = function (text) {
                    var texts = text.split("<controlSeparator><br/></controlSeparator>");
                    for (var i = 0; i < this.sources.length; i++) {
                        this.sources[i].set_text(texts[i]);
                    }
                }
            }
            function spellCheck() {
            }
        </script>
    </telerik:RadCodeBlock>
    <div >
        <telerik:RadToolBar ID="RadToolBarTimesheetCommentsView" runat="server" Width="100%" SingleClick="ToolBar"
            OnClientButtonClicking="RadToolBarTimesheetCommentsViewOnClientButtonClicking">
            <Items>
                <telerik:RadToolBarButton Text="" Value="Save" CommandName="Save" SkinID="RadToolBarButtonSave"
                    ToolTip="Save">
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Text="Cancel" Value="Cancel" CommandName="Cancel" SkinID="RadToolBarButtonClear"
                    ToolTip="Cancel">
                </telerik:RadToolBarButton>
            </Items>
        </telerik:RadToolBar>
    </div>
    <div >
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#TextBoxProductCategory").dblclick(function () {
                var currentScope = angular.element($('#TextBoxClientCode')).scope();
                if (currentScope.searchActive) {
                    OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=ts&control='
                         + $("#TextBoxProductCategory").val() + "&type=productcategory&client="
                         + $("#TextBoxClientCode").val()
                         + '&division=' + $("#TextBoxDivisionCode").val()
                         + '&product=' + $("#TextBoxProductCode").val());
                }
                return false;
            });
            setMinimumHeight();
        });

        function processLookupSelection(selectedItem) {
            var currentScope = angular.element($('#TextBoxClientCode')).scope();
            currentScope.processLookupSelection(selectedItem);
            currentScope.$apply();
        };

        function setMinimumHeight() {
            var clientCodeTextBox = $('#TextBoxClientCode');
            var currentScope = angular.element(clientCodeTextBox).scope();
            currentScope.setMinimumHeight();

        };

        function validateTimesheetRow() {
            var clientCodeTextBox = $('#TextBoxClientCode');
            var currentScope = angular.element(clientCodeTextBox).scope();
            currentScope.commentsViewActive = true;
            currentScope.validateCurrentTimesheetEntry();
        };

        function highlightRequiredFields(day) {
            var clientCodeTextBox = $('#TextBoxClientCode');
            var currentScope = angular.element(clientCodeTextBox).scope();
            var parsedValue = 0;
            if (currentScope.TimesheetSettings.CommentsRequiredForJob) {
                parsedValue = parseFloat($('#Txt' + day + 'Hours').val());
                if ($('#Txt' + day + 'Hours').val().trim() != '' && parsedValue != 0) {
                    $('#Txt' + day + 'Comments').addClass("RequiredInput");
                } else {
                    $('#Txt' + day + 'Comments').removeClass("RequiredInput");
                }
            }
        };

        function disableSearch() {
            angular.element($('#TextBoxClientCode')).scope().searchActive = false;
        };
        function processAurLookupToAngular(args) {
            if (args) {
                //console.log("processAurLookupToAngular CV", args)
                var clientCodeTextBox = $('#TextBoxClientCode');
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
    <div ng-app="webvantageApp">
        <div style="margin: 0px 4px 0px 4px;" ng-controller="timeSheetLookupController">
            <asp:HiddenField ID="HiddenField_EmployeeCode" runat="server" ClientIDMode="Static" />
            <!-- Header -->
            <div>
                <div style="text-align:center;">
                    <asp:Label ID="LblMessage" runat="server" CssClass="warning" Text=""></asp:Label>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:Label ID="Label_Client" runat="server">Client</asp:Label>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TextBoxClientCode" runat="server" TabIndex="1" Width="85" ng-model="ClientCode" ng-dblclick="open('Client')" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <div class="code-description-label" style="display: inline-block;">
                            <asp:Label ID="Label_FuncCat" runat="server"></asp:Label>
                        </div>
                        <div class="code-description-code" style="display: inline-block;">
                            <asp:TextBox ID="TextBoxFunctionCategoryCode" runat="server" CssClass="RequiredInput"
                                MaxLength="10" TabIndex="6" Width="85" ng-model="FunctionCategory" ng-dblclick="open('FunctionCategory')" ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:Label ID="Label_Division" runat="server"></asp:Label>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TextBoxDivisionCode" runat="server" TabIndex="2" Width="85" ng-model="DivisionCode" ng-dblclick="open('Division')" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <div class="code-description-label" style="display: inline-block;">
                            Department<span class="warning">*</span>
                        </div>
                        <div class="code-description-code" style="display: inline-block;">
                            <telerik:RadComboBox ID="RadComboBoxDepartment" runat="server" TabIndex="7" DropDownCssClass="RequiredBackground" Width="160">
                            </telerik:RadComboBox>
                        </div>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:Label ID="Label_Product" runat="server"></asp:Label>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TextBoxProductCode" runat="server" TabIndex="3" Width="85" ng-model="ProductCode" ng-dblclick="open('Product')" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div class="code-description-label">
                        <asp:Label ID="Label_Assignment" runat="server">Assignment</asp:Label>
                    </div>
                    <div class="code-description-code">
<%--                        <asp:TextBox ID="TextBoxAssignment" runat="server" TabIndex="3" Width="85" ng-model="AlertSubject" ng-dblclick="open('Assignment')" ClientIDMode="Static"></asp:TextBox>--%>
                        <asp:TextBox ID="TextBoxAlertID" runat="server" TabIndex="3" Width="85" ng-model="AlertID" ng-dblclick="open('Assignment')" ClientIDMode="Static"></asp:TextBox>
                    </div>

                    <div class="code-description-description">
                        <div class="code-description-label" style="display: inline-block;">
                            <asp:Label ID="Label_ProdCat" runat="server"></asp:Label>
                        </div>
                        <div class="code-description-code" style="display: inline-block;">
                            <asp:TextBox ID="TextBoxProductCategory" ClientIDMode="Static" runat="server" TabIndex="8" Width="85"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:Label ID="Label_Job" runat="server"></asp:Label>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TextBoxJobNumber" runat="server" TabIndex="4" Width="85" ng-model="JobNumber" ng-keyup="getDefaultJobComponentNumber(true)" ng-dblclick="open('Job')" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TextBoxJobDescription" runat="server" TabIndex="-1" Width="261" ReadOnly="true" ng-model="JobDescription"></asp:TextBox>
                    </div>
                </div>
                <div class="code-description-container">
                    <div class="code-description-label">
                        <asp:Label ID="Label_JobComp" runat="server"></asp:Label>
                    </div>
                    <div class="code-description-code">
                        <asp:TextBox ID="TextBoxJobComponentNbr" runat="server" TabIndex="5" Width="85" ng-model="JobComponentNumber" ng-dblclick="open('JobComponent')" ng-keyup="getJobComponentDescription()" ClientIDMode="Static"></asp:TextBox>
                    </div>
                    <div class="code-description-description">
                        <asp:TextBox ID="TextBoxJobComponentDescription" runat="server" TabIndex="-1" Width="261" ReadOnly="true" ng-model="JobComponentDescription" ></asp:TextBox>
                    </div>
                </div>
            </div>
            <div id="DivDays">
                <asp:Panel ID="PanelSunday" runat="server">
                    <div class="form-horizontal">
                        <h4>
                            <asp:Label ID="LblSundayHeader" runat="server" Text="" ClientIDMode="Static"></asp:Label>
                            <asp:HiddenField ID="HiddenFieldSundayDate" runat="server" />        
                        </h4>
                        <div class="">
                            Hours:
                        <div class="">
                            <asp:TextBox ID="TxtSundayHours" runat="server" Enabled="false" TabIndex="12" Width="50" onfocus="this.select();return false;"
                                Style="text-align: right;" ClientIDMode="Static" onchange="highlightRequiredFields('Sunday');" onkeyup="highlightRequiredFields('Sunday');"></asp:TextBox>
                            <asp:HiddenField ID="HfSundayHours" runat="server" />
                            <asp:ImageButton ID="ImageButtonSundayStopWatch" runat="server" ImageUrl="~/Images/Icons/Grey/256/stopwatch2.png" CssClass="icon-image" ToolTip="Stop Stopwatch" />
                        </div>
                        </div>
                        <div class="">
                            Comment:
                        <div class="">
                            <asp:TextBox ID="TxtSundayComments" runat="server" TextMode="multiLine" ClientIDMode="Static"
                                Width="650" TabIndex="13">
                            </asp:TextBox>
                            <asp:HiddenField ID="HfSundayComments" runat="server" />
                        </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="PanelMonday" runat="server">
                    <div class="form-horizontal">
                        <h4>
                            <asp:Label ID="LblMondayHeader" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="HiddenFieldMondayDate" runat="server" />
                        </h4>
                        <div class="">
                            Hours:
                        <div class="">
                            <asp:TextBox ID="TxtMondayHours" runat="server" Enabled="false" TabIndex="14" Width="50" onfocus="this.select();return false;" style="text-align: right;" ClientIDMode="Static" onchange="highlightRequiredFields('Monday');" onkeyup="highlightRequiredFields('Monday');"></asp:TextBox>
                            <asp:HiddenField ID="HfMondayHours" runat="server" />
                            <asp:ImageButton ID="ImageButtonMondayStopWatch" runat="server" ImageUrl="~/Images/Icons/Grey/256/stopwatch2.png" CssClass="icon-image" ToolTip="Stop Stopwatch" />
                        </div>
                        </div>
                        <div class="">
                            Comment:
                        <div class="">
                            <asp:TextBox ID="TxtMondayComments" runat="server" TextMode="multiLine"
                                Width="650" TabIndex="15" ClientIDMode="Static">
                            </asp:TextBox>
                            <asp:HiddenField ID="HfMondayComments" runat="server" />
                        </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="PanelTuesday" runat="server">
                    <div class="form-horizontal">
                        <h4>
                            <asp:Label ID="LblTuesdayHeader" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="HiddenFieldTuesdayDate" runat="server" />
                        </h4>
                        <div class="">
                            Hours:
                        <div class="">
                            <asp:TextBox ID="TxtTuesdayHours" runat="server" Enabled="false" TabIndex="16" Width="50" onfocus="this.select();return false;"
                                Style="text-align: right;" ClientIDMode="Static" onchange="highlightRequiredFields('Tuesday');" onkeyup="highlightRequiredFields('Tuesday');"></asp:TextBox>
                            <asp:HiddenField ID="HfTuesdayHours" runat="server" />
                            <asp:ImageButton ID="ImageButtonTuesdayStopWatch" runat="server" ImageUrl="~/Images/Icons/Grey/256/stopwatch2.png" CssClass="icon-image" ToolTip="Stop Stopwatch" />
                        </div>
                        </div>
                        <div class="">
                            Comment:
                        <div class="">
                            <asp:TextBox ID="TxtTuesdayComments" runat="server" TextMode="multiLine"
                                Width="650" TabIndex="17" ClientIDMode="Static">
                            </asp:TextBox>
                            <asp:HiddenField ID="HfTuesdayComments" runat="server" />
                        </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="PanelWednesday" runat="server">
                    <div class="form-horizontal">
                        <h4>
                            <asp:Label ID="LblWednesdayHeader" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="HiddenFieldWednesdayDate" runat="server" />
                        </h4>
                        <div class="">
                            Hours:
                        <div class="">
                            <asp:TextBox ID="TxtWednesdayHours" runat="server" Enabled="false" TabIndex="18" Width="50" onfocus="this.select();return false;"
                                Style="text-align: right;" ClientIDMode="Static" onchange="highlightRequiredFields('Wednesday');" onkeyup="highlightRequiredFields('Wednesday');"></asp:TextBox>
                            <asp:HiddenField ID="HfWednesdayHours" runat="server" />
                            <asp:ImageButton ID="ImageButtonWednesdayStopWatch" runat="server" ImageUrl="~/Images/Icons/Grey/256/stopwatch2.png" CssClass="icon-image" ToolTip="Stop Stopwatch" />
                        </div>
                        </div>
                        <div class="">
                            Comment:
                        <div class="">
                            <asp:TextBox ID="TxtWednesdayComments" runat="server" TextMode="multiLine"
                                Width="650" TabIndex="19" ClientIDMode="Static">
                            </asp:TextBox>
                            <asp:HiddenField ID="HfWednesdayComments" runat="server" />
                        </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="PanelThursday" runat="server">
                    <div class="form-horizontal">
                        <h4>
                            <asp:Label ID="LblThursdayHeader" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="HiddenFieldThursdayDate" runat="server" />
                        </h4>
                        <div class="">
                            Hours:
                        <div class="">
                            <asp:TextBox ID="TxtThursdayHours" runat="server" Enabled="false" TabIndex="20" Width="50" onfocus="this.select();return false;"
                                Style="text-align: right;" ClientIDMode="Static" onchange="highlightRequiredFields('Thursday');" onkeyup="highlightRequiredFields('Thursday');"></asp:TextBox>
                            <asp:HiddenField ID="HfThursdayHours" runat="server" />
                            <asp:ImageButton ID="ImageButtonThursdayStopWatch" runat="server" ImageUrl="~/Images/Icons/Grey/256/stopwatch2.png" CssClass="icon-image" ToolTip="Stop Stopwatch" />
                        </div>
                        </div>
                        <div class="">
                            Comment:
                        <div class="">
                            <asp:TextBox ID="TxtThursdayComments" runat="server" TextMode="multiLine"
                                Width="650" TabIndex="21" ClientIDMode="Static">
                            </asp:TextBox>
                            <asp:HiddenField ID="HfThursdayComments" runat="server" />
                        </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="PanelFriday" runat="server">
                    <div class="form-horizontal">
                        <h4>
                            <asp:Label ID="LblFridayHeader" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="HiddenFieldFridayDate" runat="server" />
                        </h4>
                        <div class="">
                            Hours:
                        <div class="">
                            <asp:TextBox ID="TxtFridayHours" runat="server" Enabled="false" TabIndex="22" Width="50" ClientIDMode="Static" onfocus="this.select();return false;"
                                Style="text-align: right;" onchange="highlightRequiredFields('Friday');" onkeyup="highlightRequiredFields('Friday');"></asp:TextBox>
                            <asp:HiddenField ID="HfFridayHours" runat="server" />
                            <asp:ImageButton ID="ImageButtonFridayStopWatch" runat="server" ImageUrl="~/Images/Icons/Grey/256/stopwatch2.png" CssClass="icon-image" ToolTip="Stop Stopwatch" />
                        </div>
                        </div>
                        <div class="">
                            Comment:
                        <div class="">
                            <asp:TextBox ID="TxtFridayComments" runat="server" TextMode="multiLine"
                                Width="650" TabIndex="23" ClientIDMode="Static">
                            </asp:TextBox>
                            <asp:HiddenField ID="HfFridayComments" runat="server" />
                        </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="PanelSaturday" runat="server">
                    <div class="form-horizontal">
                        <h4>
                            <asp:Label ID="LblSaturdayHeader" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="HiddenFieldSaturdayDate" runat="server" />
                        </h4>
                        <div class="">
                            Hours:
                        <div class="">
                            <asp:TextBox ID="TxtSaturdayHours" runat="server" Enabled="false" TabIndex="24" Width="50" onfocus="this.select();return false;"
                                Style="text-align: right;" ClientIDMode="Static" onchange="highlightRequiredFields('Saturday');" onkeyup="highlightRequiredFields('Saturday');"></asp:TextBox>
                            <asp:HiddenField ID="HfSaturdayHours" runat="server" />
                            <asp:ImageButton ID="ImageButtonSaturdayStopWatch" runat="server" ImageUrl="~/Images/Icons/Grey/256/stopwatch2.png" CssClass="icon-image" ToolTip="Stop Stopwatch" />
                        </div>
                        </div>
                        <div class="">
                            Comment:
                        <div class="">
                            <asp:TextBox ID="TxtSaturdayComments" runat="server" TextMode="multiLine"
                                Width="650" TabIndex="25" ClientIDMode="Static">
                            </asp:TextBox>
                            <asp:HiddenField ID="HfSaturdayComments" runat="server" />
                        </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
