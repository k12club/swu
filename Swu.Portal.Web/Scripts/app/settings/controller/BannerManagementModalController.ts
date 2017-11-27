module Swu {
    interface BannerManagementModalScope extends ng.IScope {
        id: number;
        text: string;
        mode: actionMode;
        data: ISlider;
        selectedCateogry: string;
        file: any;
        title: string;
        displayStartDate: string;

        edit(id: number): void;
        validate(): void;
        isValid(): boolean;
        cancel(): void;
        save(): void;
        delete(id: number): void;
    }
    @Module("app")
    @Controller({ name: "BannerManagementModalController" })
    export class BannerManagementModalController {
        static $inject: Array<string> = ["$scope", "$state", "bannerManagementService", "toastr", "$modalInstance", "AuthServices", "id", "mode"];
        constructor(private $scope: BannerManagementModalScope, private $state: ng.ui.IStateService, private bannerManagementService: IbannerManagementService, private toastr: Toastr, private $modalInstance: ng.ui.bootstrap.IModalServiceInstance, private auth: IAuthServices, private id: number, private mode: number) {
            this.$scope.id = id;
            this.$scope.mode = mode;
            this.$scope.edit = (id: number): void => {
                this.bannerManagementService.getById(id).then((response) => {
                    this.$scope.data = response;
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
                        var models: NamePairValue[] = [];
                        models.push({ name: "file", value: this.$scope.file });
                        models.push({ name: "slider", value: this.$scope.data });
                        this.bannerManagementService.addNewOrUpdate(models).then((response) => {
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
                this.bannerManagementService.deleteById(id).then((response) => {
                    this.$modalInstance.close();
                    this.toastr.success("Success");
                }, (error) => { });
            };
            this.init();
        }
        init(): void {
            if (this.$scope.mode == 1) {
                this.$scope.mode = actionMode.addNew;
                this.$scope.title = "Add New Banner";
            } else if (this.$scope.mode == 2) {
                this.$scope.title = "Edit Banner";
                this.$scope.mode = actionMode.edit;
                this.$scope.edit(this.$scope.id);
            }

        };
    }
}