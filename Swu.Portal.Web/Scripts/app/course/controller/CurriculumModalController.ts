module Swu {
    export interface DropDownOption {
        id: number;
        title: string;
    }
    interface CurriculumModalScope extends ng.IScope {
        id: string;
        options: SummernoteOptions;
        text: string;
        mode: actionMode;

        curriculum: ICurriculum;
        types: DropDownOption[];
        selectedType: string;
        file: any;
        title: string;

        edit(id: string): void;
        validate(): void;
        isValid(): boolean;
        cancel(): void;
        save(): void;
    }
    @Module("app")
    @Controller({ name: "CurriculumModalController" })
    export class CurriculumModalController {
        static $inject: Array<string> = ["$scope", "$state", "courseService", "toastr", "$modalInstance", "profileService", "AuthServices", "webboardService", "id", "mode"];
        constructor(private $scope: CurriculumModalScope, private $state: ng.ui.IStateService, private courseService: IcourseService, private toastr: Toastr, private $modalInstance: ng.ui.bootstrap.IModalServiceInstance, private profileService: IprofileService, private auth: IAuthServices, private webboardService: IwebboardService, private id: string, private mode: number) {
            this.$scope.id = id;
            this.$scope.mode = mode;
            //this.$scope.edit = (id: string): void => {
            //    this.courseManagementService.getCourseById(id).then((response) => {
            //        this.$scope.course = response;
            //        this.$scope.selectedCateogry = _.filter(this.$scope.categories, function (item, index) {
            //            return item.id == $scope.course.categoryId;
            //        })[0].id.toString();
            //    }, (error) => { });
            //}
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
                    this.$scope.curriculum.courseId = this.$scope.id;
                    this.$scope.curriculum.type = parseInt(this.$scope.selectedType);
                    console.log(this.$scope.curriculum);
                    this.courseService.saveCurriculum(this.$scope.curriculum).then((response) => {
                        this.$modalInstance.close();
                    }, (error) => { });
                }

            }
            this.init();
        }
        init(): void {
            this.$scope.types = [];
            this.$scope.types.push({ id: CurriculumType.lecture, title: "Lecture" });
            this.$scope.types.push({ id: CurriculumType.exam, title: "Exam" });
            if (this.$scope.mode == 1) {
                this.$scope.mode = actionMode.addNew;
                this.$scope.title = "Add New Course";
                this.$scope.selectedType = _.first(this.$scope.types).id.toString();
            } else if (this.$scope.mode == 2) {
                this.$scope.title = "Edit Course";
                this.$scope.mode = actionMode.edit;
                this.$scope.edit(this.$scope.id);
            }

        };

    }
}