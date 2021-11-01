@ModelType AdvantageFramework.ViewModels.ProjectSchedule.ProjectScheduleFindAndReplaceViewModel
@Code

    ViewData("Title") = "Project Schedule - Search and Replace"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True
    ViewData("IsAngular") = True

End Code

@Section HeaderScripts
    
    <script src="~/app/js/app.js" type="text/javascript"></script>
    <script src="~/app/js/services.js" type="text/javascript"></script>

End Section

<style type="text/css">
    .fullWidth .k-textbox, .fullWidth .k-widget {
        width: 100%;
    }
</style>

@Helper PageContent()

    @<div ng-app="webvantageApp" ng-controller="projectScheduleFindAndReplaceController as vm" style="margin-top:10px;">
        <div id="errors" style="margin-top: 10px;" ng-show="errors.length >= 1" ng-cloak>
            <div ng-repeat="error in errors track by $index" class="alert alert-danger">
                {{ error }}
            </div>
        </div>
        <div class="form-horizontal">
            <div id="mainCriteria" class="form-group">
                <label class="control-label col-sm-2 col-lg-1">Criteria:</label>
                <div class="col-sm-9 col-lg-10 fullWidth">
                    <select kendo-drop-down-list
                            ng-model="model.SelectedCriteria"
                            k-options="criteriaOptions"
                            height="500"></select>
                </div>
            </div>
            <div class="form-group" ng-show="model.SelectedCriteria == 'TaskComment'">
                <label class="control-label col-sm-2 col-lg-1">Task Code:</label>
                <div class="col-sm-9 col-lg-10 fullWidth">
                    <input class="k-textbox"
                           ng-model="model.TaskCodeSearchFor"
                           maxlength="10"
                           data-lookup="Task"
                           ng-dblclick="lookup($event)"
                           name="TaskCodeSearchFor" />
                </div>
            </div>
            <div id="criteriaSelection" ng-show="model.SelectedCriteria" ng-cloak>
                <div class="form-group" ng-show="model.SelectedCriteria != 'TaskComment'">
                    <label class="control-label col-sm-2 col-lg-1">Search for:</label>
                    <div id="SearchCriteria" class="col-sm-9 col-lg-10">
                        <div ng-show="model.SelectedCriteria == 'StartDate' || model.SelectedCriteria == 'DueDate' || model.SelectedCriteria == 'CompletedDate' || model.SelectedCriteria == 'HeaderStartDate' || model.SelectedCriteria == 'HeaderDueDate' || model.SelectedCriteria == 'HeaderCompletedDate'">
                            <input kendo-date-picker
                                   ng-model="model.FromDateSearchFor" />
                            &nbsp;&nbsp;to&nbsp;&nbsp;
                            <input kendo-date-picker
                                   ng-model="model.ToDateSearchFor" />
                        </div>
                        <div ng-show="model.SelectedCriteria == 'TimeDue'" class="fullWidth">
                            <input class="k-textbox"
                                   ng-model="model.TimeDueSearchFor"
                                   maxlength="10" />
                        </div>
                        <div ng-show="model.SelectedCriteria == 'EmployeeAssignment'" class="fullWidth">
                            <input class="k-textbox"
                                   id="testID"
                                   ng-model="model.EmployeeCodeSearchFor"
                                   maxlength="6"
                                   data-lookup="Employee"
                                   ng-dblclick="lookup($event)"
                                   name="EmployeeCodeSearchFor" /><br />
                        </div>
                        <div ng-show="model.SelectedCriteria == 'ClientContactAssignment'" class="fullWidth">
                            <input class="k-textbox"
                                   ng-model="model.ClientContactCodeSearchFor"
                                   maxlength="6"
                                   data-lookup="ClientContact"
                                   ng-dblclick="lookup($event)"
                                   name="ClientContactCodeSearchFor" />
                        </div>
                        <div ng-show="model.SelectedCriteria == 'TaskStatus'">
                            <select kendo-drop-down-list
                                    ng-model="model.TaskStatusSearchFor"
                                    k-options="taskStatusSearchForOptions"></select>
                        </div>
                        <div ng-show="model.SelectedCriteria == 'Manager'" class="fullWidth">
                            <input class="k-textbox"
                                   ng-model="model.ManagerCodeSearchFor"
                                   maxlength="6"
                                   data-lookup="Manager"
                                   ng-dblclick="lookup($event)"
                                   name="ManagerCodeSearchFor" />
                        </div>
                    </div>
                </div>
                <div class="form-group" ng-show="model.SelectedCriteria != 'TaskComment'">
                    <label class="control-label col-sm-2 col-lg-1">Replace with:</label>
                    <div id="ReplaceWithCriteria" class="col-sm-9 col-lg-10">
                        <div ng-show="model.SelectedCriteria == 'StartDate' || model.SelectedCriteria == 'DueDate' || model.SelectedCriteria == 'CompletedDate' || model.SelectedCriteria == 'HeaderStartDate' || model.SelectedCriteria == 'HeaderDueDate' || model.SelectedCriteria == 'HeaderCompletedDate'">
                            <input kendo-date-picker
                                   ng-model="model.DateReplaceWith" />
                        </div>
                        <div ng-show="model.SelectedCriteria == 'TimeDue'" class="fullWidth">
                            <input class="k-textbox"
                                   ng-model="model.TimeDueReplaceWith"
                                   maxlength="10" />
                        </div>
                        <div ng-show="model.SelectedCriteria == 'EmployeeAssignment'" class="fullWidth">
                            <input class="k-textbox"
                                   ng-model="model.EmployeeCodeReplaceWith"
                                   maxlength="6"
                                   data-lookup="Employee"
                                   ng-dblclick="lookup($event)"
                                   name="EmployeeCodeReplaceWith" />
                        </div>
                        <div ng-show="model.SelectedCriteria == 'ClientContactAssignment'" class="fullWidth">
                            <input class="k-textbox"
                                   ng-model="model.ClientContactCodeReplaceWith"
                                   maxlength="6"
                                   data-lookup="ClientContact"
                                   ng-dblclick="lookup($event)"
                                   name="ClientContactCodeReplaceWith" />
                        </div>
                        <div ng-show="model.SelectedCriteria == 'TaskStatus'">
                            <select kendo-drop-down-list
                                    ng-model="model.TaskStatusReplaceWith"
                                    k-options="taskStatusReplaceWithOptions"></select>
                        </div>
                        <div ng-show="model.SelectedCriteria == 'Manager'" class="fullWidth">
                            <input class="k-textbox"
                                   ng-model="model.ManagerCodeReplaceWith"
                                   maxlength="6"
                                   data-lookup="Manager"
                                   ng-dblclick="lookup($event)"
                                   name="ManagerCodeReplaceWith" />
                        </div>
                     </div>
                </div>
                <div class="form-group" ng-show="model.SelectedCriteria == 'TaskComment'">
                    <label class="control-label col-sm-2 col-lg-1">Update With:</label>
                    <div ng-show="model.SelectedCriteria == 'TaskComment'" class="col-sm-9 col-lg-10 fullWidth">
                        <textarea name="TaskCommentTextArea" class="form-control" ng-model="model.TaskCommentReplaceWith"></textarea>
                    </div>
                </div>
                <div class="form-group" ng-show="model.SelectedCriteria == 'EmployeeAssignment'">
                    <label class="control-label col-sm-2 col-lg-1">Task Code:</label>
                    <div class="col-sm-9 col-lg-10 fullWidth">
                        <input class="k-textbox"
                               ng-model="model.TaskCodeSearchFor"
                               maxlength="10"
                               data-lookup="Task"
                               ng-dblclick="lookup($event)"
                               name="TaskCodeSearchFor" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-lg-offset-1 col-sm-10 col-lg-11">
                        <kendo-button ng-click="submit()" type="button">Replace All</kendo-button>
                    </div>
                </div>
            </div>
        </div>
        <div id="log" ng-show="model.Log.length >= 1" ng-cloak>
            <table class="table">
                <tr class="info" ng-repeat="log in model.Log track by $index">
                    <td>{{ log }}</td>
                </tr>
            </table>
        </div>
    </div>

End Helper

@Using (Ajax.BeginForm("FindAndReplace", Nothing, New AjaxOptions() With {.HttpMethod = "POST"}, New With {.id = "CriteriaForm"}))
    @Html.AntiForgeryToken()

    @PageContent()

End Using

<script>

    app.controller('projectScheduleFindAndReplaceController', function ($scope, $rootScope, $http, $modal, $timeout, dataService) {

        $scope.model = @Html.Raw(Json.Encode(Model));

        $scope.form = function () {
            return $('#CriteriaForm');
        };

        $scope.model = @Html.Raw(Json.Encode(Model));
        $scope.errors = [];

        $scope.lookup = function (e) {
            var element = $(e.target);
            var type = element.data('lookup');
            var property = element.attr('ng-model').split(".")[1];
            var baseUrl = 'ProjectManagement/ProjectSchedule/';
            var url;
            var isReplaceWith = element[0].name.indexOf('ReplaceWith') > -1 ? true : false;
            if (type === 'Task') {
                url = 'LookupTasks';
            } else if (type === 'Employee' || type === 'Manager') {
                url = 'LookupEmployees?ShowAll=' + (isReplaceWith ? 'False' : 'True');
            } else if (type === 'ClientContact') {
                url = 'LookupClientContacts?ClientCode=' + $scope.model.ClientCode + '&ShowAll=' + (isReplaceWith ? 'False' : 'True');;
            }
            var onClose = function (selectedItem) {
                if (selectedItem) {
                    $scope.model[property] = selectedItem['Code'];
                    $scope.$apply();
                }
            };
            if (url) {
                openRadWindowLookupWithEvents(baseUrl + url, onClose);
            }
        };

        $scope.submit = function () {

            console.log($scope.form().attr('action'));

            $scope.errors = [];
            kendo.ui.progress($scope.form(), true);
            $.ajax({
                type: 'POST',
                url: $scope.form().attr('action'),
                data: $scope.model,
                error: function (response) {
                    $scope.errors.push('Something went wrong.');
                    $scope.$apply();
                },
                success: function (response) {
                    if (response.success === true) {
                        if (response.data.Log) {
                            $scope.model.Log = response.data.Log;
                        }
                    } else {
                        for (var prop in response.data) {
                            if (response.data[prop].errors) {
                                for (var i = 0; i < response.data[prop].errors.length; i++) {
                                    $scope.errors.push(response.data[prop].errors[i]);
                                }
                            }
                        }
                    }
                    $scope.$apply();
                }
            }).always(function () {
                kendo.ui.progress($scope.form(), false);
            });
        };

        $scope.resetCriteria = function () {
            $scope.errors = [];
            $scope.model.FromDateSearchFor = null;
            $scope.model.ToDateSearchFor = null;
            $scope.model.DateReplaceWith = null;
            $scope.model.EmployeeCodeSearchFor = null;
            $scope.model.EmployeeCodeReplaceWith = null;
            $scope.model.TimeDueSearchFor = null;
            $scope.model.TimeDueReplaceWith = null;
            $scope.model.TaskCodeSearchFor = null;
            $scope.model.ManagerCodeSearchFor = null;
            $scope.model.ManagerCodeReplaceWith = null;
            $scope.model.ClientContactCodeSearchFor = null;
            $scope.model.ClientContactIDSearchFor = null;
            $scope.model.ClientContactCodeReplaceWith = null;
            $scope.model.ClientContactIDReplaceWith = null;
            $scope.model.TaskStatusSearchFor = 'P';
            $scope.model.TaskStatusReplaceWith = 'P';
            $scope.model.TaskCommentReplaceWith = null;
        };

        $scope.init = function () {

            var criteriaList = [];
            var taskStatusList = [];

            for (var prop in $scope.model.Criterias) {
                criteriaList.push({ Value: prop, Text: $scope.model.Criterias[prop] });
            }
            for (var prop in $scope.model.TaskStatuses) {
                taskStatusList.push({ Value: prop, Text: $scope.model.TaskStatuses[prop] });
            }

            if (!$scope.model.TaskStatusSearchFor) {
                $scope.model.TaskStatusSearchFor = 'P';
            }
            if (!$scope.model.TaskStatusReplaceWith) {
                $scope.model.TaskStatusReplaceWith = 'P';
            }

            $scope.criteriaOptions = {
                dataTextField: 'Text',
                dataValueField: 'Value',
                optionLabel: '[Please Select]',
                dataSource: new kendo.data.DataSource({
                    data: criteriaList
                }),
                change: function (e) {
                    $scope.resetCriteria();
                    $scope.$apply();
                }
            };

            $scope.taskStatusReplaceWithOptions = {
                dataTextField: 'Text',
                dataValueField: 'Value',
                dataSource: new kendo.data.DataSource({
                    data: taskStatusList
                })
            };

            $scope.taskStatusSearchForOptions = {
                dataTextField: 'Text',
                dataValueField: 'Value',
                dataSource: new kendo.data.DataSource({
                    data: taskStatusList
                })
            };

        };

        $scope.init();

        });

    function openRadWindowLookupWithEvents(url, onCloseCallback) {
        OpenRadWindowLookup(url, onCloseCallback);
        setTimeout(function () {
            var win = GetRadWindow().BrowserWindow.FindWindow(url);
            if (win) {
                win.add_close(function (sender, args) {
                    var selectedItem = sender.get_contentFrame().contentWindow.selectedItem;
                    if (onCloseCallback) {
                        onCloseCallback(selectedItem);
                    }
                });
            }
        }, 500);
    }

    function OpenRadWindowLookup(url, onCloseCallback) {
        url = '@Url.Content("~")' + url;
        let Dialog = $("#LookUpDlgDiv");

        if (typeof Dialog !== 'undefined' && Dialog.length) {
            $("#LookUpDlgDiv").remove();
            Dialog = $('<div id="LookUpDlgDiv"></div>');
        }
        else {
            Dialog = $('<div id="LookUpDlgDiv"></div>');
        }

        var Title = '';

        Dialog.ejDialog({
            autoOpen: false,
            modal: true,
            height: 700,
            width: 625,
            title: "Lookup" + Title,
            enableResize: false,
            contentUrl: url,
            contentType: "iframe"
        });

        var iFrame = Dialog[0].ownerDocument.getElementsByClassName('e-iframe')[0];

        iFrame.contentWindow.Close = function (selectedItem) {

            if (onCloseCallback) {
                onCloseCallback(selectedItem);
            }

            Dialog.ejDialog('close');
        }
    }

</script>

@Section PageScripts

    <script src="~/JScripts/validator.js" type="text/javascript"></script>

End Section

