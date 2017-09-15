module Swu {
    interface ForumModalScope extends ng.IScope {
        id: string;
        categoryId: number;
        userId: string;

        mode: actionMode;
        currentUserId: string;

        title: string;
        forum: Webboarditems;

        getCurrentUser(): IUserProfile;
        edit(id: string): void;
        delete(): void;
        validate(): void;
        isValid(): boolean;
        cancel(): void;
        save(): void;
    }
    @Module("app")
    @Controller({ name: "ForumModalController" })
    export class ForumModalController {
        static $inject: Array<string> = ["$scope", "$state", "webboardService", "toastr", "$modalInstance", "profileService", "AuthServices", "id", "categoryId", "userId", "mode"];
        constructor(private $scope: ForumModalScope, private $state: ng.ui.IStateService, private webboardService: IwebboardService, private toastr: Toastr, private $modalInstance: ng.ui.bootstrap.IModalServiceInstance, private profileService: IprofileService, private auth: IAuthServices, private id: string, private categoryId: number, private userId: string, private mode: number) {
            this.$scope.id = id;
            this.$scope.mode = mode;
            this.$scope.categoryId = categoryId;
            this.$scope.userId = userId;
            this.$scope.edit = (id: string): void => {
                this.webboardService.getPostById(id).then((response) => {
                    this.$scope.forum = response;
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
                    this.$scope.forum.categoryId = this.$scope.categoryId;
                    this.$scope.forum.userId = this.$scope.userId;
                    this.webboardService.addOrUpdatePost(this.$scope.forum).then((response) => {
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
                this.$scope.title = "Add New Post";
            } else if (this.$scope.mode == 2) {
                this.$scope.title = "Edit Post";
                this.$scope.mode = actionMode.edit;
                this.$scope.edit(this.$scope.id);
            }

        };

    }
}