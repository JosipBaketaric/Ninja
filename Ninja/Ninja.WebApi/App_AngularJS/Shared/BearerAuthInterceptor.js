angular.module('appModule').factory('httpRequestInterceptor', ['$window', function ($window) {

    var interceptor =
        {
            request: function (config) {

                var Token = $window.localStorage['Token'];
                var NinjaId = $window.localStorage['NinjaId'];

                if (Token == null || NinjaId == null) {
                    Token = 'undefined';
                    NinjaId = -1;
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