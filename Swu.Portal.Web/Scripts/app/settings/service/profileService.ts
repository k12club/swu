module Swu {
    export interface IprofileService {
        updateUserProfile(models: NamePairValue[]): ng.IPromise<HttpStatusCode>;
    }
    @Module("app")
    @Factory({ name: "profileService" })
    class profileService implements IprofileService {
        static $inject = ['apiService', 'AppConstant'];
        constructor(private apiService: apiService, private constant: AppConstant) {

        }
        updateUserProfile(models: NamePairValue[]): ng.IPromise<HttpStatusCode> {
            return this.apiService.postWithFormData<HttpStatusCode>(models, "Account/uploadAsync");
        }
    }
}