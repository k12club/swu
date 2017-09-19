module Swu {
    interface CourseManagementModalScope extends ng.IScope {
        id: number;
        text: string;
        mode: actionMode;
        event: IEvent;
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
    @Controller({ name: "EventManagementModalController" })
    export class EventManagementModalController {
        static $inject: Array<string> = ["$scope", "$state", "eventManagementService", "toastr", "$modalInstance", "AuthServices", "id", "mode"];
        constructor(private $scope: CourseManagementModalScope, private $state: ng.ui.IStateService, private eventManagementService: IeventManagementService, private toastr: Toastr, private $modalInstance: ng.ui.bootstrap.IModalServiceInstance, private auth: IAuthServices, private id: number, private mode: number) {
            this.$scope.id = id;
            this.$scope.mode = mode;
            this.$scope.edit = (id: number): void => {
                this.eventManagementService.getEventById(id).then((response) => {
                    this.$scope.event = response;
                    this.$scope.displayStartDate = moment(this.$scope.event.startDate).format("MM/DD/YYYY");
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
                        this.$scope.event.startDate = new Date(this.$scope.displayStartDate);
                        this.eventManagementService.addNewOrUpdate(this.$scope.event).then((response) => {
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
                this.eventManagementService.deleteById(id).then((response) => {
                    this.$modalInstance.close();
                    this.toastr.success("Success");
                }, (error) => { });
            };
            this.init();
        }
        init(): void {
            if (this.$scope.mode == 1) {
                this.$scope.mode = actionMode.addNew;
                this.$scope.title = "Add New Event";
            } else if (this.$scope.mode == 2) {
                this.$scope.title = "Edit Event";
                this.$scope.mode = actionMode.edit;
                this.$scope.edit(this.$scope.id);
            }

        };

    }
}