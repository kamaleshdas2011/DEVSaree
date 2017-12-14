// Code goes here
(function () {

    var app = angular.module("app");

    var ProductDetailsController = function ($scope, $routeParams, ProductDetails, DataService) {
        // get store and cart from service
        $scope.cart = DataService.cart;

        // apply changes when cart items change
        $scope.cart.itemsChanged = function (e) {
            if (!$scope.$$phase) {
                $scope.$apply();
            }
        }
        //var sku = $routeParams.sku;
        //var onGetProductDetails = function (data) {
        //    $scope.productdetails = data;
        //};
        //var onError = function (reason) {
        //    $scope.error = reason;
        //};
        //ProductDetails.getProductDetails(sku).then(onGetProductDetails, onError);
    };

    app.controller("ProductDetailsController", ProductDetailsController);

}())