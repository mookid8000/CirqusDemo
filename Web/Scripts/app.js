var app = angular.module('todoom', ["ngRoute"])

app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider

        // route for the home page
        .when('/', {
            templateUrl: 'Scripts/Main/template.html',
            controller: 'homeController'
        })

        // route for the about page
        .when('/about', {
            templateUrl: 'Scripts/About/template.html',
            controller: 'aboutController'
        })

        // route for the contact page
        .when('/contact', {
            templateUrl: 'pages/contact.html',
            controller: 'contactController'
        });
}]);