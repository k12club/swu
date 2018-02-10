module Swu {
    interface AlumniScope extends baseControllerScope {
        year: string;
        students: alumni[];
        init(): void;
    }
    @Module("app")
    @Controller({ name: "AlumniByYearController" })
    export class AlumniByYearController {
        static $inject: Array<string> = ["$scope", "$rootScope", "$state", "$stateParams", "AuthServices", "AppConstant", "alumniService"];
        constructor(private $scope: AlumniScope, private $rootScope: IRootScope, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService, private auth: IAuthServices, private AppConstant: AppConstant, private alumniService: IalumniService) {
            this.$scope.year = this.$stateParams["year"];
            this.$scope.swapLanguage = (lang: string): void => {
                moment.locale(lang);
                switch (lang) {
                    case "en": {
                        _.map($scope.students, function (s) {
                            s.fullName = s.fullName_en;
                        });
                        break;
                    }
                    case "th": {
                        _.map($scope.students, function (s) {
                            s.fullName = s.fullName_th;
                        });
                        break;
                    }
                }
                console.log($scope.students);
            };
            this.$rootScope.$watch("lang", function (newValue: string, oldValue: string) {
                alumniService.getStudentByYear($scope.year).then((response) => {
                    if (response.length > 0)
                        $scope.students = [];
                    _.forEach(response, (value, key) => {
                        $scope.students.push({
                            studentId: value.studentId,
                            fullName_en: value.fullName_en,
                            fullName_th: value.fullName_th,
                            graduatedYear: value.graduatedYear
                        });
                    });
                    console.log(newValue);
                    $scope.swapLanguage(newValue);
                }, (error) => { });
            });
            this.$scope.init = () => {
                this.alumniService.getStudentByYear(this.$scope.year).then((response) => {
                    this.$scope.students = response;
                }, (error) => { });
            };
            this.$scope.init();
        }
    }
}