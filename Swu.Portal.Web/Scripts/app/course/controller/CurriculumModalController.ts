module Swu {
    export interface DropDownOption {
        id: number;
        title: string;
    }
    interface CurriculumModalScope extends ng.IScope {
        id: number;
        courseId: string;
        options: SummernoteOptions;
        text: string;
        mode: actionMode;
        displayPublishDate: string;

        curriculum: ICurriculum;
        types: DropDownOption[];
        selectedType: string;
        file: any;
        title: string;

        edit(id: number): void;
        delete(): void;
        validate(): void;
        isValid(): boolean;
        cancel(): void;
        save(): void;
    }
    @Module("app")
    @Controller({ name: "CurriculumModalController" })
    export class CurriculumModalController {
        static $inject: Array<string> = ["$scope", "$state", "courseService", "toastr", "$modalInstance", "profileService", "AuthServices", "webboardService", "id","courseId", "mode"];
        constructor(private $scope: CurriculumModalScope, private $state: ng.ui.IStateService, private courseService: IcourseService, private toastr: Toastr, private $modalInstance: ng.ui.bootstrap.IModalServiceInstance, private profileService: IprofileService, private auth: IAuthServices, private webboardService: IwebboardService, private id: number, private courseId:string, private mode: number) {
            this.$scope.id = id;
            this.$scope.courseId = courseId;
            this.$scope.mode = mode;
            this.$scope.edit = (id: number): void => {
                this.courseService.getCurriculumById(id).then((response) => {
                    this.$scope.curriculum = response;
                    console.log(response);
                    this.$scope.displayPublishDate = moment(this.$scope.curriculum.startDate).format("MM/DD/YYYY");
                    this.$scope.selectedType = this.$scope.curriculum.type.toString();
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
                    this.$scope.curriculum.id = this.$scope.id;
                    this.$scope.curriculum.courseId = this.$scope.courseId;
                    this.$scope.curriculum.type = parseInt(this.$scope.selectedType);
                    this.$scope.curriculum.startDate = new Date(this.$scope.displayPublishDate);
                    this.courseService.saveCurriculum(this.$scope.curriculum).then((response) => {
                        this.$modalInstance.close();
                    }, (error) => { });
                }

            }
            $scope.delete = () => {

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