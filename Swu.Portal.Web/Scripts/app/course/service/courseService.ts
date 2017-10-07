module Swu {
    export interface SearchCritirea {
        name?: string;
    }
    export interface IcourseService {
        getById(id: number): ng.IPromise<ICourseAllDetail>;
        getCourseByCriteria(criteria: SearchCritirea): ng.IPromise<ICourseBriefDetail[]>;
        saveCurriculum(curriculum: ICurriculum): ng.IPromise<ICurriculum>;
        getCurriculumById(id: number): ng.IPromise<ICurriculum>;
        takeCourse(courseId: string, studentId: string): ng.IPromise<HttpStatusCode>;
        removeCourse(courseId: string, studentId: string): ng.IPromise<HttpStatusCode>;
        approveTakeCourse(courseId: string, studentId: string): ng.IPromise<HttpStatusCode>;
        savePhoto(models: NamePairValue[]): ng.IPromise<HttpStatusCode>;
        removePhoto(photoId: number): ng.IPromise<HttpStatusCode>;
        saveStudentScores(scores: StudentScore[]): ng.IPromise<HttpStatusCode>;
    }
    @Module("app")
    @Factory({ name: "courseService" })
    class courseService implements IcourseService {
        static $inject = ['apiService', 'AppConstant'];
        constructor(private apiService: apiService, private constant: AppConstant) {

        }
        getById(id: number): ng.IPromise<ICourseAllDetail> {
            return this.apiService.getData<ICourseAllDetail>("course/getById?id=" + id);
        }
        getCourseByCriteria(criteria: SearchCritirea) {
            return this.apiService.getData<ICourseBriefDetail[]>("course/getCourseByCriteria?keyword=" + criteria.name);
        }
        saveCurriculum(curriculum: ICurriculum): ng.IPromise<ICurriculum> {
            return this.apiService.postData<ICurriculum>(curriculum, "course/addOrUpdateCurriculum");
        }
        getCurriculumById(id: number): ng.IPromise<ICurriculum> {
            return this.apiService.getData<ICurriculum>("course/getCurriculumById?id=" + id);
        }
        takeCourse(courseId: string, studentId: string): ng.IPromise<HttpStatusCode> {
            return this.apiService.getData<HttpStatusCode>("course/takeCourse?courseId=" + courseId + "&studentId=" + studentId);
        }
        removeCourse(courseId: string, studentId: string): ng.IPromise<HttpStatusCode> {
            return this.apiService.getData<HttpStatusCode>("course/removeCourse?courseId=" + courseId + "&studentId=" + studentId);
        }
        approveTakeCourse(courseId: string, studentId: string): ng.IPromise<HttpStatusCode> {
            return this.apiService.getData<HttpStatusCode>("course/approveTakeCourse?courseId=" + courseId + "&studentId=" + studentId);
        }
        savePhoto(models: NamePairValue[]): ng.IPromise<HttpStatusCode> {
            return this.apiService.postWithFormData(models, "Course/uploadPhotoAsnc");
        }
        removePhoto(photoId: number): ng.IPromise<HttpStatusCode>{
            return this.apiService.getData<HttpStatusCode>("course/removePhoto?photoId=" + photoId);
        }
        saveStudentScores(scores: StudentScore[]): ng.IPromise<HttpStatusCode> {
            return this.apiService.postData<HttpStatusCode>(scores, "course/updateScores");
        }
    }
}