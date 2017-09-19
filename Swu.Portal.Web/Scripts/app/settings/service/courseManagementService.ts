module Swu {
    export interface IcourseManagementService {
        //getRoles(): ng.IPromise<IRole[]>;
        addNewOrUpdate(models: NamePairValue[]): ng.IPromise<HttpStatusCode>;
        getAll(): ng.IPromise<ICourseDetail[]>;
        getCourseById(id: string): ng.IPromise<ICourseDetail>;
        deleteById(id: string): ng.IPromise<HttpStatusCode>;
    }
    @Module("app")
    @Factory({ name: "courseManagementService" })
    class courseManagementService implements IcourseManagementService {
        static $inject = ['apiService', 'AppConstant'];
        constructor(private apiService: apiService, private constant: AppConstant) {

        }
        //getRoles(): ng.IPromise<IRole[]> {
        //    return this.apiService.getData<IRole[]>("role/all");
        //}
        addNewOrUpdate(models: NamePairValue[]): ng.IPromise<HttpStatusCode> {
            return this.apiService.postWithFormData<HttpStatusCode>(models, "Course/SaveAsync");
        }
        getAll(): ng.IPromise<ICourseDetail[]> {
            return this.apiService.getData<ICourseDetail[]>("Course/allCourse");
        }
        getCourseById(id: string): ng.IPromise<ICourseDetail> {
            return this.apiService.getData<ICourseDetail>("Course/getCourseById?id=" + id);
        }
        deleteById(id: string): ng.IPromise<HttpStatusCode> {
            return this.apiService.getData("course/deleteById?id=" + id);
        }

    }
}