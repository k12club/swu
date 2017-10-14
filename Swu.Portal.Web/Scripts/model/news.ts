module Swu {
    export interface INews {
        id: number;
        imageUrl?: string;
        title?: string;
        description?: string;
        createdBy: string;
        startDate: Date;

        title_en?: string;
        description_en?: string;

        title_th?: string;
        description_th?: string;
    }
}