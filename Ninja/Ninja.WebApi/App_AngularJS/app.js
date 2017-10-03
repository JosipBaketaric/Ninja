
var appModule = angular.module('appModule', ['ngMaterial' ,'ui.router']);

//Configure routes
appModule.config(function($stateProvider, $urlRouterProvider, $locationProvider)
{

    //DEFAULT
    $urlRouterProvider.otherwise('/login');





    $stateProvider



        //login
        //-------------------------------------------------
    .state('login', 
    {
    url: '/login',
    templateUrl: 'Login/MainView.html'
    })
        //-------------------------------------------------






        //Ninja profile
        //-------------------------------------------------
    .state('ninja',
    {
        url: '/ninja',
        templateUrl: 'ninja/MainView.html'
    })
        //-------------------------------------------------





        //Clan profile
        //-------------------------------------------------
    .state('clan',
    {
        url: '/clan',
        templateUrl: 'Clan/MainView.html'
    })
        //-------------------------------------------------







});