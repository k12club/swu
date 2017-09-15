module Swu {
    interface CommentModalScope extends ng.IScope {
        id: number;
        comment: Comment;

        mode: actionMode;
        currentUserId: string;

        title: string;

        getCurrentUser(): IUserProfile;
        edit(id: number): void;
        delete(): void;
        validate(): void;
        isValid(): boolean;
        cancel(): void;
        save(): void;
    }
    @Module("app")
    @Controller({ name: "CommentModalController" })
    export class CommentModalController {
        static $inject: Array<string> = ["$scope", "$state", "forumService", "toastr", "$modalInstance", "profileService", "AuthServices", "id", "mode"];
        constructor(private $scope: CommentModalScope, private $state: ng.ui.IStateService, private forumService: IforumService, private toastr: Toastr, private $modalInstance: ng.ui.bootstrap.IModalServiceInstance, private profileService: IprofileService, private auth: IAuthServices, private id: number, private mode: number) {
            this.$scope.id = id;
            this.$scope.mode = mode;
            this.$scope.edit = (id: number): void => {
                this.forumService.getCommentById(id).then((response) => {
                    this.$scope.comment = response;
                }, (error) => { });
            }
            this.$scope.validate = (): void => {
                $('form').validator();
            };
            this.$scope.isValid = (): boolean => {
                return ($('#form').validator('validate').has('.has-error').length === 0);
            };
            this.$scope.cancel = () => {
                this.$modalInstance.dismiss("");
            }
            this.$scope.save = (): void => {
                if (this.$scope.isValid()) {
                    this.forumService.updateComment(this.$scope.comment).then((response) => {
                        this.$modalInstance.close(response);
                    }, (error) => { });
                }
            }
            $scope.delete = () => {

            }
            this.init();
        }
        init(): void {
            if (this.$scope.mode == 1) {
                this.$scope.mode = actionMode.addNew;
                this.$scope.title = "Add New Comment";
            } else if (this.$scope.mode == 2) {
                this.$scope.title = "Edit Comment";
                this.$scope.mode = actionMode.edit;
                this.$scope.edit(this.$scope.id);
            }

        };

    }
}