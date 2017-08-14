module Swu {
    export interface IcommitmentService {
        getCommitments(): ng.IPromise<ICommitment[]>;
    }
    @Module("app")
    @Factory({ name: "commitmentService" })
    class commitmentService implements IcommitmentService {
        static $inject = ['apiService', 'AppConstant'];
        constructor(private apiService: apiService, private constant: AppConstant) {

        }
        getCommitments(): ng.IPromise<ICommitment[]> {
            return this.apiService.getData<ICommitment[]>("shared/commitments");
        }
    }
}