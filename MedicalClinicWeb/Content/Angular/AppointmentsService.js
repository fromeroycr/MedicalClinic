app.service("appointmentsService", function ($http) {

    var appointmentsServiceUrl = 'http://localhost:50186/api/Appointments/CreateAppointment';

    this.createAppointment = function (appointment) {

        var result = null;        

        var response = $http({
            method: "post",
            url: appointmentsServiceUrl,
            data: JSON.stringify(appointment),
            dataType: "json"
        });

        return result;
    }

});