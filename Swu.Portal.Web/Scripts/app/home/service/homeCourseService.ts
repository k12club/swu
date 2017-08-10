module Swu {
    export interface IhomeCourseService {
        getCourses(): ng.IPromise<ICourseCard[]>;
    }
    @Module("app")
    @Factory({ name: "homeCourseService" })
    class homeCourseService implements IhomeCourseService {
        static $inject = ['apiService', 'AppConstant'];
        constructor(private apiService: apiService, private constant: AppConstant) {
            
        }
        getCourses(): ng.IPromise<ICourseCard[]> {
            return this.apiService.getData<ICourseCard[]>("course/all");
        }
    }
}