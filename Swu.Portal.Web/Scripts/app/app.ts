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
        scrollToToped(): void;
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
            "pascalprecht.translate"
        ])
        .filter('range', function rangeFilter() {
            return function (input: number[], total: number) {
                for (var i = 0; i < total; i++) {
                    input.push(i);
                }
                return input;
            };
        })
        .filter('trustAsHtml', ['$sce', function ($sce: ng.ISCEService) {
            return function (html:any) {
                return $sce.trustAsHtml(html);
            };
        }])
        .config(["$translateProvider", "AppConstant", "$mdDateLocaleProvider", function ($translateProvider: any, AppConstant: AppConstant, $mdDateLocaleProvider: any) {
            $translateProvider.translations("en", translations_en);
            $translateProvider.translations("th", translations_th);
            $translateProvider.preferredLanguage(AppConstant.defaultLang);
            $translateProvider.fallbackLanguage(AppConstant.defaultLang);
            $mdDateLocaleProvider.formatDate = function (date: any) {
                return moment(date).format('DD/MM/YYYY');
            };
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
            $rootScope.scrollToToped = () => {
                $('html, body').animate({ scrollTop: 0 }, 800);
            };
        }]);
}