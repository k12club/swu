module Swu {
    export interface IuserService {
        getRoles(): ng.IPromise<IRole[]>;
    }
    @Module("app")
    @Factory({ name: "userService" })
    class userService implements IuserService {
        static $inject = ['apiService', 'AppConstant'];
        constructor(private apiService: apiService, private constant: AppConstant) {

        }
        getRoles(): ng.IPromise<IRole[]> {
            return this.apiService.getData<IRole[]>("role/all");
        }
    }
}