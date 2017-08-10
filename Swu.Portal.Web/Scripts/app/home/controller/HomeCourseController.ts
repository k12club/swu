module Swu {
    interface IHomeCourseScope extends ng.IScope {
        CourseCards: ICourseCard[];
        TopRateCourse: ICourseCard[];
        PopularCourse: ICourseCard[];
        RecentlyCourse: ICourseCard[];
    }
    @Module("app")
    @Controller({ name: "HomeCourseController" })
    export class HomeCourseController {
        static $inject: Array<string> = ["$scope", "$state","homeCourseService"];
        constructor(private $scope: IHomeCourseScope, private $state: ng.ui.IState, private homeCourseService: IhomeCourseService) {
            this.init();
        }
        init(): void {
            this.homeCourseService.getCourses().then((response) => {
                this.$scope.CourseCards = response;
                this.$scope.TopRateCourse = _.filter(this.$scope.CourseCards, function (course) {
                    return course.cardType == CardType.topRate;
                });
                this.$scope.PopularCourse = _.filter(this.$scope.CourseCards, function (course) {
                    return course.cardType == CardType.popular;
                });
                this.$scope.RecentlyCourse = _.filter(this.$scope.CourseCards, function (course) {
                    return course.cardType == CardType.recently;
                });
            }, (error) => { });
        };
        
    }
}