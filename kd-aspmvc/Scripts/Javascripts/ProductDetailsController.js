// Code goes here
(function () {

    var app = angular.module("app");

    var ProductDetailsController = function ($scope, $routeParams, ProductDetails, DataService, $uibModal) {
        // get store and cart from service
        $scope.cart = DataService.cart;

        // apply changes when cart items change
        $scope.cart.itemsChanged = function (e) {
            if (!$scope.$$phase) {
                $scope.$apply();
            }
        }
        $scope.showModal = function (sku,name) {
            $uibModal.open({
                controller: 'ModalImageController',
                templateUrl: '/Image/ModalImage',
                resolve: {
                    sku: function () {
                        return sku;
                    },
                    name: function () {
                        return name;
                    }
                }
            });
        }
        $scope.init = function (model) {
            $scope.product = model;
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