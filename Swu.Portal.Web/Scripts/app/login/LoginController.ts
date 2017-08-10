/// <reference path="../../_references.ts" />
module Swu {
    interface ILoginScope extends ng.IScope {
        userName: string;
        password: string;
        userProfile: IUserProfile;
        showModal: boolean;
        ShowModalLogin(flag: boolean): void;
        Login(): void;
        isLogin(): boolean;
    }
    @Module("app")
    @Controller({ name: "LoginController" })
    export class LoginController {
        static $inject: Array<string> = ["$scope", "$state", "loginServices"];
        constructor(private $scope: ILoginScope, private $state: ng.ui.IStateService, private loginServices: ILoginServices) {
            this.$scope.showModal = false;
            this.$scope.ShowModalLogin = (flag: boolean) => {
                this.$scope.showModal = flag;
            }
            this.$scope.Login = () => {
                console.log({ "userName": this.$scope.userName, "password": this.$scope.password });
                this.loginServices.login({ "userName": this.$scope.userName, "password": this.$scope.password }).then(
                    (data: IUserProfile) => {
                        this.$scope.userProfile = data;
                        this.$scope.showModal = false;
                        //this.$state.go("settings");
                    },
                    (error: any) => {
                    });
            }
            this.$scope.isLogin = (): boolean => {
                return !(this.$scope.userProfile == undefined || this.$scope.userProfile == null);
            }
        }
    }
}