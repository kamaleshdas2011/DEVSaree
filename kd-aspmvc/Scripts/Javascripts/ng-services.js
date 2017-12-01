(function () {
    var FeaturedItems = function ($http) {
       
        var getFeaturedItems = function () {
            return $http.get("/Image/GetFeaturedItems")
                .then(function (response) {
                    return response.data
                });
        }
        return {
            getFeaturedItems: getFeaturedItems
        }
    }

    var module = angular.module("app");
    module.factory("FeaturedItems", FeaturedItems);
}()
);