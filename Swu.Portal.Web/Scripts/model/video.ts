module Swu {
    export interface IVideo{
        id: number;
        imageUrl: string;
        videoUrl: string;
        title?: string;
        title_en?: string;
        title_th?: string;
    }
    export interface IVideoAlbum {
        id: number;
        photos: IVideo[];
    }
}