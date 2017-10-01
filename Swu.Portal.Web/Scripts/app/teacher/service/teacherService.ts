module Swu {
    export interface IteacherService {
        getAllTeachers(criteria: SearchCritirea, lang: string): ng.IPromise<ITeacherDetail[]>;
    }
    @Module("app")
    @Factory({ name: "teacherService" })
    class teacherService implements IteacherService {
        static $inject = ['apiService', 'AppConstant'];
        constructor(private apiService: apiService, private constant: AppConstant) {

        }
        getAllTeachers(criteria: SearchCritirea, lang: string): ng.IPromise<ITeacherDetail[]> {
            var keyword = (criteria.name == "" || criteria.name == null) ? "*" : criteria.name;
            return this.apiService.getData("account/teachers?keyword=" + criteria.name + "&lang=" + lang);
        }
    }
}