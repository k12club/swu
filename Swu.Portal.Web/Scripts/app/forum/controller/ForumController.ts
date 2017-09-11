module Swu {
    interface ForumScope extends ng.IScope {
        id: string;
        forumAndComments: ForumAndComments;
        getForumAndComments(id: string): void;
        save(): void;
    }
    @Module("app")
    @Controller({ name: "ForumController" })
    export class ForumController {
        static $inject: Array<string> = ["$scope", "$rootScope", "$state", "$stateParams", "$sce","forumService"];
        constructor(private $scope: ForumScope, private $rootScope: IRootScope, private $state: ng.ui.IState, private $stateParams: ng.ui.IStateParamsService, private $sce: ng.ISCEService, private forumService :IforumService) {
            this.$scope.id = this.$stateParams["id"];
            this.$scope.getForumAndComments = (id: string) => {
                this.forumService.getForumDetail(id).then((response) => {
                    this.$scope.forumAndComments = response;
                }, (error) => { });
            };
            this.$scope.save = (): void => {
                
            };
            this.init();
        }
        init(): void {
            this.$scope.getForumAndComments(this.$scope.id);
        };

    }
}