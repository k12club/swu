module Swu {
    interface UserModalScope extends ng.IScope {
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
            this.init();
        }
        init(): void {
            this.$scope.validate();
        };

    }
}