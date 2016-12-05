Onlinefoodstore.controller("RegisterController", function ($scope, RegisterUserService)
{
    $scope.registerUser = function () {
        uname = $scope.custname;
        phonenumber = $scope.phone;
        password = $scope.password;
        repeatpass = $scope.repeatpass;
        email = $scope.Email;
        address = $scope.address;

        console.log(uname + ':' + password + ':' + repeatpass);
        if (password != repeatpass) {
            alert("Password & repeat password shd be same");
            return;
        }
        var registerEntity =
        {
            UserName: uname,
            Password: password,
            ConfirmPassword: repeatpass,
            phone: phonenumber,
            Email: email,
            Address: address
        }

        RegisterUserService.RegisterUser(registerEntity, function (response) {
            console.log(response);
            //var customer = JSON.stringify(response.data);
            console.log(response.CustomerID);
            if (response.CustomerID != null) {
                window.location.href = "/";
            }
        });
    }

});

Onlinefoodstore.factory('RegisterUserService',['$http', function ($http) {

    var OnlineFoodstoreService = {};
   
    OnlineFoodstoreService.RegisterUser = function (registerEntity,callback) {
        return $http.post('/Account/Register',registerEntity).success(callback);
    }

    return OnlineFoodstoreService;


}]);