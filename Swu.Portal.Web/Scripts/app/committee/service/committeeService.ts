module Swu {
    export interface IcommitteeService {
        getCommittees(): ng.IPromise<ICommittee[]>;
    }
    @Module("app")
    @Factory({ name: "committeeService" })
    class committeeService implements IcommitteeService {
        static $inject = ['apiService', 'AppConstant'];
        constructor(private apiService: apiService, private constant: AppConstant) {

        }
        getCommittees(): ng.IPromise<ICommittee[]> {
            return this.apiService.getData("committee/all");
        }
    }
}