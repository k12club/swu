module Swu {
    @Module("app")
    @Config
    class StateConfig {
        static $inject: Array<string> = ["$stateProvider", "$urlRouterProvider", "$locationProvider", "$httpProvider"];
        constructor(
            private $stateProvider: ng.ui.IStateProvider,
            private $urlRouterProvider: ng.ui.IUrlRouterProvider,
            private $locationProvider: ng.ILocationProvider,
            private $httpProvider: ng.IHttpProvider) {
            $urlRouterProvider.otherwise("/app");
            $stateProvider
                .state("alumni", {
                    url: "/alumni",
                    views: {
                        '': { templateUrl: '/Scripts/app/alumni/main.html' },
                        'subContent@alumni': {
                            templateUrl: '/Scripts/app/alumni/view/default.html'
                        },
                    }
                })
                .state("alumni.year", {
                    parent: "alumni",
                    url: "/year/:year",
                    views: {
                        'subContent@alumni': {
                            templateUrl: '/Scripts/app/alumni/view/alumni.html',
                            controller: 'AlumniByYearController as vm'
                        },
                    }
                });
        }
    }
} 
