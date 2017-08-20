module Swu {
    export interface ICourseScope extends ng.IScope {
        id: number;
        courseDetail: ICourseAllDetail;
        splitStudents1: IStudentDetail[];
        splitStudents2: IStudentDetail[];
        getCourse(id: number): void;
    }
    @Module("app")
    @Controller({ name: "CourseController" })
    export class CourseController {
        static $inject: Array<string> = ["$scope", "$state", "courseService", "$stateParams", "$sce"];
        constructor(private $scope: ICourseScope, private $state: ng.ui.IState, private courseService: IcourseService, private $stateParams: ng.ui.IStateParamsService, private $sce: ng.ISCEService) {
            this.$scope.id = this.$stateParams["id"];
            this.$scope.getCourse = (id: number) => {
                this.courseService.getById(id).then((response) => {
                    this.$scope.courseDetail = response;
                    this.$scope.courseDetail.course.fullDescription = $sce.trustAsHtml(this.$scope.courseDetail.course.fullDescription);
                    _.map(this.$scope.courseDetail.teachers, function (t) {
                        t.description = $sce.trustAsHtml(t.description);
                    });
                    _.forEach(this.$scope.courseDetail.students, (value, key) => {
                        if (key < (this.$scope.courseDetail.students.length / 2)) {
                            this.$scope.splitStudents1.push({
                                id: value.id,
                                number: key+1,
                                studentId: value.studentId,
                                name: value.name,
                                description: value.description,
                                imageUrl: value.imageUrl
                            });
                        } else {
                            this.$scope.splitStudents2.push({
                                id: value.id,
                                number: key+1,
                                studentId: value.studentId,
                                name: value.name,
                                description: value.description,
                                imageUrl: value.imageUrl
                            });
                        }
                    });
                }, (error) => { });
            }
            this.init();
        }
        init(): void {
            this.$scope.splitStudents1 = [];
            this.$scope.splitStudents2 = [];
            this.$scope.getCourse(this.$scope.id);
        };

    }
}