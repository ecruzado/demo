angularApp.controller("HomeController", function ($scope, $location, employeeResource) {
    $scope.addNewEmployee = function () {
        $location.path('/newEmployeeForm');
    };

    $scope.loadEmployees = function () {
        //var url = "http://localhost:49182/api/Employees";
        //$http.get(url).then(function (result) {
        //    console.log(result);
        //});
        employeeResource.query(function (data) {
            console.log(data);
        });
    };
});