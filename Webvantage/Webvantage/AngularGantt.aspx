<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AngularGantt.aspx.vb" Inherits="Webvantage.AngularGantt" MasterPageFile="~/ChildPage.Master" %>
<%@ Register Src="UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <link rel="stylesheet" href="Content/kendo/current/kendo.common.min.css" />
    <link rel="stylesheet" href="Content/kendo/current/kendo.bootstrap.min.css" />
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
    <script type="text/javascript" src="Scripts/angular.min.js"></script>
    <script type="text/javascript" src="Scripts/angular-ui/ui-bootstrap-tpls.min.js"></script>
    <script type="text/javascript" src="Scripts/kendo/current/kendo.all.min.js"></script>
    <script type="text/javascript" src="app/js/app.js"></script>
    <script type="text/javascript" src="app/js/services.js"></script>
    <script type="text/javascript" src="app/js/controllers/angularGantt.js"></script>
    <style type="text/css">
        .k-gantt-create, .k-task-draghandle, .k-task-dot, .k-task-delete {
            visibility: hidden;
        }

        div.k-gantt-actions button.k-button.k-button-icontext.k-gantt-custom-export span.k-icon.k-download {
            background-image: url('Images/Icons/Grey/256/download.png');
            background-size: contain;
            height: 25px;
            width: 25px;
        }

        .k-window
        {
            width: 440px;
        }
    </style>

    <script type="text/javascript">

        function addTask(element) {
            var currentScope = angular.element(element).scope();
            currentScope.addTask(currentScope.JobComponentPair);
            return false;
        };

        function refreshData(element) {
            var currentScope = angular.element(element).scope();
            currentScope.refreshData(currentScope.JobComponentPair);
            return false;
        };

        function exportPDF(element) {
            var currentScope = angular.element(element).scope();
            currentScope.exportPDF(currentScope.JobComponentPair);
            return false;
        };

        function RadToolbar_Gantt_OnClientButtonClicking(sender, args) {
            var commandName = args.get_item().get_commandName();
            var ganttScope = angular.element($('#content')).scope();

            switch (commandName) {
                case "togglerelatedjobs":
                    var currentTitle = args._item.get_text();
                    ganttScope.toggleRelatedJobs();

                    if (currentTitle == 'Show Related Jobs') {
                        args._item.set_text('Hide Related Jobs');
                    } else {
                        args._item.set_text('Show Related Jobs');
                    }
                    args.set_cancel(true);
                    break;
                case "togglephases":
                    var currentTitle = args._item.get_text();
                    ganttScope.togglePhases();

                    if (currentTitle == 'Show Phases') {
                        args._item.set_text('Hide Phases');
                    } else {
                        args._item.set_text('Show Phases');
                    }
                    args.set_cancel(true);
                    break;

                case "toggleEmployees":
                    var currentTitle = args._item.get_text();
                    ganttScope.toggleEmployees();

                    if (currentTitle == 'Show Employees') {
                        args._item.set_text('Hide Employees');
                    } else {
                        args._item.set_text('Show Employees');
                    }
                    args.set_cancel(true);
                    break;
                case "refresh":
                    ganttScope.refresh();
                    args.set_cancel(true);
                   break;

                case "recalculatedates":
                    ganttScope.recalculate();
                    args.set_cancel(true);
                    break;
            }
        }
    </script>
    <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
    <div ng-app="webvantageApp">
        <div id="content" ng-controller="angularGanttController">
            <div style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
                <telerik:RadToolBar ID="RadToolbar_Gantt" runat="server" AutoPostBack="false"
                    OnClientButtonClicking="RadToolbar_Gantt_OnClientButtonClicking" Width="100%">
                    <Items>
                        <telerik:RadToolBarButton ID="RadToolbarButton_ToggleRelatedJobs" CommandName="togglerelatedjobs" Text="Show Related Jobs" Value="togglerelatedjobs" ToolTip="Show or hide jobs that are related to this one" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolbarButton_TogglePhases" CommandName="togglephases" Text="Show Phases" Value="togglephases" ToolTip="Show or hide project phases" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolbarButton_ToggleEmployees" CommandName="toggleEmployees" Text="Show Employees" Value="toggleEmployees" ToolTip="Show or hide assigned employees" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolbarButton_RecalculateDates" CommandName="recalculatedates" Text="Recalculate Dates" Value="recalculatedates" ToolTip="Recalculate job dates" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolbarButton_Refresh" SkinID="RadToolBarButtonRefresh" CommandName="refresh" Value="refresh" ToolTip="Refresh the current Gantt chart" />
                    </Items>
                </telerik:RadToolBar>
            </div>
            <div class="telerik-aqua-body">
                <script id="ganttTaskEditor" type="text/x-kendo-template">
	                    <div class="k-edit-label">
		                    <label for="title">Title</label>
	                    </div>
	                    <div class="k-edit-field">
		                    <input readonly type="text" class="k-input k-textbox" name="title" style="border-style: none;" />
	                    </div>
	                    <div class="k-edit-label">
		                    <label for="start">Start</label>
	                    </div>
	                    <div class="k-edit-field">
		                    <input data-role="datepicker" name="start" />
		                 </div> 
                        <div class="k-edit-label">
			                <label for="end">End</label>
		                </div>
                        <div class="k-edit-field">
			                <input data-role="datepicker" name="end" />
		                </div>
		                <div class="k-edit-label">
			                <label for="percentComplete">Complete</label>
		                </div>
		                <div class="k-edit-field">
			                <input readonly kendo-numeric-text-box name="percentComplete" k-options="defaultPercentOptions" />
		                </div>
                </script>
                <div kendo-window="taskDialog" k-options="windowOptions" k-on-open="taskDialogActive" k-on-close="!taskDialogActive" k-visible="false">
                    <div>
                        <label>Parent Task</label>
                        <select kendo-drop-down-list="availableParentDropdown"
                            k-data-text-field="'Title'"
                            k-data-value-field="'ID'"
                            k-data-source="availableParentTasks"
                            style="width: 100%">
                        </select>
                    </div>
                </div>
                <div style="padding-top: 50px;" ng-repeat="JobComponentPair in JobComponentPairs()" ng-show="JobComponentPair.IsRelatedJob == false || showRelatedJobs" ng-init="ganttInit(JobComponentPair)">
                    <div>
                        <div>
                            <h3>{{JobComponentPair.JobNumber}}-{{JobComponentPair.JobComponentNumber}} {{JobComponentPair.JobDescription}}</h3>
                        </div>
                        <div class="ganttContainer">
                            <div kendo-gantt="chartObject_{{JobComponentPair.JobNumber}}_{{JobComponentPair.JobComponentNumber}}" id="chartObject_{{JobComponentPair.JobNumber}}_{{JobComponentPair.JobComponentNumber}}" k-options="ganttOptions_{{JobComponentPair.JobNumber}}_{{JobComponentPair.JobComponentNumber}}" k-views="[{type: 'week', selected: true }, 'month']"></div>
                            <div>{{preventDrag(JobComponentPair)}}</div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <asp:HiddenField ID="HiddenFieldCalledFrom" runat="server" ClientIDMode="Static" />
</asp:Content>
