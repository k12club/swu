
module Swu {
    interface ForumScope extends ng.IScope {
        id: string;
        forumAndComments: ForumAndComments;
        comment: string;
        canPost: boolean;
        currentUser: IUserProfile;

        getCurrentUser(): IUserProfile;
        getForumAndComments(id: string): void;
        save(): void;
        canEdit(creatorId: string): boolean;
        editComment(id: number): void;
    }
    @Module("app")
    @Controller({ name: "ForumController" })
    export class ForumController {
        static $inject: Array<string> = ["$scope", "$rootScope", "$state", "$stateParams", "$sce", "forumService", "AuthServices", "toastr","$uibModal"];
        constructor(private $scope: ForumScope, private $rootScope: IRootScope, private $state: ng.ui.IState, private $stateParams: ng.ui.IStateParamsService, private $sce: ng.ISCEService, private forumService: IforumService, private auth: IAuthServices, private toastr: Toastr, private $uibModal: ng.ui.bootstrap.IModalService) {
            this.$scope.id = this.$stateParams["id"];
            this.$scope.getForumAndComments = (id: string) => {
                this.forumService.getForumDetail(id).then((response) => {
                    this.$scope.forumAndComments = response;
                    _.map(this.$scope.forumAndComments.comments, (c) => {
                        c.description = this.$sce.trustAsHtml(c.description);
                    });
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
            this.$scope.getCurrentUser = () => {
                if (this.$scope.currentUser == null) {
                    this.$scope.currentUser = this.auth.getCurrentUser();
                }
                return this.$scope.currentUser;
            };
            this.$scope.canEdit = (creatorId: string): boolean => {
                var _canEdit = false;
                if (this.$scope.currentUser != null) {
                    _canEdit = this.$scope.currentUser.id == creatorId;
                }
                return _canEdit;
            };
            this.$scope.editComment = (id: number): void => {
                var options: ng.ui.bootstrap.IModalSettings = {
                    templateUrl: '/Scripts/app/forum/view/comment.tmpl.html',
                    controller: CommentModalController,
                    resolve: {
                        id: function () {
                            return id;
                        },
                        mode: function () {
                            return actionMode.edit;
                        }
                    },
                    size: "lg"
                };
                this.$uibModal.open(options).result.then(() => {
                    this.$scope.getForumAndComments(this.$scope.id);
                });
            };
            this.init();
        }
        init(): void {
            this.$scope.comment = "";
            this.$scope.currentUser = this.$scope.getCurrentUser();
            this.$scope.canPost = this.auth.isLoggedIn();
            this.$scope.getForumAndComments(this.$scope.id);
        };

    }
}