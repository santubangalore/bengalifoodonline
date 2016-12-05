Onlinefoodstore.controller('CheckoutController', function ($scope, CheckoutService) {
    $scope.foodItems = [];
  
    $scope.State = 'Karnataka';
    $scope.City = 'Bangalore';
    function GetDefaultUser() {
        var getBookData = OnlineFoodService.GetDefaultUser();

        getBookData.then(function (book) {
            $scope.user = book.data;
            console.log($scope.user);
            $scope.custname = $scope.user.CustomerName;
            $scope.phone = $scope.user.Phone;
            $scope.address = $scope.user.CustomerAddress;

        }, function ()
        {
            alert('Error in getting user details');
        });
    }

    $scope.OrderSubmit = function ()
    {
        var Fname = $scope.FirstName;
        var Lname = $scope.LastName;
        var address = $scope.address;
        var phone = $scope.Phone;
        var city = $scope.City;
        var state = $scope.State;
        var country = $scope.Country;
        var paymentMode = $scope.PaymentType;
        var odate = $scope.OrderDate;
        var postalcode = $scope.PostalCode;

        //console.log(paymentMode);
        //console.log(Lname);

        console.log('phone:'+phone);
        //console.log(city);

        //public int OrderId { get; set; }
        //public System.DateTime OrderDate { get; set; }
        //public string Username { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Address { get; set; }
        //public string City { get; set; }
        //public string State { get; set; }
        //public string PostalCode { get; set; }
        //public string Country { get; set; }
        //public string Phone { get; set; }
        //public string Email { get; set; }
        //public decimal Total { get; set; }
        //public System.DateTime Experation { get; set; }
        //public bool SaveInfo { get; set; }
        //public string PaymentType { get; set; }
        //public Nullable<int> CompanyID { get; set; }
        if (odate == undefined) {
            alert('Order date is needed');
            return;
        }
        if (address == undefined) {
            alert('address is needed');
            return;
        }
        if (phone == undefined || phone=='') {
            alert('phone number is needed');
            return;
        }
        if (paymentMode == undefined) {
            alert('Please select payment mode');
            return;
        }
        var orderItem =
        {
            FirstName: Fname,
            LastName: Lname,
            Address: address,
            City: city,
            State: state,
            PostalCode: postalcode,
            Country: country,
            Phone: phone,
            PaymentType: paymentMode,
            OrderDate: odate,


        }

        CheckoutService.ConfirmOrder(orderItem, function (response) {
            console.log(response.OrderId);

            if (response.OrderId > 0) {
                console.log(response.OrderId);
                CheckoutService.GetCompletePage(response.OrderId);
            }
        });
        
    }

    $scope.selectedItem = function () {
        //$scope.description = $scope.fooditem.Description;
        console.log($scope.fooditem);

        // console.log($scope.description);

        $('#lblHid').text($scope.description);
        $('divHid').css("visibility", 'visible');
    }

   

       
       

   

    function InsertOrderItem(menuItem, orderDate, address, name, phone) {
        console.log(menuItem + ': ' + orderDate + ':' + address);
        var getBookData = OnlineFoodService.InsertOrderItem(menuItem, orderDate, address, name, phone);
    }
});


Onlinefoodstore.factory('CheckoutService', ['$http', function ($http) {

    var CheckoutService = {};
    CheckoutService.getAllFoodItems = function () {
        return $http.get('/api/Food/GetAllFood');
    };
    CheckoutService.AddToCart = function (orderitem, callback) {
        return $http.post('/ShoppingCart/AddToCart', orderitem).success(callback);;
    }

    CheckoutService.ConfirmOrder = function (orderObj, callback) {
        return $http.post('/Checkout/AddressAndPayment', orderObj).success(callback);;

    }

    
    CheckoutService.GetCompletePage = function (orderid) {
        //window.location.href = ;
        window.location.href = "/CheckOut/Complete/" + orderid;

      //  return $http.get("/CheckOut/Complete/" + orderid);
    }
    return CheckoutService;

}]);