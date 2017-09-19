module Swu {
    export interface IeventManagementService {
        addNewOrUpdate(event: IEvent): ng.IPromise<HttpStatusCode>;
        getAll(): ng.IPromise<IEvent[]>;
        getEventById(id: number): ng.IPromise<IEvent>;
        deleteById(id: number): ng.IPromise<HttpStatusCode>;
    }
    @Module("app")
    @Factory({ name: "eventManagementService" })
    class eventManagementService implements IeventManagementService {
        static $inject = ['apiService', 'AppConstant'];
        constructor(private apiService: apiService, private constant: AppConstant) {

        }
        addNewOrUpdate(event:IEvent): ng.IPromise<HttpStatusCode> {
            return this.apiService.postData<HttpStatusCode>(event, "event/addNewOrUpdate");
        }
        getAll(): ng.IPromise<IEvent[]> {
            return this.apiService.getData<IEvent[]>("event/allEvents");
        }
        getEventById(id: number): ng.IPromise<IEvent> {
            return this.apiService.getData<IEvent>("event/getEventById?id=" + id);
        }
        deleteById(id: number): ng.IPromise<HttpStatusCode> {
            return this.apiService.getData("event/deleteById?id=" + id);
        }
    }
}