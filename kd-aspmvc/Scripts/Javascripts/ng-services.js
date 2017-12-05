(function () {
    var FeaturedItems = function ($http) {
       
        var getFeaturedItems = function () {
            return $http.get("/Image/GetFeaturedItems")
                .then(function (response) {
                    return response.data
                });
        }
        var getAllImages = function () {
            return $http.get("/Image/GetAllImages")
                .then(function (response) {
                    return response.data
                });
        }
        return {
            getFeaturedItems: getFeaturedItems,
            getAllImages: getAllImages
        }
    }

    var module = angular.module("app");
    module.factory("FeaturedItems", FeaturedItems);
}()
);