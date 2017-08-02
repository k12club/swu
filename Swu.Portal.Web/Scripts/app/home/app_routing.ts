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
                .state("app", {
                    url: "/app",
                    templateUrl: "/Scripts/app/home/index.html",
                    controller: "HomeController as vm"
                });
        }
    }
} 
