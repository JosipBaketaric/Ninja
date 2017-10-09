
var appModule = angular.module('appModule', ['ngMaterial', 'ui.router']);


//Constants
appModule.constant('TOKEN_DURATION', 10);
appModule.constant('BASE_LOCATION', '/App_angularJS/application.html#!/');


//Configure routes
appModule.config(function ($stateProvider, $urlRouterProvider, $locationProvider)
{

    //DEFAULT
    $urlRouterProvider.otherwise('/login');

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
        //resolve: { authenticate: authenticate }
    })
        //-------------------------------------------------




        //Clan profile
        //-------------------------------------------------
    .state('clan',
    {
        url: '/clan',
        templateUrl: 'Clan/MainView.html',
        //resolve: { authenticate: authenticate }
    })
        //-------------------------------------------------


        //List of all clans
        //-------------------------------------------------
        .state('clans',
        {
            url: '/clans',
            templateUrl: 'Clans/MainView.html',
            //resolve: { authenticate: authenticate }
        })


        //Child view
        .state('clans.details',
        {
            url: '/clans.details',
            views: {
                "root": {
                    templateUrl: 'Clans/DetailsView.html',
                }
            }
            
            //resolve: { authenticate: authenticate }
        })
        //-------------------------------------------------




    //Route authentication
    /*
    function authenticate($q, $state, $timeout, $window) {

        var deferred = $q.defer();
        var loged = $window.localStorage['LogedIn'];
        
        if (loged == "true") {
            deferred.resolve();
        }
        else {
            deferred.reject('redirectToLogin');

        }

              
        return deferred.promise;
    }

    */


});





appModule.run(function ($rootScope, $window, $state, BASE_LOCATION, $log) {





    $rootScope.$on('$locationChangeStart',
        function (event, toState, toParams, fromState, fromParams) {


            if (toState != 'http://localhost:60887/App_angularJS/application.html#!/login')
            {
                if ($rootScope.LogedIn == false) { // Check if user allowed to transition                  
                    event.preventDefault();   // Prevent migration to default state     
                    $window.location.href = BASE_LOCATION + 'login';
                }
            }

        })


    
    var loged = $window.localStorage['LogedIn'];
    if (loged == "true")
    {
        $rootScope.LogedIn = true
    }        
    else {
        $rootScope.LogedIn = false;
    }

    
    

});


