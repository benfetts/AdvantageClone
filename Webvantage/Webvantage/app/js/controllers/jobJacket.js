app.controller('jobJacketController', function ($scope, $http, $modal, $timeout) {
    $scope.labelText = '';
    $scope.textArea = null

    $scope.open = function (labelText, textArea) {
        $scope.labelText = labelText;
        $scope.textArea = textArea;
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: 'app/templates/jobJacketModal.html',
            controller: 'jobJacketModalController',
            size: 'lg',
            resolve: {
                labelText: function () {
                    return $scope.labelText;
                },
                textAreaValue: function () {
                    return $($scope.textArea).val();
                }
            }
        });

        modalInstance.result.then(function (textAreaValue) {
            $($scope.textArea).val(textAreaValue);
           
        }, function () {
            //  $log.info('Modal dismissed at: ' + new Date());
        });
    };

    $scope.sampleAlert = function () {
        alert('alert');
    };

    $scope.toggleAnimation = function () {
        $scope.animationsEnabled = !$scope.animationsEnabled;
    };
});