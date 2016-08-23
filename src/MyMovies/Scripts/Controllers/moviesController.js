(function () {
    'use strict';

    angular
        .module('MyMovies')
        .controller('MoviesListController', MoviesListController)
        .controller('MoviesDetailsController', MoviesDetailsController);

    MoviesListController.$inject = ['$scope', 'Movie'];
    function MoviesListController($scope, Movie) {
        $scope.movies = Movie.query();
    }

    MoviesDetailsController.$inject = ['$scope', '$routeParams', '$location', 'Movie'];

    function MoviesDetailsController($scope, $routeParams, $location, Movie) {
        $scope.movie = Movie.get({ id: $routeParams.id });
        $scope.details = function () {
            $scope.movie.$save(function () {
                $location.path('/');
            });
        };
    }
})();
