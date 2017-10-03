

angular.module('appModule').controller('CountriesController', ['$scope', '$http', '$window', '$state', CountriesController]);



//Controller function
function CountriesController($scope, $http, $window, $state)
{


    $scope.GetAllCountries = function () {

        //get all data
        $http.get('/api/countries/get').then(function (data) 
        {
            $scope.countries = data.data;
        });

    };





}