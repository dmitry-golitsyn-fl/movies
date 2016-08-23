(function () {
    'use strict'; 

    config.$inject = ['$routeProvider', '$locationProvider']; 

    angular.module('MyMovies', [
        'ngRoute', 'moviesServices'
    ]).config(config);

    function config($routeProvider, $locationProvider) {
        $routeProvider
            .when('/', {
              templateUrl: '/Views/list.html',
              controller: 'MoviesListController'
            })
            .when('/movies/:timestamp', {
                templateUrl: '/Views/list.html',
                controller: 'MoviesListController'
            })
            .when('/movies/details/:id', {
                templateUrl: '/Views/details.html',
                controller: 'MoviesDetailsController'
            });

        $locationProvider.html5Mode(true); 
    }

})();