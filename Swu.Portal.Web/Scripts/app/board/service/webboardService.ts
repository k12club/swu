module Swu {
    export interface IwebboardService {
        getCourseCategory(): ng.IPromise<WebboardCategory[]>;
        getCourseItems(criteria: SearchCritirea): ng.IPromise<Webboarditems[]>;

        getForumsCategory(): ng.IPromise<WebboardCategory[]>;
        getForumsItems(criteria: SearchCritirea): ng.IPromise<Webboarditems[]>;

        getResearchCategory(): ng.IPromise<WebboardCategory[]>;
        getResearchItems(criteria: SearchCritirea): ng.IPromise<Webboarditems[]>;

        //createNewPost(models: NamePairValue[]): ng.IPromise<HttpStatusCode>;
        addOrUpdatePost(forum: Webboarditems): ng.IPromise<HttpStatusCode>;
        getPostById(id: string): ng.IPromise<Webboarditems>;
        getResearchById(id: string): ng.IPromise<Webboarditems>;
        addOrUpdateResearch(models: NamePairValue[]): ng.IPromise<HttpStatusCode>;

        addNewForumCategory(category: WebboardCategory): ng.IPromise<HttpStatusCode>;
        addNewResearchCategory(category: WebboardCategory): ng.IPromise<HttpStatusCode>;
        addNewCourseCategory(category: WebboardCategory): ng.IPromise<HttpStatusCode>;
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
        addOrUpdatePost(forum: Webboarditems): ng.IPromise<HttpStatusCode> {
            return this.apiService.postData(forum, "forum/addOrUpdatePost");
        }
        getPostById(id: string): ng.IPromise<Webboarditems> {
            return this.apiService.getData("forum/getPostById?id=" + id);
        }
        getResearchById(id: string): ng.IPromise<Webboarditems> {
            return this.apiService.getData("research/getResearchById?id=" + id);
        }
        addOrUpdateResearch(models: NamePairValue[]): ng.IPromise<HttpStatusCode> {
            return this.apiService.postWithFormData<HttpStatusCode>(models, "research/SaveAsync");
        }
        addNewForumCategory(category: WebboardCategory): ng.IPromise<HttpStatusCode> {
            return this.apiService.postData(category, "forum/addNewCategory");
        }
        addNewResearchCategory(category: WebboardCategory): ng.IPromise<HttpStatusCode> {
            return this.apiService.postData(category, "research/addNewCategory");
        }
        addNewCourseCategory(category: WebboardCategory): ng.IPromise<HttpStatusCode> {
            return this.apiService.postData(category, "course/addNewCategory");
        }
    }
}