module Swu {
    export interface IexamRegistrationService {
        getExam(): ng.IPromise<IExamClock>;
    }
    @Module("app")
    @Factory({ name: "examRegistrationService" })
    class examRegistrationService implements IexamRegistrationService {
        static $inject = ['apiService', 'AppConstant'];
        constructor(private apiService: apiService, private constant: AppConstant) {

        }
        getExam(): ng.IPromise<IExamClock> {
            return this.apiService.getData<IExamClock>("exam/getExam");
        }
    }
}