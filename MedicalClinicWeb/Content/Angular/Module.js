var app = angular.module("myApp", ["ngRoute"]);


app.config(function ($routeProvider) {
    $routeProvider
        .when("/patients", {
            templateUrl: "../patients/index",
            controller: 'myCntrl'
        })
        .when("/appointments", {
            templateUrl: "../appointments/appointment",
            controller: 'appointmentController'
        })
        .when("/", {
            templateUrl: "../patients/index",
            controller: 'myCntrl'
        });
});



app.controller("appointmentController", function ($scope) {
    $scope.FirstName = "Test";
    $scope.LastName = "Test";
})