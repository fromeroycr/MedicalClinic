

app.controller("appointmentController", function ($routeParams, $scope, patientsService) {

    var vm = this;

    vm.patientId = $routeParams.patientId;

    var patient = patientsService.getPatient(Patient.PatientID);

    vm.patientName = patient.patientName;

})