module Swu {
    export interface ICommittee extends IContact {
        name?: string;
        position?: string;
        description?: string;

        name_th?: string;
        position_th?: string;
        description_th?: string;

        name_en?: string;
        position_en?: string;
        description_en?: string;
    }
}