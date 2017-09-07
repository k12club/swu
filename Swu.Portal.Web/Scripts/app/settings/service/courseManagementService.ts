module Swu {
    export interface IcourseManagementService {
        //getRoles(): ng.IPromise<IRole[]>;
        //addNewOrUpdate(user: IUserProfile): ng.IPromise<boolean>;
        getAll(): ng.IPromise<ICourseDetail[]>;
        getCourseById(id: string): ng.IPromise<ICourseDetail>;
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
        //addNewOrUpdate(user: IUserProfile): ng.IPromise<boolean> {
        //    return this.apiService.postData<boolean>(user, "Account/addNewOrUpdate");
        //}
        getAll(): ng.IPromise<ICourseDetail[]> {
            return this.apiService.getData<ICourseDetail[]>("Course/allCourse");
        }
        getCourseById(id: string): ng.IPromise<ICourseDetail> {
            return this.apiService.getData<ICourseDetail>("Course/getCourseById?id=" + id);
        }
    }
}