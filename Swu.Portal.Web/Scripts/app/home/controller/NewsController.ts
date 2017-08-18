module Swu {
    interface INewsScope extends baseControllerScope {
        news: INews[];
        render(news: INews[]): void;
        registerScript(): void;
        count: number;
    }
    @Module("app")
    @Controller({ name: "NewsController" })
    export class NewsController {
        static $inject: Array<string> = ["$scope", "$rootScope", "$state", "newsService", "$sce", "$timeout"];
        constructor(private $scope: INewsScope, private $rootScope: IRootScope, private $state: ng.ui.IState, private newsService: InewsService, private $sce: ng.ISCEService, private $timeout: ng.ITimeoutService) {
            this.$scope.swapLanguage = (lang: string): void => {
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
            }
            this.$scope.render = (news: INews[]): void => {
                var html = "";
                _.forEach(news, (value, key) => {
                    var elements = "<div class='item'>\
                        <div class='irs-blog-post' >\
                            <div class='irs-bp-thumb' > <img class='img-responsive img-fluid' src= '../../../"+ value.imageUrl + "' alt= 'blog/1.jpg' > </div>\
                                <div class='irs-bp-details' >\
                                                    <h3 class='irs-bp-title' >"+ value.title + "</h3>\
                                                        <div class='irs-bp-meta' >\
                                                            <ul class='list-inline irs-bp-meta-dttime' >\
                                                                <li>by <span class='text-thm1' >"+ value.createdBy + "</span> </li >\
                                                                    <li><span class='flaticon-clock-1' > </span>"+ value.startDate + "</li>\
                                                                        </ul>\
                                                                        </div>\
                                                                        </div>\
                                                                        </div>\
                                                                        </div>";
                    html += elements;
                });
                $('#main-news').html(html);
            };
            this.$scope.registerScript = (): void => {
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
                    })
                }
            };
            this.$rootScope.$watch("lang", function (newValue: string, oldValue: string) {
                newsService.getNews().then((response) => {
                    _.forEach(response, (value, key) => {
                        $scope.news.push(
                            {
                                title_en: value.title_en,
                                title_th: value.title_th,
                                imageUrl: value.imageUrl,
                                createdBy: value.createdBy,
                                startDate: value.startDate
                            }
                        );
                    });
                    $scope.swapLanguage(newValue);
                    var $owl = $('.irs-blog-slider');
                    if ($scope.count == 0) {
                        $scope.render($scope.news);
                        $scope.registerScript();
                        $scope.count += 1;
                    } else {
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
        init(): void {
            this.$scope.news = [];
            this.$scope.count = 0;
        };
    }
}