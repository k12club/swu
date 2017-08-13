/// <reference path="../_references.ts" />
/// <reference path="../translate/translations.en.ts" />
/// <reference path="../translate/translations.th.ts" />

module Swu {
    var underscore = angular.module('underscore', []);
    underscore.factory('_', ['$window', function ($window: any) {
        return $window._;
    }]);
    export interface IRootScope extends ng.IRootScopeService {
        lang: string;
    }
    angular
        .module("app", [
            "ui.router",
            "ngMaterial",
            "toastr",
            "ngMessages",
            "ngStorage",
            "ngSanitize",
            "underscore",
            "ui.bootstrap",
            "pascalprecht.translate",
        ])
        .config(["$translateProvider", "AppConstant", function ($translateProvider: any, AppConstant: AppConstant, $rootScope:any) {
            $translateProvider.translations("en", translations_en);
            $translateProvider.translations("th", translations_th);
            $translateProvider.preferredLanguage(AppConstant.defaultLang);
            $translateProvider.fallbackLanguage(AppConstant.defaultLang);
        }])
        .run(["$state", "$http", "$rootScope", "AppConstant", function ($state: ng.ui.IStateService, $http: ng.IHttpService, $rootScope: IRootScope, AppConstant: AppConstant) {
            $rootScope.$on("$stateChangeSuccess", function () {
                var exceptGotoTopStateList = AppConstant.exceptGotoTopStateList;
                var result = _.contains(exceptGotoTopStateList, $state.current.name);
                if (!result) {
                    document.body.scrollTop = document.documentElement.scrollTop = 0;
                }
            });
            $rootScope.lang = AppConstant.defaultLang;
        }]);
}