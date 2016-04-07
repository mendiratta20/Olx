(function (angular) {
    'use strict';

    angular.module('olxApp').controller('LoginController', ['$scope','$http','$location', function ($scope,$http,$location) {
        $scope.Users = { Name: "", Password:""}
       

        $scope.Login = function (Users) {
          

            $http({
                url: '/Registration/Login',
                method: 'POST',
                data: $scope.Users
            }).then(function (response) {
                alert(response.data);

                 if(response.data=="True")
                {
                     $location.path('/Home');
                }
                else if(response.data=="False"){
                    alert("Login Failed")
                }
            });
        }
       
    }]

    )
}(angular));
