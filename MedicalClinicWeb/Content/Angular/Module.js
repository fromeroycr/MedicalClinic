var app = angular.module("myApp", ["ngRoute"]);


app.config(function ($routeProvider) {
    $routeProvider
        .when("/patients", {
            templateUrl: "/Content/views/patients.html",
            controller: 'patientsController'
        })
        .when("/appointments/:idPatient", {            
            templateUrl: "../Content/views/appointment.html",
            controller: 'appointmentController',
            controllerAs: "vm"
        })        
        .when("/", {
            templateUrl: "/Content/views/patients.html",
            controller: 'patientsController'
        });
});

