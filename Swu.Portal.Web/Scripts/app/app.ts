/// <reference path="../_references.ts" />
module Swu {
    var underscore = angular.module('underscore', []);
    underscore.factory('_', ['$window', function ($window: any) {
        return $window._;
    }]);
    angular
        .module("app", [
            "ui.router",
            "ngMaterial",
            "toastr",
            "ngMessages",
            "ngStorage",
            "ngSanitize",
            "underscore",
            "ui.bootstrap"
        ])
        .run(['$state', '$http', '$rootScope', 'AppConstant', function ($state: ng.ui.IStateService, $http: ng.IHttpService, $rootScope: ng.IRootScopeService, AppConstant: AppConstant) {
            $rootScope.$on('$stateChangeSuccess', function () {
                var exceptGotoTopStateList = AppConstant.exceptGotoTopStateList;
                var result = _.contains(exceptGotoTopStateList, $state.current.name);
                if (!result) {
                    document.body.scrollTop = document.documentElement.scrollTop = 0;
                }
            });
        }]);
}