﻿module Swu {
    export interface IuserService {
        getRoles(): ng.IPromise<IRole[]>;
        addNew(user: IUserProfile): ng.IPromise<boolean>;
        getAllUsers(): ng.IPromise<IUserProfile[]>;
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
        addNew(user: IUserProfile): ng.IPromise<boolean> {
            return this.apiService.postData<boolean>(user, "Account/addNew");
        }
        getAllUsers(): ng.IPromise<IUserProfile[]> {
            return this.apiService.getData<IUserProfile[]>("Account/all");
        }
    }
}