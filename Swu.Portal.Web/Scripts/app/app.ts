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
        .directive('autocomplete', function () {
            var index = -1;

            return {
                restrict: 'E',
                scope: {
                    searchParam: '=ngModel',
                    suggestions: '=data',
                    onType: '=onType',
                    onSelect: '=onSelect',
                    autocompleteRequired: '=',
                    noAutoSort: '=noAutoSort'
                },
                controller: ['$scope', function ($scope: any) {
                    // the index of the suggestions that's currently selected
                    $scope.selectedIndex = -1;

                    $scope.initLock = true;

                    // set new index
                    $scope.setIndex = function (i: any) {
                        $scope.selectedIndex = parseInt(i);
                    };

                    this.setIndex = function (i: number) {
                        $scope.setIndex(i);
                        $scope.$apply();
                    };

                    $scope.getIndex = function (i: number) {
                        return $scope.selectedIndex;
                    };

                    // watches if the parameter filter should be changed
                    var watching = true;

                    // autocompleting drop down on/off
                    $scope.completing = false;

                    // starts autocompleting on typing in something
                    $scope.$watch('searchParam', function (newValue: any, oldValue: any) {

                        if (oldValue === newValue || (!oldValue && $scope.initLock)) {
                            return;
                        }

                        if (watching && typeof $scope.searchParam !== 'undefined' && $scope.searchParam !== null) {
                            $scope.completing = true;
                            $scope.searchFilter = $scope.searchParam;
                            $scope.selectedIndex = -1;
                        }

                        // function thats passed to on-type attribute gets executed
                        if ($scope.onType)
                            $scope.onType($scope.searchParam);
                    });

                    // for hovering over suggestions
                    this.preSelect = function (suggestion: any) {

                        watching = false;

                        // this line determines if it is shown
                        // in the input field before it's selected:
                        //$scope.searchParam = suggestion;

                        $scope.$apply();
                        watching = true;

                    };

                    $scope.preSelect = this.preSelect;

                    this.preSelectOff = function () {
                        watching = true;
                    };

                    $scope.preSelectOff = this.preSelectOff;

                    // selecting a suggestion with RIGHT ARROW or ENTER
                    $scope.select = function (suggestion: any) {
                        if (suggestion) {
                            $scope.searchParam = suggestion;
                            $scope.searchFilter = suggestion;
                            if ($scope.onSelect)
                                $scope.onSelect(suggestion);
                        }
                        watching = false;
                        $scope.completing = false;
                        setTimeout(function () { watching = true; }, 1000);
                        $scope.setIndex(-1);
                    };


                }],
                link: function (scope: any, element: any, attrs: any) {
                    setTimeout(function () {
                        scope.initLock = false;
                        scope.$apply();
                    }, 250);

                    var attr = '';

                    // Default atts
                    scope.attrs = {
                        "placeholder": "Reference user's name",
                        "class": "",
                        "id": "",
                        "inputclass": "",
                        "inputid": ""
                    };

                    for (var a in attrs) {
                        attr = a.replace('attr', '').toLowerCase();
                        // add attribute overriding defaults
                        // and preventing duplication
                        if (a.indexOf('attr') === 0) {
                            scope.attrs[attr] = attrs[a];
                        }
                    }

                    if (attrs.clickActivation) {
                        element[0].onclick = function (e: any) {
                            if (!scope.searchParam) {
                                setTimeout(function () {
                                    scope.completing = true;
                                    scope.$apply();
                                }, 200);
                            }
                        };
                    }

                    var key = { left: 37, up: 38, right: 39, down: 40, enter: 13, esc: 27, tab: 9 };

                    document.addEventListener("keydown", function (e) {
                        var keycode = e.keyCode || e.which;

                        switch (keycode) {
                            case key.esc:
                                // disable suggestions on escape
                                scope.select();
                                scope.setIndex(-1);
                                scope.$apply();
                                e.preventDefault();
                        }
                    }, true);

                    document.addEventListener("blur", function (e: any) {
                        // disable suggestions on blur
                        // we do a timeout to prevent hiding it before a click event is registered
                        setTimeout(function () {
                            scope.select();
                            scope.setIndex(-1);
                            scope.$apply();
                        }, 150);
                    }, true);

                    element[0].addEventListener("keydown", function (e: any) {
                        var keycode = e.keyCode || e.which;

                        var l = angular.element(this).find('li').length;

                        // this allows submitting forms by pressing Enter in the autocompleted field
                        if (!scope.completing || l == 0) return;

                        // implementation of the up and down movement in the list of suggestions
                        switch (keycode) {
                            case key.up:

                                index = scope.getIndex() - 1;
                                if (index < -1) {
                                    index = l - 1;
                                } else if (index >= l) {
                                    index = -1;
                                    scope.setIndex(index);
                                    scope.preSelectOff();
                                    break;
                                }
                                scope.setIndex(index);

                                if (index !== -1)
                                    scope.preSelect(angular.element(angular.element(this).find('li')[index]).text());

                                scope.$apply();

                                break;
                            case key.down:
                                index = scope.getIndex() + 1;
                                if (index < -1) {
                                    index = l - 1;
                                } else if (index >= l) {
                                    index = -1;
                                    scope.setIndex(index);
                                    scope.preSelectOff();
                                    scope.$apply();
                                    break;
                                }
                                scope.setIndex(index);

                                if (index !== -1)
                                    scope.preSelect(angular.element(angular.element(this).find('li')[index]).text());

                                break;
                            case key.left:
                                break;
                            case key.right:
                            case key.enter:
                            case key.tab:

                                index = scope.getIndex();
                                // scope.preSelectOff();
                                if (index !== -1) {
                                    scope.select(angular.element(angular.element(this).find('li')[index]).text());
                                    if (keycode == key.enter) {
                                        e.preventDefault();
                                    }
                                } else {
                                    if (keycode == key.enter) {
                                        scope.select();
                                    }
                                }
                                scope.setIndex(-1);
                                scope.$apply();

                                break;
                            case key.esc:
                                // disable suggestions on escape
                                scope.select();
                                scope.setIndex(-1);
                                scope.$apply();
                                e.preventDefault();
                                break;
                            default:
                                return;
                        }

                    });
                },
                template: '\
        <div class="autocomplete {{ attrs.class }}" id="{{ attrs.id }}">\
          <input\
            type="text"\
            ng-model="searchParam"\
            placeholder="{{ attrs.placeholder }}"\
            class="{{ attrs.inputclass }}"\
            tabindex="{{ attrs.tabindex }}"\
            id="{{ attrs.inputid }}"\
            name="{{ attrs.name }}"\
            ng-required="{{ autocompleteRequired }}" />\
          <ul ng-if="!noAutoSort" ng-show="completing && (suggestions | filter:searchFilter).length > 0">\
            <li\
              suggestion\
              ng-repeat="suggestion in suggestions | filter:searchFilter | orderBy:\'toString()\' track by $index"\
              index="{{ $index }}"\
              val="{{ suggestion }}"\
              ng-class="{ active: ($index === selectedIndex) }"\
              ng-click="select(suggestion)"\
              ng-bind-html="suggestion | highlight:searchParam"></li>\
          </ul>\
          <ul ng-if="noAutoSort" ng-show="completing && (suggestions | filter:searchFilter).length > 0">\
            <li\
              suggestion\
              ng-repeat="suggestion in suggestions | filter:searchFilter track by $index"\
              index="{{ $index }}"\
              val="{{ suggestion }}"\
              ng-class="{ active: ($index === selectedIndex) }"\
              ng-click="select(suggestion)"\
              ng-bind-html="suggestion | highlight:searchParam"></li>\
          </ul>\
        </div>'
            };
        })
        .config(["$translateProvider", "AppConstant", "$mdDateLocaleProvider", function ($translateProvider: any, AppConstant: AppConstant, $mdDateLocaleProvider: any) {
            $translateProvider.translations("en", translations_en);
            $translateProvider.translations("th", translations_th);
            $translateProvider.preferredLanguage(AppConstant.defaultLang);
            $translateProvider.fallbackLanguage(AppConstant.defaultLang);
            $mdDateLocaleProvider.formatDate = function (date: any) {
                return moment(date).format('DD/MM/YYYY');
            };
        }])
        .filter('highlight', ['$sce', function ($sce: ng.ISCEService) {
            return function (input: any, searchParam: any) {
                if (typeof input === 'function') return '';
                if (searchParam) {
                    var words = '(' +
                        searchParam.split(/\ /).join(' |') + '|' +
                        searchParam.split(/\ /).join('|') +
                        ')',
                        exp = new RegExp(words, 'gi');
                    if (words.length) {
                        input = input.replace(exp, "<span class=\"highlight\">$1</span>");
                    }
                }
                return $sce.trustAsHtml(input);
            };
        }])
        .directive('suggestion', function () {
            return {
                restrict: 'A',
                require: '^autocomplete', // ^look for controller on parents element
                link: function (scope:any, element:any, attrs:any, autoCtrl:any) {
                    element.bind('mouseenter', function () {
                        autoCtrl.preSelect(attrs.val);
                        autoCtrl.setIndex(attrs.index);
                    });

                    element.bind('mouseleave', function () {
                        autoCtrl.preSelectOff();
                    });
                }
            };
        })
        .run(["$state", "$http", "$rootScope", "AppConstant", "AuthServices", "$window", function ($state: ng.ui.IStateService, $http: ng.IHttpService, $rootScope: IRootScope, AppConstant: AppConstant, auth: IAuthServices, $window: ng.IWindowService) {
            $rootScope.$on("$stateChangeSuccess", function () {
                var exceptGotoTopStateList = AppConstant.exceptGotoTopStateList;
                var result = _.contains(exceptGotoTopStateList, $state.current.name);
                if (!result) {
                    document.body.scrollTop = document.documentElement.scrollTop = 0;
                }
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