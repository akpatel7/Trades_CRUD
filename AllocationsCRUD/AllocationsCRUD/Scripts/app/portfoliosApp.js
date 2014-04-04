'use strict';

var portfoliosApp = angular.module('portfoliosApp', [
    // Angular modules 
    'ngRoute',
    'ngResource',
    'ngAnimate',        // Angular animations

    // Breeze Modules
    'breeze.angular',   // Breeze service
    'breeze.directives' // Breeze validation directive (zValidate)
]);

portfoliosApp.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
          when('/portfolio/detail', {
              templateUrl: 'Templates/partials/portfolio-detail.html',
              //controller: 'portfoliosController'
          }).
        otherwise({
            redirectTo: '/home'
        });
  }]);