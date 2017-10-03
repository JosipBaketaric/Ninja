angular.module('appModule').controller('LoginController', ['$scope', '$http', function ($scope, $http) {



    $scope.LoginNinja = function () {



        $http.get('/api/login/LoginNinja?name=' + $scope.name + "&password=" + $scope.password).then(function (data) {
            $scope.countries = data.data;

            console.log(data.data);
        });


    };



}
]);
