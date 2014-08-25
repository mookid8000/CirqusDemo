app.controller('homeController', [
    "$scope", "$http", "$modal", function ($scope, $http, $modal) {

        $http.get('api/main/index')
            .then(function (response) {
                console.log("response", response);

                $scope.lists = response.data.Lists;
            });

        $scope.showList = function (id) {
            $scope.todoListId = id;
            $modal.open({
                templateUrl: "Scripts/Show/template.html",
                controller: "showListController"
            });
        }
    }
])