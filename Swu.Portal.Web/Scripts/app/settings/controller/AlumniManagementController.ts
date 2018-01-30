module Swu {
    interface AlumniManagementScope extends ng.IScope{
        file: any;

        save(): void;
    }
    @Module("app")
    @Controller({ name: "AlumniManagementController" })
    export class AlumniManagementController {
        static $inject: Array<string> = ["$scope", "$state", "AuthServices", "toastr", "alumniManagementService"];
        constructor(private $scope: AlumniManagementScope, private $state: ng.ui.IStateService, private auth: IAuthServices, private toastr: Toastr, private alumniManagementService: IalumniManagementService) {
            this.$scope.save = () => {
                if (this.auth.isLoggedIn()) {
                        var models: NamePairValue[] = [];
                        models.push({ name: "file", value: this.$scope.file });
                        this.alumniManagementService.import(models).then((response) => {
                            this.toastr.success("Success");
                        }, (error) => { });
                } else {
                    this.toastr.error("Time out expired");
                    this.$state.go("app", { reload: true });
                }
            };
            this.init();
        }
        init(): void {
        };
    }
}