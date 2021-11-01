app.controller('jobJacketModalController', function ($scope, $modalInstance, labelText, textAreaValue) {
    $scope.labelText = angular.copy(labelText);
    $scope.textAreaValue = angular.copy(textAreaValue);

    $scope.confirmSelection = function () {
        $modalInstance.close($scope.textAreaValue);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
});