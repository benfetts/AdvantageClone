
app.service('dataService', function ($http, $q) {

    var applicationLocation = function () {
        var loc = document.location.toString();
        var appNameIndex = loc.indexOf('/', loc.indexOf('://') + 3);
        var appName = loc.substring(0, appNameIndex) + '/';
        var webFolderIndex = loc.indexOf('/', loc.indexOf(appName) + appName.length);
        var webFolderPath = loc.substring(0, webFolderIndex);

        return webFolderPath;

    };

    this.searchEmployeeDefaultFunction = function (employeeCode) {
        var deferred = $q.defer();

        try {
            $http({
                url: applicationLocation() + '/Employee/Timesheet/EmployeeDefaultFunction',
                method: "POST",
                data: { EmployeeCode: employeeCode }
            })
            .then(function (response) {
                // success
                deferred.resolve(response);
            });
        } catch (e) {
            deferred.reject(e);
        }

        return deferred.promise;
    };

    this.searchContracts = function (searchCriteria) {
        var deferred = $q.defer();

        if (searchCriteria.SearchText === null || searchCriteria.SearchText === undefined) {
            searchCriteria.SearchText = '';
        }

        if (searchCriteria.OfficeCode === null || searchCriteria.OfficeCode === undefined) {
            searchCriteria.OfficeCode = '';
        }

        if (searchCriteria.ClientCode === null || searchCriteria.ClientCode === undefined) {
            searchCriteria.ClientCode = '';
        }

        if (searchCriteria.DivisionCode === null || searchCriteria.DivisionCode === undefined) {
            searchCriteria.DivisionCode = '';
        }

        if (searchCriteria.ProductCode === null || searchCriteria.ProductCode === undefined) {
            searchCriteria.ProductCode = '';
        }

        if (searchCriteria.ContractCode === null || searchCriteria.ContractCode === undefined) {
            searchCriteria.ContractCode = '';
        }

        try {
            $http({
                //  url: window.location.origin + '/Webvantage/contracts/searchcontracts',
                url: applicationLocation() + '/requesthandlers/searchContracts.ashx',
                method: "POST",
                //  data: { searchCriteriaText: JSON.stringify(searchCriteria) }
                data: JSON.stringify(searchCriteria)
            })
            .then(function (response) {
                // success
                deferred.resolve(response);
            });
        } catch (e) {
            deferred.reject(e);
        }

        return deferred.promise;
    };


    this.searchTimeSheetFunctionCategories = function (searchCriteria) {
        var deferred = $q.defer();

        if (searchCriteria.EmployeeCode === null || searchCriteria.EmployeeCode === undefined) {
            searchCriteria.EmployeeCode = '';
        }

        if (searchCriteria.EmployeeCode === null || searchCriteria.EmployeeCode === undefined) {
            searchCriteria.JobCode = '';
        }

        try {
            $http({
                url: applicationLocation() + '/Employee/Timesheet/FunctionCategories',
                method: "POST",
                data: { SearchCriteriaText: JSON.stringify(searchCriteria) }
            })
            .then(function (response) {
                // success
                deferred.resolve(response);
            });
        } catch (e) {
            deferred.reject(e);
        }
        return deferred.promise;
    };

    this.searchLookup = function (searchCriteria) {
        var deferred = $q.defer();

        if (searchCriteria.SearchText === null || searchCriteria.SearchText === undefined) {
            searchCriteria.SearchText = '';
        }

        try {
            $http({
                url: applicationLocation() + '/Utilities/Lookup/Search',
                method: "POST",
                data: { SearchCriteriaText: JSON.stringify(searchCriteria) }
            }).then(function (response) {
                deferred.resolve(response);
            });
        } catch (e) {
            deferred.reject(e);
        }

        return deferred.promise;
    };

    this.validateStandardLookUps = function (lookUpValues) {
        var deferred = $q.defer();
        try {
            $http({
                url: applicationLocation() + '/Utilities/Lookup/Validate',
                method: "POST",
                data: { LookUps: JSON.stringify(lookUpValues) }
            }).then(function (response) {
                deferred.resolve(response);
            });
        } catch (e) {
            deferred.reject(e);
        }
        return deferred.promise;
    };

    this.jobOrComponentClosed = function (searchCriteria) {
        var deferred = $q.defer();

        try {
            $http({
                url: applicationLocation() + '/Utilities/Lookup/JobOrComponentClosed',
                method: "POST",
                data: { SearchCriteriaText: JSON.stringify(searchCriteria) }
            }).then(function (response) {
                deferred.resolve(response);
            });
        } catch (e) {
            deferred.reject(e);
        }

        return deferred.promise;
    };

    this.validateTimesheetEntry = function (validationRequest) {
        var deferred = $q.defer();

        try {
            $http({
                url: applicationLocation() + '/Employee/Timesheet/ValidateEntry',
                method: "POST",
                data: { ValidationRequestText: JSON.stringify(validationRequest) }
            }).then(function (response) {
                deferred.resolve(response);
            });
        } catch (e) {
            deferred.reject(e);
        }

        return deferred.promise;
    };
    
    this.ValidateAccountSetupEntry = function (validationRequest) {
        var deferred = $q.defer();

        try {
            $http({
                url: applicationLocation() + '/Employee/Timesheet/ValidateEntryAccount',
                method: "POST",
                data: { ValidationRequestText: JSON.stringify(validationRequest) }
            }).then(function (response) {
                deferred.resolve(response);
            });
        } catch (e) {
            deferred.reject(e);
        }

        return deferred.promise;
    };

    this.timesheetSettings = function (searchCriteria) {
        var deferred = $q.defer();

        try {
            $http({
                url: applicationLocation() + '/Employee/Timesheet/Settings',
                method: "POST",
                data: { SearchCriteriaText: JSON.stringify(searchCriteria) }
            }).then(function (response) {
                deferred.resolve(response);
            });
        } catch (e) {
            deferred.reject(e);
        }

        return deferred.promise;
    };

    this.lookupFunctionBillingRate = function (searchCriteria) {
        var deferred = $q.defer();

        try {
            $http({
                url: applicationLocation() + '/requesthandlers/SearchLookup.ashx',
                method: "POST",
                data: JSON.stringify(searchCriteria)
            }).then(function (response) {
                deferred.resolve(response);
            });
        } catch (e) {
            deferred.reject(e);
        }

        return deferred.promise;
    };

    this.getJobDescriptions = function (jobComponents) {
        var deferred = $q.defer();

        try {
            $http({
                url: applicationLocation() + '/ProjectManagement/ProjectSchedule/GetJobDescriptions',
                method: "POST",
                data: { JobComponents: JSON.stringify(jobComponents) }
            }).then(function (response) {
                deferred.resolve(response);
            });
        } catch (e) {
            deferred.reject(e);
        }

        return deferred.promise;
    };

    this.getRelatedJobs = function (jobInfo) {
        var deferred = $q.defer();

        try {
            $http({
                url: applicationLocation() + '/ProjectManagement/ProjectSchedule/GetRelatedJobs',
                method: "POST",
                data: { JobInfo: JSON.stringify(jobInfo) }
            }).then(function (response) {
                deferred.resolve(response);
            });
        } catch (e) {
            deferred.reject(e);
        }

        return deferred.promise;
    };

    this.ganttTasksListPost = function (jobNumber, jobComponentNumber) {
        var deferred = $q.defer();

        try {
            $http({
                url: applicationLocation() + '/ProjectManagement/ProjectSchedule/GanttTasksListPost',
                method: "POST",
                data: { JobNumber: jobNumber, JobComponentNumber: jobComponentNumber }
            }).then(function (response) {
                deferred.resolve(response);
            });
        } catch (e) {
            deferred.reject(e);
        }

        return deferred.promise;
    };

    this.recalculateScheduleDates = function (recalculationRequest) {
        var deferred = $q.defer();

        try {
            $http({
                url: applicationLocation() + '/ProjectManagement/ProjectSchedule/RecalculateScheduleDates',
                method: "POST",
                data: { RecalculationRequest: JSON.stringify(recalculationRequest) }
            })
            .then(function (response) {
                // success
                deferred.resolve(response);
            });
        } catch (e) {
            deferred.reject(e);
        }

        return deferred.promise;
    };

    this.getTimesheetTotals = function (totalRequest) {
        var deferred = $q.defer();

        try {
            $http({
                url: window.location.origin + '/Webvantage/Timesheet/SheetTotals',
                method: "POST",
                data: { SearchCriteriaText: JSON.stringify(totalRequest) }
            })
            .then(function (response) {
                // success
                deferred.resolve(response);
            });
        } catch (e) {
            deferred.reject(e);
        }

        return deferred.promise;
    };

});

