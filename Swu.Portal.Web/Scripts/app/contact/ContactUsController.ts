module Swu {
    @Module("app")
    @Controller({ name: "ContactUsController" })
    export class ContactUsController {
        static $inject: Array<string> = ["$scope", "$state"];
        constructor(private $scope: ng.IScope, private $state: ng.ui.IState) {

        }
        init(): void {
        };

    }
}