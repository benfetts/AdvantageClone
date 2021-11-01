@ModelType AdvantageFramework.ViewModels.JobTemplate.UpdateJobViewModel
@Code

    ViewData("Title") = "Job Template - Update Job"
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

    @<div ng-app="webvantageApp" ng-controller="updateJobsController as vm" style="margin-top:10px;">
        <div id="errors" style="margin-top: 10px;" ng-show="errors.length >= 1" ng-cloak>
            <div ng-repeat="error in errors track by $index" class="alert alert-danger">
                {{ error }}
            </div>
        </div>
        <div class="form-horizontal">            
            <div id="criteriaSelection" ng-cloak>                
                <div class="form-group">
                    <label class="control-label col-sm-2 col-lg-1">Account Executive:</label>
                    <div id="SearchCriteria" class="col-sm-9 col-lg-10">                        
                        <div class="fullWidth">
                            <input class="k-textbox"
                                   ng-model="model.EmployeeCodeAE"
                                   maxlength="10"
                                   data-lookup="Employee"
                                   ng-dblclick="lookup($event)"
                                   name="EmployeeCodeAE" />
                        </div>
                        <div class="fullWidth">
                            <input id="cbAG"
                                   class="k-checkbox"
                                   ng-model="model.IsDefaultAE"                                   
                                   maxlength="10" />
                            <input class="k-checkbox-label" for="cbAG" value="Default Account Executive" />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-sm-2 col-lg-1">Alert Group:</label>
                    <div id="ReplaceWithCriteria" class="col-sm-9 col-lg-10">
                        <div class="fullWidth">
                            <input class="k-textbox"
                                   ng-model="model.AlertGroupJob"
                                   maxlength="10"
                                   data-lookup="AlertGroup"
                                   ng-dblclick="lookup($event)"
                                   name="AlertGroupJob" />
                        </div>
                     </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-lg-offset-1 col-sm-10 col-lg-11">
                        <kendo-button ng-click="submit()" type="button">Update</kendo-button>
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

@Using (Ajax.BeginForm("UpdateJob", Nothing, New AjaxOptions() With {.HttpMethod = "POST"}, New With {.id = "CriteriaForm"}))
    @Html.AntiForgeryToken()

    @PageContent()

End Using

<script>

    app.controller('updateJobsController', function ($scope, $rootScope, $http, $modal, $timeout, dataService) {

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
            var baseUrl = 'JobJacket/';
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
                    if (response.Success === true) {
                        $scope.model = response.Data;
                    } else {
                        for (var prop in response.Data) {
                            if (response.Data[prop].errors) {
                                for (var i = 0; i < response.Data[prop].errors.length; i++) {
                                    $scope.errors.push(response.Data[prop].errors[i]);
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
            $scope.model.EmployeeCodeAE = null;
            $scope.model.AlertGroupJob = null;
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

        };

        $scope.init();

        });

    function openRadWindowLookupWithEvents(url, onCloseCallback) {
        OpenRadWindowLookup(url);
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

</script>

@Section PageScripts

    <script src="~/JScripts/validator.js" type="text/javascript"></script>

End Section

