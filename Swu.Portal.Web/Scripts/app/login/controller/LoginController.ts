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
        Logout(): void;
        changeLanguage(lang: string): void;
    }
    @Module("app")
    @Controller({ name: "LoginController" })
    export class LoginController {
        static $inject: Array<string> = ["$scope", "$rootScope", "$state", "AuthServices", "$translate", "toastr"];
        constructor(private $scope: ILoginScope, private $rootScope: IRootScope, private $state: ng.ui.IStateService, private auth: IAuthServices, private $translate: any, private toastr: Toastr) {
            this.$scope.ShowModalLogin = (flag: boolean) => {
                this.$scope.showModal = flag;
            }
            this.$scope.Login = () => {
                this.auth.login({ "userName": this.$scope.userName, "password": this.$scope.password }, this.loginSuccess, this.loginFail);
            }
            this.$scope.Logout = () => {
                this.auth.logout();
                this.init();
                console.log(this.$scope.userProfile);
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
            this.init();
        }
        loginSuccess = () => {
            this.$scope.userProfile = this.auth.getCurrentUser();
            this.$scope.showModal = false;
            this.$scope.swapLanguage(this.$rootScope.lang);
        };
        loginFail = () => {
            this.init();
            this.toastr.error("Login failed");
        };
        init = () => {
            this.$scope.userProfile = this.auth.getCurrentUser();
            this.$scope.userName = "";
            this.$scope.password = "";
            this.$scope.showModal = false;

        }
    }
}