angular.module('appModule').factory('httpRequestInterceptor',
    ['$window', '$q', '$rootScope','TOKEN_DURATION',
        function ($window, $q, $rootScope, TOKEN_DURATION) {

    var interceptor =
        {
            request: function (config) {

                var Token = $window.localStorage['Token'];
                var NinjaId = $window.localStorage['NinjaId'];
                var TokenExpirationTime = $window.localStorage['TokenExpirationTime'];
                var loged = $window.localStorage['LogedIn'];

                if (Token == null || NinjaId == null) {
                    Token = 'undefined';
                    NinjaId = -1;
                }

                var now = new Date().getTime();

                //If token have expired then remove data from local storage and logout user
                //else refresh token and add required data to header of request
                if (loged == "true" && TokenExpirationTime < now)
                {
                    //Logout
                    $window.localStorage['Token'] = null;
                    $window.localStorage['NinjaId'] = null;
                    $window.localStorage['NinjaName'] = null;
                    $window.localStorage['LogedIn'] = "false";
                    $window.localStorage['TokenExpirationTime'] = null;
                    $rootScope.LogedIn = false;

                    q.reject("Login timeout");
                }
                else {
                    var extendedTime = new Date();
                    extendedTime.setMinutes(extendedTime.getMinutes() + TOKEN_DURATION);
                    extendedTime = extendedTime.getTime();
                    $window.localStorage['TokenExpirationTime'] = extendedTime;


                    config.headers['Token'] = Token;
                    config.headers['NinjaId'] = NinjaId;
                }





                return config;
            }
        };

    return interceptor;

}]);





angular.module('appModule').config(['$httpProvider', function ($httpProvider) {
    $httpProvider.interceptors.push('httpRequestInterceptor');
}]);