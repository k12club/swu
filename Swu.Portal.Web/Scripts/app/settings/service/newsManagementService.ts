module Swu {
    export interface InewsManagementService {
        addNewOrUpdate(models: NamePairValue[]): ng.IPromise<HttpStatusCode>;
        getAll(): ng.IPromise<INews[]>;
        getById(id: number): ng.IPromise<INews>;
        deleteById(id: number): ng.IPromise<HttpStatusCode>;
    }
    @Module("app")
    @Factory({ name: "newsManagementService" })
    class newsManagementService implements InewsManagementService {
        static $inject = ['apiService', 'AppConstant'];
        constructor(private apiService: apiService, private constant: AppConstant) {

        }
        addNewOrUpdate(models: NamePairValue[]): ng.IPromise<HttpStatusCode> {
            return this.apiService.postWithFormData(models, "news/addNewOrUpdate");
        }
        getAll(): ng.IPromise<INews[]> {
            return this.apiService.getData<INews[]>("news/all");
        }
        getById(id: number): ng.IPromise<INews> {
            return this.apiService.getData<INews>("news/getById?id=" + id);
        }
        deleteById(id: number): ng.IPromise<HttpStatusCode> {
            return this.apiService.getData("news/deleteById?id=" + id);
        }
    }
}