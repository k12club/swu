module Swu {
    export interface IcategoryManagementService {
        addNewOrUpdate1(category: WebboardCategory): ng.IPromise<HttpStatusCode>;
        getAll1(): ng.IPromise<WebboardCategory[]>;
        getById1(id: number): ng.IPromise<WebboardCategory>;
        deleteById1(id: number): ng.IPromise<HttpStatusCode>;

        addNewOrUpdate2(category: WebboardCategory): ng.IPromise<HttpStatusCode>;
        getAll2(): ng.IPromise<WebboardCategory[]>;
        getById2(id: number): ng.IPromise<WebboardCategory>;
        deleteById2(id: number): ng.IPromise<HttpStatusCode>;

        addNewOrUpdate3(category: WebboardCategory): ng.IPromise<HttpStatusCode>;
        getAll3(): ng.IPromise<WebboardCategory[]>;
        getById3(id: number): ng.IPromise<WebboardCategory>;
        deleteById3(id: number): ng.IPromise<HttpStatusCode>;

    }
    @Module("app")
    @Factory({ name: "categoryManagementService" })
    class categoryManagementService implements IcategoryManagementService {
        static $inject = ['apiService', 'AppConstant'];
        constructor(private apiService: apiService, private constant: AppConstant) {

        }
        addNewOrUpdate1(category: WebboardCategory): ng.IPromise<HttpStatusCode> {
            return this.apiService.postData<HttpStatusCode>(category, "course/addNewOrUpdateCategory");
        }
        getAll1(): ng.IPromise<WebboardCategory[]> {
            return this.apiService.getData<WebboardCategory[]>("course/category");
        }
        getById1(id: number): ng.IPromise<WebboardCategory> {
            return this.apiService.getData<WebboardCategory>("course/getCategoryById?id=" + id);
        }
        deleteById1(id: number): ng.IPromise<HttpStatusCode> {
            return this.apiService.getData("course/deleteCategoryById?id=" + id);
        }


        addNewOrUpdate2(category: WebboardCategory): ng.IPromise<HttpStatusCode> {
            return this.apiService.postData<HttpStatusCode>(category, "research/addNewOrUpdateCategory");
        }
        getAll2(): ng.IPromise<WebboardCategory[]> {
            return this.apiService.getData<WebboardCategory[]>("research/category");
        }
        getById2(id: number): ng.IPromise<WebboardCategory> {
            return this.apiService.getData<WebboardCategory>("research/getCategoryById?id=" + id);
        }
        deleteById2(id: number): ng.IPromise<HttpStatusCode> {
            return this.apiService.getData("research/deleteCategoryById?id=" + id);
        }


        addNewOrUpdate3(category: WebboardCategory): ng.IPromise<HttpStatusCode> {
            return this.apiService.postData<HttpStatusCode>(category, "forum/addNewOrUpdateCategory");
        }
        getAll3(): ng.IPromise<WebboardCategory[]> {
            return this.apiService.getData<WebboardCategory[]>("forum/category");
        }
        getById3(id: number): ng.IPromise<WebboardCategory> {
            return this.apiService.getData<WebboardCategory>("forum/getCategoryById?id=" + id);
        }
        deleteById3(id: number): ng.IPromise<HttpStatusCode> {
            return this.apiService.getData("forum/deleteCategoryById?id=" + id);
        }
    }
}