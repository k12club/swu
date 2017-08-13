module Swu {
    export interface ICourse {
        id: number;
        name: string;
        name_th: string;
        name_en: string;
        imageUrl: string;
        numberOfRegistered: number;
        numberOfComments: number;
        price: number;
    }
}