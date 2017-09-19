module Swu {
    export interface IvideoManagementService {
        addNewOrUpdate(models: NamePairValue[]): ng.IPromise<HttpStatusCode>;
        getAll(): ng.IPromise<IVideo[]>;
        getById(id: number): ng.IPromise<IVideo>;
        deleteById(id: number): ng.IPromise<HttpStatusCode>;
    }
    @Module("app")
    @Factory({ name: "videoManagementService" })
    class videoManagementService implements IvideoManagementService {
        static $inject = ['apiService', 'AppConstant'];
        constructor(private apiService: apiService, private constant: AppConstant) {

        }
        addNewOrUpdate(models: NamePairValue[]): ng.IPromise<HttpStatusCode> {
            return this.apiService.postWithFormData(models, "video/addNewOrUpdate");
        }
        getAll(): ng.IPromise<IVideo[]> {
            return this.apiService.getData<IVideo[]>("video/all");
        }
        getById(id: number): ng.IPromise<IVideo> {
            return this.apiService.getData<IVideo>("video/getById?id=" + id);
        }
        deleteById(id: number): ng.IPromise<HttpStatusCode> {
            return this.apiService.getData("video/deleteById?id=" + id);
        }
    }
}