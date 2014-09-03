function ContactController($scope, $http) {
    $scope.loading = true;
    $scope.addMode = false;

    //Used to display the data  
    $http.get('/api/Contact/createAngular').success(function (data) {
        $scope.contact = data;
        $scope.loading = false;
    })
    .error(function () {
        $scope.error = "An Error has occured while loading posts!";
        $scope.loading = false;
    });

    $scope.toggleEdit = function () {
        this.contact.editMode = !this.contact.editMode;
    };
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };

    //Used to save a record after edit  
    $scope.save = function () {
        alert("Edit");
        $scope.loading = true;
        var cont = this.contact;
        alert(emp);
        $http.put('/api/Contact/createAngular', cont).success(function (data) {
            alert("Saved Successfully!!");
            emp.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Contact! " + data;
            $scope.loading = false;

        });
    };

    //Used to add a new record  
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/Contact/createAngular', this.newcontact).success(function (data) {
            alert("Added Successfully!!");
            $scope.addMode = false;
            $scope.contact.push(data);
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Adding Contact! " + data;
            $scope.loading = false;

        });
    };

    //Used to edit a record  
    $scope.deletecontact = function () {
        $scope.loading = true;
        var contactid = this.contact.ID;
        $http.delete('/api/Contact/createAngular' + ID).success(function (data) {
            alert("Deleted Successfully!!");
            $.each($scope.contacts, function (i) {
                if ($scope.contacts[i].ID === id) {
                    $scope.contacts.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Contact! " + data;
            $scope.loading = false;

        });
    };

}