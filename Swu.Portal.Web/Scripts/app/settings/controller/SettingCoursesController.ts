module Swu {
    @Module("app")
    @Controller({ name: "SettingCoursesController" })
    export class SettingCoursesController {
        static $inject: Array<string> = ["$scope", "$state"];
        constructor(private $scope: ng.IScope, private $state: ng.ui.IState) {

        }
        init(): void {
        };

    }
}