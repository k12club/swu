module Swu {
    interface UserModalScope extends ng.IScope {
        album: IPhotoAlbum;
        validate(): void;
        isValid(): boolean;
        cancel(): void;
        submit(): void;
        files: any;
        currentUser: IUserProfile;
        getCurrentUser(): void;
        isShowThisSection(name: string): boolean;
    }
    @Module("app")
    @Controller({ name: "AlbumModalController" })
    export class AlbumModalController {
        static $inject: Array<string> = ["$scope", "$state", "toastr", "$modalInstance", "albumService","AuthServices"];
        constructor(private $scope: UserModalScope, private $state: ng.ui.IState, private toastr: Toastr, private $modalInstance: ng.ui.bootstrap.IModalServiceInstance, private albumService: IalbumService, private auth: IAuthServices) {

            this.$scope.validate = (): void => {
                $('#form-album').validator();
            };
            this.$scope.isValid = (): boolean => {
                return ($('#form-album').validator('validate').has('.has-error').length === 0);
            };
            this.$scope.cancel = () => {
                this.$modalInstance.dismiss("");
            }
            this.$scope.submit = () => {
                if (this.$scope.isValid()) {
                    var models: NamePairValue[] = [];
                    models.push({ name: "title", value: this.$scope.album.title });
                    models.push({ name: "userId", value: this.$scope.currentUser.id });
                    _.forEach($scope.files, (value, key) => {
                        models.push({ name: "file", value: value });
                    });
                    this.albumService.createNewAlbum(models).then((response) => {
                        this.$modalInstance.close(response);
                    }, (error) => { });
                }
            };
            this.$scope.getCurrentUser = () => {
                if (this.$scope.currentUser == null) {
                    this.$scope.currentUser = this.auth.getCurrentUser();
                }
                return this.$scope.currentUser;
            };
            this.init();
        }
        init(): void {
            this.$scope.getCurrentUser();
        };

    }
}