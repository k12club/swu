module Swu {
    export interface StudentScores {
        studentScores:StudentScore[]
    }
    export interface StudentScore {
        id?: string;
        studentId?: string;
        name?: string;
        score?: number;
        activated?: boolean;
    }
}