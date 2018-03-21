app.service("myService", function ($http) {

    var PatientsAPIUrl = 'http://localhost:50186/api/Patients';

    //get All Patients
    
    this.getPatients = function () {        
        return $http.get(PatientsAPIUrl);
    };
    

    // get Patient By Id
    this.getPatient = function (PatientID) {

        var urlString = PatientsAPIUrl + "/" + PatientID;
        return $http.get(urlString);
        
    }

    // Update Patient
    this.updatePatient = function (Patient) {

        var serviceUrl = PatientsAPIUrl + "/PutPatient/" + Patient.PatientID;

        var response = $http({
            method: "post",
            url: serviceUrl,
            data: JSON.stringify(Patient),
            dataType: "json"
        });
        return response;
    }

    // Add Patient
    this.AddPatient = function (Patient) {
        var response = $http({
            method: "post",
            url: PatientsAPIUrl + "/PostPatient",
            data: JSON.stringify(Patient),
            dataType: "json"
        });
        return response;
    }
    
})