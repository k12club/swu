module Swu {
    @Module("app")
    @Directive({ name: "fileModel" })
    class fileModel implements ng.IDirective {
        static $inject: Array<string> = ["$parse"];
        public restric = "A";
        constructor(private $parse:ng.IParseService) { }
        public link(scope: ng.IScope, element: any, attrs: any) {
            var model = this.$parse(attrs.fileModel);
            var modelSetter = model.assign;

            element.bind('change', function () {
                scope.$apply(function () {
                    console.log(element[0].files);
                    modelSetter(scope, element[0].files[0]);
                });
            });
        }
    }
    @Module("app")
    @Directive({ name: "filesModel" })
    class filesModel implements ng.IDirective {
        static $inject: Array<string> = ["$parse"];
        public restric = "A";
        constructor(private $parse: ng.IParseService) { }
        public link(scope: ng.IScope, element: any, attrs: any) {
            var model = this.$parse(attrs.filesModel);
            var modelSetter = model.assign;

            element.bind('change', function () {
                scope.$apply(function () {
                    modelSetter(scope, element[0].files);
                });
            });
        }
    }
}