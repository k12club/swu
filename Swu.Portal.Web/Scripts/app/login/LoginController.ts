module Swu {
    interface ILoginScope extends ng.IScope {
        showModal: boolean;
        ShowModalLogin(flag:boolean): void;
        Login(): void;
    }
    @Module("app")
    @Controller({ name: "LoginController" })
    export class LoginController {
        static $inject: Array<string> = ["$scope", "$state"];
        constructor(private $scope: ILoginScope, private $state: ng.ui.IStateService) {
            this.$scope.showModal = false;
            this.$scope.ShowModalLogin = (flag:boolean) => {
                this.$scope.showModal = flag;
            }
            this.$scope.Login = () => {
                this.$scope.showModal = false;
                this.$state.go("settings");
            }
        }
    }
}