var app = angular.module('todoom', ["ngRoute", "ui.bootstrap"]);

app.config([
    "$routeProvider", function($routeProvider) {
        $routeProvider

            // route for the home page
            .when('/', {
                templateUrl: 'Scripts/Main/template.html',
                controller: 'homeController'
            })

            // route for the about page
            .when('/create-list', {
                templateUrl: 'Scripts/CreateList/template.html',
                controller: 'createListController'
            })

            // route for the contact page
            .when('/contact', {
                templateUrl: 'pages/contact.html',
                controller: 'contactController'
            });
    }
]);