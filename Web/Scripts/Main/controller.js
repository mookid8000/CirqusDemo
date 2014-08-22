app.controller('homeController', [
    "$scope", function($scope) {
        console.log("creating home controller");

        $scope.message = "hello there!!!!";

        var a = 1;
        setInterval(function () {
            $scope.$apply(function() {
                $scope.message = "callback " + (a++);
            });
        }, 1000);
    }
]);