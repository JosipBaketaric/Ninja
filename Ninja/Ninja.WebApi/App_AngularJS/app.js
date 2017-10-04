
var appModule = angular.module('appModule', ['ngMaterial', 'ui.router']);

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
    })
        //-------------------------------------------------





        //Clan profile
        //-------------------------------------------------
    .state('clan',
    {
        url: '/clan',
        templateUrl: 'Clan/MainView.html',
    })
        //-------------------------------------------------



});





appModule.run(function ($rootScope, $window) {

    if ($window.localStorage['LogedIn'] == true)
        $rootScope.LogedIn = true;
    $rootScope.LogedIn = false;
    

});
