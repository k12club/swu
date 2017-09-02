module Swu {
    export interface IforumService {
        getForumDetail(id: string): ng.IPromise<ForumAndComments>;
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
    }
}