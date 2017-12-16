module Swu {
    interface AlbumScope extends IPagination {
        currentPage: number;
        pageSize: number;
        totalPageNumber: number;

        data: IPhotoAlbum[];
        display: IPhotoAlbum[];

        getData(): void;
        addNew(): void;
        edit(id: string): void;
    }
    @Module("app")
    @Controller({ name: "AlbumManagementController" })
    export class AlbumManagementController {
        static $inject: Array<string> = ["$scope", "$state", "AppConstant", "albumManagementService", "$uibModal"];
        constructor(private $scope: AlbumScope , private $state: ng.ui.IStateService, private config: AppConstant, private albumManagementService: IalbumManagementService, private $uibModal: ng.ui.bootstrap.IModalService) {
            //Pagination section
            this.$scope.getTotalPageNumber = (): number => {
                return (this.$scope.data.length) / this.$scope.pageSize;
            };
            this.$scope.paginate = (data: IPhotoAlbum[], displayData: IPhotoAlbum[], pageSize: number, currentPage: number) => {
                displayData = data.slice(currentPage * pageSize, (currentPage + 1) * pageSize);
                this.$scope.display = displayData;
            };
            this.$scope.changePage = (page: number) => {
                this.$scope.currentPage = page;
                this.$scope.paginate<IPhotoAlbum>(this.$scope.data, this.$scope.display, this.$scope.pageSize, this.$scope.currentPage);
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
                    templateUrl: '/Scripts/app/settings/view/album.tmpl.html',
                    controller: AlbumManagementModalController,
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
            this.$scope.edit = (id: string) => {
                var options: ng.ui.bootstrap.IModalSettings = {
                    templateUrl: '/Scripts/app/settings/view/album.tmpl.html',
                    controller: AlbumManagementModalController,
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
                this.albumManagementService.getAll().then((response) => {
                    this.$scope.data = response;
                    //_.map($scope.data, function (a) {
                    //    a.link = config.web.protocal + "://" + config.web.ip + ":" + config.web.port +"/" + $state.href('photo', { "id": a.id, "title": a.title });
                    //});
                    this.$scope.totalPageNumber = this.$scope.getTotalPageNumber();
                    this.$scope.paginate<IPhotoAlbum>(this.$scope.data, this.$scope.display, this.$scope.pageSize, this.$scope.currentPage);
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