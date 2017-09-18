module Swu {
    export interface AttachFile {
        id: number;
        filePath: string;
    }
    export interface WebboardMoreDetail {
        creatorName?: string;
        publisher?: string;
        contributor?: string;
        publishDate?: Date;
    }
    export interface WebboardCategory {
        id: number;
        title: string;
        link?: string;
        numberofItems?: number;
    }
    export interface Webboarditems {
        id?: number;
        imageUrl?: string;
        name?: string;
        numberOfView?: number;
        numberOfComments?: number;
        shortDescription?: string;
        fullDescription?: string;
        createBy?: string;
        creatorImageUrl?: string;
        type: BoardType
        categoryId?: number;
        userId?: string;
        moreDetail?: WebboardMoreDetail,
        attachFiles: AttachFile[];
    }
    export interface IWebBoardScope extends IPagination {
        categoryName: string;
        type: number;
        categorys: WebboardCategory[];
        displayCategories: WebboardCategory[];
        items: Webboarditems[];
        displayItems: Webboarditems[];
        showAddNewCategory: boolean;
        newCategoty: string;

        search(): void;
        currentPage: number;
        pageSize: number;
        totalPageNumber: number;
        criteria: SearchCritirea;
        getTotalPageNumber(): number;
        addNew(): void;
        save(): void;
        cancel(): void;
    }
    @Module("app")
    @Controller({ name: "WebBoardController" })
    export class WebBoardController {
        static $inject: Array<string> = ["$scope", "$rootScope", "$state", "webboardService", "$stateParams", "$sce"];
        constructor(private $scope: IWebBoardScope, private $rootScope: IRootScope, private $state: ng.ui.IStateService, private webboardService: IwebboardService, private $stateParams: ng.ui.IStateParamsService, private $sce: ng.ISCEService) {
            this.$scope.type = Number(this.$stateParams["type"]);
            //Pagination section
            this.$scope.getTotalPageNumber = (): number => {
                return Math.ceil((this.$scope.items.length) / this.$scope.pageSize);
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
            this.$scope.addNew = () => {
                this.$scope.showAddNewCategory = true;
            };
            this.$scope.save = () => {
                if (this.$scope.newCategoty != "") {
                    switch (this.$scope.type) {
                        case 1: {
                            this.webboardService.addNewForumCategory({ id: 0, title: this.$scope.newCategoty }).then((response) => {
                                this.$scope.showAddNewCategory = false;
                                this.$scope.newCategoty = "";
                                this.$scope.search();
                            }, (error) => { });
                            break;
                        }
                        case 2: {
                            this.webboardService.addNewCourseCategory({ id: 0, title: this.$scope.newCategoty }).then((response) => {
                                this.$scope.showAddNewCategory = false;
                                this.$scope.newCategoty = "";
                                this.$scope.search();
                            }, (error) => { });
                            break;
                        }
                        case 3: {
                            this.webboardService.addNewResearchCategory({ id: 0, title: this.$scope.newCategoty }).then((response) => {
                                this.$scope.showAddNewCategory = false;
                                this.$scope.newCategoty = "";
                                this.$scope.search();
                            }, (error) => { });
                            break;
                        }
                    }
                }
            };
            this.$scope.cancel = () => {
                this.$scope.showAddNewCategory = false;
                this.$scope.newCategoty = "";
                this.$scope.search();
            };
            this.$scope.search = () => {
                switch (this.$scope.type) {
                    case 1: {
                        this.$scope.categoryName = "Forums";
                        this.webboardService.getForumsCategory().then((response) => {
                            this.$scope.categorys = response;
                            _.map(this.$scope.categorys, function (c) {
                                c.link = "board.forum({id:" + c.id + "})";
                            });
                            $state.go('board.forum', { 'id': _.first($scope.categorys).id });
                        }, (error) => { });
                        break;
                    }
                    case 2: {
                        this.$scope.categoryName = "Group Courses";
                        this.webboardService.getCourseCategory().then((response) => {
                            this.$scope.categorys = response;
                            _.map(this.$scope.categorys, function (c) {
                                c.link = "board.course({id:" + c.id + "})";
                            });
                            $state.go('board.course', { 'id': _.first($scope.categorys).id });
                        }, (error) => { });
                        break;
                    }
                    case 3: {
                        this.$scope.categoryName = "Research Type";
                        this.webboardService.getResearchCategory().then((response) => {
                            this.$scope.categorys = response;
                            _.map(this.$scope.categorys, function (c) {
                                c.link = "board.research({id:" + c.id + "})";
                            });
                            $state.go('board.research', { 'id': _.first($scope.categorys).id });
                        }, (error) => { });
                        break;
                    }
                }
            };
            this.init();
        };
        init(): void {
            this.$scope.showAddNewCategory = false;
            this.$scope.currentPage = 0;
            this.$scope.pageSize = 5;
            this.$scope.criteria = {
                name: ""
            };
            this.$scope.categorys = [];
            this.$scope.displayCategories = [];
            this.$scope.items = [];
            this.$scope.search();
        };

    }
}