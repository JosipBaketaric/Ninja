
var appModule = angular.module('appModule', ['ngMaterial', 'ui.router']);


//Constants
appModule.constant('TOKEN_DURATION', 10);
appModule.constant('BASE_LOCATION', '/App_angularJS/application.html#!/');


//Configure routes
appModule.config(function ($stateProvider, $urlRouterProvider, $locationProvider)
{

    //DEFAULT
    $urlRouterProvider.otherwise('/ninja');



    $stateProvider



        //login
        //-------------------------------------------------
    .state('login', 
    {
    url: '/login',
    templateUrl: 'Login/MainView.html',
    })
        //-------------------------------------------------

    .state('logout',
    {
        url: '/logout',
        templateUrl: 'Login/MainView.html',
        controller: 'LogoutController'
    })



        //Ninja profile
        //-------------------------------------------------
    .state('ninja',
    {
        url: '/ninja',
        templateUrl: 'ninja/MainView.html',
        resolve: { authenticate: authenticate }
    })
        //-------------------------------------------------





        //Clan profile
        //-------------------------------------------------
    .state('clan',
    {
        url: '/clan',
        templateUrl: 'Clan/MainView.html',
        resolve: { authenticate: authenticate }
    })
        //-------------------------------------------------


    //Route authentication

    function authenticate($q, $state, $timeout, $window, BASE_LOCATION) {

        var loged = $window.localStorage['LogedIn'];

        if (loged == "true") {          
            return $q.when();
        }
        else {
            $timeout(function () {
                $window.location.href = BASE_LOCATION + 'login';
            })
            return $q.reject();
        }

    }




});





appModule.run(function ($rootScope, $window) {

    var loged = $window.localStorage['LogedIn'];

    if (loged == "true")
    {
        $rootScope.LogedIn = true
    }        
    else {
        $rootScope.LogedIn = false;
    }   
    

});


