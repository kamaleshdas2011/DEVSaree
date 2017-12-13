(function () {
    var app = angular.module("app");
    
    var ProductController = function ($scope, FeaturedItems, SubmitForm, AllProducts, DataService, $routeParams) {

        // get store and cart from service
        $scope.store = DataService.store;
        $scope.cart = DataService.cart;

        // apply changes when cart items change
        $scope.cart.itemsChanged = function (e) {
            if (!$scope.$$phase) {
                $scope.$apply();
            }
        }

        // use routing to pick the selected product
        if ($routeParams.productSku != null) {
            $scope.product = $scope.store.getProduct($routeParams.productSku);
        }
        var onAllProducts = function (data) {
            $scope.product = data;
        };
        var onError = function (reason) {
            $scope.error = reason;
        };

        AllProducts.getAllProducts().then(onAllProducts, onError);
    }
    var displayProduct = function () {
        return {
            templateUrl: "/Product/DisplayProductTemplate",
            restrict: "E",
            //scope: {
            //    prod: "=prodData"
            //},
            //transclude: true,
            controller: function ($scope, $rootScope) {
                $scope.addItem = function (sku, name, price, quantity) {
                    CartService.addItem(sku, name, price, quantity);
                }
                $scope.collapsed = false;
                $scope.displayImages = false;
                $scope.collapse = function () {
                    $scope.collapsed = !$scope.collapsed;
                };
                $scope.viewAllImages = function () {
                    $scope.displayImages = !$scope.displayImages;
                }
            }
        }
    }
    var shoppingCart = function () {
        return {
            templateUrl: "/Home/ShoppingCart",
            restrict: "AE",
            //scope: {
            //    cart: "="
            //},
            //controller: function ($scope, $rootScope) {

            //}
        }
    }
    app.controller("ProductController", ProductController);
    app.directive("displayProduct", displayProduct);
    app.directive("shoppingCart", shoppingCart);
}());