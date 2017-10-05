angular.module('appModule').controller('NinjaController',
    ['$scope', '$http', '$window', '$rootScope','$state',
        function ($scope, $http, $window, $rootScope, $state) {

            $scope.ninja = [];
            $scope.clan = [];

            $scope.ninja.name = $window.localStorage['NinjaName'];
            $scope.ninja.id = $window.localStorage['NinjaId'];
           

            var getNinjaWithClan = function() {
                $http.get('/api/ninja/GetNinjaWithClan?id=' + $scope.ninja.id)
                    .then
                    (
                    function (data) {
                        $scope.clan.name = data.data.ClanName;
                        $scope.clan.id = data.data.ClanId;

                        $window.localStorage['ClanId'] = data.data.ClanId;
                        $window.localStorage['ClanName'] = data.data.ClanName;

                        if (data.data.ClanId != null)
                            $scope.clan.fhas = true;
                        else
                            $scope.clan.fhas = false;

                    },
                    function errorCallback(response) {

                    }
                    );
            }

            //Function calls

            getNinjaWithClan();
            


}]);
