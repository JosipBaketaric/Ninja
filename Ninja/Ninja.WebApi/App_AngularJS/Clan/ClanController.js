angular.module('appModule').controller('ClanController', ['$scope', '$http', '$window', '$rootScope', function ($scope, $http, $window, $rootScope) {

    $scope.name = $window.localStorage['NinjaName'];


}]);
