module Swu {
    interface ProfileModalScope extends ng.IScope {
        mode: actionMode;
        user: IUserProfile;
        file: any;

        refUsers: string[];
        updateRefUsers(name: string): void;
        selectedUser: string;

        validate(): void;
        isValid(): boolean;
        cancel(): void;
        save(): void;
    }
    @Module("app")
    @Controller({ name: "ProfileModalController" })
    export class ProfileModalController {
        static $inject: Array<string> = ["$scope", "$rootScope", "$state", "userService", "toastr", "$modalInstance", "profileService", "AuthServices"];
        constructor(private $scope: ProfileModalScope, $rootScope: IRootScope, private $state: ng.ui.IState, private userService: IuserService, private toastr: Toastr, private $modalInstance: ng.ui.bootstrap.IModalServiceInstance, private profileService: IprofileService, private AuthServices: IAuthServices) {
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
                models.push({ name: "lang", value: $rootScope.lang });
                this.profileService.updateUserProfile(models).then((response) => {
                    this.$modalInstance.close(response);
                }, (error) => { });
            }

            // gives another movie array on change
            $scope.updateRefUsers = (name: string): void => {
                // MovieRetriever could be some service returning a promise
                userService.getUsersByName(name, $rootScope.lang).then((response) => {
                    this.$scope.refUsers = response;
                }, (error) => { });
            }
            this.init();
        }
        init(): void {
            this.$scope.user = this.AuthServices.getCurrentUser();
            this.$scope.refUsers = [""];
        };

    }
}