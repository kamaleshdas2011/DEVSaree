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
            //getFeaturedItems: getFeaturedItems,
            getAllImages: getAllImages,
            getCreateData: getCreateData
        };
    }
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
    var module = angular.module("app");
    module.factory("FeaturedItems", FeaturedItems);
    module.factory("SubmitForm", SubmitForm);
    module.factory("AllBlobImages", AllBlobImages);
}()
);