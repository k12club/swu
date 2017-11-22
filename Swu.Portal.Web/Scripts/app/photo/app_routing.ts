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
                .state("photo", {
                    url: "/photo/:id/:title",
                    templateUrl: "/Scripts/app/photo/view/photo.html",
                    controller: "PhotoController as vm"
                });
        }
    }
} 
