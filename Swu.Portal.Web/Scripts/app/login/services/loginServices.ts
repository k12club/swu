module Swu {
    export interface ILoginServices {
        login(user: IUserLogin): ng.IPromise<IUserProfile>;
    }
    @Module("app")
    @Factory({ name: "loginServices" })
    class LoginServices implements ILoginServices {
        static $inject = ['apiService', 'AppConstant'];
        constructor(private apiService: apiService, private constant: AppConstant) {

        }
        login(user: IUserLogin): ng.IPromise<IUserProfile> {
            return this.apiService.postData<IUserProfile>(user, "account/login");
        }
    }
}