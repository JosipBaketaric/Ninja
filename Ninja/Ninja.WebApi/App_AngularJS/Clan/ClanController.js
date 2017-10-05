angular.module('appModule').controller('ClanController', ['$scope', '$http', '$window', '$rootScope', function ($scope, $http, $window, $rootScope) {

    $scope.clan = [];
    $scope.clan.id = $window.localStorage['ClanId'];
    $scope.clan.name = $window.localStorage['ClanName'];

    var getClan = function () {
        $http.get('/api/clan/GetClanWithNinjasById?id=' + $scope.clan.id)
            .then(function (data) {
                //success
                $scope.ninjas = data.data.Ninjas;
            }, function errorCallback(response) {
                //Error
                console.log(response.data);
            });
    }



    getClan();

}]);
