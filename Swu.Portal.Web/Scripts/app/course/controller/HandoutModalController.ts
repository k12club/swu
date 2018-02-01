module Swu {
    interface HandoutModalScope extends ng.IScope {
        id: string;
        courseId: string;
        mode: actionMode;
        currentUserId: string;

        photo: IPhoto;
        selectedType: string;
        file: any;
        title: string;
        name: string;

        getCurrentUser(): IUserProfile;
        edit(id: string): void;
        delete(): void;
        validate(): void;
        isValid(): boolean;
        cancel(): void;
        save(): void;
    }
    @Module("app")
    @Controller({ name: "HandoutModalController" })
    export class HandoutModalController {
        static $inject: Array<string> = ["$scope", "$state", "courseService", "toastr", "$modalInstance", "profileService", "AuthServices", "id", "courseId", "userId", "mode"];
        constructor(private $scope: HandoutModalScope, private $state: ng.ui.IStateService, private courseService: IcourseService, private toastr: Toastr, private $modalInstance: ng.ui.bootstrap.IModalServiceInstance, private profileService: IprofileService, private auth: IAuthServices, private id: string, private courseId: string, private userId: string, private mode: number) {
            this.$scope.id = id;
            this.$scope.courseId = courseId;
            this.$scope.currentUserId = userId;
            this.$scope.mode = mode;
            this.$scope.edit = (id: string): void => {

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
                    var models: NamePairValue[] = [];
                    models.push({ name: "file", value: this.$scope.file });
                    models.push({ name: "course", value: this.$scope.courseId });
                    console.log(models);
                    this.courseService.addNewHandout(models).then((response) => {
                        this.$modalInstance.close(response);
                    }, (error) => { });
                }

            }
            $scope.delete = () => {

            }
            this.init();
        }
        init(): void {
            if (this.$scope.mode == 1) {
                this.$scope.mode = actionMode.addNew;
                this.$scope.title = "Add New File";
            } else if (this.$scope.mode == 2) {
                this.$scope.title = "Edit File";
                this.$scope.mode = actionMode.edit;
                this.$scope.edit(this.$scope.id);
            }

        };

    }
}