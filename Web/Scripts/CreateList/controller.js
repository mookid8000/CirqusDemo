app.controller('createListController', [
    "$scope", "$location", "$http", function ($scope, $location, $http) {
        console.log("creating createListController controller");

        $scope.list = {
            title: "",
            bullets: [{}]
        };

        $scope.save = function () {
            $http.post('/api/list/new', $scope.list)
                .then(function(response) {
                    console.log("response", response);
                    $location.path("/");
                });
        };

        $scope.cancel = function() {
            $location.path("/");
        };

        $scope.remove = function(bullet) {
            var bullets = $scope.list.bullets;
            bullets.splice(bullets.indexOf(bullet), 1);
        };

        $scope.add = function() {
            var bullets = $scope.list.bullets;
            bullets.push({});
        }
    }
]);