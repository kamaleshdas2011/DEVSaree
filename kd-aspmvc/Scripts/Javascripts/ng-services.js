(function () {
    var FeaturedItems = function ($http) {
        var getAllImages = function () {
            return $http.get("/Image/GetAllImages")
                .then(function (response) {
                    return response.data
                });
        }
        var getCreateData = function () {
            return $http.get("/Admin/GetCreateData")
                .then(function (response) {
                    return { materials: response.data.Materials, colours: response.data.Colours, producttypes: response.data.ProductType };
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
    //generic service to submit form
    var UploadFiles = function ($http) {
       
        var uploadFiles = function (data, url) {
            var request = {
                method: 'POST',
                url: url,
                data: data,
                headers: {
                    'Content-Type': undefined
                }
            };
            return $http(request).then(function (response) {
                return response.data;
            });
        }
        return {
            postResponse: uploadFiles
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
    //get all products
    var ProductDetails = function ($http) {

        var getProductDetails = function (sku) {
            return $http.get("/Product/AProductDetails?sku=" + sku)
                .then(function (response) {
                    return response.data
                });
        }
        return {
            getProductDetails: getProductDetails,
        };
    }
    //get all images by products
    var GetImagesByProduct = function ($http) {

        var getImagesByProduct = function (sku) {
            return $http.get("/Image/GetImagesByProduct?sku=" + sku)
                .then(function (response) {
                    return response.data
                });
        }
        return {
            getImagesByProduct: getImagesByProduct,
        };
    }
    // create a data service that provides a store and a shopping cart that
    // will be shared by all views (instead of creating fresh ones for each view).
    var DataService = function () {

        // create store
        //var myStore = new store();

        // create shopping cart
        var myCart = new shoppingCart("AngularStore");

        // enable PayPal checkout
        // note: the second parameter identifies the merchant; in order to use the 
        // shopping cart with PayPal, you have to create a merchant account with 
        // PayPal. You can do that here:
        // https://www.paypal.com/webapps/mpp/merchant
        myCart.addCheckoutParameters("PayPal", "bernardo.castilho-facilitator@gmail.com");

        // enable Google Wallet checkout
        // note: the second parameter identifies the merchant; in order to use the 
        // shopping cart with Google Wallet, you have to create a merchant account with 
        // Google. You can do that here:
        // https://developers.google.com/commerce/wallet/digital/training/getting-started/merchant-setup
        myCart.addCheckoutParameters("Google", "500640663394527",
            {
                ship_method_name_1: "UPS Next Day Air",
                ship_method_price_1: "20.00",
                ship_method_currency_1: "USD",
                ship_method_name_2: "UPS Ground",
                ship_method_price_2: "15.00",
                ship_method_currency_2: "USD"
            }
        );

        // return data object with store and cart
        return {
            //store: myStore,
            cart: myCart
        };
    };


    var module = angular.module("app");
    module.factory("FeaturedItems", FeaturedItems);
    module.factory("SubmitForm", SubmitForm);
    module.factory("AllBlobImages", AllBlobImages);
    module.factory("AllProducts", AllProducts);
    module.factory("DataService", DataService);
    module.factory("ProductDetails", ProductDetails);
    module.factory("GetImagesByProduct", GetImagesByProduct);
    module.factory("UploadFiles", UploadFiles);
    
    
}()
);