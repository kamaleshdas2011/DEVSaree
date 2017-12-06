(function () {
    var app = angular.module("app");

    var ImageController = function ($scope, FeaturedItems, SubmitForm) {

        //var onImage = function (data) {
        //    $scope.images = data;
        //};
        var onAllImage = function (data) {
            $scope.allImages = data;
        };
        var onAllFormData = function (data) {
            $scope.materials = data.materials;
            $scope.colours = data.colours;
        };
        var onError = function (reason) {
            $scope.error = reason;
        };

        //FeaturedItems.getFeaturedItems().then(onImage, onError);
        FeaturedItems.getAllImages().then(onAllImage, onError);
        FeaturedItems.getCreateData().then(onAllFormData, onError);

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

        $scope.submitCreate = function () {
            var url = '/Sarees/Create';
            var onPost = function (data) {
                
                $scope.postResponse = data;
            };
            var sarees = { MaterialId: $scope.selectedMaterial.Id, ColourId: $scope.selectedColour.Id, ImageId: $scope.selectedImage.Id };
            SubmitForm.postResponse(sarees, url).then(onPost, onError);		
        }
    }

    app.controller("ImageController", ImageController);
}());