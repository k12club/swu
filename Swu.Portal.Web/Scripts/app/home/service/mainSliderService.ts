module Swu {
    export interface ImainSliderService {
        getSliders(): ng.IPromise<ISlider[]>;
    }
    @Module("app")
    @Factory({ name: "mainSliderService" })
    class homeCourseService implements ImainSliderService {
        static $inject = ['apiService', 'AppConstant'];
        constructor(private apiService: apiService, private constant: AppConstant) {

        }
        getSliders(): ng.IPromise<ISlider[]> {
            return this.apiService.getData<ISlider[]>("course/getSlider");
        }
    }
}