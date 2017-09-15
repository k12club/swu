module Swu {
    export interface ICourse {
        id: number;
        name: string;
        name_th: string;
        name_en: string;
        imageUrl: string;
        numberOfRegistered?: number;
        numberOfComments?: number;
        numberOfLectures?: number;
        numberOfQuizes?: number;
        numberOfTimes?: number;
        numberOfStudents?: number;
        numberOfTeachers?: number;
        lang?: string;
        price?: number;
        categoryId?: number;
        categoryName?: string;
        createdUserId?: string;
        createdDate: Date;
        updateDate: Date;
        createdBy: string;
    }
}