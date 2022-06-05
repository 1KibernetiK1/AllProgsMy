
// 1) модель данных
var model =
    [
        { name: "Вася", age: 17},
        { name: "Петя", age: 18},
        { name: "Коля", age: 19}
    ];


// ТОЧКА ВХОДА... - главный модуль
var mainApp = angular.module("mainApp", []);
// 2) контроллер - бизнес логика
mainApp.controller("mainController", function ($scope) {
    // код контроллера
    // $scope - встроенная переменная
    // для обращения к ВЬЮШКЕ
    $scope.studs = model;
    $scope.url = "plug.html";
    $scope.showTable = function () {
        $scope.url = "table.html";
    }
    $scope.showList = function () {
        $scope.url = "list.html";
    }
})