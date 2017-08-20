module Swu {
    export interface IPhoto {
        id: number;
        name: string;
        imageUrl: string;
    }
    export interface IPhotoAlbum {
        id: number;
        photos: IPhoto[];
    }
}