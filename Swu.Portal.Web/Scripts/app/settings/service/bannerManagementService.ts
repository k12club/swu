module Swu {
    export interface IbannerManagementService {
        addNewOrUpdate(models: NamePairValue[]): ng.IPromise<HttpStatusCode>;
        getAll(): ng.IPromise<ISlider[]>;
        getById(id: number): ng.IPromise<ISlider>;
        deleteById(id: number): ng.IPromise<HttpStatusCode>;
    }
    @Module("app")
    @Factory({ name: "bannerManagementService" })
    class bannerManagementService implements IbannerManagementService {
        static $inject = ['apiService', 'AppConstant'];
        constructor(private apiService: apiService, private constant: AppConstant) {

        }
        addNewOrUpdate(models: NamePairValue[]): ng.IPromise<HttpStatusCode> {
            return this.apiService.postWithFormData(models, "shared/addNewOrUpdate");
        }
        getAll(): ng.IPromise<ISlider[]> {
            return this.apiService.getData<ISlider[]>("shared/getSlider");
        }
        getById(id: number): ng.IPromise<ISlider> {
            return this.apiService.getData<ISlider>("shared/getById?id=" + id);
        }
        deleteById(id: number): ng.IPromise<HttpStatusCode> {
            return this.apiService.getData("shared/deleteById?id=" + id);
        }
    }
}