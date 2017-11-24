module Swu {
    export interface InewsService {
        getNews(): ng.IPromise<INews[]>;
        getActiveNews(): ng.IPromise<INews[]>;
    }
    @Module("app")
    @Factory({ name: "newsService" })
    class newsService implements InewsService {
        static $inject = ['apiService', 'AppConstant'];
        constructor(private apiService: apiService, private constant: AppConstant) {

        }
        getNews(): ng.IPromise<INews[]> {
            return this.apiService.getData<INews[]>("news/all");
        }
        getActiveNews(): ng.IPromise<INews[]> {
            return this.apiService.getData<INews[]>("news/allActive");
        }
    }
}