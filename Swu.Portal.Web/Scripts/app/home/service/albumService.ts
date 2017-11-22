module Swu {
    export interface IalbumService {
        getAlbums(): ng.IPromise<IPhotoAlbum[]>;
        getPhotos(id: string): ng.IPromise<IPhoto[]>;
    }
    @Module("app")
    @Factory({ name: "albumService" })
    class albumService implements IalbumService {
        static $inject = ['apiService', 'AppConstant'];
        constructor(private apiService: apiService, private constant: AppConstant) {

        }
        getAlbums(): ng.IPromise<IPhotoAlbum[]> {
            return this.apiService.getData<IPhotoAlbum[]>("shared/albums");
        }
        getPhotos(id: string): ng.IPromise<IPhoto[]> {
            return this.apiService.getData<IPhoto[]>("shared/photo?id=" + id);
        }
    }
}