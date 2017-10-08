module Swu {
    interface FooterScope extends ng.IScope {
        courses: ICourseCard[];
        splite1: ICourseCard[];
        splite2: ICourseCard[];
        goToPage(stateName: string, type: number): void;
    }
    @Module("app")
    @Controller({ name: "FooterController" })
    export class FooterController {
        static $inject: Array<string> = ["$scope", "$state", "AuthServices", "homeCourseService"];
        constructor(private $scope: FooterScope, private $state: ng.ui.IStateService, private auth: IAuthServices, private homeCourseService: IhomeCourseService) {
            this.$scope.goToPage = (stateName: string, type: number): void => {
                if (stateName == "board") {
                    this.$state.go("board", { "type": type }, { reload: true });
                } else {
                    this.$state.go(stateName, { reload: true });
                }
            };
            this.init();
        }
        init(): void {
            this.$scope.splite1 = [];
            this.$scope.splite2 = [];
            this.homeCourseService.getLatest().then((response) => {
                this.$scope.courses = response;
                _.forEach(this.$scope.courses, (value, key) => {
                    if (key < (this.$scope.courses.length / 2)) {
                        this.$scope.splite1.push({
                            course: value.course,
                            cardType: value.cardType,
                            teacher: value.teacher
                        });
                    } else {
                        this.$scope.splite2.push({
                            course: value.course,
                            cardType: value.cardType,
                            teacher: value.teacher
                        });
                    }
                });
            }, (error) => { });
        };

    }
}