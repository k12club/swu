module Swu {
    export interface IforumService {
        getForumDetail(id: string): ng.IPromise<ForumAndComments>;
        postComment(models: NamePairValue[]): ng.IPromise<HttpStatusCode>;
        getCommentById(id: number): ng.IPromise<Comment>;
        updateComment(comment: Comment): ng.IPromise<HttpStatusCode>;
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
        getCommentById(id: number): ng.IPromise<Comment> {
            return this.apiService.getData("forum/getCommentById?id=" + id);
        }
        updateComment(comment: Comment): ng.IPromise<HttpStatusCode> {
            return this.apiService.postData(comment, "forum/updateComment");
        }
    }
}