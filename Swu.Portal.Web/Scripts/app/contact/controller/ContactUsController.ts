module Swu {
    interface ContractScope extends ng.IScope {
        email: IEmail;
        sendMail(): void;
        validate(): void;
        isValid(): boolean;

    }
    @Module("app")
    @Controller({ name: "ContactUsController" })
    export class ContactUsController {
        static $inject: Array<string> = ["$scope", "contractService", "$state", "toastr"];
        constructor(private $scope: ContractScope, private contractService: IcontractService, private $state: ng.ui.IState, private toastr: Toastr) {
            this.$scope.validate = (): void => {
                $('form').validator();
            };
            this.$scope.isValid = (): boolean => {
                return ($('#form').validator('validate').has('.has-error').length === 0);
            };
            this.$scope.sendMail = () => {
                if (this.$scope.isValid()) {
                    this.contractService.sendMail(this.$scope.email).then((response) => {
                        this.toastr.success("Success");
                        $scope.email = null;
                    }, (error) => {
                        this.toastr.error("Send failed");
                        $scope.email = null;                    });
                }
            }
            this.init();
        }
        init(): void {
            this.$scope.email = null;
            this.$scope.validate();
        };

    }
}