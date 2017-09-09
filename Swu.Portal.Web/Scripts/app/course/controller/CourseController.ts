module Swu {
    export interface ICourseScope extends ng.IScope {
        id: number;
        courseDetail: ICourseAllDetail;
        splitStudents1: IStudentDetail[];
        splitStudents2: IStudentDetail[];
        getCourse(id: number): void;
        render(photos: IPhoto[]): void;
        registerScript(): void;
        hasPermission: boolean;
        addNew(): void;
        edit(id: number): void;
    }
    @Module("app")
    @Controller({ name: "CourseController" })
    export class CourseController {
        static $inject: Array<string> = ["$scope", "$state", "courseService", "$stateParams", "$sce", "$uibModal", "AuthServices"];
        constructor(private $scope: ICourseScope, private $state: ng.ui.IState, private courseService: IcourseService, private $stateParams: ng.ui.IStateParamsService, private $sce: ng.ISCEService, private $uibModal: ng.ui.bootstrap.IModalService, private AuthServices: IAuthServices) {
            this.$scope.id = this.$stateParams["id"];
            this.$scope.getCourse = (id: number) => {
                this.courseService.getById(id).then((response) => {
                    this.$scope.courseDetail = response;
                    this.$scope.hasPermission = this.AuthServices.getCurrentUser().id == this.$scope.courseDetail.course.createdUserId;
                    this.$scope.courseDetail.course.fullDescription = $sce.trustAsHtml(this.$scope.courseDetail.course.fullDescription);
                    _.map(this.$scope.courseDetail.teachers, function (t) {
                        t.description = $sce.trustAsHtml(t.description);
                    });
                    _.map(this.$scope.courseDetail.photosAlbum.photos, function (p) {
                        p.displayPublishedDate = moment(p.publishedDate).format("LL");
                    });
                    _.forEach(this.$scope.courseDetail.students, (value, key) => {
                        if (key < (this.$scope.courseDetail.students.length / 2)) {
                            this.$scope.splitStudents1.push({
                                id: value.id,
                                number: key + 1,
                                studentId: value.studentId,
                                name: value.name,
                                description: value.description,
                                imageUrl: value.imageUrl
                            });
                        } else {
                            this.$scope.splitStudents2.push({
                                id: value.id,
                                number: key + 1,
                                studentId: value.studentId,
                                name: value.name,
                                description: value.description,
                                imageUrl: value.imageUrl
                            });
                        }
                    });

                    this.$scope.render(this.$scope.courseDetail.photosAlbum.photos);
                    this.$scope.registerScript();
                }, (error) => { });
            }
            this.$scope.render = (photos: IPhoto[]) => {
                var html = "";
                _.forEach(photos, (value, key) => {
                    var elements = "<div class='col-md-4'>\
                        <div class='resources-item' >\
                            <div class='resources-category-image' >\
                                <a href='../../../../"+ value.imageUrl + "' title= '" + value.name + "' by='" + value.uploadBy + "'>\
                                    <img class='img-responsive' alt= '' src= '../../../../"+ value.imageUrl + "'>\
                                        </a>\
                                        </div>\
                                        <div class='resources-description' >\
                                            <p>"+ value.displayPublishedDate + "</p>\
                                                <h4>"+ value.name + "</h4>\
                                                </div>\
                                                </div>\
                                                </div>";
                    html += elements;
                });
                html = "<div class='row'>" + html + "</div>";
                $('.popup-gallery').html(html);
            }
            this.$scope.registerScript = () => {
                $('.popup-gallery').magnificPopup({
                    delegate: 'a',
                    type: 'image',
                    tLoading: 'Loading image #%curr%...',
                    mainClass: 'mfp-img-mobile',
                    gallery: {
                        enabled: true,
                        navigateByImgClick: true,
                        preload: [0, 1] // Will preload 0 - before current, and 1 after the current image
                    },
                    image: {
                        tError: '<a href="%url%">The image #%curr%</a> could not be loaded.',
                        titleSrc: function (item: any) {
                            return item.el.attr('title') + '<small> Upload by: ' + item.el.attr('by') + '</small>';
                        }
                    }
                });
            };
            this.$scope.addNew = () => {
                var options: ng.ui.bootstrap.IModalSettings = {
                    templateUrl: '/Scripts/app/course/view/curriculum.tmpl.html',
                    controller: CurriculumModalController,
                    resolve: {
                        id: function () {
                            return 0;
                        },
                        courseId: function () {
                            return $scope.id;
                        },
                        mode: function () {
                            return actionMode.addNew;
                        }
                    },
                    size: "md"
                };
                this.$uibModal.open(options).result.then(() => {
                    this.$scope.getCourse(this.$scope.id);
                });
            };
            this.$scope.edit = (id: number) => {
                var options: ng.ui.bootstrap.IModalSettings = {
                    templateUrl: '/Scripts/app/course/view/curriculum.tmpl.html',
                    controller: CurriculumModalController,
                    resolve: {
                        id: function () {
                            return id;
                        },
                        courseId: function () {
                            return $scope.id;
                        },
                        mode: function () {
                            return actionMode.edit;
                        }
                    },
                    size: "md"
                };
                this.$uibModal.open(options).result.then(() => {
                    this.$scope.getCourse(this.$scope.id);
                });
            };
            this.init();
        }
        init(): void {
            this.$scope.splitStudents1 = [];
            this.$scope.splitStudents2 = [];
            this.$scope.getCourse(this.$scope.id);
        };

    }
}