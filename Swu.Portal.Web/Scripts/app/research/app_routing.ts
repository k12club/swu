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
    }
} 
