app.service("appointmentsService", function ($http) {

    var appointmentsServiceUrl = 'http://localhost:50186/api/Appointments/CreateAppointment';

    this.createAppointment = function (appointment) {

        var result = null;

        //$.ajax(
        //    {
        //        url: appointmentsServiceUrl,
        //        type: 'post',
        //        datatype: 'json',
        //        data: JSON.stringify(appointment),
        //        cache: false,
        //        success: function (data) {

        //            result = data;

        //        },
        //        error: function () {
        //            alert('Error setting appointment');
        //        }
        //    }
        //);

        var response = $http({
            method: "post",
            url: appointmentsServiceUrl,
            data: JSON.stringify(appointment),
            dataType: "json"
        });

        return result;
    }

});