app.controller('homeController', [
    "$scope", "$http", function ($scope, $http) {
        console.log("creating home controller");

        $scope.message = "hello there!!!!";

        var a = 1;
        setInterval(function () {
            $scope.$apply(function () {
                $scope.message = "callback " + (a++);
            });
        }, 1000);

        $http.get('api/main/index')
            .then(function (response) {
                console.log("response", response);

                $scope.serverMessage = response.data.Text;
            });
    }
]);