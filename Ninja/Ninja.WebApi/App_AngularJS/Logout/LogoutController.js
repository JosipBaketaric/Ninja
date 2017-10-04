angular.module('appModule').controller('LogoutController', ['$scope', '$window', '$rootScope', '$http', function ($scope, $window, $rootScope, $http) {




    $rootScope.LogedIn = false;


    $http.post('/api/login/LogoutNinja?id=' + $window.localStorage['NinjaId'])
        .then
        (
        function (data) {
            //notify
        },
        function errorCallback(response) {

        }
        );


    $window.localStorage['Token'] = null;
    $window.localStorage['NinjaId'] = null;
    $window.localStorage['NinjaName'] = null;
    $window.localStorage['LogedIn'] = false;
    $window.localStorage['TokenExpirationTime'] = null;
    $window.location.href = '/App_angularJS/application.html#!/login';


}]);
