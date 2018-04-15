app.service("patientsService", function ($http) {

    var PatientsAPIUrl = 'http://localhost:50186/api/Patients';    
    
    this.getPatients = function () {

        var response = $http.get('http://localhost:50186/api/Patients/GetPatients');
        console.log(response);

        return response;
    };
    
    this.getPatient = function (PatientID) {

        var urlString = 'http://localhost:50186/api/Patients/GetPatient' + "/" + PatientID;
        return $http.get(urlString);

    }
    
    this.updatePatient = function (Patient) {

        var response = $http({
            method: "put",
            url: 'http://localhost:50186/api/patients/PutPatient/',
            data: JSON.stringify(Patient)
        });

        return response;
    }
    
    this.AddPatient = function (Patient) {
        var response = $http({
            method: "post",
            url: PatientsAPIUrl + "/PostPatient",
            data: JSON.stringify(Patient),
            dataType: "json"
        });
        return response;
    }

    this.DeletePatient = function (Patient) {

        var response = $http({
            method: "delete",
            url: PatientsAPIUrl + "/DeletePatient" + "/" + Patient.PatientID,
            data: JSON.stringify(Patient),
            dataType: "json"
        });
        return response;
    }

})