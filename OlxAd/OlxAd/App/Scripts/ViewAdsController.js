(function (angular) {
    //'use strict';

    angular.module('olxApp').controller('ViewAdsController', ['$scope', '$http', '$location', '$routeParams', function ($scope, $http, $location, $routeParams) {
        $scope.InsertAds = { Image: "", Phone: "bfghh", Address: "gsgsghsfhfd", ItemType: "", Id: 0, UserNo: 0 }
        $scope.itemsPerPage = 3;
        $scope.currentPage = 0;
        //For paging----------------------------------------



        //-For Paging-------------------------------------

       

        function init() {
            var apiParams = { Category: $routeParams.Category };
            $http.get('/ViewAds/_Ads', { params: apiParams }).then(function (response) {
                //alert(response.data.length);
                $scope.InsertAds = response.data;
                //$scope.items = response.data.length;
                
            })
        }

       


        init();

    }]

    )
}(angular));