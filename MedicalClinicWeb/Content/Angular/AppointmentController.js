

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

    function convertToDateTimeLocal(dateAppointment) {

        var date = new Date(dateAppointment);

        ten = function (i) {
            return (i < 10 ? '0' : '') + i;
        },
        YYYY = date.getFullYear(),
        MM = ten(date.getMonth() + 1),
        DD = ten(date.getDate()),
        HH = ten(date.getHours()),
        II = ten(date.getMinutes()),
        SS = ten(date.getSeconds());

        return YYYY + '-' + MM + '-' + DD + 'T' +
                 HH + ':' + II + ':' + SS;
    }

    $scope.submitForm = function () {

        var newAppointment = {};

        newAppointment.PatientID  = vm.idPatient;        
        newAppointment.Date = convertToDateTimeLocal($scope.appointmentDate);        
        newAppointment.AppointmentTypeID = vm.appointmentType.AppointmentTypeID;

        appointmentsService.createAppointment(newAppointment);
    }

})