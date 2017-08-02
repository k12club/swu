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
    }
} 
