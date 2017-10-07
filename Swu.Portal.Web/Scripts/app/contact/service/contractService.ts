module Swu {
    export interface IcontractService {
        sendMail(email: IEmail): ng.IPromise<HttpStatusCode>;
    }
    @Module("app")
    @Factory({ name: "contractService" })
    class contractService implements IcontractService {
        static $inject = ['apiService', 'AppConstant'];
        constructor(private apiService: apiService, private constant: AppConstant) {

        }
        sendMail(email: IEmail): ng.IPromise<HttpStatusCode> {
            return this.apiService.postData(email, "shared/sendMail");
        }
    }
}