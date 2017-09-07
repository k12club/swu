module Swu {
    interface CourseManagementModalScope extends ng.IScope {
        id: string;
        mode: actionMode;
        course: ICourseDetail;
        file: any;
        title: string;

        validate(): void;
        isValid(): boolean;
        cancel(): void;
        save(): void;
    }
    @Module("app")
    @Controller({ name: "CourseManagementModalController" })
    export class CourseManagementModalController {
        static $inject: Array<string> = ["$scope", "$state", "courseManagementService", "toastr", "$modalInstance", "profileService", "AuthServices", "id", "mode"];
        constructor(private $scope: CourseManagementModalScope, private $state: ng.ui.IState, private courseManagementService: IcourseManagementService, private toastr: Toastr, private $modalInstance: ng.ui.bootstrap.IModalServiceInstance, private profileService: IprofileService, private AuthServices: IAuthServices, private id: string, private mode: number) {
            this.$scope.id = id;
            if (mode == 1) {
                this.$scope.mode = actionMode.addNew;
                this.$scope.title = "Add New Course";
            } else if (mode == 2) {
                this.$scope.title = "Edit Course";
                this.$scope.mode = actionMode.edit;
            }
            if (this.$scope.mode == actionMode.edit) {
                this.courseManagementService.getCourseById(this.$scope.id).then((response) => {
                    this.$scope.course = response;
                    $("#content").summernote("code",this.$scope.course.fullDescription);
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
                //var models: NamePairValue[] = [];
                //models.push({ name: "file", value: this.$scope.file });
                //models.push({ name: "user", value: this.$scope.user });
                //this.profileService.updateUserProfile(models).then((response) => {
                //    this.$modalInstance.close(response);
                //}, (error) => { });
            }
            this.init();
        }
        init(): void {
        };

    }
}