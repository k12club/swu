/// <reference path="../../../_references.ts" />

module Swu {
    interface ILoginScope extends ng.IScope {
        appName: string;
        userName: string;
        password: string;
        userProfile: IUserProfile;
        showModal: boolean;
        ShowModalLogin(flag: boolean): void;
        Login(): void;
        isLogin(): boolean;
        changeLanguage(lang: string): void;
    }
    @Module("app")
    @Controller({ name: "LoginController" })
    export class LoginController {
        static $inject: Array<string> = ["$scope","$rootScope", "$state", "loginServices", "$translate"];
        constructor(private $scope: ILoginScope,private $rootScope: IRootScope, private $state: ng.ui.IStateService, private loginServices: ILoginServices, private $translate: any) {
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
            this.$scope.changeLanguage = function (lang) {
                $translate.use(lang);
                $rootScope.lang = lang;
            };
        }
        init = () => {
            this.$scope.showModal = false;

        }
    }
}