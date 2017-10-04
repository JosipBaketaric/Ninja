angular.module('appModule').factory('httpRequestInterceptor', ['$window', '$q', function ($window, $q) {

    var interceptor =
        {
            request: function (config) {

                var Token = $window.localStorage['Token'];
                var NinjaId = $window.localStorage['NinjaId'];
                var TokenExpirationTime = $window.localStorage['TokenExpirationTime'];

                if (Token == null || NinjaId == null) {
                    Token = 'undefined';
                    NinjaId = -1;
                }

                var now = new Date().getTime();

                if (TokenExpirationTime != null && TokenExpirationTime < now)
                {

                    console.log("usao");
                    console.log("token time: " + TokenExpirationTime);
                    console.log("Now: " + now);

                }


                config.headers['Token'] = Token;
                config.headers['NinjaId'] = NinjaId;



                return config;
            }
        };

    return interceptor;

}]);





angular.module('appModule').config(['$httpProvider', function ($httpProvider) {
    $httpProvider.interceptors.push('httpRequestInterceptor');
}]);