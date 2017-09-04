module Swu {
    export interface ICookiesService {
        get(key: string): string;
        getObject(key: string): any;
        getAll(): any;
        put(key: string, value: string, options?: any): void;
        putObject(key: string, value: any, options?: any): void;
        remove(key: string, options?: any): void;
    }
    export interface IAuthServices {
        login(user: IUserLogin, loginSuccessCallback: () => any, loginFailCallback: () => any): void;
        logout(): void;
        isLoggedIn(): boolean;
        getCurrentUser(): IUserProfile;
    }
    @Module("app")
    @Factory({ name: "AuthServices" })
    class LoginServices implements IAuthServices {
        static $inject = ['apiService', 'AppConstant', '$cookies'];
        constructor(private apiService: apiService, private constant: AppConstant, private $cookies: ICookiesService) {

        }
        login(user: IUserLogin, loginSuccessCallback: () => any, loginFailCallback: () => any): void {
            this.apiService.postData<IUserProfile>(user, "account/login").then((response) => {
                this.setCurrentUser(response);
                loginSuccessCallback();
            }, (error) => {
                loginFailCallback();
            });
        }
        logout() {
            this.$cookies.remove("currentUser");
        };
        isLoggedIn(): boolean {
            return this.getCurrentUser() != null;
        };
        private setCurrentUser(currentUser: IUserProfile): void {
            this.$cookies.putObject("currentUser", JSON.stringify(currentUser), { expires: new Date(Date.now() + (60 * 1000 * this.constant.timeoutExpired))});
        };
        getCurrentUser(): IUserProfile {
            var user = this.$cookies.getObject("currentUser");
            if (user != null) {
                user = JSON.parse(user);
            }
            console.log(user);
            return user;
        };
    }
}