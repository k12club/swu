module Swu {
    export interface IalbumManagementService {
        getAll(): ng.IPromise<IPhotoAlbum[]>;
        getById(id: string): ng.IPromise<IPhotoAlbum>;
        deleteById(id: string): ng.IPromise<HttpStatusCode>;
        updatePhotoAlbum(model: IPhotoAlbum): ng.IPromise<HttpStatusCode>;
    }
    @Module("app")
    @Factory({ name: "albumManagementService" })
    class albumManagementService implements IalbumManagementService {
        static $inject = ['apiService', 'AppConstant'];
        constructor(private apiService: apiService, private constant: AppConstant) {

        }
        getAll(): ng.IPromise<IPhotoAlbum[]> {
            return this.apiService.getData<IPhotoAlbum[]>("shared/allAlbums");
        }
        getById(id: string): ng.IPromise<IPhotoAlbum> {
            return this.apiService.getData<IPhotoAlbum>("shared/getAlbumById?id=" + id);
        }
        deleteById(id: string): ng.IPromise<HttpStatusCode> {
            return this.apiService.getData("shared/deleteAlbumById?id=" + id);
        }
        updatePhotoAlbum(model: IPhotoAlbum): ng.IPromise<HttpStatusCode> {
            return this.apiService.postData(model, "shared/updatePhotoAlbum");
        }
    }
}