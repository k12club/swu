module Swu {
    interface UserModalScope extends ng.IScope {
        user: IUserProfile;
        isValid(): boolean;
        submit(): void;
        validate(): void;
    }
    @Module("app")
    @Controller({ name: "UsersModalController" })
    export class UsersModalController {
        static $inject: Array<string> = ["$scope", "$state"];
        constructor(private $scope: UserModalScope, private $state: ng.ui.IState) {
            this.$scope.validate = (): void => {
                $('form').validator();
            };
            this.$scope.isValid = ():boolean => {
                return $('form').validator('validate').has('.has-error').length == 0;
            }
            this.$scope.submit = () => {
                if (this.$scope.isValid()) {
                    alert('the form is valid');
                }
            };
        }
        init(): void {
            this.$scope.user = {};
            this.$scope.validate();
        };

    }
}