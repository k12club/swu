module Swu {
    export interface IalumniManagementService {
        import(models: NamePairValue[]): ng.IPromise<HttpStatusCode>;

    }
    @Module("app")
    @Factory({ name: "alumniManagementService" })
    class alumniManagementService implements IalumniManagementService {
        static $inject = ['apiService', 'AppConstant'];
        constructor(private apiService: apiService, private constant: AppConstant) {

        }
        import(models: NamePairValue[]): ng.IPromise<HttpStatusCode> {
            return this.apiService.postWithFormData(models, "shared/importAlumni");
        }
    }
}