module Swu {
    @Module("app")
    @Controller({ name: "HomeController" })
    export class HomeController {
        static $inject: Array<string> = ["$scope", "$state"];
        constructor() {
            //alert('HomeController');
        }

    }
}