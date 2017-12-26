module Swu {
    export interface IEvent {
        id?:number;
        title?: string;
        place?: string;
        description?: string;
        displayStartDate?: string;
        displayStartTime?: string;

        title_en: string;
        place_en: string;
        description_en: string;

        title_th: string;
        place_th: string;
        description_th: string;

        imageUrl: string;
        startDate: Date;

        isActive?: boolean;
        createdUserId?: string;
    }
}