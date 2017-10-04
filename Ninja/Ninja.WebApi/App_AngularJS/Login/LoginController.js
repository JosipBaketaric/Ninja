angular.module('appModule').controller('LoginController', ['$scope', '$http', '$window', '$rootScope', function ($scope, $http, $window, $rootScope) {






    $scope.LoginNinja = function ()
    {

        $scope.error = false;

        $http.get('/api/login/LoginNinja?name=' + $scope.name + "&password=" + $scope.password)
            .then
            (
                function (data)
                {

                    var expirationTime = new Date();
                    expirationTime.setMinutes(expirationTime.getMinutes() + 10);
                    expirationTime = expirationTime.getTime();

                    //Save to local storage
                    $window.localStorage['Token'] = data.data['Token'];
                    $window.localStorage['NinjaId'] = data.data['NinjaId'];
                    $window.localStorage['NinjaName'] = $scope.name;
                    $window.localStorage['LogedIn'] = true;
                    $window.localStorage['TokenExpirationTime'] = expirationTime;

                    $rootScope.LogedIn = true;
                    //Redirect to ninja profile
                    $window.location.href = '/App_angularJS/application.html#!/ninja';
                    
                },
                function errorCallback(response)
                {
                    $scope.error = true;
                    $scope.errorMessage = response.data.Message;
                    $window.localStorage['LogedIn'] = false;
                    $rootScope.LogedIn = false;
                }
            );
    };






}
]);
