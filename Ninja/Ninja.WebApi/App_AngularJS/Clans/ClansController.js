angular.module('appModule').controller('ClansController', ['$scope', '$http', '$window', '$rootScope', '$state', '$mdDialog',
    function ($scope, $http, $window, $rootScope, $state, $mdDialog) {


        if ($window.localStorage['ClanId'] == 0)
            $scope.fHasClan = false;
        else
            $scope.fHasClan = true;

        var getClans = function () {
            $http.get('/api/clan/GetAllClans')
                .then(function (data) {
                    //success
                    $scope.clans = data.data;
                }, function errorCallback(response) {
                    //Error
                    console.log(response.data);
                });
        }

        var JoinClan = function (id) {
            $http.post('/api/ninja/AddNinjaToClan?ninjaId=' + $window.localStorage['NinjaId'] + "&clanId=" + id)
                .then(function (data) {
                    //success
                    $state.go('ninja');
                }, function errorCallback(response) {
                    //Error
                    
                });
        };



    $scope.showConfirmLJoinClan = function (ev, id) {
        // Appending dialog to document.body to cover sidenav in docs app
        var confirm = $mdDialog.confirm()
            .title('Would you like to join clan?')
            .targetEvent(ev)
            .ok('Join!')
            .cancel('Return!');

        $mdDialog.show(confirm).then(function () {
            JoinClan(id);
        }, function () {
            //Return
        });
    };


    $scope.ClanDetails = function (id) {
    $http.get('/api/clan/GetClanWithNinjasById?id=' + id)
        .then(function (data) {
            //success
            $scope.details = [];
            $scope.details.clan = data.data;
            $state.transitionTo('clans.details');

        }, function errorCallback(response) {
            //Error
            console.log(response.data);
        });
    }












    getClans();










}]);
