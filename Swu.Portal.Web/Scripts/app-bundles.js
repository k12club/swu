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
    Swu.translations_en = {
        shared: {
            applicationName: "SWU-Joint Medical",
            address: "114 Sukhumvit 23Wattana, Bangkok 10110 Thailand",
            phone: "+66 2649 5000"
        },
        login: {
            anyQuestions: "Any Questions?",
            callUs: "Call Us",
            login: "Login",
            register: "Register",
            loginAs: "",
            loginOrRegister: "Login or Register",
            description: "Sign in or register today in order to have access to all our courses or purchase new ones.",
            loginTitle: "Enter username and password to login:",
            registerTitle: "Join our community today:",
            btnLogin: "Login to account",
            btnRegister: "Sign Me Up",
            userName: "User Name",
            firstName: "First Name",
            lastName: "Last Name",
            password: "Password",
            rePassword: "Re-Password",
            email: "Email"
        },
        menu: {
            home: "Home",
            aboutUs: "About Us",
            history: "History",
            visionAndMission: "Vision And Mission",
            ethics: "Ethics",
            departments: "Departments",
            courses: "Courses",
            research: "Research",
            ourPeoples: "OurPeoples",
            teacher: "Teacher",
            contact: "Contact",
            committee: "Programme Commitee"
        },
        home: {},
        course: {
            all: "All Courses",
            topRated: "Top Rated",
            mostPopular: "Most Popular",
            recentlyAdded: "Recently Added"
        },
        registration: {
            identityCardNumber: "IDENTITY CARD NUMBER",
            fullName: "FULL NAME",
            register: "Register today"
        },
        event: {
            title: "Our Edu Hub Events",
            description: "Events listed here are open to everyone. Whether you want to listen to a lecture, learn a new skill, take in a concert or an exhibition, see a play staged by our university students or attend one of our sporting events."
        },
        commitments: {
            title: "Objectives"
        },
        video: {
            title: "Campus Videos"
        },
        news: {
            title: "Edu Hub News"
        },
        testimonials: {
            title: "Our Happy Students",
            description: "Our alumni are very content with our classes and 99% of them managed to find a job in their field. Check out our full testimonials from our best students worldwide.",
            checkfaq: "Check our FAQ’s",
            thumb1: {
                quote: "“The lectures & tutorials are interesting academically stimulating, and applied to real-world case studies which is extremely useful.”",
                by: "Jaqueline Smith",
                position: "BA Hons Business Management"
            },
            thumb2: {
                quote: "“The lectures & tutorials are interesting academically stimulating, and applied to real-world case studies which is extremely useful.”",
                by: "Jaqueline Smith",
                position: "BA Hons Business Management"
            },
            thumb3: {
                quote: "“The lectures & tutorials are interesting academically stimulating, and applied to real-world case studies which is extremely useful.”",
                by: "Jaqueline Smith",
                position: "BA Hons Business Management"
            }
        },
        committee: {
            title: "Program Committee"
        },
        research: {},
        teacher: {},
        student: {},
        settings: {}
    };
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    Swu.translations_th = {
        shared: {
            applicationName: "โครงการพัฒนาระบบประชาสัมพันธ์หลักสูตรแพทยศาสตรบัณฑิตโครงการร่วมนอตติงแฮม",
            address: "อาคาร 15 คณะแพทยศาสตร์ 114 สุขุมวิท 23 กรุงเทพฯ 10110",
            phone: "+66 2649 5000"
        },
        login: {
            anyQuestions: "มีคำถามใช่ไหม?",
            callUs: "โทรมาหาเรา",
            login: "เข้าสู่ระบบ",
            register: "ลงทะเบียนสมาชิก",
            loginAs: "",
            loginOrRegister: "เข้าสู่ระบบหรือลงทะเบียน",
            description: "เข้าสู่ระบบหรือลงทะเบียนวันนี้เพื่อรับสิทธิ์ในการเข้าถึงรายละเอียดทุกวิชาที่เปิดสอน.",
            loginTitle: "ใส่ชิ่อผู้ใช้และรหัสผ่านเพื่อเข้าสู่ระบบ:",
            registerTitle: "เข้าร่วมกับเรา:",
            btnLogin: "เข้าสู่ระบบ",
            btnRegister: "ลงทะเบียน",
            userName: "ชื่อผู้ใช้",
            firstName: "ชื่อ",
            lastName: "นามสกุล",
            password: "รหัสผ่าน",
            rePassword: "ใส่รหัสผ่านอีกครั้ง",
            email: "อีเมล์"
        },
        menu: {
            home: "หน้าแรก",
            aboutUs: "เกี่ยวกับเรา",
            history: "ประวัติ",
            visionAndMission: "วิสัยทัศน์",
            ethics: "จริยธรรม",
            departments: "แผนก",
            courses: "วิชาที่เปิดสอน",
            research: "งานวิจัย",
            ourPeoples: "พวกเรา",
            teacher: "รายชื่ออาจารย์",
            contact: "ติดต่อเรา",
            committee: "กรรมการ"
        },
        home: {},
        course: {
            all: "วิชาที่เปิดสอนทั้งหมด",
            topRated: "คะแนนสูง",
            mostPopular: "ยอดนิยม",
            recentlyAdded: "เพิ่มล่าสุด"
        },
        registration: {
            identityCardNumber: "หมายเลขบัตรประชาชน",
            fullName: "ชื่อ-นามสกุล",
            register: "ลงทะเบียน"
        },
        event: {
            title: "กิจกรมภายใน",
            description: "กำหนดการต่างๆ เกี่ยวกับการสอบและกิจกรรมที่เกี่ยวข้อง"
        },
        commitments: {
            title: "วัตถุประสงค์ของหลักสูตร"
        },
        video: {
            title: "วีดีโอ"
        },
        news: {
            title: "ข่าวสาร"
        },
        testimonials: {
            title: "สัมภาษณ์นักศึกษา",
            description: "ทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบ",
            checkfaq: "คำถามที่พบบ่อย",
            thumb1: {
                quote: "“ทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบ”",
                by: "จาคิวลีน สมิท",
                position: "การจัดการธุรกิจ"
            },
            thumb2: {
                quote: "“ทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบ”",
                by: "จาคิวลีน สมิท",
                position: "การจัดการธุรกิจ"
            },
            thumb3: {
                quote: "“ทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบทดสอบ”",
                by: "จาคิวลีน สมิท",
                position: "การจัดการธุรกิจ"
            }
        },
        committee: {
            title: "คณะกรรมการ"
        },
        research: {},
        teacher: {},
        student: {},
        settings: {}
    };
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
        "ui.bootstrap",
        "pascalprecht.translate",
    ])
        .config(["$translateProvider", "AppConstant", "$mdDateLocaleProvider", function ($translateProvider, AppConstant, $mdDateLocaleProvider) {
            $translateProvider.translations("en", Swu.translations_en);
            $translateProvider.translations("th", Swu.translations_th);
            $translateProvider.preferredLanguage(AppConstant.defaultLang);
            $translateProvider.fallbackLanguage(AppConstant.defaultLang);
            $mdDateLocaleProvider.formatDate = function (date) {
                return moment(date).format('DD/MM/YYYY');
            };
        }])
        .run(["$state", "$http", "$rootScope", "AppConstant", function ($state, $http, $rootScope, AppConstant) {
            $rootScope.$on("$stateChangeSuccess", function () {
                var exceptGotoTopStateList = AppConstant.exceptGotoTopStateList;
                var result = _.contains(exceptGotoTopStateList, $state.current.name);
                if (!result) {
                    document.body.scrollTop = document.documentElement.scrollTop = 0;
                }
            });
            $rootScope.lang = AppConstant.defaultLang;
        }]);
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var AppConstant = (function () {
        function AppConstant() {
            this.defaultLang = "th";
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
        function LoginController($scope, $rootScope, $state, loginServices, $translate) {
            var _this = this;
            this.$scope = $scope;
            this.$rootScope = $rootScope;
            this.$state = $state;
            this.loginServices = loginServices;
            this.$translate = $translate;
            this.init = function () {
                _this.$scope.showModal = false;
            };
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
            this.$scope.changeLanguage = function (lang) {
                $translate.use(lang);
                $rootScope.lang = lang;
            };
        }
        LoginController.$inject = ["$scope", "$rootScope", "$state", "loginServices", "$translate"];
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
                templateUrl: "/Scripts/app/course/view/course_detail.html",
                controller: "CourseController as vm"
            })
                .state("course-list", {
                url: "/course-list",
                templateUrl: "/Scripts/app/course/view/course_list.html",
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
    var StateConfig = (function () {
        function StateConfig($stateProvider, $urlRouterProvider, $locationProvider, $httpProvider) {
            this.$stateProvider = $stateProvider;
            this.$urlRouterProvider = $urlRouterProvider;
            this.$locationProvider = $locationProvider;
            this.$httpProvider = $httpProvider;
            $urlRouterProvider.otherwise("/app");
            $stateProvider
                .state("committee-list", {
                url: "/committee-list",
                templateUrl: "/Scripts/app/committee/view/committee-list.html"
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
        function HomeCourseController($scope, $rootScope, $state, homeCourseService, $translate) {
            var _this = this;
            this.$scope = $scope;
            this.$rootScope = $rootScope;
            this.$state = $state;
            this.homeCourseService = homeCourseService;
            this.$translate = $translate;
            this.init();
            this.$scope.courseGrouping = function () {
                _this.$scope.TopRateCourse = _.filter(_this.$scope.CourseCards, function (card) {
                    return card.cardType == Swu.CardType.topRate;
                });
                _this.$scope.PopularCourse = _.filter(_this.$scope.CourseCards, function (card) {
                    return card.cardType == Swu.CardType.popular;
                });
                _this.$scope.RecentlyCourse = _.filter(_this.$scope.CourseCards, function (card) {
                    return card.cardType == Swu.CardType.recently;
                });
            };
            this.$scope.swapLanguage = function (lang) {
                switch (lang) {
                    case "en": {
                        _.map(_this.$scope.CourseCards, function (c) {
                            c.course.name = c.course.name_en;
                        });
                        break;
                    }
                    case "th": {
                        _.map(_this.$scope.CourseCards, function (c) {
                            c.course.name = c.course.name_th;
                        });
                        break;
                    }
                }
            };
            this.$rootScope.$watch("lang", function (newValue, oldValue) {
                if ($scope.CourseCards != undefined || $scope.CourseCards != null) {
                    $scope.swapLanguage(newValue);
                    $scope.courseGrouping();
                }
            });
        }
        HomeCourseController.prototype.init = function () {
            var _this = this;
            this.homeCourseService.getCourses().then(function (response) {
                _this.$scope.CourseCards = response;
                _this.$scope.swapLanguage(_this.$rootScope.lang);
                _this.$scope.courseGrouping();
            }, function (error) { });
        };
        ;
        HomeCourseController.$inject = ["$scope", "$rootScope", "$state", "homeCourseService", "$translate"];
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
    var MainSliderController = (function () {
        function MainSliderController($scope, $rootScope, $state, mainSliderService, $sce, $timeout) {
            this.$scope = $scope;
            this.$rootScope = $rootScope;
            this.$state = $state;
            this.mainSliderService = mainSliderService;
            this.$sce = $sce;
            this.$timeout = $timeout;
            this.$scope.swapLanguage = function (lang) {
                switch (lang) {
                    case "en": {
                        _.map($scope.sliders, function (s) {
                            s.title = $sce.trustAsHtml(s.title_en);
                            s.description = s.description_en;
                        });
                        break;
                    }
                    case "th": {
                        _.map($scope.sliders, function (s) {
                            s.title = $sce.trustAsHtml(s.title_th);
                            s.description = s.description_th;
                        });
                        break;
                    }
                }
            };
            this.$scope.renderSlide = function (sliders) {
                var html = "";
                _.forEach(sliders, function (value, key) {
                    var elements = "<div class='item'>\
                <div class='caption animatedParent'>\
                    <div class='irs-text-one animated fadeInUp delay-1250'>\
                    " + value.title + "\
                                </div>\
                                <div class='irs-text-three animated fadeInUp delay-1500' >\
                                <p>" + value.description + "</p>\
                                    </div>\
                                        </div>\
                                        <img class='img-responsive' src= '../../../" + value.imageUrl + "' alt= '' >\
                                            </div>";
                    html += elements;
                });
                $('#main-slider').html(html);
            };
            this.$scope.registerScript = function () {
                if ($('.irs-main-slider').length) {
                    var $owl = $('.irs-main-slider');
                    $owl.owlCarousel({
                        loop: true,
                        margin: 0,
                        dots: false,
                        nav: false,
                        autoplayHoverPause: false,
                        autoplay: true,
                        autoHeight: false,
                        smartSpeed: 2000,
                        touchDrag: false,
                        mouseDrag: false,
                        navText: [
                            '<i class=""></i>',
                            '<i class=""></i>'
                        ],
                        responsive: {
                            0: {
                                items: 1,
                                center: false
                            },
                            480: {
                                items: 1,
                                center: false
                            },
                            600: {
                                items: 1,
                                center: false
                            },
                            768: {
                                items: 1
                            },
                            992: {
                                items: 1
                            },
                            1200: {
                                items: 1
                            }
                        }
                    });
                }
            };
            this.$rootScope.$watch("lang", function (newValue, oldValue) {
                mainSliderService.getSliders().then(function (response) {
                    _.forEach(response, function (value, key) {
                        $scope.sliders.push({
                            id: value.id,
                            title_en: value.title_en,
                            title_th: value.title_th,
                            description_en: value.description_en,
                            description_th: value.description_th,
                            imageUrl: value.imageUrl
                        });
                    });
                    $scope.swapLanguage(newValue);
                    var $owl = $('.irs-main-slider');
                    if ($scope.count == 0) {
                        $scope.renderSlide($scope.sliders);
                        $scope.registerScript();
                        $scope.count += 1;
                    }
                    else {
                        if ($owl.hasClass("owl-carousel")) {
                            $owl.data('owlCarousel').destroy();
                            $owl.removeClass('owl-carousel owl-loaded');
                            $owl.find('.owl-stage-outer').children().unwrap();
                            $owl.removeData();
                            $scope.renderSlide($scope.sliders);
                            $scope.registerScript();
                        }
                    }
                });
            });
            this.init();
        }
        MainSliderController.prototype.init = function () {
            this.$scope.sliders = [];
            this.$scope.count = 0;
        };
        ;
        MainSliderController.$inject = ["$scope", "$rootScope", "$state", "mainSliderService", "$sce", "$timeout"];
        MainSliderController = __decorate([
            Swu.Module("app"),
            Swu.Controller({ name: "MainSliderController" })
        ], MainSliderController);
        return MainSliderController;
    }());
    Swu.MainSliderController = MainSliderController;
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var CommitmentController = (function () {
        function CommitmentController($scope, $rootScope, $state, commitmentService) {
            this.$scope = $scope;
            this.$rootScope = $rootScope;
            this.$state = $state;
            this.commitmentService = commitmentService;
            this.$scope.commitments = [];
            this.$scope.swapLanguage = function (lang) {
                switch (lang) {
                    case "en": {
                        _.map($scope.commitments, function (s) {
                            s.title = s.title_en;
                            s.description = s.description_en;
                        });
                        break;
                    }
                    case "th": {
                        _.map($scope.commitments, function (s) {
                            s.title = s.title_th;
                            s.description = s.description_th;
                        });
                        break;
                    }
                }
            };
            this.$rootScope.$watch("lang", function (newValue, oldValue) {
                $scope.commitments = [];
                commitmentService.getCommitments().then(function (response) {
                    _.forEach(response, function (value, key) {
                        var mod = key % 2;
                        var mod2 = (key + 1) % 4;
                        var alignment = "";
                        var columnCss = "";
                        var delay = 0;
                        var style = "";
                        var commentCss = "";
                        if (mod == 0) {
                            alignment = "left";
                            columnCss = "irs-commtmnt-column";
                            commentCss = "irs-cmmt-details";
                        }
                        else {
                            alignment = "right";
                            columnCss = "irs-commtmnt-column2";
                            commentCss = "irs-cmmt-details2";
                        }
                        if (mod2 == 1) {
                            style = "style_one";
                        }
                        $scope.commitments.push({
                            title_en: value.title_en,
                            description_en: value.description_en,
                            title_th: value.title_th,
                            description_th: value.description_th,
                            alignment: "text-" + alignment,
                            iconCss: value.iconCss,
                            columnCss: columnCss,
                            style: style,
                            commentCss: commentCss
                        });
                    });
                    $scope.swapLanguage(newValue);
                }, function (error) { });
            });
        }
        CommitmentController.prototype.init = function () {
        };
        ;
        CommitmentController.$inject = ["$scope", "$rootScope", "$state", "commitmentService"];
        CommitmentController = __decorate([
            Swu.Module("app"),
            Swu.Controller({ name: "CommitmentController" })
        ], CommitmentController);
        return CommitmentController;
    }());
    Swu.CommitmentController = CommitmentController;
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var ExamRegistrationController = (function () {
        function ExamRegistrationController($scope, $rootScope, $state, examRegistrationService) {
            var _this = this;
            this.$scope = $scope;
            this.$rootScope = $rootScope;
            this.$state = $state;
            this.examRegistrationService = examRegistrationService;
            this.$scope.getExam = function () {
                _this.examRegistrationService.getExam().then(function (response) {
                    $scope.register_flipClock(response.remainingTime);
                }, function (error) { });
            };
            this.$scope.swapLanguage = function (lang) {
                switch (lang) {
                    case "en": {
                        $scope.exam.examInfo.title = $scope.exam.examInfo.title_en;
                        $scope.exam.examInfo.description = $scope.exam.examInfo.description_en;
                        break;
                    }
                    case "th": {
                        $scope.exam.examInfo.title = $scope.exam.examInfo.title_th;
                        $scope.exam.examInfo.description = $scope.exam.examInfo.description_th;
                        break;
                    }
                }
            };
            this.$scope.register_flipClock = function (remaining) {
                var clock;
                clock = $('.clock').FlipClock({
                    clockFace: 'DailyCounter',
                    autoStart: false,
                    callbacks: {
                        stop: function () {
                            $('.message').html('The clock has stopped!');
                        }
                    }
                });
                clock.setTime(remaining);
                clock.setCountdown(true);
                clock.start();
            };
            this.$rootScope.$watch("lang", function (newValue, oldValue) {
                examRegistrationService.getExam().then(function (response) {
                    $scope.exam = response;
                    $scope.swapLanguage(newValue);
                    console.log($scope.exam);
                }, function (error) { });
            });
            this.init();
        }
        ExamRegistrationController.prototype.init = function () {
            this.$scope.getExam();
        };
        ;
        ExamRegistrationController.$inject = ["$scope", "$rootScope", "$state", "examRegistrationService"];
        ExamRegistrationController = __decorate([
            Swu.Module("app"),
            Swu.Controller({ name: "ExamRegistrationController" })
        ], ExamRegistrationController);
        return ExamRegistrationController;
    }());
    Swu.ExamRegistrationController = ExamRegistrationController;
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var EventController = (function () {
        function EventController($scope, $rootScope, $state, eventService, $sce, $timeout) {
            this.$scope = $scope;
            this.$rootScope = $rootScope;
            this.$state = $state;
            this.eventService = eventService;
            this.$sce = $sce;
            this.$timeout = $timeout;
            this.$scope.swapLanguage = function (lang) {
                moment.locale(lang);
                switch (lang) {
                    case "en": {
                        _.map($scope.events, function (s) {
                            s.title = s.title_en;
                            s.place = s.place_en;
                            s.description = s.description_en;
                            s.displayStartDate = moment(s.startDate).format("LL");
                            s.displayStartTime = moment(s.startDate).format("LT");
                        });
                        break;
                    }
                    case "th": {
                        _.map($scope.events, function (s) {
                            s.title = s.title_th;
                            s.place = s.place_th;
                            s.description = s.description_th;
                            s.displayStartDate = moment(s.startDate).format("LL");
                            s.displayStartTime = moment(s.startDate).format("LT");
                        });
                        break;
                    }
                }
            };
            this.$scope.renderSlide = function (event) {
                var html = "";
                _.forEach(event, function (value, key) {
                    var elements = "<div class='item'>\
                        <div class='irs-event-grid'>\
                            <div class='irs-edetails irs-ext-pad'>\
                                <div class='irs-ettl'>\
                                    <h4>" + value.title + "</h4>\
                                        </div>\
                                        <div class='irs-edate-time'>\
                                            <ul class='list-unstyled'>\
                                                <li><a href='#'> <span class='flaticon-clock text-thm2'></span> Date: " + value.displayStartDate + " </a></li>\
                                                    <li><a href='#'> <span class='flaticon-clock-1 text-thm2' > </span> Time: " + value.displayStartTime + "</a></li>\
                                                        <li><a href='#'> <span class='flaticon-buildings text-thm2' > </span> " + value.place + "</a></li>\
                                                            </ul>\
                                                            <p> " + value.description + "</p>\
                                                                <div class='irs-evnticon'> <span class='flaticon-cross'> </span></div>\
                                                                    </div>\
                                                                    </div>\
                                                                    </div>\
                                                                    </div>";
                    html += elements;
                });
                $('.irs-event-carousel').html(html);
            };
            this.$scope.registerScript = function () {
                if ($('.irs-event-carousel').length) {
                    $('.irs-event-carousel').owlCarousel({
                        loop: false,
                        margin: 0,
                        dots: false,
                        nav: true,
                        autoplayHoverPause: false,
                        autoPlay: false,
                        autoHeight: false,
                        smartSpeed: 2000,
                        navText: [
                            '<span class="flaticon-arrows"></span>',
                            '<span class="flaticon-arrows-1"></span>'
                        ],
                        responsive: {
                            0: {
                                items: 1,
                                center: false
                            },
                            480: {
                                items: 1,
                                center: false
                            },
                            600: {
                                items: 1,
                                center: false
                            },
                            768: {
                                items: 2
                            },
                            992: {
                                items: 3
                            },
                            1200: {
                                items: 3
                            },
                            1366: {
                                items: 3
                            },
                            1440: {
                                items: 1
                            },
                            1600: {
                                items: 3
                            }
                        }
                    });
                }
            };
            this.$rootScope.$watch("lang", function (newValue, oldValue) {
                eventService.getEvents().then(function (response) {
                    console.log(response);
                    _.forEach(response, function (value, key) {
                        $scope.events.push({
                            title_en: value.title_en,
                            place_en: value.place_en,
                            description_en: value.description_en,
                            title_th: value.title_th,
                            place_th: value.place_th,
                            description_th: value.description_th,
                            imageUrl: value.imageUrl,
                            startDate: value.startDate
                        });
                    });
                    $scope.swapLanguage(newValue);
                    var $owl = $('.irs-event-carousel');
                    if ($scope.count == 0) {
                        $scope.renderSlide($scope.events);
                        $scope.registerScript();
                        $scope.count += 1;
                    }
                    else {
                        if ($owl.hasClass("owl-carousel")) {
                            $owl.data('owlCarousel').destroy();
                            $owl.removeClass('owl-carousel owl-loaded');
                            $owl.find('.owl-stage-outer').children().unwrap();
                            $owl.removeData();
                            $scope.renderSlide($scope.events);
                            $scope.registerScript();
                        }
                    }
                });
            });
            this.init();
        }
        EventController.prototype.init = function () {
            this.$scope.events = [];
            this.$scope.count = 0;
        };
        ;
        EventController.$inject = ["$scope", "$rootScope", "$state", "eventService", "$sce", "$timeout"];
        EventController = __decorate([
            Swu.Module("app"),
            Swu.Controller({ name: "EventController" })
        ], EventController);
        return EventController;
    }());
    Swu.EventController = EventController;
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var VideoController = (function () {
        function VideoController($scope, $rootScope, $state, videoService, $translate) {
            var _this = this;
            this.$scope = $scope;
            this.$rootScope = $rootScope;
            this.$state = $state;
            this.videoService = videoService;
            this.$translate = $translate;
            this.$scope.swapLanguage = function (lang) {
                switch (lang) {
                    case "en": {
                        _.map(_this.$scope.videos, function (v) {
                            v.title = v.title_en;
                        });
                        break;
                    }
                    case "th": {
                        _.map(_this.$scope.videos, function (v) {
                            v.title = v.title_th;
                        });
                        break;
                    }
                }
            };
            this.$scope.render = function (videos) {
                var html = "";
                _.forEach(videos, function (value, key) {
                    var elements = "<div class='irs-ss-item swiper-slide'>\
                    <div class='irs-campus-thumb'>\
                        <img class='img-responsive img-fluid' src='../../../" + value.imageUrl + "' alt= '' >\
                            <div class='irs-campus-overlayer' ><a class='popup-youtube' href= '" + value.videoUrl + "' > <span class='flaticon-play-1' > </span></a> </div>\
                                <p> " + value.title + "</p>\
                                    </div>\
                                    </div>";
                    html += elements;
                });
                $('#main-video').html(html);
            };
            this.$scope.registerScript = function () {
                var swiper = new Swiper('.swiper-container', {
                    pagination: '.swiper-pagination',
                    slidesPerView: 2,
                    slidesPerColumn: 2,
                    paginationClickable: true,
                    spaceBetween: 20,
                    mousewheelControl: true
                });
                $('.popup-youtube').magnificPopup({
                    type: 'iframe'
                });
            };
            this.$rootScope.$watch("lang", function (newValue, oldValue) {
                if ($scope.videos != undefined || $scope.videos != null) {
                    videoService.getVideos().then(function (response) {
                        $scope.videos = response;
                        $scope.swapLanguage($rootScope.lang);
                        $scope.render($scope.videos);
                        $scope.registerScript();
                    }, function (error) { });
                }
            });
            this.init();
        }
        VideoController.prototype.init = function () {
            this.$scope.videos = [];
        };
        ;
        VideoController.$inject = ["$scope", "$rootScope", "$state", "videoService", "$translate"];
        VideoController = __decorate([
            Swu.Module("app"),
            Swu.Controller({ name: "VideoController" })
        ], VideoController);
        return VideoController;
    }());
    Swu.VideoController = VideoController;
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var NewsController = (function () {
        function NewsController($scope, $rootScope, $state, newsService, $sce, $timeout) {
            this.$scope = $scope;
            this.$rootScope = $rootScope;
            this.$state = $state;
            this.newsService = newsService;
            this.$sce = $sce;
            this.$timeout = $timeout;
            this.$scope.swapLanguage = function (lang) {
                switch (lang) {
                    case "en": {
                        _.map($scope.news, function (s) {
                            s.title = s.title_en;
                        });
                        break;
                    }
                    case "th": {
                        _.map($scope.news, function (s) {
                            s.title = s.title_th;
                        });
                        break;
                    }
                }
            };
            this.$scope.render = function (news) {
                var html = "";
                _.forEach(news, function (value, key) {
                    var elements = "<div class='item'>\
                        <div class='irs-blog-post' >\
                            <div class='irs-bp-thumb' > <img class='img-responsive img-fluid' src= '../../../" + value.imageUrl + "' alt= 'blog/1.jpg' > </div>\
                                <div class='irs-bp-details' >\
                                                    <h3 class='irs-bp-title' >" + value.title + "</h3>\
                                                        <div class='irs-bp-meta' >\
                                                            <ul class='list-inline irs-bp-meta-dttime' >\
                                                                <li>by <span class='text-thm1' >" + value.createdBy + "</span> </li >\
                                                                    <li><span class='flaticon-clock-1' > </span>" + value.startDate + "</li>\
                                                                        </ul>\
                                                                        </div>\
                                                                        </div>\
                                                                        </div>\
                                                                        </div>";
                    html += elements;
                });
                $('#main-news').html(html);
            };
            this.$scope.registerScript = function () {
                if ($('.irs-blog-slider').length) {
                    $('.irs-blog-slider').owlCarousel({
                        loop: true,
                        margin: 0,
                        dots: false,
                        nav: true,
                        autoplayHoverPause: false,
                        autoPlay: false,
                        autoHeight: false,
                        smartSpeed: 2000,
                        navText: [
                            '<span class="flaticon-arrows"></span>',
                            '<span class="flaticon-arrows-1"></span>'
                        ],
                        responsive: {
                            0: {
                                items: 1,
                                center: false
                            },
                            480: {
                                items: 1,
                                center: false
                            },
                            600: {
                                items: 1,
                                center: false
                            },
                            768: {
                                items: 2
                            },
                            992: {
                                items: 3
                            },
                            1200: {
                                items: 3
                            },
                            1366: {
                                items: 3
                            },
                            1440: {
                                items: 3
                            },
                            1600: {
                                items: 3
                            }
                        }
                    });
                }
            };
            this.$rootScope.$watch("lang", function (newValue, oldValue) {
                newsService.getNews().then(function (response) {
                    _.forEach(response, function (value, key) {
                        $scope.news.push({
                            title_en: value.title_en,
                            title_th: value.title_th,
                            imageUrl: value.imageUrl,
                            createdBy: value.createdBy,
                            startDate: value.startDate
                        });
                    });
                    $scope.swapLanguage(newValue);
                    var $owl = $('.irs-blog-slider');
                    if ($scope.count == 0) {
                        $scope.render($scope.news);
                        $scope.registerScript();
                        $scope.count += 1;
                    }
                    else {
                        if ($owl.hasClass("owl-carousel")) {
                            $owl.data('owlCarousel').destroy();
                            $owl.removeClass('owl-carousel owl-loaded');
                            $owl.find('.owl-stage-outer').children().unwrap();
                            $owl.removeData();
                            $scope.render($scope.news);
                            $scope.registerScript();
                        }
                    }
                });
            });
            this.init();
        }
        NewsController.prototype.init = function () {
            this.$scope.news = [];
            this.$scope.count = 0;
        };
        ;
        NewsController.$inject = ["$scope", "$rootScope", "$state", "newsService", "$sce", "$timeout"];
        NewsController = __decorate([
            Swu.Module("app"),
            Swu.Controller({ name: "NewsController" })
        ], NewsController);
        return NewsController;
    }());
    Swu.NewsController = NewsController;
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
    var homeCourseService = (function () {
        function homeCourseService(apiService, constant) {
            this.apiService = apiService;
            this.constant = constant;
        }
        homeCourseService.prototype.getSliders = function () {
            return this.apiService.getData("course/getSlider");
        };
        homeCourseService.$inject = ['apiService', 'AppConstant'];
        homeCourseService = __decorate([
            Swu.Module("app"),
            Swu.Factory({ name: "mainSliderService" })
        ], homeCourseService);
        return homeCourseService;
    }());
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var commitmentService = (function () {
        function commitmentService(apiService, constant) {
            this.apiService = apiService;
            this.constant = constant;
        }
        commitmentService.prototype.getCommitments = function () {
            return this.apiService.getData("shared/commitments");
        };
        commitmentService.$inject = ['apiService', 'AppConstant'];
        commitmentService = __decorate([
            Swu.Module("app"),
            Swu.Factory({ name: "commitmentService" })
        ], commitmentService);
        return commitmentService;
    }());
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var examRegistrationService = (function () {
        function examRegistrationService(apiService, constant) {
            this.apiService = apiService;
            this.constant = constant;
        }
        examRegistrationService.prototype.getExam = function () {
            return this.apiService.getData("exam/getExam");
        };
        examRegistrationService.$inject = ['apiService', 'AppConstant'];
        examRegistrationService = __decorate([
            Swu.Module("app"),
            Swu.Factory({ name: "examRegistrationService" })
        ], examRegistrationService);
        return examRegistrationService;
    }());
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var eventService = (function () {
        function eventService(apiService, constant) {
            this.apiService = apiService;
            this.constant = constant;
        }
        eventService.prototype.getEvents = function () {
            return this.apiService.getData("event/all");
        };
        eventService.$inject = ['apiService', 'AppConstant'];
        eventService = __decorate([
            Swu.Module("app"),
            Swu.Factory({ name: "eventService" })
        ], eventService);
        return eventService;
    }());
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var videoService = (function () {
        function videoService(apiService, constant) {
            this.apiService = apiService;
            this.constant = constant;
        }
        videoService.prototype.getVideos = function () {
            return this.apiService.getData("video/all");
        };
        videoService.$inject = ['apiService', 'AppConstant'];
        videoService = __decorate([
            Swu.Module("app"),
            Swu.Factory({ name: "videoService" })
        ], videoService);
        return videoService;
    }());
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var newsService = (function () {
        function newsService(apiService, constant) {
            this.apiService = apiService;
            this.constant = constant;
        }
        newsService.prototype.getNews = function () {
            return this.apiService.getData("news/all");
        };
        newsService.$inject = ['apiService', 'AppConstant'];
        newsService = __decorate([
            Swu.Module("app"),
            Swu.Factory({ name: "newsService" })
        ], newsService);
        return newsService;
    }());
})(Swu || (Swu = {}));
var Swu;
(function (Swu) {
    var CourseController = (function () {
        function CourseController($scope, $state, courseService, $stateParams, $sce) {
            var _this = this;
            this.$scope = $scope;
            this.$state = $state;
            this.courseService = courseService;
            this.$stateParams = $stateParams;
            this.$sce = $sce;
            this.$scope.id = this.$stateParams["id"];
            this.$scope.getCourse = function (id) {
                _this.courseService.getById(id).then(function (response) {
                    _this.$scope.courseDetail = response;
                    _this.$scope.courseDetail.course.fullDescription = $sce.trustAsHtml(_this.$scope.courseDetail.course.fullDescription);
                    _.map(_this.$scope.courseDetail.teachers, function (t) {
                        t.description = $sce.trustAsHtml(t.description);
                    });
                    _.map(_this.$scope.courseDetail.photosAlbum.photos, function (p) {
                        p.displayPublishedDate = moment(p.publishedDate).format("LL");
                    });
                    _.forEach(_this.$scope.courseDetail.students, function (value, key) {
                        if (key < (_this.$scope.courseDetail.students.length / 2)) {
                            _this.$scope.splitStudents1.push({
                                id: value.id,
                                number: key + 1,
                                studentId: value.studentId,
                                name: value.name,
                                description: value.description,
                                imageUrl: value.imageUrl
                            });
                        }
                        else {
                            _this.$scope.splitStudents2.push({
                                id: value.id,
                                number: key + 1,
                                studentId: value.studentId,
                                name: value.name,
                                description: value.description,
                                imageUrl: value.imageUrl
                            });
                        }
                    });
                    _this.$scope.render(_this.$scope.courseDetail.photosAlbum.photos);
                    _this.$scope.registerScript();
                }, function (error) { });
            };
            this.$scope.render = function (photos) {
                var html = "";
                _.forEach(photos, function (value, key) {
                    var elements = "<div class='col-md-4'>\
                        <div class='resources-item' >\
                            <div class='resources-category-image' >\
                                <a href='../../../../" + value.imageUrl + "' title= '" + value.name + "' by='" + value.uploadBy + "'>\
                                    <img class='img-responsive' alt= '' src= '../../../../" + value.imageUrl + "'>\
                                        </a>\
                                        </div>\
                                        <div class='resources-description' >\
                                            <p>" + value.displayPublishedDate + "</p>\
                                                <h4>" + value.name + "</h4>\
                                                </div>\
                                                </div>\
                                                </div>";
                    html += elements;
                });
                html = "<div class='row'>" + html + "</div>";
                $('.popup-gallery').html(html);
            };
            this.$scope.registerScript = function () {
                $('.popup-gallery').magnificPopup({
                    delegate: 'a',
                    type: 'image',
                    tLoading: 'Loading image #%curr%...',
                    mainClass: 'mfp-img-mobile',
                    gallery: {
                        enabled: true,
                        navigateByImgClick: true,
                        preload: [0, 1]
                    },
                    image: {
                        tError: '<a href="%url%">The image #%curr%</a> could not be loaded.',
                        titleSrc: function (item) {
                            return item.el.attr('title') + '<small> Upload by: ' + item.el.attr('by') + '</small>';
                        }
                    }
                });
            };
            this.init();
        }
        CourseController.prototype.init = function () {
            this.$scope.splitStudents1 = [];
            this.$scope.splitStudents2 = [];
            this.$scope.getCourse(this.$scope.id);
        };
        ;
        CourseController.$inject = ["$scope", "$state", "courseService", "$stateParams", "$sce"];
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
    var courseService = (function () {
        function courseService(apiService, constant) {
            this.apiService = apiService;
            this.constant = constant;
        }
        courseService.prototype.getById = function (id) {
            return this.apiService.getData("course/getById?id=" + id);
        };
        courseService.$inject = ['apiService', 'AppConstant'];
        courseService = __decorate([
            Swu.Module("app"),
            Swu.Factory({ name: "courseService" })
        ], courseService);
        return courseService;
    }());
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
var Swu;
(function (Swu) {
    (function (CurriculumType) {
        CurriculumType[CurriculumType["lecture"] = 1] = "lecture";
        CurriculumType[CurriculumType["exam"] = 2] = "exam";
    })(Swu.CurriculumType || (Swu.CurriculumType = {}));
    var CurriculumType = Swu.CurriculumType;
})(Swu || (Swu = {}));
