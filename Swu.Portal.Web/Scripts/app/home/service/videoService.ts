module Swu {
    export interface IvideoService {
        getVideos(): ng.IPromise<IVideo[]>;
    }
    @Module("app")
    @Factory({ name: "videoService" })
    class videoService implements IvideoService {
        static $inject = ['apiService', 'AppConstant'];
        constructor(private apiService: apiService, private constant: AppConstant) {

        }
        getVideos(): ng.IPromise<IVideo[]> {
            return this.apiService.getData<IVideo[]>("video/all");
        }
    }
}