

app.controller("appointmentController", function ($routeParams, $scope, patientsService, appointmentTypesService, appointmentsService) {

    var vm = this;

    LoadPatientData();

    function LoadPatientData() {

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
    }

    $scope.submitForm = function () {

        var appointmentDate = $scope.appointmentDate;

        var newAppointment = {};
        newAppointment.PatientID  = vm.idPatient;
        newAppointment.Date  = $scope.appointmentDate;
        newAppointment.AppointmentTypeID  = vm.appointmentType.AppointmentTypeID;

        appointmentsService.createAppointment(newAppointment);

    }

})