module Swu {
    interface UserModalScope extends ng.IScope {
        $parent: any;
        user: IUserProfile;
        roles: IRole[];
        getRoles(): void;
        validate(): void;
        isValid(): boolean;
        selectedRole: string;
        submit(): void;
    }
    @Module("app")
    @Controller({ name: "UsersModalController" })
    export class UsersModalController {
        static $inject: Array<string> = ["$scope", "$state", "userService", "toastr"];
        constructor(private $scope: UserModalScope, private $state: ng.ui.IState, private userService: IuserService, private toastr: Toastr) {
            this.$scope.validate = (): void => {
                $('form').validator();
            };
            this.$scope.isValid = (): boolean => {
                return ($('#form').validator('validate').has('.has-error').length === 0);
            };
            this.$scope.getRoles = (): void => {
                this.userService.getRoles().then((response) => {
                    this.$scope.roles = response;
                    this.$scope.selectedRole = _.first(this.$scope.roles).id;
                }, (error) => { });
            };
            this.$scope.submit = () => {
                if (this.$scope.isValid()) {
                    var _selectedRole = _.filter(this.$scope.roles, function (item, index) {
                        return item.id == $scope.selectedRole;
                    });
                    this.$scope.user.selectedRoleName = _selectedRole[0].name;
                    this.userService.addNew(this.$scope.user).then((response) => {
                        this.$scope.$parent.showModal = false;
                        if (response) {
                            this.$scope.$parent.getUsers();
                            this.toastr.success("Success");
                        } else {
                            this.toastr.error("Error");
                        }
                        this.$scope.user = {};
                    }, (error) => { });
                }
            };
            this.init();
        }
        init(): void {
            this.$scope.validate();
            this.$scope.getRoles();
        };

    }
}