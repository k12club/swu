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
                .state("teacher", {
                    url: "/teacher/:id",
                    templateUrl: "/Scripts/app/teacher/view/teacher_detail.html",
                    controller: "TeacherController as vm"
                })
                .state("teacher-list", {
                    url: "/teacher-list",
                    templateUrl: "/Scripts/app/teacher/view/teacher_list.html",
                    controller: "TeacherListController as vm"
                });
        }
    }
} 
