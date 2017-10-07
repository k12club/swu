module Swu {
    interface NavScope extends ng.IScope {
        goToPage(stateName: string, type: number): void;
    }
    @Module("app")
    @Controller({ name: "NavController" })
    export class NavController {
        static $inject: Array<string> = ["$scope", "$state", "AuthServices"];
        constructor(private $scope: NavScope, private $state: ng.ui.IStateService, private auth: IAuthServices) {
            this.$scope.goToPage = (stateName: string, type: number): void => {
                if (stateName == "board") {
                    $state.go("board", { "type": type }, { reload: true });
                } else {
                    $state.go(stateName, { reload: true });
                }
            };
            this.init();
        }
        init(): void {
        };

    }
}