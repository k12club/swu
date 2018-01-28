module Swu {
    export interface IalumniService {
        getYear(): ng.IPromise<string[]>;
        getStudentByYear(id: string): ng.IPromise<alumni[]>;
    }
    @Module("app")
    @Factory({ name: "alumniService" })
    class alumniService implements IalumniService {
        static $inject = ['apiService', 'AppConstant'];
        constructor(private apiService: apiService, private constant: AppConstant) {

        }
        getYear(): ng.IPromise<string[]> {
            return this.apiService.getData<string[]>("shared/alumniYear");
        }
        getStudentByYear(year: string): ng.IPromise<alumni[]> {
            return this.apiService.getData<alumni[]>("shared/getStudentByYear?year=" + year);
        }
    }
}