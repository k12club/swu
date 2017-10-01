module Swu {
    export interface IprofileService {
        updateUserProfile(models: NamePairValue[]): ng.IPromise<HttpStatusCode>;
        approve(childId: string, parentId: string): ng.IPromise<HttpStatusCode>;
        reject(childId: string, parentId: string): ng.IPromise<HttpStatusCode>;

        uploadPersonalFile(models: NamePairValue[]): ng.IPromise<HttpStatusCode>;
        removeFile(id: number): ng.IPromise<HttpStatusCode>;
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
        approve(childId: string, parentId: string): ng.IPromise<HttpStatusCode> {
            return this.apiService.getData("Account/approveRequest?childId=" + childId + "&parentId=" + parentId);
        }
        reject(childId: string, parentId: string): ng.IPromise<HttpStatusCode> {
            return this.apiService.getData("Account/rejectRequest?childId=" + childId + "&parentId=" + parentId);
        }
        uploadPersonalFile(models: NamePairValue[]): ng.IPromise<HttpStatusCode> {
            return this.apiService.postWithFormData<HttpStatusCode>(models, "Account/uploadPersonalFileAsync");
        }
        removeFile(id: number): ng.IPromise<HttpStatusCode> {
            return this.apiService.getData("Account/removeFile?id=" + id);
        }
    }
}