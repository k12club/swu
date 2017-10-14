module Swu {
    interface NewsDetailModalScope extends baseControllerScope {
        id: number;
        lang: string;
        mode: actionMode;
        news: INews;
        selectedCateogry: string;
        file: any;
        title: string;
        displayStartDate: string;

        get(id: number): void;
        validate(): void;
        isValid(): boolean;
        cancel(): void;
    }
    @Module("app")
    @Controller({ name: "NewsDetailModalController" })
    export class NewsDetailModalController {
        static $inject: Array<string> = ["$scope","$rootScope", "$state", "newsManagementService", "toastr", "$modalInstance", "AuthServices", "id","lang"];
        constructor(private $scope: NewsDetailModalScope, private $rootScope: IRootScope, private $state: ng.ui.IStateService, private newsManagementService: InewsManagementService, private toastr: Toastr, private $modalInstance: ng.ui.bootstrap.IModalServiceInstance, private auth: IAuthServices, private id: number, private lang:string) {
            this.$scope.id = id;
            this.$scope.lang = lang;
            this.$scope.get = (id: number): void => {
                this.newsManagementService.getById(id).then((response) => {
                    this.$scope.news = response;
                    this.$scope.displayStartDate = moment(this.$scope.news.startDate).format("MM/DD/YYYY");
                    switch (this.$scope.lang) {
                        case "en": {
                            this.$scope.news.title = this.$scope.news.title_en;
                            this.$scope.news.description = this.$scope.news.description_en;
                            break;
                        }
                        case "th": {
                            this.$scope.news.title = this.$scope.news.title_th;
                            this.$scope.news.description = this.$scope.news.description_th;
                            break;
                        }
                    }
                }, (error) => { });
            }
            this.$scope.cancel = () => {
                this.$modalInstance.dismiss("");
            }
            this.init();
        }
        init(): void {
            this.$scope.mode = actionMode.edit;
            this.$scope.get(this.$scope.id);
        };
    }
}