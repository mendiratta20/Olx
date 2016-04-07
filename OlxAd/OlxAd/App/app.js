(function (angular) {
    //'use strict';

    var olxApp = angular.module('olxApp', ['ngRoute']);
    var configFunction = function ($routeProvider, $locationProvider) {
       
        $routeProvider.
            when('/', {
                templateUrl: 'App/Templates/Login.html',
                controller: 'LoginController'
            })
        .when('/Home', {
            templateUrl: 'App/Templates/Home.html',
            controller: 'HomeController'
        })
              .when('/Ads/:Category', {
                  
                 
                  templateUrl: 'App/Templates/ViewAds.html',
                  controller: 'ViewAdsController'
    }  ) 
             
        .otherwise({
            redirectTo: '/'
        });
    }

    configFunction.$inject = ['$routeProvider'];
    olxApp.config(configFunction);

    
}(angular));

