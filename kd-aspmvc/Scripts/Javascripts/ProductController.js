(function () {
    var app = angular.module("app");

    var ProductController = function ($scope, $routeParams,
        $location, $anchorScroll,
        SubmitForm, AllProducts,
        DataService, FeaturedItems) {

        // get store and cart from service
        $scope.cart = DataService.cart;

        // apply changes when cart items change
        $scope.cart.itemsChanged = function (e) {
            if (!$scope.$$phase) {
                $scope.$apply();
            }
        };

        var onAllProducts = function (data) {
            $scope.product = data;
        };
        var onError = function (reason) {
            $scope.error = reason;
        };
        AllProducts.getAllProducts().then(onAllProducts, onError);

        $scope.selectedImage = null;
        var onAllImage = function (data) {
            $scope.allImages = data;
        };

        var onAllFormData = function (data) {
            $scope.materials = data.materials;
            $scope.colours = data.colours;
            $scope.producttypes = data.producttypes;
        };
        FeaturedItems.getCreateData().then(onAllFormData, onError);
        FeaturedItems.getAllImages().then(onAllImage, onError);

        //functions
        $scope.hoverImage = null;

        //select image
        $scope.onSelect = function (index, img) {
            $scope.selectedImage = img;
            $scope.hoverImage = index;
        };
        //add product
        $scope.AddProduct = function () {
            var url = '/Admin/AddProduct';
            var onPost = function (data) {
                $scope.postResponse = data;
                $scope.id = null;
                AllProducts.getAllProducts().then(onAllProducts, onError);
            };
            var products = {
                id: $scope.id,
                product_name: $scope.product_name,
                product_description: $scope.product_description,
                product_type_id: $scope.selectedProductType.id,
                unit: $scope.unit,
                price_per_unit: $scope.price_per_unit,
                PreviewImageId: $scope.selectedImage.Id,
                all_image_ids: $scope.all_image_ids
            };
            SubmitForm.postResponse(products, url).then(onPost, onError);
        };
        //delete product
        //edit product
        function searchImage(nameKey, myArray) {
            for (var i = 0; i < myArray.length; i++) {
                if (myArray[i].Id === nameKey) {
                    return myArray[i];
                }
            }
        }
        function searchType(nameKey, myArray) {
            for (var i = 0; i < myArray.length; i++) {
                if (myArray[i].id === nameKey) {
                    return myArray[i];
                }
            }
        }
        $scope.Delete = function (prod) {
            var onPost = function (data) {
                $scope.postResponse = data;
                $scope.id = null;
                AllProducts.getAllProducts().then(onAllProducts, onError);
            };
            SubmitForm.postResponse(prod, '/Admin/DeleteProduct').then(onPost, onError);
        }
        $scope.EditProduct = function (prod) {
            $scope.id = prod.id,
            $scope.product_name = prod.product_name,
            $scope.product_description = prod.product_description,
            $scope.selectedProductType = searchType(prod.product_type_id, $scope.producttypes);
            $scope.unit = prod.unit,
            $scope.price_per_unit = prod.price_per_unit,
            $scope.selectedImage = searchImage(prod.PreviewImageId, $scope.allImages);
            $scope.all_image_ids = prod.all_image_ids;  
            var newHash = 'mainAdmin';
            if ($location.hash() !== newHash) {
                $location.hash('mainAdmin');
            } else {
                $anchorScroll();
            }
        }
    };
    var displayProduct = function () {
        return {
            templateUrl: "/Product/DisplayProductTemplate",
            restrict: "E",
            scope: true,
            controller: function ($scope, $location) {
                $scope.Details = function (sku) {
                    window.location.href = "/Product/ProductDetails?sku=" + sku;
                };
            }
        };
    };
    var shoppingCart = function () {
        return {
            templateUrl: "/Home/ShoppingCart",
            restrict: "AE"
        };
    };

    app.controller("ProductController", ProductController);
    app.directive("displayProduct", displayProduct);
    app.directive("shoppingCart", shoppingCart);
}());