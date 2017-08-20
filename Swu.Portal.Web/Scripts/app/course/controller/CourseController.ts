module Swu {
    @Module("app")
    @Controller({ name: "CourseController" })
    export class CourseController {
        static $inject: Array<string> = ["$scope", "$state","courseService"];
        constructor(private $scope: ng.IScope, private $state: ng.ui.IState, private courseService: IcourseService) {

        }
        init(): void {
        };

    }
}