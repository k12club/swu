module Swu {
    export interface ICourseDetail extends ICourse {
        bigImageUrl: string;
        shortDescription: string;
        fullDescription: string;
    }
    export interface ICurriculum {
        id: number;
        name?: string;
        type?: CurriculumType;
        numberOfTime?: number;
        //time?: string;
        courseId?: string;
        studentScores: StudentScores;

        startDate?: Date;
        room?: string;
        surveyLink?: string;
        curriculumDocuments?: AttachFile[];
    }
    export interface ITeacherDetail extends ITeacher { }
    export interface IStudentDetail extends IStudent {
        number?: number;
    }
    export interface ICourseAllDetail {
        course: ICourseDetail;
        curriculums: ICurriculum[];
        teachers: ITeacherDetail[];
        students: IStudentDetail[];
        photosAlbum: IPhotoAlbum;
    }
    export interface ICourseBriefDetail {
        course: ICourseDetail;
        teachers: ITeacherDetail[];
    }
}