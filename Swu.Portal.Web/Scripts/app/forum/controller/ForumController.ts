module Swu {
    interface ForumScope extends ng.IScope {
        id: string;
        forumAndComments: ForumAndComments;
        comment: string;
        canPost: boolean;

        getForumAndComments(id: string): void;
        save(): void;
    }
    @Module("app")
    @Controller({ name: "ForumController" })
    export class ForumController {
        static $inject: Array<string> = ["$scope", "$rootScope", "$state", "$stateParams", "$sce", "forumService", "AuthServices","toastr"];
        constructor(private $scope: ForumScope, private $rootScope: IRootScope, private $state: ng.ui.IState, private $stateParams: ng.ui.IStateParamsService, private $sce: ng.ISCEService, private forumService: IforumService, private auth: IAuthServices, private toastr: Toastr) {
            this.$scope.id = this.$stateParams["id"];
            this.$scope.getForumAndComments = (id: string) => {
                this.forumService.getForumDetail(id).then((response) => {
                    this.$scope.forumAndComments = response;
                }, (error) => { });
            };
            this.$scope.save = (): void => {
                var models: NamePairValue[] = [];
                var userId = this.auth.getCurrentUser().id;
                models.push({ name: "forumId", value: this.$scope.id });
                models.push({ name: "userId", value: userId });
                models.push({ name: "comment", value: this.$scope.comment });
                this.forumService.postComment(models).then((response) => {
                    this.init();
                    this.toastr.success("Success");
                }, (error) => {
                    this.toastr.error("Error");
                });
            };
            this.init();
        }
        init(): void {
            this.$scope.canPost = this.auth.isLoggedIn();
            this.$scope.getForumAndComments(this.$scope.id);
        };

    }
}