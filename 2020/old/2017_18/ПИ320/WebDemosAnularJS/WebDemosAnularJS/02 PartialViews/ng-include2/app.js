var mainApp = angular.module("mainApp", []);

var model = [
    { name: "Вася", age: 17},
    { name: "Петя", age: 16},
    { name: "Коля", age: 18}
];

mainApp.controller("mainCtrl", function ($scope) {
    $scope.items = model;
    $scope.url = "table.html";

    $scope.showList = function () {
        $scope.url = "list.html";
    }
    $scope.showTable = function () {
        $scope.url = "table.html";
    }
});
