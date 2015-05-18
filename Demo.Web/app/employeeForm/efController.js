angularApp.controller('efController', function ($scope, efService) {
    $scope.employee = efService.employee;
    $scope.departments = ["Administration", "Engineering", "Marketing", "Finance"];

    $scope.submitForm = function () {
        console.log("sumbit");
    };
});