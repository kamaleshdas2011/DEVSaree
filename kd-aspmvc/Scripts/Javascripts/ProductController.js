(function () {
    var app = angular.module("app");
    
    var ProductController = function ($scope, FeaturedItems, SubmitForm, AllProducts) {
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
            scope: {
                prod: "=prodData"
            },
            controller: function ($scope) {
                $scope.collapsed = false;
                $scope.addToCart = function (product) {
                    
                };
                $scope.collapse = function () {
                    $scope.collapsed = !$scope.collapsed;
                };
            }
        }
    }
    app.controller("ProductController", ProductController);
    app.directive("displayProduct", displayProduct);
}());