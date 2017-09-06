module Swu {
    @Module("app")
    @Directive({ name: "loginModal" })
    class loginModal implements ng.IDirective {
        public restric = "A";
        public link(scope: ng.IScope, element: any, attrs: any) {
             scope.$watch(attrs.loginModal, function (value) {
                if (value) element.modal('show');
                else element.modal('hide');
            });
        }
    }
}