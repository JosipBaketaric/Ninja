angular.module('appModule').controller('NinjaController',
    ['$scope', '$http', '$window', '$rootScope',
        function ($scope, $http, $window, $rootScope) {


    $scope.name = $window.localStorage['NinjaName'];


}]);
