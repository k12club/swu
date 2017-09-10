module Swu {
    export interface IStudent extends BaseUser {
        studentId: string;
        description: string;
        activated: boolean;
    }
}