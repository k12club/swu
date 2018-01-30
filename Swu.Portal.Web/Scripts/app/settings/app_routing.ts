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
                .state("settings", {
                    url: "/settings",
                    views: {
                        '': { templateUrl: '/Scripts/app/settings/main.html' },
                        'subContent@settings': {
                            templateUrl: '/Scripts/app/settings/default.html'
                        },
                    }
                })
                .state("settings.users", {
                    parent: "settings",
                    url: "/users",
                    views: {
                        'subContent@settings': {
                            templateUrl: '/Scripts/app/settings/view/users.html',
                            controller: 'UsersController as vm'
                        },
                    }
                })
                .state("settings.courses", {
                    parent: "settings",
                    url: "/courses",
                    views: {
                        'subContent@settings': {
                            templateUrl: '/Scripts/app/settings/view/courses.html',
                            controller: 'CourseManagementController as vm'
                        },
                    }
                })
                .state("settings.events", {
                    parent: "settings",
                    url: "/events",
                    views: {
                        'subContent@settings': {
                            templateUrl: '/Scripts/app/settings/view/events.html',
                            controller: 'EventManagementController as vm'
                        },
                    }
                })
                .state("settings.videos", {
                    parent: "settings",
                    url: "/videos",
                    views: {
                        'subContent@settings': {
                            templateUrl: '/Scripts/app/settings/view/videos.html',
                            controller: 'VideoManagementController as vm'
                        },
                    }
                })
                .state("settings.news", {
                    parent: "settings",
                    url: "/news",
                    views: {
                        'subContent@settings': {
                            templateUrl: '/Scripts/app/settings/view/news.html',
                            controller: 'NewsManagementController as vm'
                        },
                    }
                })
                .state("settings.categories", {
                    parent: "settings",
                    url: "/categories",
                    views: {
                        'subContent@settings': {
                            templateUrl: '/Scripts/app/settings/view/category.html',
                            controller: 'CategoryManagementController as vm'
                        },
                    }
                })
                .state("settings.banners", {
                    parent: "settings",
                    url: "/banners",
                    views: {
                        'subContent@settings': {
                            templateUrl: '/Scripts/app/settings/view/banner.html',
                            controller: 'BannerManagementController as vm'
                        },
                    }
                })
                .state("settings.album", {
                    parent: "settings",
                    url: "/album",
                    views: {
                        'subContent@settings': {
                            templateUrl: '/Scripts/app/settings/view/album.html',
                            controller: 'AlbumManagementController as vm'
                        },
                    }
                })
                .state("settings.alumni", {
                    parent: "settings",
                    url: "/alumni",
                    views: {
                        'subContent@settings': {
                            templateUrl: '/Scripts/app/settings/view/alumni.html',
                            controller: 'AlumniManagementController as vm'
                        },
                    }
                });
        }
    }
} 
