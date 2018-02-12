module Swu {
    interface IQualificationScope extends baseControllerScope {
        //content: string;
        isShowThai: boolean;
        isShowEng: boolean;
    }
    @Module("app")
    @Controller({ name: "QualificationController" })
    export class QualificationController {
        static $inject: Array<string> = ["$scope", "$rootScope", "$state"];
        constructor(private $scope: IQualificationScope, private $rootScope: IRootScope, private $state: ng.ui.IState) {
            this.$scope.swapLanguage = (lang: string): void => {
                switch (lang) {
                    case "en": {
                        $scope.isShowEng = true;
                        $scope.isShowThai = false;
                        break;
                    }
                    case "th": {
                        $scope.isShowEng = false;
                        $scope.isShowThai = true;
                        break;
                    }
                }
            };
            this.$rootScope.$watch("lang", function (newValue: string, oldValue: string) {
                $scope.swapLanguage(newValue);
            });
            this.init();
        }
        init(): void {

        };

    }
}