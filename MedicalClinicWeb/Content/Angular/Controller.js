app.controller("myCntrl", function ($scope, $http, myService) {

    $scope.divPatient = false;

    GetAllPatient();
    //To Get All Records 
    
    function GetAllPatient() {
        
        //var getData = myService.getPatients();
        
        //getData.then(function (response) {
        //    $scope.patients = response.data;            
        //}, function () {
        //    alert('Error in getting records');
        //});

        /*
        $http.get('http://localhost:50186/api/Patients/GetPatients').success(function (data) {
            debugger;
            scope.patients = data;

        }).error(function (data) {
                debugger;
                alert('Error in getting records');
        });*/

        $http.get('http://localhost:50186/api/Patients/GetPatients').then(
            function successCallback(response) {
            // this callback will be called asynchronously
            // when the response is available                               
                $scope.patients = response.data;
        }, function errorCallback(response) {
            // called asynchronously if an error occurs
            // or server returns response with an error status.
            alert(response);
        });

    }

    $scope.editPatient = function (Patient) {

        var getData = myService.getPatient(Patient.PatientID);

        getData.then(function (patient) {
            
            $scope.Patient = patient.data;
            $scope.PatientID = Patient.PatientID;
            $scope.PatientName = Patient.Name;
            $scope.PatientAge = Patient.Age;
            $scope.PatientGender = Patient.Gender;
            $scope.Action = "Update";
            $scope.divPatient = true;
        },
            function () {
                alert('Error in getting patient');
            });
    }

    $scope.AddUpdatePatient = function () {
        
        var Patient = {
            PatientID: $scope.PatientID,
            Name: $scope.PatientName,
            Gender: 1,
            Age: $scope.PatientAge
        };
        var getAction = $scope.Action;

        if (getAction == "Update") {
            Patient.PatientID = $scope.PatientID;
            var getData = myService.updatePatient(Patient);

            
            getData.then(function (msg) {
                debugger;
                GetAllPatient();
                debugger;
                alert(msg.data);
                $scope.divPatient = false;
            }, function () {
                alert('Error in updating patient');
            });
        } else {
            var getData = myService.AddPatient(Patient);
            getData.then(function (msg) {
                GetAllPatient();
                alert(msg.data);
                $scope.divPatient = false;
            }, function () {
                alert('Error in adding record');
            });
        }
    }

    $scope.AddPatientDiv = function () {
        ClearFields();
        $scope.Action = "Add";
        $scope.divPatient = true;
    }

    $scope.deletePatient = function (Patient) {
        var getData = myService.DeleteEmp(Patient.Id);
        getData.then(function (msg) {
            GetAllPatient();
            alert('Patient Deleted');
        }, function () {
            alert('Error in Deleting Record');
        });
    }

    function ClearFields() {
        $scope.PatientId = "";
        $scope.PatientName = "";
        $scope.PatientEmail = "";
        $scope.PatientAge = "";
    }
});