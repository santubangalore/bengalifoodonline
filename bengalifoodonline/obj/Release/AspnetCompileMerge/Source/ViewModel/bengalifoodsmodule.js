var Onlinefoodstore = angular.module('OnlinefoodstoreApp', []);
Onlinefoodstore.controller('FoodStoreController', function ($scope, OnlineFoodService)
{
    GetAllMenuItems();
    //To Get all book records  
    function GetAllMenuItems() {
        //debugger;
        var getBookData = OnlineFoodService.getAllFoodItems();
        getBookData.then(function (book) {
            $scope.foodItems = book.data;
            console.log($scope.foodItems);
        }, function () {
            alert('Error in getting food menu items');
        });
    }
});

Onlinefoodstore.factory('OnlineFoodService', ['$http', function ($http) {

    var OnlineFoodstoreService = {};
    OnlineFoodstoreService.getAllFoodItems = function () {
        return $http.get('/api/Food/GetAllFood');
    };

   
    return OnlineFoodstoreService;

}]);