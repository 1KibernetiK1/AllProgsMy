/*
 AngularJS - сервис, (как модуль) но проще и
 имеет как правило ограниченный функционал
*/
mainApp.service("ngApiService", function ($http) {
    var urlAPI = "http://localhost:64931/api/";

    this.getName = function () {
        return "ngApiService";
    };

});