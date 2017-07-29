/// <reference path="../_references.ts" />
module Swu {
    angular
        .module("app", [
            "ui.router",
            "ngMaterial",
            "toastr",
            "ngMessages",
            "ngStorage"])
        .config(function () {
        })
        .run(['$state', '$http', function ($state: ng.ui.IStateService, $http: ng.IHttpService) {

        }]);
}