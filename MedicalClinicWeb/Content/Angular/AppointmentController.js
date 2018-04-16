

app.controller("appointmentController", function ($routeParams, $scope, patientsService) {

    var vm = this;

    vm.idPatient = $routeParams.idPatient;

    
    var getData = patientsService.getPatient(vm.idPatient);
    

    getData.then(function (patient) {
        
        vm.patientName = patient.data.Name;
    },
    function () {
       alert('Error in getting patient');
    });   

})