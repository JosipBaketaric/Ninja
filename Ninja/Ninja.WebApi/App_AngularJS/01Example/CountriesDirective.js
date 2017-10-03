angular.module('appModule').directive('countriesInfo', function () {
    return {
        restrict: 'E',
        templateUrl: 'Countries/countries-info-template.html',

        scope: {
            country: '='
        }

    };
});