module Swu {
    interface CourseManagementModalScope extends ng.IScope {
        id: string;
        mode: actionMode;
        course: ICourseDetail;
        categories: WebboardCategory[];
        selectedCateogry: string;
        file: any;
        title: string;

        getCategory(): void;
        edit(id: string): void;
        validate(): void;
        isValid(): boolean;
        cancel(): void;
        save(): void;
    }
    @Module("app")
    @Controller({ name: "CourseManagementModalController" })
    export class CourseManagementModalController {
        static $inject: Array<string> = ["$scope", "$state", "courseManagementService", "toastr", "$modalInstance", "profileService", "AuthServices", "webboardService", "id", "mode"];
        constructor(private $scope: CourseManagementModalScope, private $state: ng.ui.IState, private courseManagementService: IcourseManagementService, private toastr: Toastr, private $modalInstance: ng.ui.bootstrap.IModalServiceInstance, private profileService: IprofileService, private auth: IAuthServices, private webboardService: IwebboardService, private id: string, private mode: number) {
            this.$scope.id = id;
            this.$scope.mode = mode;
            this.$scope.edit = (id: string): void => {
                this.courseManagementService.getCourseById(id).then((response) => {
                    this.$scope.course = response;
                    $("#content").summernote("code", this.$scope.course.fullDescription);
                    this.$scope.selectedCateogry = _.filter(this.$scope.categories, function (item, index) {
                        return item.id == $scope.course.categoryId;
                    })[0].id.toString();
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
                if (this.$scope.isValid()) {
                    var models: NamePairValue[] = [];
                    this.$scope.course.categoryId = parseInt(this.$scope.selectedCateogry);
                    this.$scope.course.categoryName = _.filter(this.$scope.categories, function (item, index) {
                        return item.id == $scope.course.categoryId;
                    })[0].title;
                    this.$scope.course.createdUserId = this.auth.getCurrentUser().id;
                    models.push({ name: "file", value: this.$scope.file });
                    models.push({ name: "course", value: this.$scope.course });
                    this.courseManagementService.addNewOrUpdate(models).then((response) => {
                        this.$modalInstance.close();
                    }, (error) => { });
                }
            }
            this.init();
        }
        init(): void {
            this.webboardService.getCourseCategory().then((response) => {
                this.$scope.categories = response;

                if (this.$scope.mode == 1) {
                    this.$scope.mode = actionMode.addNew;
                    this.$scope.title = "Add New Course";
                    this.$scope.selectedCateogry = _.first(this.$scope.categories).id.toString();
                } else if (this.$scope.mode == 2) {
                    this.$scope.title = "Edit Course";
                    this.$scope.mode = actionMode.edit;
                    this.$scope.edit(this.$scope.id);
                }
            }, (error) => { });

        };

    }
}