Onlinefoodstore.controller('FoodOrderController', function ($scope, OnlineFoodService) {
    $scope.foodItems = [];
    $('.first').circleProgress({
        value: 0.35,
        animation: false,
        fill: { gradient: ['#ff1e41', '#ff5f43'] }
    });

    GetAllMenuItems();
    //To Get all book records
    //GetDefaultUser();
    $('.first').hide();

    function GetDefaultUser()
    {
        var getBookData = OnlineFoodService.GetDefaultUser();

        getBookData.then(function (book) {
            $scope.user = book.data;
            console.log($scope.user);
            $scope.custname = $scope.user.CustomerName;
            $scope.phone = $scope.user.Phone;
            $scope.address = $scope.user.CustomerAddress;

        }, function () {
            alert('Error in getting user details');
        });
    }
    $scope.GetPendingOrders = function (fromdate, todate, orderno) {
        var queryObject = {
            FromDate: fromdate,
            ToDate: todate,
            OrderNo:orderno,
        };
        OnlineFoodService.GetPendingOrders(queryObject, function (response) {
            console.log(response);
            $scope.result = response;
                
        });
    }

    function GetAllMenuItems() {
        //debugger;
        var getBookData = OnlineFoodService.getAllFoodItems();
        getBookData.then(function (book) {
            $scope.foodItems = book.data;
            //console.log($scope.foodItems);
        }, function () {
            alert('Error in getting food menu items');
        });
    }

    $scope.selectedItem = function ()
    {
        //$scope.description = $scope.fooditem.Description;
        console.log($scope.fooditem);

        // console.log($scope.description);

        $('#lblHid').text($scope.description);
        $('divHid').css("visibility", 'visible');
    }

    $scope.AddToCart = function (menuitem, quantity) {
       // console.log(menuitem);
        console.log($scope.orderDate);
        var odate = $scope.orderDate;
        if (odate == undefined) {
            alert("date is required");
            return;
        }

        if (menuitem == undefined) {
            console.log("menuitem is required");
            alert("menuitem is required");
            return;
        }

        if (quantity == undefined) {
            console.log("quantity is required");
            alert("quantity is required");
            return;
        }

        var orderItem =
        {
            MenuItemID: menuitem,
            Quantity: quantity,
            Odate:odate
        }
        OnlineFoodService.AddToCart(orderItem,function (response){
            console.log(response);
            $('.first').html(response.Message);
            $('.first').show();
            $('#cart-status').text(response.CartCount);
        });

    }

    function InsertOrderItem(menuItem, orderDate, address, name, phone) {
        console.log(menuItem + ': ' + orderDate + ':' + address);
        var getBookData = OnlineFoodService.InsertOrderItem(menuItem, orderDate, address, name, phone);
    }
});


Onlinefoodstore.factory('OnlineFoodService', ['$http', function ($http) {

    var OnlineFoodstoreService = {};
    OnlineFoodstoreService.getAllFoodItems = function () {
        return $http.get('/api/Food/GetAllFood');
    };
    OnlineFoodstoreService.AddToCart = function (orderitem, callback)
    {
        return $http.post('/ShoppingCart/AddToCart', orderitem).success(callback);;
    }
    OnlineFoodstoreService.GetPendingOrders = function (orderitem, callback) {
        return $http.post('/ShoppingCart/AddToCart', orderitem).success(callback);;
    }
    OnlineFoodstoreService.InsertOrderItem = function (menuItem, OrderDate, address, name, phone) {

    }

    OnlineFoodstoreService.GetDefaultUser = function ()
    {
         return $http.get('/api/User/GetDefaultUser');
    }
    return OnlineFoodstoreService;

}]);