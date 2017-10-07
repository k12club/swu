module Swu {
    interface ITeacherListScope extends baseControllerScope, IPagination {
        currentPage: number;
        pageSize: number;
        totalPageNumber: number;

        criteria: SearchCritirea;
        search(): void;

        items: ITeacherDetail[];
        displayItems: ITeacherDetail[];
    }
    @Module("app")
    @Controller({ name: "TeacherListController" })
    export class TeacherListController {
        static $inject: Array<string> = ["$scope", "$rootScope", "$state", "teacherService"];
        constructor(private $scope: ITeacherListScope, private $rootScope: IRootScope, private $state: ng.ui.IState, private teacherService: IteacherService) {
            this.$scope.swapLanguage = (lang: string): void => {
                switch (lang) {
                    case "en": {
                        _.map($scope.items, function (c) {
                            c.firstName = c.firstName_en;
                            c.lastName = c.lastName_en;
                            c.description = c.description_en;
                            c.position = c.position_en
                        });
                        break;
                    }
                    case "th": {
                        _.map($scope.items, function (c) {
                            c.firstName = c.firstName_th;
                            c.lastName = c.lastName_th;
                            c.description = c.description_th;
                            c.position = c.position_th
                        });
                        break;
                    }
                }
            };
            this.$rootScope.$watch("lang", function (newValue: string, oldValue: string) {
                if ($scope.items != undefined || $scope.items != null) {
                    $scope.swapLanguage(newValue);
                }
            });
            //Pagination section
            this.$scope.getTotalPageNumber = (): number => {
                return Math.ceil((this.$scope.displayItems.length) / this.$scope.pageSize);
            };
            this.$scope.paginate = (data: ITeacherDetail[], displayData: ITeacherDetail[], pageSize: number, currentPage: number) => {
                displayData = data.slice(currentPage * pageSize, (currentPage + 1) * pageSize);
                this.$scope.displayItems = displayData;
            };
            this.$scope.changePage = (page: number) => {
                this.$scope.currentPage = page;
                this.$scope.paginate<ITeacherDetail>(this.$scope.items, this.$scope.displayItems, this.$scope.pageSize, this.$scope.currentPage);
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
                this.teacherService.getAllTeachers(this.$scope.criteria, $rootScope.lang).then((response) => {
                    this.$scope.items = response;
                    this.$scope.paginate<ITeacherDetail>(this.$scope.items, this.$scope.displayItems, this.$scope.pageSize, this.$scope.currentPage);
                    this.$scope.totalPageNumber = this.$scope.getTotalPageNumber();
                    this.$scope.swapLanguage(this.$rootScope.lang);
                }, (error) => { });
            };
            this.init();
        }
        init(): void {
            this.$scope.currentPage = 0;
            this.$scope.pageSize = 5;
            this.$scope.criteria = {
                name: ""
            };
            this.$scope.search();
        };

    }
}