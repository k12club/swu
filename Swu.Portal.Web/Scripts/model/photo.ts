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
        title: string;
        displayImage?: string;
        photos: IPhoto[];
        uploadBy?: string;
        publishedDate?: Date;
    }
}