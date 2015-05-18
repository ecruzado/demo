var angularApp = angular.module('angularApp', ['ngRoute',"common.services"]);

angularApp.config(function ($routeProvider) {
    $routeProvider
        .when("/home", {
            templateUrl: "app/Home.html",
            controller: "HomeController"
        })
        .when("/newEmployeeForm", {
            templateUrl: "app/EmployeeForm/efTemplate.html",
            controller: "efController"
        })
        .otherwise({
            redirectTo: "/home"
        });
});