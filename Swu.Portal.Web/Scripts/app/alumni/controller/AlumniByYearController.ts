module Swu {
    interface AlumniScope extends ng.IScope {
        year: string;
        students: alumni[];
        init(): void;
    }
    @Module("app")
    @Controller({ name: "AlumniByYearController" })
    export class AlumniByYearController {
        static $inject: Array<string> = ["$scope", "$state", "$stateParams", "AuthServices", "AppConstant", "alumniService"];
        constructor(private $scope: AlumniScope, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService, private auth: IAuthServices, private AppConstant: AppConstant, private alumniService: IalumniService) {
            this.$scope.year = this.$stateParams["year"];
            this.$scope.init = () => {
                this.alumniService.getStudentByYear(this.$scope.year).then((response) => {
                    this.$scope.students = response;
                    console.log(response);
                }, (error) => { });
            };
            this.$scope.init();
        }
    }
}