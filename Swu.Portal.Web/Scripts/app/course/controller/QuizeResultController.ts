module Swu {
    interface QuizeResultScope extends ng.IScope {
        students: StudentScore[];
        splitStudents1: StudentScore[];
        splitStudents2: StudentScore[];
        close(): void;
    }
    @Module("app")
    @Controller({ name: "QuizeResultController" })
    export class QuizeResultController {
        static $inject: Array<string> = ["$scope", "$modalInstance","studentScores"];
        constructor(private $scope: QuizeResultScope, private $modalInstance: ng.ui.bootstrap.IModalServiceInstance, private studentScores: StudentScore[]) {
            this.$scope.students = studentScores;
            this.$scope.close = () => {
                this.$modalInstance.dismiss("");
            };
            this.init();
        }
        init(): void {
            this.$scope.splitStudents1 = [];
            this.$scope.splitStudents2 = [];
            _.forEach(this.$scope.students, (value, key) => {
                if (key < (this.$scope.students.length / 2)) {
                    this.$scope.splitStudents1.push({
                        id: value.id,
                        activated: value.activated,
                        name: value.name,
                        score: value.score,
                        studentId: value.studentId
                    });
                } else {
                    this.$scope.splitStudents2.push({
                        id: value.id,
                        activated: value.activated,
                        name: value.name,
                        score: value.score,
                        studentId: value.studentId
                    });
                }
            });
        };

    }
}