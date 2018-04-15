var app = angular.module("myApp", ["ngRoute"]);


app.config(function ($routeProvider) {
    $routeProvider
        .when("/patients", {
            templateUrl: "../patients/index",
            controller: 'patientsController'
        })
        .when("/appointments", {
            templateUrl: "../appointments/appointment",
            controller: 'appointmentController'
        })
        .when("/", {
            templateUrl: "../patients/index",
            controller: 'patientsController'
        });
});

