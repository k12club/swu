module Swu {
    interface UserScope extends ng.IScope {
        users: IUserProfile[];
        getUsers(): void;
        showModal: boolean;
        ShowModalLogin(flag: boolean): void;
    }
    @Module("app")
    @Controller({ name: "UsersController" })
    export class UsersController {
        static $inject: Array<string> = ["$scope", "$state","userService"];
        constructor(private $scope: UserScope, private $state: ng.ui.IState, private userService: IuserService) {
            this.$scope.ShowModalLogin = (flag: boolean) => {
                this.$scope.showModal = flag;
            }
            this.$scope.getUsers = (): void => {
                this.userService.getAllUsers().then((response) => {
                    this.$scope.users = _.filter(response, function (item, index) {
                        return item.selectedRoleName != null;
                    });
                    _.map(this.$scope.users, (item, index) => {
                        switch (item.selectedRoleName) {
                            case "Admin": {
                                item.displayRoleName = "A";
                                break;
                            }
                            case "Officer": {
                                item.displayRoleName = "O";
                                break;
                            }
                            case "Teacher": {
                                item.displayRoleName = "T";
                                break;
                            }
                            case "Student": {
                                item.displayRoleName = "S";
                                break;
                            }
                            case "Parent": {
                                item.displayRoleName = "P";
                                break;
                            }
                        }
                    });

                }, (error) => { });
            };
            this.init();
        }
        init(): void {
            this.$scope.showModal = false;
            this.$scope.getUsers();
        };

    }
}