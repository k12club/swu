/// <reference path="../_references.ts" />

module Swu {
    export interface owlScope {
        initCarousel(element: any):void;
    }
    @Module("app")
    @Directive({ name: "owlCarousel" })
    class owlCarousel implements ng.IDirective {
        public restric = "E";
        public replace = true;
        public templateUrl = "/Scripts/app/template/chooseFile.html";
        public scope = {
        };
        public link(scope: owlScope, element: ng.IAugmentedJQuery, attrs: ng.IAttributes) {
            scope.initCarousel = (element:any) =>  {
                // provide any default options you want
                var defaultOptions = {
                };
                var customOptions = scope.$eval($(element).attr('data-options'));
                // combine the two options objects
                for (var key in customOptions) {
                    defaultOptions[key] = customOptions[key];
                }
                // init carousel
                $(element).owlCarousel(defaultOptions);
            };
        }
    }
}