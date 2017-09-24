module Swu {
    export interface  ICommitteeScope extends baseControllerScope{
        committee: ICommittee[];
    }
    @Module("app")
    @Controller({ name: "CommitteeController" })
    export class CommitteeController {
        static $inject: Array<string> = ["$scope","$rootScope", "$state","committeeService"];
        constructor(private $scope: ICommitteeScope, private $rootScope :IRootScope, private $state: ng.ui.IState, private committeeService: IcommitteeService) {
            this.$scope.swapLanguage = (lang: string): void => {
                switch (lang) {
                    case "en": {
                        _.map($scope.committee, function (c) {
                            c.name = c.name_en;
                            c.position = c.position_en;
                            c.description = c.description_en;
                        });
                        break;
                    }
                    case "th": {
                        _.map($scope.committee, function (c) {
                            c.name = c.name_th;
                            c.position = c.position_th;
                            c.description = c.description_th;
                        });
                        break;
                    }
                }
            };
            this.$rootScope.$watch("lang", function (newValue: string, oldValue: string) {
                if ($scope.committee != undefined || $scope.committee != null) {
                    $scope.swapLanguage(newValue);
                }
            });
            this.init();
        }
        init(): void {
            this.committeeService.getCommittees().then((response) => {
                this.$scope.committee = response;
                this.$scope.swapLanguage(this.$rootScope.lang);
            }, (error) => { });
        };

    }
}