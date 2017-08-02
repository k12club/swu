module Swu {
    @Module("app")
    @Controller({ name: "CourseController" })
    export class CourseController {
        static $inject: Array<string> = ["$scope", "$state"];
        constructor(private $scope: ng.IScope, private $state: ng.ui.IState) {

        }
        showMessage(): void {
            alert('test');
        }
        init(): void {
        };

    }
}