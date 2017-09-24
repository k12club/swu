module Swu {
    export interface ITeacher extends BaseUser {
        position: string;
        description: string;

        position_en?: string;
        description_en?: string;
        position_th?: string;
        description_th?: string;
    }
}