module Swu {
    interface ProfileScope extends baseControllerScope {
        currentUser: IUserProfile;
        file: any;

        edit(): void;
        getCurrentUser(): void;
        save(): void;
    }

    @Module("app")
    @Controller({ name: "ProfileController" })
    export class ProfileController {
        static $inject: Array<string> = ["$scope","$rootScope", "$state", "profileService", "AuthServices", "$uibModal", "$timeout","AppConstant"];
        constructor(private $scope: ProfileScope, private $rootScope:IRootScope, private $state: ng.ui.IStateService, private profileService: IprofileService, private auth: IAuthServices, private $uibModal: ng.ui.bootstrap.IModalService, private $timeout: ng.ITimeoutService, private AppConstant: AppConstant) {
            this.$scope.getCurrentUser = (): void => {
                this.$scope.currentUser = this.auth.getCurrentUser();
                this.$scope.swapLanguage(this.$rootScope.lang);
            }
            this.$scope.edit = () => {
                var options: ng.ui.bootstrap.IModalSettings = {
                    templateUrl: '/Scripts/app/settings/view/profile.tmpl.html',
                    controller: ProfileModalController,
                    size:'lg'
                };
                this.$uibModal.open(options).result.then((user: IUserProfile) => {
                    this.auth.updateProfile(() => {
                        $timeout(function () {
                            $scope.currentUser = auth.getCurrentUser();
                            $scope.swapLanguage($rootScope.lang);
                        });
                    }, () => { });
                });
            };
            this.$scope.swapLanguage = (lang: string): void => {
                switch (lang) {
                    case "en": {
                        this.$scope.currentUser.firstName = this.$scope.currentUser.firstName_en;
                        this.$scope.currentUser.lastName = this.$scope.currentUser.lastName_en;
                        this.$scope.currentUser.position = this.$scope.currentUser.position_en;
                        this.$scope.currentUser.description = this.$scope.currentUser.description_en;
                        this.$scope.currentUser.tag = this.$scope.currentUser.tag_en;
                        this.$scope.currentUser.lineId = this.$scope.currentUser.lineId;
                        this.$scope.currentUser.officeTel = this.$scope.currentUser.officeTel;
                        this.$scope.currentUser.mobile = this.$scope.currentUser.mobile;
                        break;
                    }
                    case "th": {
                        this.$scope.currentUser.firstName = this.$scope.currentUser.firstName_th;
                        this.$scope.currentUser.lastName = this.$scope.currentUser.lastName_th;
                        this.$scope.currentUser.position = this.$scope.currentUser.position_th;
                        this.$scope.currentUser.description = this.$scope.currentUser.description_th;
                        this.$scope.currentUser.tag = this.$scope.currentUser.tag_th;
                        this.$scope.currentUser.lineId = this.$scope.currentUser.lineId;
                        this.$scope.currentUser.officeTel = this.$scope.currentUser.officeTel;
                        this.$scope.currentUser.mobile = this.$scope.currentUser.mobile;
                        break;
                    }
                }
            }
            this.$rootScope.$watch("lang", function (newValue: string, oldValue: string) {
                if ($scope.currentUser != undefined || $scope.currentUser != null) {
                    $scope.swapLanguage(newValue);
                }
            });
            this.init();
        }
        init(): void {
            this.$scope.getCurrentUser();
            this.$scope.swapLanguage(this.$rootScope.lang);
        };

    }
}