module Swu {
    interface ProfileModalScope extends ng.IScope {
        mode: actionMode;
        user: IUserProfile;
        file: any;

        validate(): void;
        isValid(): boolean;
        cancel(): void;
        save(): void;
    }
    @Module("app")
    @Controller({ name: "ProfileModalController" })
    export class ProfileModalController {
        static $inject: Array<string> = ["$scope", "$state", "userService", "toastr", "$modalInstance", "profileService", "AuthServices"];
        constructor(private $scope: ProfileModalScope, private $state: ng.ui.IState, private userService: IuserService, private toastr: Toastr, private $modalInstance: ng.ui.bootstrap.IModalServiceInstance, private profileService: IprofileService, private AuthServices: IAuthServices) {
            this.$scope.validate = (): void => {
                $('form').validator();
            };
            this.$scope.isValid = (): boolean => {
                return ($('#form').validator('validate').has('.has-error').length === 0);
            };
            this.$scope.cancel = () => {
                this.$modalInstance.dismiss("");
            }
            this.$scope.save = (): void => {
                var models: NamePairValue[] = [];
                models.push({ name: "file", value: this.$scope.file });
                models.push({ name: "user", value: this.$scope.user });
                this.profileService.updateUserProfile(models).then((response) => {
                    this.$modalInstance.close(response);
                }, (error) => { });
            }
            this.init();
        }
        init(): void {
            this.$scope.user = this.AuthServices.getCurrentUser();
        };

    }
}