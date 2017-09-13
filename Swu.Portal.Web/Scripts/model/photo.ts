module Swu {
    export interface IPhoto {
        id: number;
        name: string;
        imageUrl: string;
        publishedDate: Date;
        displayPublishedDate: string;
        uploadBy: string;
    }
    export interface IPhotoAlbum {
        id: string;
        photos: IPhoto[];
    }
}