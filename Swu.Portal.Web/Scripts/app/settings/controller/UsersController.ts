module Swu {
    interface UserScope extends ng.IScope {
        users: IUserProfile[];
        showModal: boolean;
        ShowModalLogin(flag: boolean): void;
    }
    @Module("app")
    @Controller({ name: "UsersController" })
    export class UsersController {
        static $inject: Array<string> = ["$scope", "$state"];
        constructor(private $scope: UserScope, private $state: ng.ui.IState) {
            this.$scope.ShowModalLogin = (flag: boolean) => {
                this.$scope.showModal = flag;
            }
            this.init();
        }
        init(): void {
            this.$scope.showModal = false;
        };

    }
}