module Swu {
    interface IExamRegistrationScope extends baseControllerScope {
        exam: IExamClock;
        getExam(): void;
        register_flipClock(remaining: number): void;
    }
    @Module("app")
    @Controller({ name: "ExamRegistrationController" })
    export class ExamRegistrationController {
        static $inject: Array<string> = ["$scope","$rootScope", "$state", "examRegistrationService"];
        constructor(private $scope: IExamRegistrationScope, private $rootScope: IRootScope, private $state: ng.ui.IState, private examRegistrationService: IexamRegistrationService) {
            this.$scope.getExam = () => {
                this.examRegistrationService.getExam().then((response) => {
                    $scope.register_flipClock(response.remainingTime);
                }, (error) => { });
            };
            this.$scope.swapLanguage = (lang: string): void => {
                switch (lang) {
                    case "en": {
                        $scope.exam.examInfo.title = $scope.exam.examInfo.title_en;
                        $scope.exam.examInfo.description = $scope.exam.examInfo.description_en;
                        break;
                    }
                    case "th": {
                        $scope.exam.examInfo.title = $scope.exam.examInfo.title_th;
                        $scope.exam.examInfo.description = $scope.exam.examInfo.description_th;
                        break;
                    }
                }
            }
            this.$scope.register_flipClock = (remaining: number) => {
                var clock: any;
                clock = $('.clock').FlipClock({
                    clockFace: 'DailyCounter',
                    autoStart: false,
                    callbacks: {
                        stop: function () {
                            $('.message').html('The clock has stopped!')
                        }
                    }
                });

                clock.setTime(remaining);
                clock.setCountdown(true);
                clock.start();
            };
            this.$rootScope.$watch("lang", function (newValue: string, oldValue: string) {
                examRegistrationService.getExam().then((response) => {
                    $scope.exam = response;
                    $scope.swapLanguage(newValue);
                }, (error) => { });
            });
            this.init();
        }
        init(): void {
            this.$scope.getExam();
        };

    }
}