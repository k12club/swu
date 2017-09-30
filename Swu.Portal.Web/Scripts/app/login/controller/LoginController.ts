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

        validate(): void;
        isValid(): boolean;

        registerUser: IUserProfile;
        register(): void;
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
                this.auth.login({ "userName": this.$scope.userName, "password": this.$scope.password, "lang": this.$rootScope.lang }, this.loginSuccess, this.loginFail);
                this.$state.go("app", { reload: true });
            }
            this.$scope.Logout = () => {
                this.auth.logout();
                this.init();
                this.$state.go("app", { reload: true });
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
            this.$scope.validate = (): void => {
                $('form').validator();
            };
            this.$scope.isValid = (): boolean => {
                return ($('#form').validator('validate').has('.has-error').length === 0);
            };
            this.$scope.register = () => {
                if (this.$scope.isValid()) {
                    this.auth.register(this.$scope.registerUser).then((response) => {
                        toastr.success("Success");
                        this.$scope.showModal = false;
                    }, (error) => {
                        toastr.error("Failed");
                    });
                }
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