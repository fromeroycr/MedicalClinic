var app = angular.module("myApp", ["ngRoute"]);


app.config(function ($routeProvider) {
    $routeProvider
        .when("/patients", {
            templateUrl: "../patients/index",
            controller: 'patientsController'
        })
        .when("/appointments/:idPatient", {            
            templateUrl: "../appointments/appointment",
            controller: 'appointmentController',
            controllerAs: "vm"
        })
        .when("/appointments", {
            controller: 'appointmentController',
            controllerAs: "vm",
            templateUrl: "../appointments/appointment"

        })
        .when("/", {
            templateUrl: "../patients/index",
            controller: 'patientsController'
        });
});

