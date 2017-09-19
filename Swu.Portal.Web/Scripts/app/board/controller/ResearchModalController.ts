module Swu {
    interface ResearchModalScope extends ng.IScope {
        id: string;
        categoryId: number;
        userId: string;

        mode: actionMode;
        currentUserId: string;

        title: string;
        research: Webboarditems;
        displayPublishDate: string;
        file: AttachFile;

        getCurrentUser(): IUserProfile;
        edit(id: string): void;
        delete(): void;
        validate(): void;
        isValid(): boolean;
        cancel(): void;
        save(): void;
    }
    @Module("app")
    @Controller({ name: "ResearchModalController" })
    export class ResearchModalController {
        static $inject: Array<string> = ["$scope", "$state", "webboardService", "toastr", "$modalInstance", "profileService", "AuthServices", "id", "categoryId", "userId", "mode"];
        constructor(private $scope: ResearchModalScope, private $state: ng.ui.IStateService, private webboardService: IwebboardService, private toastr: Toastr, private $modalInstance: ng.ui.bootstrap.IModalServiceInstance, private profileService: IprofileService, private auth: IAuthServices, private id: string, private categoryId: number, private userId: string, private mode: number) {
            this.$scope.id = id;
            this.$scope.mode = mode;
            this.$scope.categoryId = categoryId;
            this.$scope.userId = userId;
            this.$scope.edit = (id: string): void => {
                this.webboardService.getResearchById(id).then((response) => {
                    this.$scope.research = response;
                    this.$scope.displayPublishDate = moment(this.$scope.research.moreDetail.publishDate).format("MM/DD/YYYY");
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
                    var models: NamePairValue[] = [];
                    this.$scope.research.userId = this.$scope.userId;
                    this.$scope.research.categoryId = this.$scope.categoryId;
                    this.$scope.research.moreDetail.publishDate = new Date(this.$scope.displayPublishDate);
                    models.push({ name: "file", value: this.$scope.file });
                    models.push({ name: "research", value: this.$scope.research });
                    this.webboardService.addOrUpdateResearch(models).then((response) => {
                        this.$modalInstance.close(response);
                        this.toastr.success("Success");
                    }, (error) => { });
                }

            }
            this.$scope.delete = () => {

            }
            this.init();
        }
        init(): void {
            if (this.$scope.mode == 1) {
                this.$scope.mode = actionMode.addNew;
                this.$scope.title = "Add New Research";
            } else if (this.$scope.mode == 2) {
                this.$scope.title = "Edit Research";
                this.$scope.mode = actionMode.edit;
                this.$scope.edit(this.$scope.id);
            }

        };

    }
}