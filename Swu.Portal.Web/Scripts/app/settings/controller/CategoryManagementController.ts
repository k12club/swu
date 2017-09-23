module Swu {
    export interface CategoryScope extends ng.IScope {
        pageSize: number;

        course: WebboardCategory[];
        displayCourse: WebboardCategory[];
        currentPage1: number;
        totalPageNumber1: number;
        paginate1<T>(data: T[], displayData: T[], pageSize: number, currentPage: number): void;
        next1(): void;
        prev1(): void;
        changePage1(page: number): void;
        getTotalPageNumber1(): number;
        getData1(): void;
        addNew1(): void;
        edit1(id: number): void;


        research: WebboardCategory[];
        displayResearch: WebboardCategory[];
        currentPage2: number;
        totalPageNumber2: number;
        paginate2<T>(data: T[], displayData: T[], pageSize: number, currentPage: number): void;
        next2(): void;
        prev2(): void;
        changePage2(page: number): void;
        getTotalPageNumber2(): number;
        getData2(): void;
        addNew2(): void;
        edit2(id: number): void;


        forum: WebboardCategory[];
        displayForum: WebboardCategory[];
        currentPage3: number;
        totalPageNumber3: number;
        paginate3<T>(data: T[], displayData: T[], pageSize: number, currentPage: number): void;
        next3(): void;
        prev3(): void;
        changePage3(page: number): void;
        getTotalPageNumber3(): number;
        getData3(): void;
        addNew3(): void;
        edit3(id: number): void;
    }
    @Module("app")
    @Controller({ name: "CategoryManagementController" })
    export class CategoryManagementController {
        static $inject: Array<string> = ["$scope", "$state", "categoryManagementService", "$uibModal"];
        constructor(private $scope: CategoryScope, private $state: ng.ui.IState, private categoryManagementService: IcategoryManagementService, private $uibModal: ng.ui.bootstrap.IModalService) {
            //Pagination section1
            this.$scope.getTotalPageNumber1 = (): number => {
                return (this.$scope.course.length) / this.$scope.pageSize;
            };
            this.$scope.paginate1 = (data: WebboardCategory[], displayData: WebboardCategory[], pageSize: number, currentPage: number) => {
                displayData = data.slice(currentPage * pageSize, (currentPage + 1) * pageSize);
                this.$scope.displayCourse = displayData;
            };
            this.$scope.changePage1 = (page: number) => {
                this.$scope.currentPage1 = page;
                this.$scope.paginate1<WebboardCategory>(this.$scope.course, this.$scope.displayCourse, this.$scope.pageSize, this.$scope.currentPage1);
            };
            this.$scope.next1 = () => {
                var nextPage = this.$scope.currentPage1 + 1;
                if (nextPage < this.$scope.getTotalPageNumber1()) {
                    this.$scope.changePage1(nextPage);
                }
            };
            this.$scope.prev1 = () => {
                var prevPage = this.$scope.currentPage1 - 1;
                if (prevPage >= 0) {
                    this.$scope.changePage1(prevPage);
                }
            };
            //End Pagination section1

            //Pagination section2
            this.$scope.getTotalPageNumber2 = (): number => {
                return (this.$scope.research.length) / this.$scope.pageSize;
            };
            this.$scope.paginate2 = (data: WebboardCategory[], displayData: WebboardCategory[], pageSize: number, currentPage: number) => {
                displayData = data.slice(currentPage * pageSize, (currentPage + 1) * pageSize);
                this.$scope.displayResearch = displayData;
            };
            this.$scope.changePage2 = (page: number) => {
                this.$scope.currentPage2 = page;
                this.$scope.paginate2<WebboardCategory>(this.$scope.course, this.$scope.displayCourse, this.$scope.pageSize, this.$scope.currentPage2);
            };
            this.$scope.next2 = () => {
                var nextPage = this.$scope.currentPage2 + 1;
                if (nextPage < this.$scope.getTotalPageNumber2()) {
                    this.$scope.changePage2(nextPage);
                }
            };
            this.$scope.prev2 = () => {
                var prevPage = this.$scope.currentPage2 - 1;
                if (prevPage >= 0) {
                    this.$scope.changePage2(prevPage);
                }
            };
            //End Pagination section2

            //Pagination section3
            this.$scope.getTotalPageNumber3 = (): number => {
                return (this.$scope.forum.length) / this.$scope.pageSize;
            };
            this.$scope.paginate3 = (data: WebboardCategory[], displayData: WebboardCategory[], pageSize: number, currentPage: number) => {
                displayData = data.slice(currentPage * pageSize, (currentPage + 1) * pageSize);
                this.$scope.displayForum = displayData;
            };
            this.$scope.changePage3 = (page: number) => {
                this.$scope.currentPage3 = page;
                this.$scope.paginate3<WebboardCategory>(this.$scope.course, this.$scope.displayCourse, this.$scope.pageSize, this.$scope.currentPage3);
            };
            this.$scope.next3 = () => {
                var nextPage = this.$scope.currentPage3 + 1;
                if (nextPage < this.$scope.getTotalPageNumber3()) {
                    this.$scope.changePage3(nextPage);
                }
            };
            this.$scope.prev3 = () => {
                var prevPage = this.$scope.currentPage3 - 1;
                if (prevPage >= 0) {
                    this.$scope.changePage3(prevPage);
                }
            };
            //End Pagination section3

            this.$scope.addNew1 = () => {
                var options: ng.ui.bootstrap.IModalSettings = {
                    templateUrl: '/Scripts/app/settings/view/category.tmpl.html',
                    controller: CategoryMangementModalController,
                    resolve: {
                        id: function () {
                            return 0;
                        },
                        type: function () {
                            return 1;
                        },
                        mode: function () {
                            return actionMode.addNew;
                        }
                    }
                };
                this.$uibModal.open(options).result.then(() => {
                    this.$scope.getData1();
                });
            }
            this.$scope.edit1 = (id: number) => {
                var options: ng.ui.bootstrap.IModalSettings = {
                    templateUrl: '/Scripts/app/settings/view/category.tmpl.html',
                    controller: CategoryMangementModalController,
                    resolve: {
                        id: function () {
                            return id;
                        },
                        type: function () {
                            return 1;
                        },
                        mode: function () {
                            return actionMode.edit;
                        }
                    }
                };
                this.$uibModal.open(options).result.then(() => {
                    this.$scope.getData1();
                });
            };
            this.$scope.getData1 = (): void => {
                this.categoryManagementService.getAll1().then((response) => {
                    this.$scope.course = response;
                    this.$scope.totalPageNumber1 = this.$scope.getTotalPageNumber1();
                    this.$scope.paginate1<WebboardCategory>(this.$scope.course, this.$scope.displayCourse, this.$scope.pageSize, this.$scope.currentPage1);
                }, (error) => { });
            };

            this.$scope.addNew2 = () => {
                var options: ng.ui.bootstrap.IModalSettings = {
                    templateUrl: '/Scripts/app/settings/view/category.tmpl.html',
                    controller: CategoryMangementModalController,
                    resolve: {
                        id: function () {
                            return 0;
                        },
                        type: function () {
                            return 2;
                        },
                        mode: function () {
                            return actionMode.addNew;
                        }
                    }
                };
                this.$uibModal.open(options).result.then(() => {
                    this.$scope.getData2();
                });
            }
            this.$scope.edit2 = (id: number) => {
                var options: ng.ui.bootstrap.IModalSettings = {
                    templateUrl: '/Scripts/app/settings/view/category.tmpl.html',
                    controller: CategoryMangementModalController,
                    resolve: {
                        id: function () {
                            return id;
                        },
                        type: function () {
                            return 2;
                        },
                        mode: function () {
                            return actionMode.edit;
                        }
                    }
                };
                this.$uibModal.open(options).result.then(() => {
                    this.$scope.getData2();
                });
            };
            this.$scope.getData2 = (): void => {
                this.categoryManagementService.getAll2().then((response) => {
                    this.$scope.research = response;
                    this.$scope.totalPageNumber2 = this.$scope.getTotalPageNumber2();
                    this.$scope.paginate2<WebboardCategory>(this.$scope.research, this.$scope.displayResearch, this.$scope.pageSize, this.$scope.currentPage2);
                }, (error) => { });
            };

            this.$scope.addNew3 = () => {
                var options: ng.ui.bootstrap.IModalSettings = {
                    templateUrl: '/Scripts/app/settings/view/category.tmpl.html',
                    controller: CategoryMangementModalController,
                    resolve: {
                        id: function () {
                            return 0;
                        },
                        type: function () {
                            return 3;
                        },
                        mode: function () {
                            return actionMode.addNew;
                        }
                    }
                };
                this.$uibModal.open(options).result.then(() => {
                    this.$scope.getData3();
                });
            }
            this.$scope.edit3 = (id: number) => {
                var options: ng.ui.bootstrap.IModalSettings = {
                    templateUrl: '/Scripts/app/settings/view/category.tmpl.html',
                    controller: CategoryMangementModalController,
                    resolve: {
                        id: function () {
                            return id;
                        },
                        type: function () {
                            return 3;
                        },
                        mode: function () {
                            return actionMode.edit;
                        }
                    }
                };
                this.$uibModal.open(options).result.then(() => {
                    this.$scope.getData3();
                });
            };
            this.$scope.getData3 = (): void => {
                this.categoryManagementService.getAll3().then((response) => {
                    this.$scope.forum = response;
                    this.$scope.totalPageNumber3 = this.$scope.getTotalPageNumber3();
                    this.$scope.paginate3<WebboardCategory>(this.$scope.forum, this.$scope.displayResearch, this.$scope.pageSize, this.$scope.currentPage3);
                }, (error) => { });
            };
            this.init();
        }
        init(): void {
            this.$scope.currentPage1 = 0;
            this.$scope.currentPage2 = 0;
            this.$scope.currentPage3 = 0;
            this.$scope.pageSize = 5;
            this.$scope.getData1();
            this.$scope.getData2();
            this.$scope.getData3();
        };

    }
}