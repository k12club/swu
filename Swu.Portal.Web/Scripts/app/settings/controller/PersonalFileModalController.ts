module Swu {
    interface PersonalFileModalScope extends ng.IScope {
        id: number;
        userId: string;
        mode: actionMode;
        title: string;
        file: any;

        edit(id: number): void;
        validate(): void;
        isValid(): boolean;
        cancel(): void;
        submit(): void;
        delete(id: number): void;
    }
    @Module("app")
    @Controller({ name: "PersonalFileModalController" })
    export class PersonalFileModalController {
        static $inject: Array<string> = ["$scope", "$state", "profileService", "toastr", "$modalInstance", "AuthServices", "id","userId", "mode"];
        constructor(private $scope: PersonalFileModalScope, private $state: ng.ui.IStateService, private profileService: IprofileService, private toastr: Toastr, private $modalInstance: ng.ui.bootstrap.IModalServiceInstance, private auth: IAuthServices, private id: number, private userId: string, private mode: number) {
            this.$scope.id = id;
            this.$scope.userId = userId;
            this.$scope.mode = mode;
            this.$scope.edit = (id: number): void => {
                
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
            this.$scope.submit = (): void => {
                var models: NamePairValue[] = [];
                models.push({ name: "file", value: this.$scope.file });
                models.push({ name: "userId", value: this.$scope.userId });
                this.profileService.uploadPersonalFile(models).then((response) => {
                    this.$modalInstance.close();
                }, (error) => { });
            }
            this.$scope.delete = (id: number): void => {
                
            };
            this.init();
        }
        init(): void {
            if (this.$scope.mode == 1) {
                this.$scope.mode = actionMode.addNew;
                this.$scope.title = "Add New File";
            }

        };

    }
}