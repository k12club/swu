module Swu {
    export interface IAlbumScope extends baseControllerScope {
        albums: IPhotoAlbum[];
        html: string;
        link: string;
        getAlbums(): void;
        render(albums: IPhotoAlbum[]): void;
        registerScript(): void;
        goToPhotoAlbum(id: string, title: string): void;
        copyUrlToClipboard(id: string, title: string): void;
        createNewAlbum(): void;
    }

    @Module("app")
    @Controller({ name: "AlbumController" })
    export class AlbumController {
        static $inject: Array<string> = ["$scope", "$rootScope", "AppConstant", "$state", "AuthServices", "albumService", "$uibModal"];
        constructor(private $scope: IAlbumScope, private $rootScope: IRootScope, private config: AppConstant, private $state: ng.ui.IStateService, private auth: IAuthServices, private IalbumService: IalbumService, private $uibModal: ng.ui.bootstrap.IModalService) {
            this.$scope.swapLanguage = (lang: string): void => {
                switch (lang) {
                    case "en": {
                        _.map(this.$scope.albums, function (v) {

                        });
                        break;
                    }
                    case "th": {
                        _.map(this.$scope.albums, function (v) {

                        });
                        break;
                    }
                }
            }
            this.$scope.goToPhotoAlbum = (id: string, title: string): void => {
                var url = $state.href('photo', { "id": id, "title": title });
                window.open(url, '_blank');
            };
            this.$scope.copyUrlToClipboard = (id: string, title: string): void => {
                try {
                    $("#" + id).select();
                    document.execCommand("copy");
                } catch (exception) {
                    console.log(exception);
                }
            };
            this.$scope.render = (albums: IPhotoAlbum[]) => {
                var html = "";
                _.forEach(albums, (value, key) => {
                    var elements = '\
                        <div class="col-md-3">\
                            <div class="resources-item" ng-click="goToPhotoAlbum(\''+ value.id + '\'\,\'' + value.title + '\')">\
                                <div class="resources-category-image" >\
                                    <img class="img-responsive" alt= "" src= "../../../../'+ value.displayImage + '" >\
                                </div>\
                                <div class="resources-description" >\
                                    <p>'+ moment(value.publishedDate).format('LLLL') + '</p>\
                                    <h5>'+ value.title + '</h5>\
                                </div>\
                            </div>\
                            <div class="input-group">\
                                    <input type= "text" id="'+ value.id + '" class="form-control" value= "' + config.web.protocal + "://" + config.web.ip + ":" + config.web.port + $state.href('photo', { "id": value.id, "title": value.title }) + '" placeholder= "Photo gallery url" id= "copy-input" >\
                                    <span class="input-group-btn" >\
                                        <button class="btn btn-default" type= "button" id= "copy-button" data- toggle="tooltip" data- placement="bottom" title= "" data- original - title="Copy to Clipboard" ng-click="copyUrlToClipboard(\''+ value.id + '\'\,\'' + value.title + '\')">Copy</button>\
                                    </span>\
                            </div>\
                        </div>';
                    html += elements;
                });
                if (this.auth.isLoggedIn()) {
                    html += '\
                <div class="col-md-3">\
                    <div class="resources-item" style= "margin-top:30px !important" ng-click="createNewAlbum()">\
                        <div class="resources-description" >\
                            <p>&nbsp; </p>\
                            <h2> CREATE NEW ALBUM </h2>\
                            <div class="irs-evnticon" > <span class="flaticon-cross" > </span></div></div>\
                        </div>\
                </div>';
                }
                this.$scope.html = html;
            }
            this.$scope.registerScript = () => {

            }
            this.$scope.getAlbums = () => {
                this.$scope.albums = [];
                IalbumService.getAlbums().then((response) => {
                    _.forEach(response, (value, key) => {
                        $scope.albums.push({
                            id: value.id,
                            title: value.title,
                            displayImage: value.displayImage,
                            uploadBy: value.uploadBy,
                            publishedDate: value.publishedDate,
                            photos: []
                        });
                    });
                    $scope.swapLanguage($rootScope.lang);
                    $scope.render($scope.albums);
                    $scope.registerScript();
                });
            }
            this.$scope.createNewAlbum = () => {
                var options: ng.ui.bootstrap.IModalSettings = {
                    templateUrl: '/Scripts/app/home/view/album.tmpl.html',
                    controller: AlbumModalController,
                    resolve: {
                    },
                    backdrop: false
                };
                this.$uibModal.open(options).result.then(() => {
                    this.$scope.getAlbums();
                });
            };
            this.$rootScope.$watch("lang", function (newValue: string, oldValue: string) {
                if ($scope.albums != undefined || $scope.albums != null) {
                    IalbumService.getAlbums().then((response) => {
                        _.forEach(response, (value, key) => {
                            $scope.albums.push({
                                id: value.id,
                                title: value.title,
                                displayImage: value.displayImage,
                                uploadBy: value.uploadBy,
                                publishedDate: value.publishedDate,
                                photos: []
                            });
                        });
                        $scope.swapLanguage(newValue);
                        $scope.render($scope.albums);
                        $scope.registerScript();
                    });
                }

            });
            this.init();
        }

        init(): void {
            this.$scope.albums = [];
        }
    }
}