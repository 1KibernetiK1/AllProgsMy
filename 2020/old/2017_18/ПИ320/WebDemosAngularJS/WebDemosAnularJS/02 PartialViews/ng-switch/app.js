var mainApp = angular.module("mainApp", []);

var model = [
    { name: "Вася", age: 17},
    { name: "Петя", age: 16},
    { name: "Коля", age: 18}
];

mainApp.controller("mainCtrl", function ($scope) {
    $scope.items = model;

    $scope.options = [
        { display: "Таблица", value: "table" },
        { display: "Списком", value: "list" },
        { display: "Список с бейдж", value: "budges" }
    ];    

    $scope.current = $scope.options[0];
});
