module Swu {
    export interface IResearchBoardScope extends IPagination {
        id: number;
        items: Webboarditems[];
        displayItems: Webboarditems[];
        currentUser: IUserProfile;
        canAddNew: boolean;
        canEdit(creatorId: string): boolean;

        canEdit(creatorId: string): boolean;
        getCurrentUser(): IUserProfile;
        search(): void;
        currentPage: number;
        pageSize: number;
        totalPageNumber: number;
        criteria: SearchCritirea;
        getTotalPageNumber(): number;
        addNew(): void;
        edit(id: string): void;
        getFileName(path: string): string;
    }
    @Module("app")
    @Controller({ name: "ResearchBoardController" })
    export class ResearchBoardController {
        static $inject: Array<string> = ["$scope", "$rootScope", "$state", "webboardService", "$stateParams", "$sce", "AuthServices", "$uibModal"];
        constructor(private $scope: IResearchBoardScope, private $rootScope: IRootScope, private $state: ng.ui.IState, private webboardService: IwebboardService, private $stateParams: ng.ui.IStateParamsService, private $sce: ng.ISCEService, private auth: IAuthServices, private $uibModal: ng.ui.bootstrap.IModalService) {
            this.$scope.id = this.$stateParams["id"];
            //Pagination section
            this.$scope.getTotalPageNumber = (): number => {
                return Math.ceil((this.$scope.displayItems.length) / this.$scope.pageSize);
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

            this.$scope.getCurrentUser = () => {
                if (this.$scope.currentUser == null) {
                    this.$scope.currentUser = this.auth.getCurrentUser();
                }
                return this.$scope.currentUser;
            };
            this.$scope.search = () => {
                this.webboardService.getResearchItems(this.$scope.criteria).then((response) => {
                    this.$scope.items = response;
                    console.log(response);
                    this.$scope.displayItems = _.filter(this.$scope.items, (item: Webboarditems) => {
                        return item.type == BoardType.research && item.categoryId == this.$scope.id;
                    });
                    this.$scope.totalPageNumber = this.$scope.getTotalPageNumber();
                }, (error) => { });
            };
            this.$scope.canEdit = (creatorId: string): boolean => {
                var _canEdit = false;
                if (this.$scope.currentUser != null) {
                    _canEdit = this.$scope.currentUser.id == creatorId;
                }
                return _canEdit;
            };
            this.$scope.addNew = () => {
                var options: ng.ui.bootstrap.IModalSettings = {
                    templateUrl: '/Scripts/app/board/view/research.tmpl.html',
                    controller: ResearchModalController,
                    resolve: {
                        id: function () {
                            return "";
                        },
                        categoryId: function () {
                            return $scope.id;
                        },
                        userId: function () {
                            return $scope.getCurrentUser().id;
                        },
                        mode: function () {
                            return actionMode.addNew;
                        }
                    },
                    size: "md"
                };
                this.$uibModal.open(options).result.then(() => {
                    this.$scope.search();
                });
            };
            this.$scope.edit = (id: string): void => {
                var options: ng.ui.bootstrap.IModalSettings = {
                    templateUrl: '/Scripts/app/board/view/research.tmpl.html',
                    controller: ResearchModalController,
                    resolve: {
                        id: function () {
                            return id;
                        },
                        categoryId: function () {
                            return $scope.id;
                        },
                        userId: function () {
                            return $scope.getCurrentUser().id;
                        },
                        mode: function () {
                            return actionMode.edit;
                        }
                    },
                    size: "md"
                };
                this.$uibModal.open(options).result.then(() => {
                    this.$scope.search();
                });
            };
            this.$scope.getFileName = (path: string): string => {
                var fileName = path.split('\\').pop().split('/').pop();
                return fileName;
            };
            this.init();
        }
        init(): void {
            this.$scope.currentUser = this.$scope.getCurrentUser();
            if (this.$scope.currentUser != null) {
                this.$scope.canAddNew = true;
            }
            this.$scope.items = [];
            this.$scope.displayItems = [];
            this.$scope.search();
        };

    }
}