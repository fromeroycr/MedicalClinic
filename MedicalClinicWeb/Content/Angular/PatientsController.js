app.controller("patientsController", function ($scope, $http, patientsService) {

    $scope.divPatient = false;

    $scope.Genders = [
        { value: "0", name: "Masculino" },
        { value: "1", name: "Femenino" }
    ];

    GetAllPatient();
    //To Get All Records 

    function GetAllPatient() {

        //var getData = patientsService.getPatients();      

        //$scope.patients = getData;        

        //getData.then(function (response) {
        //    debugger;
        //    $scope.patients = response;            
        //}, function () {
        //    alert('Error in getting patients records');
        //});

        $http.get('http://localhost:50186/api/Patients/GetPatients')
            // on success...
            .then(function (result) {
                foo = result.data;
                response = result.data;
                $scope.patients = result.data;                
            },
            // on failure...
            function (errorMsg) {
                console.log('Something went wrong loading patients list: ' + errorMsg);
            });
    }

    $scope.editPatient = function (Patient) {

        var getData = patientsService.getPatient(Patient.PatientID);

        getData.then(function (patient) {

            $scope.Patient = patient.data;
            $scope.PatientID = Patient.PatientID;
            $scope.PatientName = Patient.Name;
            $scope.PatientAge = Patient.Age;

            $scope.selectedGender = String(Patient.Gender);
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
            Gender: $scope.selectedGender,
            Age: $scope.PatientAge
        };

        var getAction = $scope.Action;

        if (getAction == "Update") {
            Patient.PatientID = $scope.PatientID;
            var getData = patientsService.updatePatient(Patient);


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

            var getData = patientsService.AddPatient(Patient);

            getData.then(function (msg) {
                GetAllPatient();
                debugger;
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
        var getData = patientsService.DeletePatient(Patient);
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