module Swu {
    export interface IUserProfile {
        id?: string;
        firstName?: string;
        lastName?: string;
        firstName_en?: string;
        lastName_en?: string;
        firstName_th?: string;
        lastName_th?: string;
        password?: string;
        rePassword?: string;
        selectedRoleName?: string;
        displayRoleName?: string;
    }
}