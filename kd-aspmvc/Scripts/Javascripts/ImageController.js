(function () {
    var app = angular.module("app");

    var ImageController = function ($scope, FeaturedItems) {

        var onImage = function (data) {
            $scope.images = data;
        };
        var onAllImage = function (data) {
            $scope.allImages = data;
        };
        var onError = function (reason) {
            $scope.error = reason;
        };

        FeaturedItems.getFeaturedItems().then(onImage, onError);
        FeaturedItems.getAllImages().then(onAllImage, onError);
        $scope.selectedImage = null;
        $scope.changeColour = function (index, bool) {
            if (bool === true) {
                $scope.selectedImage = index;
            } else if (bool === false) {
                $scope.selectedImage = null; //or, whatever the original color is
            }
        };
    }

    app.controller("ImageController", ImageController);
}());