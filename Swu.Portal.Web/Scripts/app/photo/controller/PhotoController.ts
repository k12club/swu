module Swu {
    export interface IPhotoController extends baseControllerScope {
        id: string;
        html: string;
        title: string;
        photos: IPhoto[];
        render(photos: IPhoto[]): void;
        registerScript(): void;
    }

    @Module("app")
    @Controller({ name: "PhotoController" })
    export class PhotoController {
        static $inject: Array<string> = ["$scope", "$rootScope", "$state", "$stateParams", "AuthServices", "albumService"];
        constructor(private $scope: IPhotoController, private $rootScope: IRootScope, private $state: ng.ui.IState, private $stateParams: ng.ui.IStateParamsService, private auth: IAuthServices, private IalbumService: IalbumService) {
            this.$scope.id = this.$stateParams["id"];
            this.$scope.title = this.$stateParams["title"];
            this.$scope.swapLanguage = (lang: string): void => {
                switch (lang) {
                    case "en": {
                        _.map(this.$scope.photos, function (p) {
                            p.displayPublishedDate = moment(p.publishedDate).format("LL");

                        });
                        break;
                    }
                    case "th": {
                        _.map(this.$scope.photos, function (p) {
                            p.displayPublishedDate = moment(p.publishedDate).format("LL");
                        });
                        break;
                    }
                }
            }
            this.$scope.render = (photos: IPhoto[]) => {
                var html = "";
                _.forEach(photos, (value, key) => {
                    var elements = "<div class='col-md-3'>\
                        <div class='resources-item' >\
                            <div class='resources-category-image' >\
                                <a href='../../../../"+ value.imageUrl + "' title= '" + value.name + "' by='" + value.uploadBy + "'>\
                                    <img class='img-responsive' alt= '' src= '../../../../"+ value.imageUrl + "'></a>\
                            </div>\
                        <div class='resources-description' ><p>"+ value.displayPublishedDate + "</p>\
                        <b>"+ value.name + "</b>\
                        </div></div>\
                    </div>";
                    html += elements;
                });
                this.$scope.html = html;
            }
            this.$scope.registerScript = () => {

            }
            this.$rootScope.$watch("lang", function (newValue: string, oldValue: string) {
                if ($scope.photos != undefined || $scope.photos != null) {
                    IalbumService.getPhotos($scope.id).then((response) => {
                        _.forEach(response, (value, key) => {
                            $scope.photos.push({
                                id: value.id,
                                name: value.name,
                                imageUrl: value.imageUrl,
                                displayPublishedDate: value.displayPublishedDate,
                                publishedDate: value.publishedDate,
                                uploadBy: value.uploadBy
                            });
                        });
                        $scope.swapLanguage(newValue);
                        $scope.render($scope.photos);
                        $scope.registerScript();
                    });
                }

            });
            this.init();
        }
        init(): void {
            this.$scope.photos = [];
        }
    }
}