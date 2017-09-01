module Swu {
    interface IHomeCourseScope extends baseControllerScope {
        CourseCards: ICourseCard[];
        TopRateCourse: ICourseCard[];
        PopularCourse: ICourseCard[];
        RecentlyCourse: ICourseCard[];
        courseGrouping(): void;
    }
    @Module("app")
    @Controller({ name: "HomeCourseController" })
    export class HomeCourseController {
        static $inject: Array<string> = ["$scope", "$rootScope", "$state", "homeCourseService"];
        constructor(private $scope: IHomeCourseScope, private $rootScope: IRootScope, private $state: ng.ui.IState, private homeCourseService: IhomeCourseService) {
            this.init();
            this.$scope.courseGrouping = (): void => {
                this.$scope.TopRateCourse = _.filter(this.$scope.CourseCards, function (card) {
                    return card.cardType == CardType.topRate;
                });
                this.$scope.PopularCourse = _.filter(this.$scope.CourseCards, function (card) {
                    return card.cardType == CardType.popular;
                });
                this.$scope.RecentlyCourse = _.filter(this.$scope.CourseCards, function (card) {
                    return card.cardType == CardType.recently;
                });
            };
            this.$scope.swapLanguage = (lang: string): void => {
                switch (lang) {
                    case "en": {
                        _.map(this.$scope.CourseCards, function (c) {
                            c.course.name = c.course.name_en;
                        });
                        break;
                    }
                    case "th": {
                        _.map(this.$scope.CourseCards, function (c) {
                            c.course.name = c.course.name_th;
                        });
                        break;
                    }
                }
            }
            this.$rootScope.$watch("lang", function (newValue: string, oldValue: string) {
                if ($scope.CourseCards != undefined || $scope.CourseCards != null) {
                    $scope.swapLanguage(newValue);
                    $scope.courseGrouping();
                }
            });
        }
        init(): void {
            this.homeCourseService.getCourses().then((response) => {
                this.$scope.CourseCards = response;
                this.$scope.swapLanguage(this.$rootScope.lang);
                this.$scope.courseGrouping();
            }, (error) => { });
        };

    }
}