var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var ngAnnotations;
(function (ngAnnotations) {
    'use strict';
    function Module(name) {
        return provideAngularComponent;
        function provideAngularComponent(constrFn) {
            constrFn.$$annotationConfig.providerFn(name, constrFn);
        }
    }
    ngAnnotations.Module = Module;
    function Config(constrFn) {
        constrFn.$$annotationConfig = { providerFn: _provideConfig };
    }
    ngAnnotations.Config = Config;
    function Constant(config) {
        config.providerFn = _provideConstant;
        return _decorateProviderClass(config);
    }
    ngAnnotations.Constant = Constant;
    function Controller(config) {
        config.providerFn = _provideController;
        return _decorateProviderClass(config);
    }
    ngAnnotations.Controller = Controller;
    function Directive(config) {
        config.providerFn = _provideDirective;
        return _decorateProviderClass(config);
    }
    ngAnnotations.Directive = Directive;
    function Factory(config) {
        config.providerFn = _provideFactory;
        return _decorateProviderClass(config);
    }
    ngAnnotations.Factory = Factory;
    function Provider(config) {
        config.providerFn = _provideProvider;
        return _decorateProviderClass(config);
    }
    ngAnnotations.Provider = Provider;
    function Run(constrFn) {
        constrFn.$$annotationConfig = { providerFn: _provideRun };
    }
    ngAnnotations.Run = Run;
    function Service(config) {
        config.providerFn = _provideService;
        return _decorateProviderClass(config);
    }
    ngAnnotations.Service = Service;
    function Value(config) {
        config.providerFn = _provideValue;
        return _decorateProviderClass(config);
    }
    ngAnnotations.Value = Value;
    function Decorator(config) {
        config.providerFn = _provideDecorator;
        return _decorateProviderClass(config);
    }
    ngAnnotations.Decorator = Decorator;
    function Filter(config) {
        config.providerFn = _provideFilter;
        return _decorateProviderClass(config);
    }
    ngAnnotations.Filter = Filter;
    function _decorateProviderClass(config) {
        return function (constrFn) {
            constrFn.$$annotationConfig = config;
        };
    }
    function _provideConfig(module, constrFn) {
        angular.module(module).config(_normalizeFunction(constrFn));
    }
    function _provideConstant(module, constrFn) {
        var constant = angular.isFunction(constrFn) ? new constrFn() : constrFn;
        var name = constrFn.$$annotationConfig.name;
        angular.module(module).constant(name, constant);
    }
    function _provideController(module, constrFn) {
        var config = constrFn.$$annotationConfig;
        var name = config.name;
        angular.module(module).controller(name, _normalizeFunction(constrFn));
        if (config.when) {
            var routeConfig = ['$routeProvider', function ($routeProvider) {
                    $routeProvider.when(config.when.path, config.when.route);
                }];
            angular.module(module).config(routeConfig);
        }
    }
    function _provideDirective(module, constrFn) {
        if (!constrFn.prototype.compile) {
            constrFn.prototype.compile = function () {
            };
        }
        var originalCompileFn = _cloneFunction(constrFn.prototype.compile);
        _override(constrFn.prototype, 'compile', function () {
            return function () {
                originalCompileFn.apply(this, arguments);
                if (constrFn.prototype.link) {
                    return constrFn.prototype.link.bind(this);
                }
            };
        });
        var inlineArrayAnnotation = _createInlineArrayAnnotation(_normalizeFunction(constrFn));
        var name = constrFn.$$annotationConfig.name;
        angular.module(module).directive(_toCamelCase(name), inlineArrayAnnotation);
    }
    function _provideFactory(module, constrFn) {
        var inlineArrayAnnotation = _createInlineArrayAnnotation(_normalizeFunction(constrFn));
        var name = constrFn.$$annotationConfig.name;
        angular.module(module).factory(name, inlineArrayAnnotation);
    }
    function _provideProvider(module, constrFn) {
        var config = constrFn.$$annotationConfig;
        var name = config.name;
        var providerName = name.replace(/[pP]+rovider/i, '');
        angular.module(module).provider(providerName, _createServiceProvider(constrFn));
    }
    function _provideService(module, constrFn) {
        var name = constrFn.$$annotationConfig.name;
        angular.module(module).service(name, _normalizeFunction(constrFn));
    }
    function _provideRun(module, constrFn) {
        angular.module(module).run(_normalizeFunction(constrFn));
    }
    function _provideValue(module, constrFn) {
        var val = angular.isFunction(constrFn) ? new constrFn() : constrFn;
        var name = constrFn.$$annotationConfig.name;
        angular.module(module).value(name, val);
    }
    function _provideDecorator(module, constrFn) {
        angular.module(module).config(['$provide', function ($provide) {
                var name = constrFn.$$annotationConfig.name;
                $provide.decorator(name, constrFn);
            }]);
    }
    function _provideFilter(module, constrFn) {
        var name = constrFn.$$annotationConfig.name;
        angular.module(module).filter(name, constrFn);
    }
    function _createInlineArrayAnnotation(constrFn, provider) {
        var injects = constrFn.$inject || [];
        var inlineArrayAnnotation = injects.slice();
        inlineArrayAnnotation.push(function () {
            var args = [];
            for (var _i = 0; _i < arguments.length; _i++) {
                args[_i - 0] = arguments[_i];
            }
            args.unshift(this);
            var instance = new (Function.prototype.bind.apply(constrFn, args));
            return instance;
        });
        return inlineArrayAnnotation;
    }
    function _cloneFunction(original) {
        return function () {
            return original.apply(this, arguments);
        };
    }
    function _override(object, methodName, callback) {
        object[methodName] = callback(object[methodName]);
    }
    function _normalizeFunction(constrFn) {
        if (constrFn.$inject) {
            return constrFn;
        }
        else {
            var paramNames = _getParamNames(constrFn);
            constrFn.$inject = paramNames;
            return constrFn;
        }
    }
    function _getParamNames(constrFn) {
        var STRIP_COMMENTS = /((\/\/.*$)|(\/\*[\s\S]*?\*\/))/mg;
        var ARGUMENT_NAMES = /([^\s,]+)/g;
        var fnStr = constrFn.toString().replace(STRIP_COMMENTS, '');
        var result = fnStr.slice(fnStr.indexOf('(') + 1, fnStr.indexOf(')')).match(ARGUMENT_NAMES);
        if (result === null)
            result = [];
        return result;
    }
    function _toCamelCase(str) {
        return str
            .replace(/\s(.)/g, function ($1) {
            return $1.toUpperCase();
        })
            .replace(/\s/g, '')
            .replace(/^(.)/, function ($1) {
            return $1.toLowerCase();
        });
    }
    function _createServiceProvider(constrFn) {
        var config = constrFn.$$annotationConfig;
        var injects = config.service.$inject || [];
        var inlineArrayAnnotation = injects.slice(1);
        inlineArrayAnnotation.push(function () {
            var args = [];
            for (var _i = 0; _i < arguments.length; _i++) {
                args[_i - 0] = arguments[_i];
            }
            args.unshift(null, this);
            var instance = new (Function.prototype.bind.apply(config.service, args));
            return instance;
        });
        constrFn.prototype.$get = inlineArrayAnnotation;
        return _createInlineArrayAnnotation(constrFn);
    }
})(ngAnnotations || (ngAnnotations = {}));
var Swu;
(function (Swu) {
    "use strict";
    Swu.Module = ngAnnotations.Module;
    Swu.Config = ngAnnotations.Config;
    Swu.Constant = ngAnnotations.Constant;
    Swu.Controller = ngAnnotations.Controller;
    Swu.Directive = ngAnnotations.Directive;
    Swu.Factory = ngAnnotations.Factory;
    Swu.Provider = ngAnnotations.Provider;
    Swu.Run = ngAnnotations.Run;
    Swu.Service = ngAnnotations.Service;
    Swu.Value = ngAnnotations.Value;
    Swu.Filter = ngAnnotations.Filter;
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var underscore = angular.module('underscore', []);
    underscore.factory('_', ['$window', function ($window) {
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
        .run(['$state', '$http', '$rootScope', 'AppConstant', function ($state, $http, $rootScope, AppConstant) {
            $rootScope.$on('$stateChangeSuccess', function () {
                var exceptGotoTopStateList = AppConstant.exceptGotoTopStateList;
                var result = _.contains(exceptGotoTopStateList, $state.current.name);
                if (!result) {
                    document.body.scrollTop = document.documentElement.scrollTop = 0;
                }
            });
        }]);
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var AppConstant = (function () {
        function AppConstant() {
            this.api = {
                protocal: "http",
                ip: "localhost",
                port: "8081",
                versionName: "V1"
            };
            this.exceptGotoTopStateList = [
                "settings",
                "settings.courses"
            ];
        }
        AppConstant = __decorate([
            Swu.Module("app"),
            Swu.Constant({ name: "AppConstant" })
        ], AppConstant);
        return AppConstant;
    }());
    Swu.AppConstant = AppConstant;
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var apiService = (function () {
        function apiService($q, $http, constant) {
            this.$q = $q;
            this.$http = $http;
            this.constant = constant;
        }
        apiService.prototype.getData = function (url) {
            var def = this.$q.defer();
            var url = this.constant.api.versionName + "/" + url;
            this.$http.get(url)
                .then(function (successResponse) {
                if (successResponse)
                    def.resolve(successResponse.data);
                else
                    def.reject('server error');
            }, function (errorRes) {
                def.reject(errorRes.statusText);
            });
            return def.promise;
        };
        apiService.prototype.postData = function (data, url, contentType) {
            var url = this.constant.api.versionName + "/" + url;
            var def = this.$q.defer();
            this.$http({
                url: url,
                method: 'POST',
                data: data,
                withCredentials: true,
                headers: {
                    'Content-Type': contentType || 'application/json'
                }
            }).then(function (successResponse) {
                def.resolve(successResponse.data);
            }, function (errorRes) {
                def.reject(errorRes);
            });
            return def.promise;
        };
        apiService.$inject = ['$q', '$http', 'AppConstant'];
        apiService = __decorate([
            Swu.Module("app"),
            Swu.Factory({ name: "apiService" })
        ], apiService);
        return apiService;
    }());
    Swu.apiService = apiService;
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var loginModal = (function () {
        function loginModal() {
            this.restric = "A";
        }
        loginModal.prototype.link = function (scope, element, attrs) {
            scope.$watch(attrs.loginModal, function (value) {
                if (value)
                    element.modal('show');
                else
                    element.modal('hide');
            });
        };
        loginModal = __decorate([
            Swu.Module("app"),
            Swu.Directive({ name: "loginModal" })
        ], loginModal);
        return loginModal;
    }());
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var LoginController = (function () {
        function LoginController($scope, $state, loginServices) {
            var _this = this;
            this.$scope = $scope;
            this.$state = $state;
            this.loginServices = loginServices;
            this.$scope.showModal = false;
            this.$scope.ShowModalLogin = function (flag) {
                _this.$scope.showModal = flag;
            };
            this.$scope.Login = function () {
                console.log({ "userName": _this.$scope.userName, "password": _this.$scope.password });
                _this.loginServices.login({ "userName": _this.$scope.userName, "password": _this.$scope.password }).then(function (data) {
                    _this.$scope.userProfile = data;
                    _this.$scope.showModal = false;
                }, function (error) {
                });
            };
            this.$scope.isLogin = function () {
                return !(_this.$scope.userProfile == undefined || _this.$scope.userProfile == null);
            };
        }
        LoginController.$inject = ["$scope", "$state", "loginServices"];
        LoginController = __decorate([
            Swu.Module("app"),
            Swu.Controller({ name: "LoginController" })
        ], LoginController);
        return LoginController;
    }());
    Swu.LoginController = LoginController;
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var LoginServices = (function () {
        function LoginServices(apiService, constant) {
            this.apiService = apiService;
            this.constant = constant;
        }
        LoginServices.prototype.login = function (user) {
            return this.apiService.postData(user, "account/login");
        };
        LoginServices.$inject = ['apiService', 'AppConstant'];
        LoginServices = __decorate([
            Swu.Module("app"),
            Swu.Factory({ name: "loginServices" })
        ], LoginServices);
        return LoginServices;
    }());
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var StateConfig = (function () {
        function StateConfig($stateProvider, $urlRouterProvider, $locationProvider, $httpProvider) {
            this.$stateProvider = $stateProvider;
            this.$urlRouterProvider = $urlRouterProvider;
            this.$locationProvider = $locationProvider;
            this.$httpProvider = $httpProvider;
        }
        StateConfig.$inject = ["$stateProvider", "$urlRouterProvider", "$locationProvider", "$httpProvider"];
        StateConfig = __decorate([
            Swu.Module("app"),
            Swu.Config
        ], StateConfig);
        return StateConfig;
    }());
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var StateConfig = (function () {
        function StateConfig($stateProvider, $urlRouterProvider, $locationProvider, $httpProvider) {
            this.$stateProvider = $stateProvider;
            this.$urlRouterProvider = $urlRouterProvider;
            this.$locationProvider = $locationProvider;
            this.$httpProvider = $httpProvider;
            $urlRouterProvider.otherwise("/app");
            $stateProvider
                .state("app", {
                url: "/app",
                templateUrl: "/Scripts/app/home/index.html",
                controller: "HomeController as vm"
            });
        }
        StateConfig.$inject = ["$stateProvider", "$urlRouterProvider", "$locationProvider", "$httpProvider"];
        StateConfig = __decorate([
            Swu.Module("app"),
            Swu.Config
        ], StateConfig);
        return StateConfig;
    }());
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var StateConfig = (function () {
        function StateConfig($stateProvider, $urlRouterProvider, $locationProvider, $httpProvider) {
            this.$stateProvider = $stateProvider;
            this.$urlRouterProvider = $urlRouterProvider;
            this.$locationProvider = $locationProvider;
            this.$httpProvider = $httpProvider;
            $stateProvider
                .state("course", {
                url: "/course/:id",
                templateUrl: "/Scripts/app/course/course_detail.html",
                controller: "CourseController as vm"
            })
                .state("course-list", {
                url: "/course-list",
                templateUrl: "/Scripts/app/course/course_list.html",
                controller: "CourseListController as vm"
            });
        }
        StateConfig.$inject = ["$stateProvider", "$urlRouterProvider", "$locationProvider", "$httpProvider"];
        StateConfig = __decorate([
            Swu.Module("app"),
            Swu.Config
        ], StateConfig);
        return StateConfig;
    }());
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var StateConfig = (function () {
        function StateConfig($stateProvider, $urlRouterProvider, $locationProvider, $httpProvider) {
            this.$stateProvider = $stateProvider;
            this.$urlRouterProvider = $urlRouterProvider;
            this.$locationProvider = $locationProvider;
            this.$httpProvider = $httpProvider;
            $stateProvider
                .state("teacher", {
                url: "/teacher/:id",
                templateUrl: "/Scripts/app/teacher/teacher_detail.html",
                controller: "TeacherController as vm"
            })
                .state("teacher-list", {
                url: "/teacher-list",
                templateUrl: "/Scripts/app/teacher/teacher_list.html",
                controller: "TeacherListController as vm"
            });
        }
        StateConfig.$inject = ["$stateProvider", "$urlRouterProvider", "$locationProvider", "$httpProvider"];
        StateConfig = __decorate([
            Swu.Module("app"),
            Swu.Config
        ], StateConfig);
        return StateConfig;
    }());
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var StateConfig = (function () {
        function StateConfig($stateProvider, $urlRouterProvider, $locationProvider, $httpProvider) {
            this.$stateProvider = $stateProvider;
            this.$urlRouterProvider = $urlRouterProvider;
            this.$locationProvider = $locationProvider;
            this.$httpProvider = $httpProvider;
            $stateProvider
                .state("research", {
                url: "/research/:id",
                templateUrl: "/Scripts/app/research/research_detail.html",
                controller: "CourseController as vm"
            })
                .state("research-list", {
                url: "/research-list",
                templateUrl: "/Scripts/app/research/research_list.html",
                controller: "CourseListController as vm"
            });
        }
        StateConfig.$inject = ["$stateProvider", "$urlRouterProvider", "$locationProvider", "$httpProvider"];
        StateConfig = __decorate([
            Swu.Module("app"),
            Swu.Config
        ], StateConfig);
        return StateConfig;
    }());
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var StateConfig = (function () {
        function StateConfig($stateProvider, $urlRouterProvider, $locationProvider, $httpProvider) {
            this.$stateProvider = $stateProvider;
            this.$urlRouterProvider = $urlRouterProvider;
            this.$locationProvider = $locationProvider;
            this.$httpProvider = $httpProvider;
            $stateProvider
                .state("contact", {
                url: "/contact",
                templateUrl: "/Scripts/app/contact/contact.html",
                controller: "ContactUsController as vm"
            });
        }
        StateConfig.$inject = ["$stateProvider", "$urlRouterProvider", "$locationProvider", "$httpProvider"];
        StateConfig = __decorate([
            Swu.Module("app"),
            Swu.Config
        ], StateConfig);
        return StateConfig;
    }());
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var StateConfig = (function () {
        function StateConfig($stateProvider, $urlRouterProvider, $locationProvider, $httpProvider) {
            this.$stateProvider = $stateProvider;
            this.$urlRouterProvider = $urlRouterProvider;
            this.$locationProvider = $locationProvider;
            this.$httpProvider = $httpProvider;
            $stateProvider
                .state("settings", {
                url: "/settings",
                views: {
                    '': { templateUrl: '/Scripts/app/settings/main.html' },
                    'subContent@settings': {
                        templateUrl: '/Scripts/app/settings/default.html',
                        controller: 'SettingCoursesController as vm'
                    }
                }
            })
                .state("settings.courses", {
                parent: "settings",
                url: "/courses",
                views: {
                    'subContent@settings': {
                        templateUrl: '/Scripts/app/settings/courses.html',
                        controller: 'SettingCoursesController as vm'
                    }
                }
            });
        }
        StateConfig.$inject = ["$stateProvider", "$urlRouterProvider", "$locationProvider", "$httpProvider"];
        StateConfig = __decorate([
            Swu.Module("app"),
            Swu.Config
        ], StateConfig);
        return StateConfig;
    }());
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var HomeController = (function () {
        function HomeController($scope, $state) {
            this.$scope = $scope;
            this.$state = $state;
        }
        HomeController.prototype.showMessage = function () {
            alert('test');
        };
        HomeController.prototype.init = function () {
        };
        ;
        HomeController.$inject = ["$scope", "$state"];
        HomeController = __decorate([
            Swu.Module("app"),
            Swu.Controller({ name: "HomeController" })
        ], HomeController);
        return HomeController;
    }());
    Swu.HomeController = HomeController;
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var HomeCourseController = (function () {
        function HomeCourseController($scope, $state, homeCourseService) {
            this.$scope = $scope;
            this.$state = $state;
            this.homeCourseService = homeCourseService;
            this.init();
        }
        HomeCourseController.prototype.init = function () {
            var _this = this;
            this.homeCourseService.getCourses().then(function (response) {
                _this.$scope.CourseCards = response;
                _this.$scope.TopRateCourse = _.filter(_this.$scope.CourseCards, function (course) {
                    return course.cardType == Swu.CardType.topRate;
                });
                _this.$scope.PopularCourse = _.filter(_this.$scope.CourseCards, function (course) {
                    return course.cardType == Swu.CardType.popular;
                });
                _this.$scope.RecentlyCourse = _.filter(_this.$scope.CourseCards, function (course) {
                    return course.cardType == Swu.CardType.recently;
                });
            }, function (error) { });
        };
        ;
        HomeCourseController.$inject = ["$scope", "$state", "homeCourseService"];
        HomeCourseController = __decorate([
            Swu.Module("app"),
            Swu.Controller({ name: "HomeCourseController" })
        ], HomeCourseController);
        return HomeCourseController;
    }());
    Swu.HomeCourseController = HomeCourseController;
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var homeCourseService = (function () {
        function homeCourseService(apiService, constant) {
            this.apiService = apiService;
            this.constant = constant;
        }
        homeCourseService.prototype.getCourses = function () {
            return this.apiService.getData("course/all");
        };
        homeCourseService.$inject = ['apiService', 'AppConstant'];
        homeCourseService = __decorate([
            Swu.Module("app"),
            Swu.Factory({ name: "homeCourseService" })
        ], homeCourseService);
        return homeCourseService;
    }());
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var CourseController = (function () {
        function CourseController($scope, $state) {
            this.$scope = $scope;
            this.$state = $state;
        }
        CourseController.prototype.showMessage = function () {
            alert('test');
        };
        CourseController.prototype.init = function () {
        };
        ;
        CourseController.$inject = ["$scope", "$state"];
        CourseController = __decorate([
            Swu.Module("app"),
            Swu.Controller({ name: "CourseController" })
        ], CourseController);
        return CourseController;
    }());
    Swu.CourseController = CourseController;
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var CourseListController = (function () {
        function CourseListController($scope, $state) {
            this.$scope = $scope;
            this.$state = $state;
        }
        CourseListController.prototype.showMessage = function () {
            alert('test');
        };
        CourseListController.prototype.init = function () {
        };
        ;
        CourseListController.$inject = ["$scope", "$state"];
        CourseListController = __decorate([
            Swu.Module("app"),
            Swu.Controller({ name: "CourseListController" })
        ], CourseListController);
        return CourseListController;
    }());
    Swu.CourseListController = CourseListController;
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var TeacherController = (function () {
        function TeacherController($scope, $state) {
            this.$scope = $scope;
            this.$state = $state;
        }
        TeacherController.prototype.showMessage = function () {
            alert('test');
        };
        TeacherController.prototype.init = function () {
        };
        ;
        TeacherController.$inject = ["$scope", "$state"];
        TeacherController = __decorate([
            Swu.Module("app"),
            Swu.Controller({ name: "TeacherController" })
        ], TeacherController);
        return TeacherController;
    }());
    Swu.TeacherController = TeacherController;
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var TeacherListController = (function () {
        function TeacherListController($scope, $state) {
            this.$scope = $scope;
            this.$state = $state;
        }
        TeacherListController.prototype.init = function () {
        };
        ;
        TeacherListController.$inject = ["$scope", "$state"];
        TeacherListController = __decorate([
            Swu.Module("app"),
            Swu.Controller({ name: "TeacherListController" })
        ], TeacherListController);
        return TeacherListController;
    }());
    Swu.TeacherListController = TeacherListController;
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var ResearchController = (function () {
        function ResearchController($scope, $state) {
            this.$scope = $scope;
            this.$state = $state;
        }
        ResearchController.prototype.showMessage = function () {
            alert('test');
        };
        ResearchController.prototype.init = function () {
        };
        ;
        ResearchController.$inject = ["$scope", "$state"];
        ResearchController = __decorate([
            Swu.Module("app"),
            Swu.Controller({ name: "ResearchController" })
        ], ResearchController);
        return ResearchController;
    }());
    Swu.ResearchController = ResearchController;
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var ResearchListController = (function () {
        function ResearchListController($scope, $state) {
            this.$scope = $scope;
            this.$state = $state;
        }
        ResearchListController.prototype.showMessage = function () {
            alert('test');
        };
        ResearchListController.prototype.init = function () {
        };
        ;
        ResearchListController.$inject = ["$scope", "$state"];
        ResearchListController = __decorate([
            Swu.Module("app"),
            Swu.Controller({ name: "ResearchListController" })
        ], ResearchListController);
        return ResearchListController;
    }());
    Swu.ResearchListController = ResearchListController;
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var ContactUsController = (function () {
        function ContactUsController($scope, $state) {
            this.$scope = $scope;
            this.$state = $state;
        }
        ContactUsController.prototype.init = function () {
        };
        ;
        ContactUsController.$inject = ["$scope", "$state"];
        ContactUsController = __decorate([
            Swu.Module("app"),
            Swu.Controller({ name: "ContactUsController" })
        ], ContactUsController);
        return ContactUsController;
    }());
    Swu.ContactUsController = ContactUsController;
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var SettingCoursesController = (function () {
        function SettingCoursesController($scope, $state) {
            this.$scope = $scope;
            this.$state = $state;
        }
        SettingCoursesController.prototype.init = function () {
        };
        ;
        SettingCoursesController.$inject = ["$scope", "$state"];
        SettingCoursesController = __decorate([
            Swu.Module("app"),
            Swu.Controller({ name: "SettingCoursesController" })
        ], SettingCoursesController);
        return SettingCoursesController;
    }());
    Swu.SettingCoursesController = SettingCoursesController;
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    (function (CardType) {
        CardType[CardType["topRate"] = 1] = "topRate";
        CardType[CardType["popular"] = 2] = "popular";
        CardType[CardType["recently"] = 3] = "recently";
    })(Swu.CardType || (Swu.CardType = {}));
    var CardType = Swu.CardType;
})(Swu || (Swu = {}));
