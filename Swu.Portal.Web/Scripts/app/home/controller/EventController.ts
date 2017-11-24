module Swu {
    interface IEventScope extends baseControllerScope {
        events: IEvent[];
        renderSlide(event: IEvent[]): void;
        registerScript(): void;
        count: number;
    }
    @Module("app")
    @Controller({ name: "EventController" })
    export class EventController {
        static $inject: Array<string> = ["$scope", "$rootScope", "$state", "eventService", "$sce", "$timeout"];
        constructor(private $scope: IEventScope, private $rootScope: IRootScope, private $state: ng.ui.IState, private eventService: IeventService, private $sce: ng.ISCEService, private $timeout: ng.ITimeoutService) {
            this.$scope.swapLanguage = (lang: string): void => {
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
            }
            this.$scope.renderSlide = (event: IEvent[]): void => {
                var html = "";
                _.forEach(event, (value, key) => {
                    var elements = "<div class='item'>\
                        <div class='irs-event-grid'>\
                            <div class='irs-edetails irs-ext-pad'>\
                                <div class='irs-ettl'>\
                                    <h4>"+ value.title + "</h4>\
                                        </div>\
                                        <div class='irs-edate-time'>\
                                            <ul class='list-unstyled'>\
                                                <li><a href='#'> <span class='flaticon-clock text-thm2'></span> Date: "+ value.displayStartDate + " </a></li>\
                                                <li><a href='#'> <span class='flaticon-clock-1 text-thm2' > </span> Time: "+ value.displayStartTime + "</a></li>\
                                                <li><a href='#'> <span class='flaticon-buildings text-thm2' > </span> "+ value.place + "</a></li>\
                                            </ul>\
                                            <p> "+ value.description + "</p>\
                                        </div>\
                                </div>\
                            </div>\
                        </div>";
                    html += elements;
                });
                $('.irs-event-carousel').html(html);
            };
            this.$scope.registerScript = (): void => {
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
                    })
                }
            };
            this.$rootScope.$watch("lang", function (newValue: string, oldValue: string) {
                eventService.getActiveEvents().then((response) => {
                    _.forEach(response, (value, key) => {
                        $scope.events.push(
                            {
                                title_en: value.title_en,
                                place_en: value.place_en,
                                description_en: value.description_en,
                                title_th: value.title_th,
                                place_th: value.place_th,
                                description_th: value.description_th,
                                imageUrl: value.imageUrl,
                                startDate: value.startDate,
                            }
                        );
                    });
                    $scope.swapLanguage(newValue);
                    var $owl = $('.irs-event-carousel');
                    if ($scope.count == 0) {
                        $scope.renderSlide($scope.events);
                        $scope.registerScript();
                        $scope.count += 1;
                    } else {
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
        init(): void {
            this.$scope.events = [];
            this.$scope.count = 0;
        };
    }
}