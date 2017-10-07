module Swu {
    interface QuizeResultScope extends ng.IScope {
        id: number;
        hasPermission: boolean;
        students: StudentScore[];
        splitStudents1: StudentScore[];
        splitStudents2: StudentScore[];
        close(): void;
        save(): void;
    }
    @Module("app")
    @Controller({ name: "QuizeResultController" })
    export class QuizeResultController {
        static $inject: Array<string> = ["$scope", "$modalInstance", "courseService", "studentScores","hasPermission"];
        constructor(private $scope: QuizeResultScope, private $modalInstance: ng.ui.bootstrap.IModalServiceInstance, private courseService: IcourseService, private studentScores: StudentScore[], private hasPermission:boolean) {
            this.$scope.students = studentScores;
            this.$scope.hasPermission = hasPermission;
            this.$scope.close = () => {
                this.$modalInstance.dismiss("");
            };
            this.$scope.save = () => {
                var students = this.$scope.splitStudents1.concat(this.$scope.splitStudents2);
                this.courseService.saveStudentScores(students).then((response) => {
                    this.$modalInstance.close();
                }, (error) => { });
            };
            this.init();
        }
        init(): void {
            this.$scope.splitStudents1 = [];
            this.$scope.splitStudents2 = [];
            _.forEach(this.$scope.students, (value, key) => {
                if (key < (this.$scope.students.length / 2)) {
                    this.$scope.splitStudents1.push({
                        scoreId: value.scoreId,
                        activated: value.activated,
                        name: value.name,
                        score: value.score,
                        studentId: value.studentId,
                        curriculumId: value.curriculumId,
                        imageUrl : value.imageUrl
                    });
                } else {
                    this.$scope.splitStudents2.push({
                        scoreId: value.scoreId,
                        activated: value.activated,
                        name: value.name,
                        score: value.score,
                        studentId: value.studentId,
                        curriculumId: value.curriculumId,
                        imageUrl: value.imageUrl
                    });
                }
            });
        };

    }
}