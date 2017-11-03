module Swu {
    export interface UserScope extends IPagination {
        currentPage: number;
        pageSize: number;
        totalPageNumber: number;

        users: IUserProfile[];
        displayUsers: IUserProfile[];

        waiting: IUserProfile[];
        getUsers(): void;
        addNew(): void;
        edit(id: string): void;
        approve(id: string): void;
    }
    @Module("app")
    @Controller({ name: "UsersController" })
    export class UsersController {
        static $inject: Array<string> = ["$scope", "$state", "userService", "$uibModal"];
        constructor(private $scope: UserScope, private $state: ng.ui.IState, private userService: IuserService, private $uibModal: ng.ui.bootstrap.IModalService) {
            //Pagination section
            this.$scope.getTotalPageNumber = (): number => {
                return (this.$scope.users.length) / this.$scope.pageSize;
            };
            this.$scope.paginate = (data: IUserProfile[], displayData: IUserProfile[], pageSize: number, currentPage: number) => {
                displayData = data.slice(currentPage * pageSize, (currentPage + 1) * pageSize);
                this.$scope.displayUsers = displayData;
            };
            this.$scope.changePage = (page: number) => {
                this.$scope.currentPage = page;
                this.$scope.paginate<IUserProfile>(this.$scope.users, this.$scope.displayUsers, this.$scope.pageSize, this.$scope.currentPage);
            };
            this.$scope.next = () => {
                var nextPage = this.$scope.currentPage + 1;
                if (nextPage < this.$scope.getTotalPageNumber()) {
                    this.$scope.changePage(nextPage);
                }
            };
            this.$scope.prev = () => {
                var prevPage = this.$scope.currentPage - 1;
                if (prevPage >= 0) {
                    this.$scope.changePage(prevPage);
                }
            };
            //End Pagination section

            this.$scope.addNew = () => {
                var options: ng.ui.bootstrap.IModalSettings = {
                    templateUrl: '/Scripts/app/settings/view/user.tmpl.html',
                    controller: UsersModalController,
                    resolve: {
                        userId: function () {
                            return "";
                        },
                        mode: function () {
                            return actionMode.addNew;
                        }
                    },
                    backdrop: false
                };
                this.$uibModal.open(options).result.then(() => {
                    this.$scope.getUsers();
                });
            }
            this.$scope.edit = (id: string) => {
                var options: ng.ui.bootstrap.IModalSettings = {
                    templateUrl: '/Scripts/app/settings/view/user.tmpl.html',
                    controller: UsersModalController,
                    resolve: {
                        userId: function () {
                            return id;
                        },
                        mode: function () {
                            return actionMode.edit;
                        }
                    }
                };
                this.$uibModal.open(options).result.then(() => {
                    this.$scope.getUsers();
                });
            };
            this.$scope.approve = (id: string) => {
                var options: ng.ui.bootstrap.IModalSettings = {
                    templateUrl: '/Scripts/app/settings/view/user.tmpl.html',
                    controller: UsersModalController,
                    resolve: {
                        userId: function () {
                            return id;
                        },
                        mode: function () {
                            return actionMode.approve;
                        }
                    }
                };
                this.$uibModal.open(options).result.then(() => {
                    this.$scope.getUsers();
                });
            };
            this.$scope.getUsers = (): void => {
                this.userService.getAllUsers().then((response) => {
                    this.$scope.users = _.filter(response, function (item, index) {
                        return item.selectedRoleName != null;
                    });
                    console.log(this.$scope.users);
                    this.$scope.totalPageNumber = this.$scope.getTotalPageNumber();
                    this.$scope.paginate<IUserProfile>(this.$scope.users, this.$scope.displayUsers, this.$scope.pageSize, this.$scope.currentPage);

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
            this.$scope.currentPage = 0;
            this.$scope.pageSize = 5;
            this.$scope.getUsers();
        };

    }
}