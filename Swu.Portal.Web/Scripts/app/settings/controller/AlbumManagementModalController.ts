module Swu {
    interface AlbumModalScope extends ng.IScope {
        id: string;
        text: string;
        mode: actionMode;
        data: IPhotoAlbum;
        selectedCateogry: string;
        file: any;
        title: string;
        displayStartDate: string;

        edit(id: string): void;
        validate(): void;
        isValid(): boolean;
        cancel(): void;
        save(): void;
        delete(id: string): void;

    }
    @Module("app")
    @Controller({ name: "AlbumManagementModalController" })
    export class AlbumManagementModalController {
        static $inject: Array<string> = ["$scope", "$state", "AppConstant", "albumManagementService", "toastr", "$modalInstance", "AuthServices", "id", "mode"];
        constructor(private $scope: AlbumModalScope, private $state: ng.ui.IStateService, private config: AppConstant, private albumManagementService: IalbumManagementService, private toastr: Toastr, private $modalInstance: ng.ui.bootstrap.IModalServiceInstance, private auth: IAuthServices, private id: string, private mode: number) {
            this.$scope.id = id;
            this.$scope.mode = mode;
            this.$scope.edit = (id: string): void => {
                this.albumManagementService.getById(id).then((response) => {
                    this.$scope.data = response;
                    this.$scope.data.link = config.web.protocal + "://" + config.web.ip + "/" + $state.href('photo', { "id": this.$scope.data.id, "title": this.$scope.data.title });
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
                this.albumManagementService.updatePhotoAlbum(this.$scope.data).then((response) => {
                    this.$modalInstance.close();
                    this.toastr.success("Success");

                }, (error) => { });
            }
            this.$scope.delete = (id: string): void => {
                this.albumManagementService.deleteById(id).then((response) => {
                    this.$modalInstance.close();
                    this.toastr.success("Success");
                }, (error) => { });
            };
            this.init();
        }
        init(): void {
            if (this.$scope.mode == 1) {
                this.$scope.mode = actionMode.addNew;
                this.$scope.title = "Add New Album";
            } else if (this.$scope.mode == 2) {
                this.$scope.title = "Edit Album";
                this.$scope.mode = actionMode.edit;
                this.$scope.edit(this.$scope.id);
            }

        };
    }
}