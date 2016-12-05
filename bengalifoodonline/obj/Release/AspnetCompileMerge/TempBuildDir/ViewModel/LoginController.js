Onlinefoodstore.controller("LoginController", function ($scope, LoginService) {
    
        $scope.Login = function (username, password) {
            uname = $scope.custname;
            password = $scope.password;
            console.log(uname + ':' + password);

            var loginEntity =
                {
                    UserName: uname,
                    Password: password,
                  
                }

            LoginService.Login(loginEntity, function (response) {

                console.log(response);
                if (response.CustomerID != null) {
                    window.location.href = "/";
                }
            });
        }

    $scope.Register = function () {
        window.location.href = "/Account/Register";

    }
});



Onlinefoodstore.factory('LoginService', ['$http', function ($http) {

    var OnlineFoodstoreService = {};

    OnlineFoodstoreService.Login = function (loginEntity, callback) {
        return $http.post('/Account/Login', loginEntity).success(callback);
    }

    return OnlineFoodstoreService;


}]);