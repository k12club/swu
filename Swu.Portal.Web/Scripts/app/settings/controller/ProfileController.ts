﻿module Swu {
    interface ProfileScope extends baseControllerScope {
        currentUser: IUserProfile;
        file: any;

        parent: IUserProfile;
        waiting: IUserProfile;

        child: IUserProfile;

        edit(): void;
        getCurrentUser(): void;
        approve(parentId: string): void;
        reject(parentId: string): void;

        personalFile: any;
        uploadFile(): void;
        getFileName(path: string): string;
        addNew(): void;
        removeFile(id: number): void;
    }

    @Module("app")
    @Controller({ name: "ProfileController" })
    export class ProfileController {
        static $inject: Array<string> = ["$scope", "$rootScope", "$state", "profileService", "AuthServices", "$uibModal", "$timeout", "AppConstant"];
        constructor(private $scope: ProfileScope, private $rootScope: IRootScope, private $state: ng.ui.IStateService, private profileService: IprofileService, private auth: IAuthServices, private $uibModal: ng.ui.bootstrap.IModalService, private $timeout: ng.ITimeoutService, private AppConstant: AppConstant) {
            this.$scope.getCurrentUser = (): void => {
                this.$scope.currentUser = this.auth.getCurrentUser();
                this.$scope.swapLanguage(this.$rootScope.lang);
            }
            this.$scope.edit = () => {
                var options: ng.ui.bootstrap.IModalSettings = {
                    templateUrl: '/Scripts/app/settings/view/profile.tmpl.html',
                    controller: ProfileModalController,
                    size: 'lg'
                };
                this.$uibModal.open(options).result.then((user: IUserProfile) => {
                    this.auth.updateProfile(() => {
                        $timeout(function () {
                            $scope.currentUser = auth.getCurrentUser();
                            $scope.swapLanguage($rootScope.lang);
                        });
                    }, () => { });
                });
            };
            this.$scope.swapLanguage = (lang: string): void => {
                switch (lang) {
                    case "en": {
                        this.$scope.currentUser.firstName = this.$scope.currentUser.firstName_en;
                        this.$scope.currentUser.lastName = this.$scope.currentUser.lastName_en;
                        this.$scope.currentUser.position = this.$scope.currentUser.position_en;
                        this.$scope.currentUser.description = this.$scope.currentUser.description_en;
                        this.$scope.currentUser.tag = this.$scope.currentUser.tag_en;
                        this.$scope.currentUser.lineId = this.$scope.currentUser.lineId;
                        this.$scope.currentUser.officeTel = this.$scope.currentUser.officeTel;
                        this.$scope.currentUser.mobile = this.$scope.currentUser.mobile;
                        if (this.$scope.currentUser.selectedRoleName == "Student") {
                            if (this.$scope.currentUser.parent != null) {
                                this.$scope.currentUser.parent.firstName = this.$scope.currentUser.parent.firstName_en;
                                this.$scope.currentUser.parent.lastName = this.$scope.currentUser.parent.lastName_en;
                                var _approve = this.$scope.currentUser.parent.approve;
                                if (_approve) {
                                    this.$scope.parent = this.$scope.currentUser.parent;
                                    this.$scope.waiting = null;
                                } else {
                                    this.$scope.waiting = this.$scope.currentUser.parent;
                                    this.$scope.parent = null;
                                }
                            } else {
                                this.$scope.waiting = null;
                                this.$scope.parent = null;
                            }
                        } else if (this.$scope.currentUser.selectedRoleName == "Parent") {
                            if (this.$scope.currentUser.child != null) {
                                this.$scope.currentUser.child.firstName = this.$scope.currentUser.child.firstName_en;
                                this.$scope.currentUser.child.lastName = this.$scope.currentUser.child.lastName_en;
                                var _approve = this.$scope.currentUser.child.approve;
                                if (_approve) {
                                    this.$scope.child = this.$scope.currentUser.child;
                                } else {
                                    this.$scope.child = null;
                                }
                            } else {
                                this.$scope.child = null;
                            }
                        } else { }
                        break;
                    }
                    case "th": {
                        this.$scope.currentUser.firstName = this.$scope.currentUser.firstName_th;
                        this.$scope.currentUser.lastName = this.$scope.currentUser.lastName_th;
                        this.$scope.currentUser.position = this.$scope.currentUser.position_th;
                        this.$scope.currentUser.description = this.$scope.currentUser.description_th;
                        this.$scope.currentUser.tag = this.$scope.currentUser.tag_th;
                        this.$scope.currentUser.lineId = this.$scope.currentUser.lineId;
                        this.$scope.currentUser.officeTel = this.$scope.currentUser.officeTel;
                        this.$scope.currentUser.mobile = this.$scope.currentUser.mobile;
                        if (this.$scope.currentUser.selectedRoleName == "Student") {
                            if (this.$scope.currentUser.parent != null) {
                                this.$scope.currentUser.parent.firstName = this.$scope.currentUser.parent.firstName_th;
                                this.$scope.currentUser.parent.lastName = this.$scope.currentUser.parent.lastName_th;
                                var _approve = this.$scope.currentUser.parent.approve;
                                if (_approve) {
                                    this.$scope.parent = this.$scope.currentUser.parent;
                                    this.$scope.waiting = null;
                                } else {
                                    this.$scope.waiting = this.$scope.currentUser.parent;
                                    this.$scope.parent = null;
                                }
                            } else {
                                this.$scope.waiting = null;
                                this.$scope.parent = null;
                            }
                        } else if (this.$scope.currentUser.selectedRoleName == "Parent") {
                            if (this.$scope.currentUser.child != null) {
                                this.$scope.currentUser.child.firstName = this.$scope.currentUser.child.firstName_en;
                                this.$scope.currentUser.child.lastName = this.$scope.currentUser.child.lastName_en;
                                var _approve = this.$scope.currentUser.child.approve;
                                if (_approve) {
                                    this.$scope.child = this.$scope.currentUser.child;
                                } else {
                                    this.$scope.child = null;
                                }
                            } else {
                                this.$scope.child = null;
                            }
                        } else { }
                        break;
                    }
                }
            }
            this.$rootScope.$watch("lang", function (newValue: string, oldValue: string) {
                if ($scope.currentUser != undefined || $scope.currentUser != null) {
                    $scope.swapLanguage(newValue);
                }
            });
            this.$scope.approve = (parentId: string): void => {
                this.profileService.approve(this.$scope.currentUser.id, parentId).then((response) => {
                    this.auth.updateProfile(() => {
                        $timeout(function () {
                            $scope.currentUser = auth.getCurrentUser();
                            $scope.swapLanguage($rootScope.lang);
                        });
                    }, () => { });
                }, (error) => { });
            };
            this.$scope.reject = (parentId: string): void => {
                this.profileService.reject(this.$scope.currentUser.id, parentId).then((response) => {
                    this.auth.updateProfile(() => {
                        $timeout(function () {
                            $scope.currentUser = auth.getCurrentUser();
                            $scope.swapLanguage($rootScope.lang);
                        });
                    }, () => { });
                }, (error) => { });
            };
            this.$scope.addNew = () => {
                var options: ng.ui.bootstrap.IModalSettings = {
                    templateUrl: '/Scripts/app/settings/view/personalFile.tmpl.html',
                    controller: PersonalFileModalController,
                    resolve: {
                        id: function () {
                            return 0;
                        },
                        userId: function () {
                            return $scope.currentUser.id;
                        },
                        mode: function () {
                            return actionMode.addNew;
                        }
                    }
                };
                this.$uibModal.open(options).result.then(() => {
                    this.auth.updateProfile(() => {
                        $timeout(function () {
                            $scope.currentUser = auth.getCurrentUser();
                            $scope.swapLanguage($rootScope.lang);
                            toastr.success("success");
                        });
                    }, () => { });
                });
            };
            this.$scope.getFileName = (path: string): string => {
                var fileName = path.split('\\').pop().split('/').pop();
                return fileName;
            };
            this.$scope.removeFile = (id: number) => {
                this.profileService.removeFile(id).then((response) => {
                    this.auth.updateProfile(() => {
                        $timeout(function () {
                            $scope.currentUser = auth.getCurrentUser();
                            $scope.swapLanguage($rootScope.lang);
                            toastr.success("success");
                        });
                    }, () => { });
                }, (error) => {
                    toastr.error("Failed");
                });
            };
            this.init();
        }
        init(): void {
            this.$scope.getCurrentUser();
            this.$scope.swapLanguage(this.$rootScope.lang);
        };

    }
}