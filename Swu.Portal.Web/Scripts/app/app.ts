/// <reference path="../_references.ts" />
module Swu {
    angular
        .module("app", [
            "ui.router",
            "ngMaterial",
            "toastr",
            "ngMessages",
            "ngStorage",
            "ngSanitize"])
        .config(function () {
        })
        .run(['$state', '$http', '$rootScope', function ($state: ng.ui.IStateService, $http: ng.IHttpService, $rootScope:ng.IRootScopeService) {
            $rootScope.$on('$stateChangeSuccess', function () {
                document.body.scrollTop = document.documentElement.scrollTop = 0;
            });
        }]);
}