app.controller("myCntrl", function ($scope, myService) {

    $scope.divPatient = false;

    GetAllPatient();
    //To Get All Records 
    
    function GetAllPatient() {
         
        var getData = myService.getPatients();
        
        getData.then(function (response) {
            $scope.patients = response.data;            
        }, function () {
            alert('Error in getting records');
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
                alert('Error in getting records');
            });
    }

    $scope.AddUpdatePatient = function () {
        
        var Patient = {
            PatientID: $scope.PatientID,
            Name: $scope.PatientName,
            Gender: $scope.PatientGender,
            Age: $scope.PatientAge
        };
        var getAction = $scope.Action;

        if (getAction == "Update") {
            Patient.PatientID = $scope.PatientID;
            var getData = myService.updatePatient(Patient);

            debugger;
            getData.then(function (msg) {
                GetAllPatient();
                alert(msg.data);
                $scope.divPatient = false;
            }, function () {
                alert('Error in updating record');
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