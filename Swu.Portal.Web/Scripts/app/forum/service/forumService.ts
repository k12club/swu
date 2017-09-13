module Swu {
    export interface IforumService {
        getForumDetail(id: string): ng.IPromise<ForumAndComments>;
        postComment(models: NamePairValue[]): ng.IPromise<HttpStatusCode>;
    }
    @Module("app")
    @Factory({ name: "forumService" })
    class forumService implements IforumService {
        static $inject = ['apiService', 'AppConstant'];
        constructor(private apiService: apiService, private constant: AppConstant) {

        }
        getForumDetail(id: string): ng.IPromise<ForumAndComments> {
            return this.apiService.getData<ForumAndComments>("forum/getForumDetail?id=" + id);
        }
        postComment(models: NamePairValue[]): ng.IPromise<HttpStatusCode> {
            return this.apiService.postWithFormData(models, "forum/postComment");
        }
    }
}