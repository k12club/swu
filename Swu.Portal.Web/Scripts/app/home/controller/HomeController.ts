﻿module Swu {
    @Module("app")
    @Controller({ name: "HomeController" })
    export class HomeController {
        static $inject: Array<string> = ["$scope", "$state"];
        constructor(private $scope:ng.IScope,private $state:ng.ui.IState) {
           
        }
        init(): void {
        };

    }
}