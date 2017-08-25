module Swu {
    export interface IPagination extends ng.IScope {
        paginate<T>(data: T[], displayData: T[], pageSize: number, currentPage: number): void;
        next(): void;
        prev(): void;
        changePage(page: number): void;
    }
    export interface ICourseListScope extends IPagination{
        currentPage: number;
        pageSize: number;
        totalPageNumber: number;
        criteria: CourseCritirea;
        courses: ICourseBriefDetail[];
        displayCourses: ICourseBriefDetail[];
        getCourseByCriteria(criteria: CourseCritirea): void;
        getTotalPageNumber(): number;
        search(): void;
    }
    @Module("app")
    @Controller({ name: "CourseListController" })
    export class CourseListController {
        static $inject: Array<string> = ["$scope", "$rootScope", "$state", "courseService"];
        constructor(private $scope: ICourseListScope, private $rootScope: IRootScope, private $state: ng.ui.IState, private courseService: IcourseService) {
            this.$scope.getCourseByCriteria = (criteria: CourseCritirea) => {
                this.courseService.getCourseByCriteria(this.$scope.criteria).then((response) => {
                    this.$scope.courses = response;
                    this.$scope.totalPageNumber = this.$scope.getTotalPageNumber();
                    //this.$scope.currentPage = 2;
                    this.$scope.paginate<ICourseBriefDetail>(this.$scope.courses,this.$scope.displayCourses, this.$scope.pageSize, this.$scope.currentPage);
                }, (error) => { });
            };
            this.$scope.getTotalPageNumber = (): number => {
                return (this.$scope.courses.length) / this.$scope.pageSize;
            };
            this.$scope.search = () => {
                console.log(this.$scope.criteria);
                this.$scope.getCourseByCriteria(this.$scope.criteria);
            };

            //Pagination section
            this.$scope.paginate = (data: ICourseBriefDetail[], displayData: ICourseBriefDetail[], pageSize: number, currentPage: number) => {
                displayData = data.slice(currentPage * pageSize, (currentPage + 1) * pageSize);
                this.$scope.displayCourses = displayData;
            };
            this.$scope.changePage = (page: number) => {
                this.$scope.currentPage = page;
                console.log('current page: '+page);
                this.$scope.paginate<ICourseBriefDetail>(this.$scope.courses,this.$scope.displayCourses, this.$scope.pageSize, this.$scope.currentPage);
            };
            this.$scope.next = () => {
                var nextPage = this.$scope.currentPage + 1;
                if (nextPage < this.$scope.getTotalPageNumber()){
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
            
            this.init();
        }

        init(): void {
            this.$scope.currentPage = 0;
            this.$scope.pageSize = 5;
            this.$scope.courses = [];
            this.$scope.criteria = {
                name: ""
            };
            this.$scope.getCourseByCriteria(this.$scope.criteria);
        };

    }
}