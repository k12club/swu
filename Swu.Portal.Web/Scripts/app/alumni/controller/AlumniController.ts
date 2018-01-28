module Swu {
    export interface Years {
        id?: number;
        title: string;
        icon?: string;
        link?: string;
    }
    interface AlumniMainScope extends ng.IScope {
        alumniList: alumni[];
        menus: Years[];

        init(): void;
    }
    @Module("app")
    @Controller({ name: "AlumniController" })
    export class AlumniController {
        static $inject: Array<string> = ["$scope", "$state", "AuthServices", "AppConstant", "alumniService"];
        constructor(private $scope: AlumniMainScope, private $state: ng.ui.IStateService, private auth: IAuthServices, private AppConstant: AppConstant, private alumniService: IalumniService) {
            this.$scope.menus = [];
            this.$scope.init = () => {
                this.alumniService.getYear().then((response) => {
                    console.log(response);
                    _.forEach(response, (value, key) => {
                        this.$scope.menus.push({ id: key, title: value, link: "alumni.year({year:" + value + "})", icon: "flaticon-arrows-3" });
                    });
                    $state.go('alumni.year', { 'year': _.first($scope.menus).title });
                }, (error) => { });
            };
            this.$scope.init();
        }
    }
}