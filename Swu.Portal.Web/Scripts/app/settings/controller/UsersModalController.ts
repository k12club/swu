module Swu {
    interface UserModalScope extends ng.IScope {
        user: IUserProfile;
        roles: IRole[];
        getRoles(): void;
        validate(): void;
        selectedRole: string;
        submit(): void;
    }
    @Module("app")
    @Controller({ name: "UsersModalController" })
    export class UsersModalController {
        static $inject: Array<string> = ["$scope", "$state","userService"];
        constructor(private $scope: UserModalScope, private $state: ng.ui.IState, private userService: IuserService) {
            this.$scope.validate = (): void => {
                $('form').validator();
            };
            this.$scope.getRoles = (): void => {
                this.userService.getRoles().then((response) => {
                    this.$scope.roles = response;
                    this.$scope.selectedRole = _.first(this.$scope.roles).id;
                }, (error) => { });
            };
            this.$scope.submit = () => {
                console.log(this.$scope.user);
            };
            this.init();
        }
        init(): void {
            this.$scope.validate();
            this.$scope.getRoles();
        };

    }
}