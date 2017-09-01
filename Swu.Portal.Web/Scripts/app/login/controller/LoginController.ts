/// <reference path="../../../_references.ts" />

module Swu {
    interface ILoginScope extends baseControllerScope {
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
                this.loginServices.login({ "userName": this.$scope.userName, "password": this.$scope.password }).then(
                    (data: IUserProfile) => {
                        this.$scope.userProfile = data;
                        this.$scope.swapLanguage(this.$rootScope.lang);
                        this.$scope.showModal = false;
                        //this.$state.go("settings");
                    },
                    (error: any) => {
                    });
            }
            this.$scope.isLogin = (): boolean => {
                return !(this.$scope.userProfile == undefined || this.$scope.userProfile == null);
            }
            this.$scope.swapLanguage = (lang: string): void => {
                if ($scope.userProfile != null || $scope.userProfile != undefined) {
                    switch (lang) {
                        case "en": {
                            $scope.userProfile.firstName = $scope.userProfile.firstName_en;
                            $scope.userProfile.lastName = $scope.userProfile.lastName_en;
                            break;
                        }
                        case "th": {
                            $scope.userProfile.firstName = $scope.userProfile.firstName_th;
                            $scope.userProfile.lastName = $scope.userProfile.lastName_th;
                            break;
                        }
                    }
                }
            };
            this.$scope.changeLanguage = function (lang) {
                $translate.use(lang);
                $rootScope.lang = lang;
                $scope.swapLanguage(lang);
            };
        }
        init = () => {
            this.$scope.showModal = false;

        }
    }
}