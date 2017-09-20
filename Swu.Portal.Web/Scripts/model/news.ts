﻿module Swu {
    export interface INews {
        imageUrl?: string;
        title?: string;
        title_en: string;
        title_th: string;
        createdBy: string;
        startDate: Date;
        fullDescription_en: string;
        fullDescription_th: string;
    }
}