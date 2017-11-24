module Swu {
    interface NewsScope extends IPagination {
        currentPage: number;
        pageSize: number;
        totalPageNumber: number;

        data: INews[];
        display: INews[];

        getData(): void;
        addNew(): void;
        edit(id: number): void;
    }
    @Module("app")
    @Controller({ name: "NewsManagementController" })
    export class NewsManagementController {
        static $inject: Array<string> = ["$scope", "$state", "newsManagementService", "$uibModal"];
        constructor(private $scope: NewsScope, private $state: ng.ui.IState, private newsManagementService: InewsManagementService, private $uibModal: ng.ui.bootstrap.IModalService) {
            //Pagination section
            this.$scope.getTotalPageNumber = (): number => {
                return (this.$scope.data.length) / this.$scope.pageSize;
            };
            this.$scope.paginate = (data: INews[], displayData: INews[], pageSize: number, currentPage: number) => {
                displayData = data.slice(currentPage * pageSize, (currentPage + 1) * pageSize);
                this.$scope.display = displayData;
            };
            this.$scope.changePage = (page: number) => {
                this.$scope.currentPage = page;
                this.$scope.paginate<INews>(this.$scope.data, this.$scope.display, this.$scope.pageSize, this.$scope.currentPage);
            };
            this.$scope.next = () => {
                var nextPage = this.$scope.currentPage + 1;
                if (nextPage < this.$scope.getTotalPageNumber()) {
                    this.$scope.changePage(nextPage);
                }
            };
            this.$scope.prev = () => {
                var prevPage = this.$scope.currentPage - 1;
                if (prevPage >= 0) {
                    this.$scope.changePage(prevPage);
                }
            };
            //End Pagination section

            this.$scope.addNew = () => {
                var options: ng.ui.bootstrap.IModalSettings = {
                    templateUrl: '/Scripts/app/settings/view/news.tmpl.html',
                    controller: NewsManagementModalController,
                    resolve: {
                        id: function () {
                            return 0;
                        },
                        mode: function () {
                            return actionMode.addNew;
                        }
                    }, size: "lg",
                    backdrop: false
                };
                this.$uibModal.open(options).result.then(() => {
                    this.$scope.getData();
                });
            }
            this.$scope.edit = (id: number) => {
                var options: ng.ui.bootstrap.IModalSettings = {
                    templateUrl: '/Scripts/app/settings/view/news.tmpl.html',
                    controller: NewsManagementModalController,
                    resolve: {
                        id: function () {
                            return id;
                        },
                        mode: function () {
                            return actionMode.edit;
                        }
                    }, size: "lg"
                };
                this.$uibModal.open(options).result.then(() => {
                    this.$scope.getData();
                });
            };
            this.$scope.getData = (): void => {
                this.newsManagementService.getAll().then((response) => {
                    this.$scope.data = response;
                    this.$scope.totalPageNumber = this.$scope.getTotalPageNumber();
                    this.$scope.paginate<INews>(this.$scope.data, this.$scope.display, this.$scope.pageSize, this.$scope.currentPage);
                }, (error) => { });
            };
            this.init();
        }
        init(): void {
            this.$scope.currentPage = 0;
            this.$scope.pageSize = 5;
            this.$scope.getData();
        };

    }
}