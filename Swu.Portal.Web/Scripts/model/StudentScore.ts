module Swu {
    export interface StudentScores {
        studentScores:StudentScore[]
    }
    export interface StudentScore {
        scoreId?: number;
        studentId?: string;
        name?: string;
        score?: number;
        activated?: boolean;
        curriculumId?: number;
        imageUrl?: string;
    }
}