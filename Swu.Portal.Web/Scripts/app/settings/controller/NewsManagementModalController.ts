module Swu {
    interface NewsManagementModalScope extends ng.IScope {
        id: number;
        text: string;
        mode: actionMode;
        news: INews;
        selectedCateogry: string;
        file: any;
        title: string;
        displayStartDate: string;

        getCategory(): void;
        edit(id: number): void;
        validate(): void;
        isValid(): boolean;
        cancel(): void;
        save(): void;
        delete(id: number): void;
    }
    @Module("app")
    @Controller({ name: "NewsManagementModalController" })
    export class NewsManagementModalController {
        static $inject: Array<string> = ["$scope", "$state", "newsManagementService", "toastr", "$modalInstance", "AuthServices", "id", "mode"];
        constructor(private $scope: NewsManagementModalScope, private $state: ng.ui.IStateService, private newsManagementService: InewsManagementService, private toastr: Toastr, private $modalInstance: ng.ui.bootstrap.IModalServiceInstance, private auth: IAuthServices, private id: number, private mode: number) {
            this.$scope.id = id;
            this.$scope.mode = mode;
            this.$scope.edit = (id: number): void => {
                this.newsManagementService.getById(id).then((response) => {
                    this.$scope.news = response;
                    this.$scope.displayStartDate = moment(this.$scope.news.startDate).format("MM/DD/YYYY");
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
                if (this.auth.isLoggedIn()) {
                    if (this.$scope.isValid()) {
                        this.$scope.news.startDate = new Date(this.$scope.displayStartDate);
                        this.$scope.news.createdUserId = this.auth.getCurrentUser().id;
                        var models: NamePairValue[] = [];
                        models.push({ name: "file", value: this.$scope.file });
                        models.push({ name: "news", value: this.$scope.news });
                        this.newsManagementService.addNewOrUpdate(models).then((response) => {
                            this.$modalInstance.close();
                            this.toastr.success("Success");
                        }, (error) => { });
                    }
                } else {
                    this.toastr.error("Time out expired");
                    this.$state.go("app", { reload: true });
                }
            }
            this.$scope.delete = (id: number): void => {
                this.newsManagementService.deleteById(id).then((response) => {
                    this.$modalInstance.close();
                    this.toastr.success("Success");
                }, (error) => { });
            };
            this.init();
        }
        init(): void {
            if (this.$scope.mode == 1) {
                this.$scope.mode = actionMode.addNew;
                this.$scope.title = "Add New News";
            } else if (this.$scope.mode == 2) {
                this.$scope.title = "Edit News";
                this.$scope.mode = actionMode.edit;
                this.$scope.edit(this.$scope.id);
            }

        };

    }
}