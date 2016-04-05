/// <reference path="angular.js" />

var app = angular.module("mymodule", []);
var mycontroller = function ($scope) {
    $scope.message = "angular";
}

//app.controller("mycontroller",mycontroller)

app.controller("mycontroller", function ($scope) {
    $scope.message = "angular";
})