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
            "pascalprecht.translate",
            "ngCookies",
            "summernote"
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
            return function (html: any) {
                return $sce.trustAsHtml(html);
            };
        }])
        .directive('compile', ['$compile', function ($compile: ng.ICompileService) {
            return function (scope: ng.IScope, element: any, attrs: any) {
                scope.$watch(
                    function (scope) {
                        return scope.$eval(attrs.compile);
                    },
                    function (value) {
                        element.html(value);
                        $compile(element.contents())(scope);
                    }
                )
            }
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
        .run(["$state", "$http", "$rootScope", "AppConstant", "AuthServices", "$window", function ($state: ng.ui.IStateService, $http: ng.IHttpService, $rootScope: IRootScope, AppConstant: AppConstant, auth: IAuthServices, $window: ng.IWindowService) {
            $rootScope.$on("$stateChangeSuccess", function () {
                var exceptGotoTopStateList = AppConstant.exceptGotoTopStateList;
                var result = _.contains(exceptGotoTopStateList, $state.current.name);
                if (!result) {
                    document.body.scrollTop = document.documentElement.scrollTop = 0;
                }
                //if (_.contains(AppConstant.authorizeStateList, $state.current.name)) {
                //    if (auth.isLoggedIn() == false) {
                //        $state.go("app", { reload: true });
                //    }
                //}
                var permission = _.filter(AppConstant.authorizeStateList, (item: any, index: number) => { return item.name == $state.current.name })[0];
                if (permission != null) {
                    if (auth.isLoggedIn()) {
                        if (!_.contains(permission.roles, auth.getCurrentUser().selectedRoleName)) {
                            $state.go("app", { reload: true });
                        }
                    } else {
                        $state.go("app", { reload: true });
                    }
                }
            });
            $rootScope.lang = AppConstant.defaultLang;
            $rootScope.scrollToToped = () => {
                $('html, body').animate({ scrollTop: 0 }, 800);
            };
        }]);
}