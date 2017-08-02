module Swu {
    @Module("app")
    @Controller({ name: "TeacherListController" })
    export class TeacherListController {
        static $inject: Array<string> = ["$scope", "$state"];
        constructor(private $scope: ng.IScope, private $state: ng.ui.IState) {

        }
        init(): void {
        };

    }
}