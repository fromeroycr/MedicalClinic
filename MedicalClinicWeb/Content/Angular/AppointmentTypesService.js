
app.service("appointmentTypesService", function ($http) {

    var apointmentTypesAPIUrl = 'http://localhost:50186/api/AppointmentTypes/GetAppointmentTypes';

    this.getAppointmentTypes = function () {

        var result = null;

        $.ajax({

            url: apointmentTypesAPIUrl,
            type: 'get',
            datatype: 'json',
            cache: false,
            success: function (data) {                
                result = data;
            },
            error: function() {            
                alert('Error getting appointment types')
            },            
            async: false
        });        

        return result;
    }

});