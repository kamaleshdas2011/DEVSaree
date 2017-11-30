(function () {
    var app = angular.module("app");

    var ImageController = function ($scope) {
        $scope.message = "new angular";
    }

    app.controller("ImageController", ["$scope", ImageController]);
}());