module Swu {
    export interface IteacherService {
        getAllTeachers(): ng.IPromise<ITeacherDetail[]>;
    }
    @Module("app")
    @Factory({ name: "teacherService" })
    class teacherService implements IteacherService {
        static $inject = ['apiService', 'AppConstant'];
        constructor(private apiService: apiService, private constant: AppConstant) {

        }
        getAllTeachers(): ng.IPromise<ITeacherDetail[]> {
            return this.apiService.getData("account/teachers");
        }
    }
}