(function () {
    var app = angular.module("app", ["ngRoute","ngAnimate"]);

    //var adminapp = angular.module("adminapp", ["ngRoute"]);
    app.config(function ($routeProvider, $locationProvider) {
        $routeProvider            
            .when("/material", {
                templateUrl: "/Admin/Material",
                controller:"MaterialController"
            })
            .when("/colour", {
                templateUrl: "/Admin/Colour",
                controller: "ColourController"
            })
            .when("/image", {
                templateUrl: "/Admin/Image",
                controller: "AddImageController"
            })
            .when("/about", {
                templateUrl: "/Home/About",
            })
            .when("/contact", {
                templateUrl: "/Home/Contact",
            })
            //.when("/products", {
            //    templateUrl: "/Product/Product",
            //    controller: "ProductController"
            //})
            //.when("/details/:sku", {
            //    templateUrl: function (params) {
            //        return '/Product/ProductDetails?sku=' + params.sku;
            //    },
            //    controller: "ProductDetailsController"
            //})
            .otherwise({ redirectTo: "/" })
        $locationProvider.html5Mode(false).hashPrefix('!'); // This is for Hashbang Mode
    })   

    

}());