(function () {
    var app = angular.module("app");

    var ImageController = function ($scope, FeaturedItems) {

        var onImage = function (data) {
            $scope.images = data;
        };

        var onError = function (reason) {
            $scope.error = reason;
        };

        FeaturedItems.getFeaturedItems().then(onImage, onError);
    }

    app.controller("ImageController", ImageController);
}());