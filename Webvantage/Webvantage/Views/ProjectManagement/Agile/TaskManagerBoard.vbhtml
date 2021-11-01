@ModelType AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard
@Code

    ViewData("Title") = "Task Manager"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True
    ViewData("IsAngular") = True

End Code

@Section HeaderScripts

    <script src="~/app/js/app.js" type="text/javascript"></script>
    <script src="~/app/js/services.js" type="text/javascript"></script>

End Section
@Section PageScripts
    

    <script src="~/JScripts/validator.js" type="text/javascript"></script>
    <script type="text/javascript" src="~/JScripts/agile.mvc.js"></script>

End Section
<style type="text/css">
    #kb-filters ul {
        list-style: none;
        padding: 0;
        margin: 0;
    }
    #kb-filters ul li {
        margin-bottom: 5px;
    }
    .list-group-item {
        padding-top: 5px;
        padding-bottom: 5px;
    }
    .list-group-item.show-more {
        background: #ececec;
        padding: 2px;
        text-align: center;
    }
    .filter-link {
        font-weight: bold;
        font-size: 14px;
        border-bottom: 1px solid #ececec;
        padding-bottom: 5px;
        padding-top: 5px;
    }
    .filter-wrapper.open .filter-link {
        border-bottom: none;
    }
    
    .filter-link a {
        text-decoration: none;
    }
    .filter-link a .glyphicon {
        float: right;
    }
</style>

<div ng-app="webvantageApp" ng-controller="taskManagerController as vm" style="margin-top: 10px;">

    <div style="float: left; margin-right: 15px; min-height: 500px; min-width: 175px" id="kb-filters">
        <div ng-repeat="filter in model.Filters" class="filter-wrapper" ng-class="{'open': filter.open}">
            <div class="filter-link">
                <a href="javascript:void(0)" ng-click="expandFilter(filter, false)" >{{filter.Watermark}}<span class="glyphicon" ng-class="{'glyphicon-minus': filter.open, 'glyphicon-plus': !filter.open}"></span></a>
            </div>
            <div class="list-group" ng-show="filter.open" ng-class="{'showing-all': filter.showAll}">
                <a ng-repeat="filterItem in filter.Items" href="javascript:void(0)" class="list-group-item" ng-show="$index < 5 || filter.showAll" ng-click="toggleFilter(filterItem)" ng-class="{'active': filterItem.checked }">{{filterItem.Description}}</a>
                <a href="javascript:void(0)" class="list-group-item show-more" ng-show="filter.Items.length > 5" ng-click="expandFilter(filter, true)">{{ filter.showAll ? 'Show Less' : 'Show More' }}</a>
            </div>
        </div>
    </div>
        
    <div>
        <div ng-show="currentFilters.length > 0" style="margin: 0px 0px 10px 0px">
            <strong>Filters:</strong>
            <button ng-repeat="filter in currentFilters" ng-click="toggleFilter(filter)" type="button" style="margin-left:5px;" class="btn btn-primary">{{filter.Description}}<span style="margin-left: 10px;" class="glyphicon glyphicon-remove"></span></button>
        </div>
        <div id="ControlRegion">
            @Html.Partial("_Board", Model)
        </div>
    </div>
    <div style="clear: both;"></div>
</div>

<script>

    app.controller('taskManagerController', function ($scope, $rootScope, $http, $modal, $timeout, dataService) {

        $scope.model = @Html.Raw(Json.Encode(Model));
        $scope.currentFilters = [];

        $scope.toggleFilter = function(filterItem){
            var filterIndex = $scope.currentFilters.indexOf(filterItem);
            filterItem.checked = !filterItem.checked;
            if(filterIndex > -1){
                $scope.currentFilters.splice(filterIndex, 1);
            } else {
                $scope.currentFilters.push(filterItem);
            }
            $scope.resetFilter();
        }

        $scope.expandFilter = function(filter, isShowAll) {
            if(isShowAll){
                filter.showAll = !filter.showAll;
            } else {
                filter.open = !filter.open;
            }
            if(!filter.open) {
                filter.showAll = false;
            }
        }

        $scope.resetFilter = function() {
            var kb = $('#Kanban').data('ejKanban');
            kb.KanbanFilter.clearFilter();
            for(var i = 0; i < $scope.model.Filters.length; i++){
                var val;
                var filt = $scope.model.Filters[i];
                var prop = filt.Field;
                var pred = null;
                for(var f = 0; f < filt.Items.length; f++){
                    if(filt.Items[f].checked){
                        val = filt.Items[f].Code;
                        if(!pred){
                            pred = ej.Predicate(prop, ej.FilterOperators.equal, val);
                        } else {
                            pred = pred.or(prop, ej.FilterOperators.equal, val);
                        }
                    }
                }
                if(pred){
                    kb.KanbanFilter.filterCards(new ej.Query().where(pred));

                }
            }
        }

       //console.log($scope.model);

    });


</script>