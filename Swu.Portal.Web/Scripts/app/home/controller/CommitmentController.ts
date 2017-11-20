module Swu {
    interface ICommitmentScope extends baseControllerScope {
        commitments: ICommitment[];
    }
    @Module("app")
    @Controller({ name: "CommitmentController" })
    export class CommitmentController {
        static $inject: Array<string> = ["$scope", "$rootScope", "$state", "commitmentService"];
        constructor(private $scope: ICommitmentScope, private $rootScope: IRootScope, private $state: ng.ui.IState, private commitmentService: IcommitmentService) {
            this.$scope.commitments = [];
            this.$scope.swapLanguage = (lang: string): void => {
                switch (lang) {
                    case "en": {
                        _.map($scope.commitments, function (s) {
                            s.title = s.title_en;
                            s.description = s.description_en;
                        });
                        break;
                    }
                    case "th": {
                        _.map($scope.commitments, function (s) {
                            s.title = s.title_th;
                            s.description = s.description_th;
                        });
                        break;
                    }
                }
            }
            this.$rootScope.$watch("lang", function (newValue: string, oldValue: string) {
                $scope.commitments = [];
                commitmentService.getCommitments().then((response) => {
                    _.forEach(response, (value, key) => {
                        var mod = key % 2;
                        var mod2 = (key + 1) % 4;
                        var alignment = "";
                        var columnCss = "";
                        var delay = 0;
                        var style = "";
                        var commentCss = "";
                        if (mod == 0) {
                            alignment = "left";
                            columnCss = "irs-commtmnt-column";
                            commentCss = "irs-cmmt-details";
                        } else {
                            alignment = "right";
                            columnCss = "irs-commtmnt-column2";
                            commentCss = "irs-cmmt-details2";
                        }
                        if (mod2 == 1) {
                            style = "style_one";
                        }
                        $scope.commitments.push({
                            title_en: value.title_en,
                            description_en: value.description_en,
                            title_th: value.title_th,
                            description_th: value.description_th,
                            alignment: "text-" + alignment,
                            iconCss: value.iconCss,
                            columnCss: columnCss,
                            style: style,
                            commentCss: commentCss,
                            isImgContent: false
                        });
                    });
                    $scope.commitments.push(
                        {
                            title_en: "Test",
                            description_en: "Test",
                            title_th: "Test",
                            description_th: "Test",
                            alignment: "text-right",
                            columnCss: "irs-commtmnt-column2",
                            commentCss: "irs-cmmt-details2",
                            isImgContent: true
                        });
                    $scope.swapLanguage(newValue);
                }, (error) => { });
            });
        }
        init(): void {
        };

    }
}