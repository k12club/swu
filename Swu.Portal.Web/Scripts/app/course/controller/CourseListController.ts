module Swu {
    export interface ICourseListScope extends ng.IScope {
        currentPage: number;
        pageSize: number;
        totalPageNumber: number;
        criteria: CourseCritirea;
        courses: ICourseBriefDetail[];
        displayCourses: ICourseBriefDetail[];
        getCourseByCriteria(criteria: CourseCritirea): void;
        getTotalPageNumber(): number;
        paginate(courses: ICourseBriefDetail[], pageSize: number, currentPage: number): void;
        changePage(page: number): void;
        search(): void;
    }
    @Module("app")
    @Controller({ name: "CourseListController" })
    export class CourseListController {
        static $inject: Array<string> = ["$scope", "$state", "courseService"];
        constructor(private $scope: ICourseListScope, private $state: ng.ui.IState, private courseService: IcourseService) {
            this.$scope.getCourseByCriteria = (criteria: CourseCritirea) => {
                this.courseService.getCourseByCriteria(this.$scope.criteria).then((response) => {
                    this.$scope.courses = response;
                    this.$scope.totalPageNumber = this.$scope.getTotalPageNumber();
                    //this.$scope.currentPage = 2;
                    this.$scope.paginate(this.$scope.courses, this.$scope.pageSize, this.$scope.currentPage);
                }, (error) => { });
            };
            this.$scope.getTotalPageNumber = (): number => {
                return (this.$scope.courses.length) / this.$scope.pageSize;
            };
            this.$scope.search = () => {
                console.log(this.$scope.criteria);
                this.$scope.getCourseByCriteria(this.$scope.criteria);
            };
            this.$scope.paginate = (courses: ICourseBriefDetail[], pageSize: number, currentPage: number) => {
                console.log(this.$scope.courses.length);
                this.$scope.displayCourses = courses.slice(currentPage * pageSize, (currentPage + 1) * pageSize);
                console.log(this.$scope.displayCourses.length);
            };
            this.$scope.changePage = (page: number) => {
                this.$scope.currentPage = page;
                this.$scope.paginate(this.$scope.courses, this.$scope.pageSize, this.$scope.currentPage);
            };
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