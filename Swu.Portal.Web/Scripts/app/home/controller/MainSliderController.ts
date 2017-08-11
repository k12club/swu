module Swu {
    interface IMainSliderScope extends ng.IScope {
        sliders: ISlider[];
    }
    @Module("app")
    @Controller({ name: "MainSliderController" })
    export class MainSliderController {
        static $inject: Array<string> = ["$scope", "$state", "mainSliderService", "$sce"];
        constructor(private $scope: IMainSliderScope, private $state: ng.ui.IState, private mainSliderService: ImainSliderService, private $sce: ng.ISCEService) {
            this.$scope.sliders = [];
            this.init();
        }
        init(): void {
            this.mainSliderService.getSliders().then((response) => {
                console.log(response);
                _.forEach(response, (value, key) => {
                    this.$scope.sliders.push(
                        {
                            id: value.id,
                            title: this.$sce.trustAsHtml(value.title),
                            description: value.description,
                            imageUrl: value.imageUrl
                        }
                    );
                });
                this.renderSlide(this.$scope.sliders);
                this.registerScript();
            }, (error) => { });
        };
        renderSlide(sliders: ISlider[]): void {
            var html = "";
            _.forEach(sliders, (value, key) => {
                var elements = "<div class='item'>\
                <div class='caption animatedParent'>\
                    <div class='irs-text-one animated fadeInUp delay-1250'>\
                    "+ value.title + "\
                                </div>\
                                <div class='irs-text-three animated fadeInUp delay-1500' >\
                                <p>"+ value.description + "</p>\
                                    </div>\
                                    <a href= '#' class='btn btn-lg irs-btn-thm irs-home-btn animated fadeInUp delay-1750' ><span>Check Courses</span> </a>\
                                        </div>\
                                        <img class='img-responsive' src= '../../../"+ value.imageUrl +"' alt= '' >\
                                            </div>";
                html += elements;
            });
            $('#main-slider').html(html);
        }
        registerScript(): void {
            $('.irs-main-slider').owlCarousel({
                loop: true,
                margin: 0,
                dots: false,
                nav: false,
                autoplayHoverPause: false,
                autoplay: true,
                autoHeight: false,
                smartSpeed: 2000,
                navText: [
                    '<i class=""></i>',
                    '<i class=""></i>'
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
                        items: 1
                    },
                    992: {
                        items: 1
                    },
                    1200: {
                        items: 1
                    }
                }
            });
        }
    }
}