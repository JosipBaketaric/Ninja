angular.module('appModule').controller('ClanController', ['$scope', '$http', '$window', '$rootScope', '$mdDialog', '$state',
    function ($scope, $http, $window, $rootScope, $mdDialog, $state) {

    $scope.clan = [];
    $scope.clan.id = $window.localStorage['ClanId'];
    $scope.clan.name = $window.localStorage['ClanName'];


    var ShowInfoDialog = function (text) {

        $mdDialog.show(
            $mdDialog.alert()
                .parent(angular.element(document.querySelector('#popupContainer')))
                .clickOutsideToClose(true)
                .title('Info')
                .textContent(text)
                .ariaLabel('Alert Dialog Demo')
                .ok('Ok!')

        );
    };


    var getClan = function () {
        $http.get('/api/clan/GetClanWithNinjasById?id=' + $scope.clan.id)
            .then(function (data) {
                //success
                $scope.ninjas = data.data.Ninjas;
            }, function errorCallback(response) {
                //Error
                ShowInfoDialog(response.data);
            });
    };



        var LeaveClan = function () {
            $http.put('/api/ninja/RemoveNinjaFromClan?id=' + $window.localStorage['NinjaId'])
                .then(function (data) {

                    ShowInfoDialog("You left clan.");

                    $window.localStorage['ClanId'] = null;
                    $window.localStorage['ClanName'] = null;

                    $state.go('ninja');

                }, function errorCallback(response) {
                    ShowInfoDialog(PaymentResponse.data);
                });
        };







    $scope.showConfirmLeaveClan = function (ev) {
        // Appending dialog to document.body to cover sidenav in docs app
        var confirm = $mdDialog.confirm()
            .title('Would you like to leave clan?')
            .targetEvent(ev)
            .ok('Leave!')
            .cancel('Stay!');

        $mdDialog.show(confirm).then(function () {
            LeaveClan();
        }, function () {
            //STAY
        });
    };





    getClan();

}]);
