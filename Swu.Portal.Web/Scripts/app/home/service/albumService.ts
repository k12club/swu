module Swu {
    export interface IalbumService {
        getAlbums(): ng.IPromise<IPhotoAlbum[]>;
        getPhotos(id: string): ng.IPromise<IPhoto[]>;
        createNewAlbum(models: NamePairValue[]): ng.IPromise<HttpStatusCode>;
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
        createNewAlbum(models: NamePairValue[]): ng.IPromise<HttpStatusCode> {
            return this.apiService.postWithFormData<HttpStatusCode>(models, "shared/createNewAlbum");
        }
    }
}