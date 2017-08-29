module Swu {
    export interface IGeneralBoardScope extends IPagination {
        id: number;
        items: Webboarditems[];
        displayItems: Webboarditems[];

        search(): void;
        currentPage: number;
        pageSize: number;
        totalPageNumber: number;
        criteria: SearchCritirea;
        getTotalPageNumber(): number;
    }
    @Module("app")
    @Controller({ name: "GeneralBoardController" })
    export class GeneralBoardController {
        static $inject: Array<string> = ["$scope", "$rootScope", "$state", "webboardService", "$stateParams", "$sce"];
        constructor(private $scope: IGeneralBoardScope, private $rootScope: IRootScope, private $state: ng.ui.IState, private webboardService: IwebboardService, private $stateParams: ng.ui.IStateParamsService, private $sce: ng.ISCEService) {
            this.$scope.id = this.$stateParams["id"];
            //Pagination section
            this.$scope.getTotalPageNumber = (): number => {
                return (this.$scope.displayItems.length) / this.$scope.pageSize;
            };
            this.$scope.paginate = (data: Webboarditems[], displayData: Webboarditems[], pageSize: number, currentPage: number) => {
                displayData = data.slice(currentPage * pageSize, (currentPage + 1) * pageSize);
                this.$scope.displayItems = displayData;
            };
            this.$scope.changePage = (page: number) => {
                this.$scope.currentPage = page;
                this.$scope.paginate<Webboarditems>(this.$scope.items, this.$scope.displayItems, this.$scope.pageSize, this.$scope.currentPage);
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

            this.$scope.search = () => {
                this.webboardService.getForumsItems(this.$scope.criteria).then((response) => {
                    this.$scope.items = response;
                    this.$scope.displayItems = _.filter(this.$scope.items, (item: Webboarditems) => {
                        return item.type == BoardType.forums && item.categoryId == this.$scope.id;
                    });
                    this.$scope.totalPageNumber = this.$scope.getTotalPageNumber();
                }, (error) => { });
            };
            this.init();
        }
        init(): void {
            this.$scope.items = [];
            this.$scope.displayItems = [];
            this.$scope.search();
        };

    }
}