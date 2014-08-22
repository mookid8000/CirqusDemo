app.controller('homeController', [
    "$scope", "$http", function ($scope, $http) {

        $http.get('api/main/index')
            .then(function (response) {
                console.log("response", response);

                $scope.lists = response.data.Lists;
            });
    }
]);