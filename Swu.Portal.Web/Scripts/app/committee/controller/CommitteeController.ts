module Swu {
    export interface  ICommitteeScope extends baseControllerScope{
        committee: ICommittee[];
        getCommittee(): void;
    }
    @Module("app")
    @Controller({ name: "CommitteeController" })
    export class CommitteeController {
        static $inject: Array<string> = ["$scope", "$state","committeeService"];
        constructor(private $scope: ICommitteeScope, private $state: ng.ui.IState, private committeeService: IcommitteeService) {
            this.$scope.getCommittee = () => {
                this.committeeService.getCommittees().then((response) => {
                    this.$scope.committee = response;
                }, (error) => { });
            };
            this.init();
        }
        init(): void {
            this.$scope.getCommittee();
        };

    }
}