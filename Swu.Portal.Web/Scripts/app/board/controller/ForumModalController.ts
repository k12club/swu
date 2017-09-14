module Swu {
    interface ForumModalScope extends ng.IScope {
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
        static $inject: Array<string> = ["$scope", "$state", "webboardService", "toastr", "$modalInstance", "profileService", "AuthServices","categoryId","userId", "mode"];
        constructor(private $scope: ForumModalScope, private $state: ng.ui.IStateService, private webboardService: IwebboardService, private toastr: Toastr, private $modalInstance: ng.ui.bootstrap.IModalServiceInstance, private profileService: IprofileService, private auth: IAuthServices, private categoryId:number,private userId:string, private mode: number) {
            this.$scope.mode = mode;
            this.$scope.categoryId = categoryId;
            this.$scope.userId = userId;
            this.$scope.edit = (id: string): void => {

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
                    //var models: NamePairValue[] = [];
                    //models.push({ name: "name", value: this.$scope.name });
                    //models.push({ name: "shortDescription", value: this.$scope.shortDescription });
                    //models.push({ name: "fullDescription", value: this.$scope.fullDescription });
                    //models.push({ name: "categoryId", value: this.$scope.categoryId });
                    //models.push({ name: "userId", value: this.$scope.userId });
                    //console.log(models);
                    this.webboardService.createNewPost(this.$scope.forum).then((response) => {
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
                //this.$scope.edit(this.$scope.id);
            }

        };

    }
}