module Swu {
    export interface IwebboardService {
        getCourseCategory(): ng.IPromise<WebboardCategory[]>;
        getCourseItems(criteria: SearchCritirea): ng.IPromise<Webboarditems[]>;

        getForumsCategory(): ng.IPromise<WebboardCategory[]>;
        getForumsItems(criteria: SearchCritirea): ng.IPromise<Webboarditems[]>;

        getResearchCategory(): ng.IPromise<WebboardCategory[]>;
        getResearchItems(criteria: SearchCritirea): ng.IPromise<Webboarditems[]>;

        //createNewPost(models: NamePairValue[]): ng.IPromise<HttpStatusCode>;
        createNewPost(forum: Webboarditems): ng.IPromise<HttpStatusCode>;
    }
    @Module("app")
    @Factory({ name: "webboardService" })
    class webboardService implements IwebboardService {
        static $inject = ['apiService', 'AppConstant'];
        constructor(private apiService: apiService, private constant: AppConstant) {

        }
        getCourseCategory(): ng.IPromise<WebboardCategory[]> {
            return this.apiService.getData<WebboardCategory[]>("course/category");
        }
        getCourseItems(criteria: SearchCritirea): ng.IPromise<Webboarditems[]> {
            var keyword = (criteria.name == "") ? "*" : criteria.name;
            return this.apiService.getData<Webboarditems[]>("course/allItems?keyword=" + keyword);
        }
        getForumsCategory(): ng.IPromise<WebboardCategory[]> {
            return this.apiService.getData<WebboardCategory[]>("forum/category");
        }
        getForumsItems(criteria: SearchCritirea): ng.IPromise<Webboarditems[]> {
            var keyword = (criteria.name == "") ? "*" : criteria.name;
            return this.apiService.getData<Webboarditems[]>("forum/allItems?keyword=" + keyword);
        }
        getResearchCategory(): ng.IPromise<WebboardCategory[]> {
            return this.apiService.getData<WebboardCategory[]>("research/category");
        }
        getResearchItems(criteria: SearchCritirea): ng.IPromise<Webboarditems[]> {
            var keyword = (criteria.name == "") ? "*" : criteria.name;
            return this.apiService.getData<Webboarditems[]>("research/allItems?keyword=" + keyword);
        }
        //createNewPost(models: NamePairValue[]): ng.IPromise<HttpStatusCode> {
        //    return this.apiService.postWithFormData(models, "forum/createNewPost");
        //}
        createNewPost(forum: Webboarditems): ng.IPromise<HttpStatusCode> {
            return this.apiService.postData(forum, "forum/createNewPost");
        }
    }
}