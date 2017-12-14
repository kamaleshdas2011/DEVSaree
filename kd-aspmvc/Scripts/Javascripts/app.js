(function () {
    var app = angular.module("app", ["ngRoute", "ngAnimate","ui.bootstrap"]);

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
            .when("/uploadimage", {
                templateUrl: "/Admin/UploadImage",
                controller: "AddImageController"
            })
            .when("/about", {
                templateUrl: "/Home/About",
            })
            .when("/contact", {
                templateUrl: "/Home/Contact",
            })
            .otherwise({ redirectTo: "/" })
        $locationProvider.html5Mode(false).hashPrefix('!'); // This is for Hashbang Mode
    })   

    

}());