(function (angular) {
    'use strict';

    angular.module('olxApp').controller('HomeController', ['$scope', '$http', '$controller', '$location',function ($scope, $http, $controller,$location) {
        $scope.InsertAds = { Image: "", Phone: "bfghh" , Address:"gsgsghsfhfd",ItemType:"",Id:0,UserNo:0}


        
         $scope.getAds = function (CategoryValue) {

             $location.path('/Ads/'+ CategoryValue)

             //$location.path('/Ads/').search({ Category: CategoryValue });
        }
    
        

       
    }]

    )
}(angular));




