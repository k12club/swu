module Swu {
    interface ProfileScope extends ng.IScope {
        currentUser: IUserProfile;
        file: any;

        edit(): void;
        getCurrentUser(): void;
        save(): void;
    }

    @Module("app")
    @Controller({ name: "ProfileController" })
    export class ProfileController {
        static $inject: Array<string> = ["$scope", "$state", "profileService", "AuthServices", "$uibModal", "$timeout","AppConstant"];
        constructor(private $scope: ProfileScope, private $state: ng.ui.IStateService, private profileService: IprofileService, private auth: IAuthServices, private $uibModal: ng.ui.bootstrap.IModalService, private $timeout: ng.ITimeoutService, private AppConstant: AppConstant) {
            this.$scope.getCurrentUser = (): void => {
                this.$scope.currentUser = this.auth.getCurrentUser();
                console.log(this.$scope.currentUser);
            }
            this.$scope.edit = () => {
                var options: ng.ui.bootstrap.IModalSettings = {
                    templateUrl: '/Scripts/app/settings/view/profile.tmpl.html',
                    controller: ProfileModalController,
                };
                this.$uibModal.open(options).result.then((user: IUserProfile) => {
                    this.auth.updateProfile(() => {
                        $timeout(function () {
                            $scope.currentUser = auth.getCurrentUser();
                        });
                    }, () => { });
                });
            };
            this.init();
        }
        init(): void {
            this.$scope.getCurrentUser();
        };

    }
}