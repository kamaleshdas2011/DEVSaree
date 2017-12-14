(function () {
    var app = angular.module("app");

    var ModalImageController = function ($scope, GetImagesByProduct,sku,name) {        
        $scope.productname = name;
        var onSuccess = function (data) {
            $scope.images = data;
            
        };
        var onError = function (reason) {
            $scope.error = reason;
        };
        GetImagesByProduct.getImagesByProduct(sku).then(onSuccess, onError);
    }
    app.controller("ModalImageController", ModalImageController);
}());