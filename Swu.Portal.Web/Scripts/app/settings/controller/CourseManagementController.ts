module Swu {
    export interface CourseManagementScope extends IPagination {
        currentPage: number;
        pageSize: number;
        totalPageNumber: number;

        courses: ICourseDetail[];
        displayCourses: ICourseDetail[];
        getData(): void;
        addNew(): void;
        edit(id: string): void;
    }
    @Module("app")
    @Controller({ name: "CourseManagementController" })
    export class CourseManagementController {
        static $inject: Array<string> = ["$scope", "$state", "courseManagementService","$uibModal"];
        constructor(private $scope: CourseManagementScope, private $state: ng.ui.IState, private courseManagementService: IcourseManagementService, private $uibModal: ng.ui.bootstrap.IModalService) {
            //Pagination section
            this.$scope.getTotalPageNumber = (): number => {
                return (this.$scope.courses.length) / this.$scope.pageSize;
            };
            this.$scope.paginate = (data: ICourseDetail[], displayData: ICourseDetail[], pageSize: number, currentPage: number) => {
                displayData = data.slice(currentPage * pageSize, (currentPage + 1) * pageSize);
                this.$scope.displayCourses = displayData;
                console.log(this.$scope.displayCourses);
            };
            this.$scope.changePage = (page: number) => {
                this.$scope.currentPage = page;
                this.$scope.paginate<ICourseDetail>(this.$scope.courses, this.$scope.displayCourses, this.$scope.pageSize, this.$scope.currentPage);
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
                    templateUrl: '/Scripts/app/settings/view/courses.tmpl.html',
                    controller: CourseManagementModalController,
                    resolve: {
                        id: function () {
                            return "";
                        },
                        mode: function () {
                            return actionMode.addNew;
                        }
                    },
                    size:"lg"
                };
                this.$uibModal.open(options).result.then(() => {
                    this.$scope.getData();
                });
            }
            this.$scope.edit = (id: string) => {
                var options: ng.ui.bootstrap.IModalSettings = {
                    templateUrl: '/Scripts/app/settings/view/courses.tmpl.html',
                    controller: CourseManagementModalController,
                    resolve: {
                        id: function () {
                            return id;
                        },
                        mode: function () {
                            return actionMode.edit;
                        }
                    },
                    size: "lg"
                };
                this.$uibModal.open(options).result.then(() => {
                    this.$scope.getData();
                });
            };
            this.$scope.getData = (): void => {
                this.courseManagementService.getAll().then((response) => {
                    this.$scope.courses = response;
                    this.$scope.totalPageNumber = this.$scope.getTotalPageNumber();
                    this.$scope.paginate<ICourseDetail>(this.$scope.courses, this.$scope.displayCourses, this.$scope.pageSize, this.$scope.currentPage);
                }, (error) => { });
            };
            this.init();
        }
        init(): void {
            this.$scope.currentPage = 0;
            this.$scope.pageSize = 5;
            this.$scope.getData();
        };

    }
}