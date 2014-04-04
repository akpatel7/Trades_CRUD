'use strict';

portfoliosApp.controller('portfoliosController',
    function ($scope, $location, portfolioService)
    {

        $scope.portfolios = portfolioService.getPortfolios('');

        $scope.services = portfolioService.getServices('');

        $scope.selectedServiceId = {};

        $scope.selectedPortfolioId = {};

        $scope.navigateToDetails = function (portfolio) {
            $location.url('/portfolio/details' + portfolio.Id);
        };

        $scope.navigateToEdit = function (portfolio) {
            $location.url('/portfolio/edit' + portfolio.Id);
        };

    }
);