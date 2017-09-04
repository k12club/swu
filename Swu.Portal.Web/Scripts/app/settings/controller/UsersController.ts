module Swu {
    export interface UserScope extends ng.IScope {
        users: IUserProfile[];
        waiting: IUserProfile[];
        getUsers(): void;
        addNew(): void;
        edit(id: string): void;
    }
    @Module("app")
    @Controller({ name: "UsersController" })
    export class UsersController {
        static $inject: Array<string> = ["$scope", "$state", "userService","$uibModal"];
        constructor(private $scope: UserScope, private $state: ng.ui.IState, private userService: IuserService, private $uibModal: ng.ui.bootstrap.IModalService) {
            this.$scope.addNew = () => {
                var options: ng.ui.bootstrap.IModalSettings = {
                    templateUrl: '/Scripts/app/settings/view/user.tmpl.html',
                    controller: UsersModalController,
                    resolve: {
                        userId: function () {
                            return "";
                        }
                    }
                };
                this.$uibModal.open(options).result.then(() => { });
            }
            this.$scope.edit = (id: string) => {
                var options: ng.ui.bootstrap.IModalSettings = {
                    templateUrl: '/Scripts/app/settings/view/user.tmpl.html',
                    controller: UsersModalController,
                    resolve: {
                        userId: function () {
                            return id;
                        }
                    }
                };
                this.$uibModal.open(options).result.then(() => { });
            };
            this.$scope.getUsers = (): void => {
                this.userService.getAllUsers().then((response) => {
                    this.$scope.users = _.filter(response, function (item, index) {
                        return item.selectedRoleName != null;
                    });
                    this.$scope.waiting = _.filter(response, function (item, index) {
                        return item.selectedRoleName == null;
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
            this.$scope.getUsers();
        };

    }
}