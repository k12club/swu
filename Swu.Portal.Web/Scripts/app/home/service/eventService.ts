module Swu {
    export interface IeventService {
        getEvents(): ng.IPromise<IEvent[]>;
    }
    @Module("app")
    @Factory({ name: "eventService" })
    class eventService implements IeventService {
        static $inject = ['apiService', 'AppConstant'];
        constructor(private apiService: apiService, private constant: AppConstant) {

        }
        getEvents(): ng.IPromise<IEvent[]> {
            return this.apiService.getData<IEvent[]>("event/all");
        }
    }
}