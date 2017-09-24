module Swu {
    export interface BaseUser {
        id: number;
        name: string;
        imageUrl: string;

        firstName?: string;
        lastName?: string;

        firstName_en?: string;
        lastName_en?: string;
        firstName_th?: string;
        lastName_th?: string;
    }
}