module Swu {
    interface CategoryMangementModalScope extends ng.IScope {
        id: number;
        type: number;

        text: string;
        mode: actionMode;
        category: WebboardCategory;
        title: string;
        edit(id: number): void;
        validate(): void;
        isValid(): boolean;
        cancel(): void;
        save(): void;
        delete(id: number): void;
    }
    @Module("app")
    @Controller({ name: "CategoryMangementModalController" })
    export class CategoryMangementModalController {
        static $inject: Array<string> = ["$scope", "$state", "categoryManagementService", "toastr", "$modalInstance", "AuthServices", "id", "type", "mode"];
        constructor(private $scope: CategoryMangementModalScope, private $state: ng.ui.IStateService, private categoryManagementService: IcategoryManagementService, private toastr: Toastr, private $modalInstance: ng.ui.bootstrap.IModalServiceInstance, private auth: IAuthServices, private id: number, private type: number, private mode: number) {
            this.$scope.id = id;
            this.$scope.type = type;
            this.$scope.mode = mode;
            this.$scope.edit = (id: number): void => {
                if (this.$scope.type == 1) {
                    this.categoryManagementService.getById1(id).then((response) => {
                        this.$scope.category = response;
                    }, (error) => { });
                } else if (this.$scope.type == 2) {
                    this.categoryManagementService.getById2(id).then((response) => {
                        this.$scope.category = response;
                    }, (error) => { });
                } else if (this.$scope.type == 3) {
                    this.categoryManagementService.getById3(id).then((response) => {
                        this.$scope.category = response;
                    }, (error) => { });
                } else { }
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
                    if (this.$scope.type == 1) {
                        this.categoryManagementService.addNewOrUpdate1(this.$scope.category).then((response) => {
                            this.$modalInstance.close();
                            this.toastr.success("Success");
                        }, (error) => { });
                    } else if (this.$scope.type == 2) {
                        this.categoryManagementService.addNewOrUpdate2(this.$scope.category).then((response) => {
                            this.$modalInstance.close();
                            this.toastr.success("Success");
                        }, (error) => { });
                    } else if (this.$scope.type == 3) {
                        this.categoryManagementService.addNewOrUpdate3(this.$scope.category).then((response) => {
                            this.$modalInstance.close();
                            this.toastr.success("Success");
                        }, (error) => { });
                    } else { }

                }
            }
            this.$scope.delete = (id: number): void => {
                if (this.$scope.type == 1) {
                    this.categoryManagementService.deleteById1(id).then((response) => {
                        this.$modalInstance.close();
                        this.toastr.success("Success");
                    }, (error) => { });
                } else if (this.$scope.type == 2) {
                    this.categoryManagementService.deleteById2(id).then((response) => {
                        this.$modalInstance.close();
                        this.toastr.success("Success");
                    }, (error) => { });
                } else if (this.$scope.type == 3) {
                    this.categoryManagementService.deleteById3(id).then((response) => {
                        this.$modalInstance.close();
                        this.toastr.success("Success");
                    }, (error) => { });
                } else { }
            };
            this.init();
        }
        init(): void {
            if (this.$scope.mode == 1) {
                this.$scope.mode = actionMode.addNew;
                this.$scope.title = "Add New Category";
            } else if (this.$scope.mode == 2) {
                this.$scope.title = "Edit Category";
                this.$scope.mode = actionMode.edit;
                this.$scope.edit(this.$scope.id);
            }

        };

    }
}