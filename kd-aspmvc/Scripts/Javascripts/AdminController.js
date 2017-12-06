(function () {
    var app = angular.module("app");
    var IndexController = function ($scope) {
        $scope.pagename = "Add/update materials, colours, images.";

    }
    var MaterialController = function ($scope, FeaturedItems, SubmitForm) {
        $scope.pagename = "Add/update materials.";
        var onAllFormData = function (data) {
            $scope.material = data.materials;
        };
        var onError = function (reason) {
            $scope.error = reason;
        };

        FeaturedItems.getCreateData().then(onAllFormData, onError);

        $scope.AddMaterial = function () {
            var url = '/Admin/AddMaterial';
            var onPost = function (data) {
                $scope.postResponse = data;
                FeaturedItems.getCreateData().then(onAllFormData, onError);
            };
            var data = { Name: $scope.name, Description: $scope.description };
            SubmitForm.postResponse(data, url).then(onPost, onError);
            
            $scope.name = null;
            $scope.description = null;
        }
    }
    var ColourController = function ($scope, FeaturedItems, SubmitForm) {
        $scope.pagename = "Add/update colours.";
        var onAllFormData = function (data) {
            $scope.colour = data.colours;
        };
        var onError = function (reason) {
            $scope.error = reason;
        };

        FeaturedItems.getCreateData().then(onAllFormData, onError);

        $scope.AddColour = function () {
            var url = '/Admin/AddColour';
            var onPost = function (data) {
                $scope.postResponse = data;
                FeaturedItems.getCreateData().then(onAllFormData, onError);
            };
            var data = { Name: $scope.name, Description: $scope.description };
            SubmitForm.postResponse(data, url).then(onPost, onError);
            
            $scope.name = null;
            $scope.description = null;
        }
    }
    var AddImageController = function ($scope, FeaturedItems, SubmitForm, AllBlobImages) {
        $scope.pagename = "Add/update images.";
        var onAllFormData = function (data) {
            $scope.image = data;
        };
        var onAllImages = function (data) {
            $scope.images = data;
        };
        var onError = function (reason) {
            $scope.error = reason;
        };

        AllBlobImages.getAllBlobImages().then(onAllImages, onError);
        FeaturedItems.getAllImages().then(onAllFormData, onError);

        $scope.selectedImage = null;
        $scope.hoverImage = null;
        $scope.changeColour = function (index, bool) {
            if (bool === true) {
                $scope.hoverImage = index;
            } else if (bool === false) {
                $scope.hoverImage = index;
            }
        };
        $scope.onSelect = function (index, img) {
            $scope.selectedImage = img;
        };

        $scope.AddImage = function () {
            var url = '/Admin/AddImage';
            var onPost = function (data) {
                $scope.postResponse = data;
                FeaturedItems.getAllImages().then(onAllFormData, onError);
            };
            var data = { Name: $scope.name, Caption: $scope.caption, ImageUri: $scope.selectedImage.ImageUri, BaseColour:$scope.basecolour };
            SubmitForm.postResponse(data, url).then(onPost, onError);

            $scope.name = null;
            $scope.caption = null;
            $scope.imageuri = null;
            $scope.basecolour = null;
        }
    }   
    app.controller("MaterialController", MaterialController);
    app.controller("IndexController", IndexController);
    app.controller("ColourController", ColourController);
    app.controller("AddImageController", AddImageController);
}());