

app.controller("appointmentController", function ($routeParams, $scope, patientsService, appointmentTypesService) {

    var vm = this;

    vm.idPatient = $routeParams.idPatient;

    
    var getData = patientsService.getPatient(vm.idPatient);
    

    getData.then(function (patient) {
        
        vm.patientName = patient.data.Name;

        vm.appointmentTypes = appointmentTypesService.getAppointmentTypes();
        vm.appointmentType = vm.appointmentTypes[0];          
    },
    function () {
       alert('Error in getting patient');
    });   

})