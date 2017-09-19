module Swu {
    interface VideoManagementModalScope extends ng.IScope {
        id: number;
        text: string;
        mode: actionMode;
        video: IVideo;
        selectedCateogry: string;
        file: any;
        title: string;
        displayStartDate: string;

        getCategory(): void;
        edit(id: number): void;
        validate(): void;
        isValid(): boolean;
        cancel(): void;
        save(): void;
        delete(id: number): void;
    }
    @Module("app")
    @Controller({ name: "VideoManagementModalController" })
    export class VideoManagementModalController {
        static $inject: Array<string> = ["$scope", "$state", "videoManagementService", "toastr", "$modalInstance", "AuthServices", "id", "mode"];
        constructor(private $scope: VideoManagementModalScope, private $state: ng.ui.IStateService, private videoManagementService: IvideoManagementService, private toastr: Toastr, private $modalInstance: ng.ui.bootstrap.IModalServiceInstance, private auth: IAuthServices, private id: number, private mode: number) {
            this.$scope.id = id;
            this.$scope.mode = mode;
            this.$scope.edit = (id: number): void => {
                this.videoManagementService.getById(id).then((response) => {
                    this.$scope.video = response;
                    console.log(response);
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
                        models.push({ name: "video", value: this.$scope.video });
                        this.videoManagementService.addNewOrUpdate(models).then((response) => {
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
                this.videoManagementService.deleteById(id).then((response) => {
                    this.$modalInstance.close();
                    this.toastr.success("Success");
                }, (error) => { });
            };
            this.init();
        }
        init(): void {
            if (this.$scope.mode == 1) {
                this.$scope.mode = actionMode.addNew;
                this.$scope.title = "Add New Video";
            } else if (this.$scope.mode == 2) {
                this.$scope.title = "Edit Video";
                this.$scope.mode = actionMode.edit;
                this.$scope.edit(this.$scope.id);
            }

        };

    }
}