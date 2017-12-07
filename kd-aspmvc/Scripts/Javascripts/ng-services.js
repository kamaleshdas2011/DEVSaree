(function () {
    var FeaturedItems = function ($http) {
       
        //var getFeaturedItems = function () {
        //    return $http.get("/Image/GetFeaturedItems")
        //        .then(function (response) {
        //            return response.data
        //        });
        //}
        var getAllImages = function () {
            return $http.get("/Image/GetAllImages")
                .then(function (response) {
                    return response.data
                });
        }
        var getCreateData = function () {
            return $http.get("/Sarees/GetCreateData")
                .then(function (response) {
                    return { materials: response.data.Materials, colours: response.data.Colours };
                });
        }
        return {
            getAllImages: getAllImages,
            getCreateData: getCreateData
        };
    }
    //generic service to submit form
    var SubmitForm = function ($http) {
        var submitForm = function (data, url) {
            return $http.post(url, data).then(
                function (response) {
                    return response.data;
                })
        }
        return {
            postResponse: submitForm
        }
    }
    //get all images from azure blob storage
    var AllBlobImages = function ($http) {
        
        var getAllBlobImages = function () {
            return $http.get("/Image/GetAllBlobImages")
                .then(function (response) {
                    return response.data
                });
        }
        return {
            getAllBlobImages: getAllBlobImages,
        };
    }
    //get all products
    var AllProducts = function ($http) {

        var getAllProducts = function () {
            return $http.get("/Product/GetAllProducts")
                .then(function (response) {
                    return response.data
                });
        }
        return {
            getAllProducts: getAllProducts,
        };
    }
    var module = angular.module("app");
    module.factory("FeaturedItems", FeaturedItems);
    module.factory("SubmitForm", SubmitForm);
    module.factory("AllBlobImages", AllBlobImages);
    module.factory("AllProducts", AllProducts);
}()
);