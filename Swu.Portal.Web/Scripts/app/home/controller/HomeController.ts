module Swu {
    @Module("app")
    @Controller({ name: "HomeController" })
    export class HomeController {
        static $inject: Array<string> = ["$scope", "$state","AuthServices"];
        constructor(private $scope: ng.IScope, private $state: ng.ui.IState, private auth: IAuthServices) {
            this.init();
        }
        init(): void {

        };

    }
}