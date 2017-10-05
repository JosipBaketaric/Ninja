angular.module('appModule').controller('LoginController',
    ['$scope', '$http', '$window', '$rootScope', 'TOKEN_DURATION','BASE_LOCATION',
        function ($scope, $http, $window, $rootScope, TOKEN_DURATION, BASE_LOCATION) {






    $scope.LoginNinja = function ()
    {

        $scope.error = false;

        $http.get('/api/login/LoginNinja?name=' + $scope.name + "&password=" + $scope.password)
            .then
            (
                function (data)
                {

                    var expirationTime = new Date();
                    expirationTime.setMinutes(expirationTime.getMinutes() + TOKEN_DURATION);
                    expirationTime = expirationTime.getTime();

                    //Save to local storage
                    $window.localStorage['Token'] = data.data['Token'];
                    $window.localStorage['NinjaId'] = data.data['NinjaId'];
                    $window.localStorage['NinjaName'] = $scope.name;
                    $window.localStorage['LogedIn'] = "true";
                    $window.localStorage['TokenExpirationTime'] = expirationTime;

                    $rootScope.LogedIn = true;
                    //Redirect to ninja profile
                    $window.location.href = BASE_LOCATION + 'ninja';
                    
                },
                function errorCallback(response)
                {
                    $scope.error = true;
                    $scope.errorMessage = response.data.Message;
                    $window.localStorage['LogedIn'] = "false";
                    $rootScope.LogedIn = false;
                }
            );
    };






}
]);
