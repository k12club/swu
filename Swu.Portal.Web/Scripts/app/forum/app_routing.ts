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
                .state("forum", {
                    url: "/forum/:id",
                    templateUrl: "/Scripts/app/forum/view/forum_detail.html",
                    controller: "ForumController as vm"
                });
        }
    }
} 
