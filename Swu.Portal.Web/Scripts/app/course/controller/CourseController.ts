module Swu {
    export interface ICourseScope extends ng.IScope {
        currentUser: IUserProfile;
        id: number;
        courseDetail: ICourseAllDetail;
        splitStudents1: IStudentDetail[];
        splitStudents2: IStudentDetail[];
        getCourse(id: number): void;
        render(photos: IPhoto[]): void;
        registerScript(): void;
        hasPermission: boolean;
        canSeeQuizeResult: boolean;
        canTakeCourse: boolean;
        html: string;

        addNew(): void;
        edit(id: number): void;
        getCurrentUser(): IUserProfile;
        getStudentScore(id: number): StudentScore;
        showResultModal(id: number): void;
        takeCourse(): void;
        removeCourse(id: string): void;
        approve(id: string): void;
        addNewPhoto(id: string): void;
        removePhoto(id: number): void;
    }
    @Module("app")
    @Controller({ name: "CourseController" })
    export class CourseController {
        static $inject: Array<string> = ["$scope", "$state", "courseService", "$stateParams", "$sce", "$uibModal", "AuthServices", "toastr"];
        constructor(private $scope: ICourseScope, private $state: ng.ui.IState, private courseService: IcourseService, private $stateParams: ng.ui.IStateParamsService, private $sce: ng.ISCEService, private $uibModal: ng.ui.bootstrap.IModalService, private auth: IAuthServices, private toastr: Toastr) {
            this.$scope.id = this.$stateParams["id"];
            this.$scope.getCurrentUser = () => {
                if (this.$scope.currentUser == null) {
                    this.$scope.currentUser = this.auth.getCurrentUser();
                }
                return this.$scope.currentUser;
            };
            this.$scope.getCourse = (id: number) => {
                this.$scope.canSeeQuizeResult = false;
                this.$scope.canTakeCourse = false;
                this.$scope.courseDetail = null;
                this.$scope.splitStudents1 = [];
                this.$scope.splitStudents2 = [];
                this.courseService.getById(id).then((response) => {
                    this.$scope.courseDetail = response;
                    if (this.$scope.getCurrentUser() != null) {
                        //is teacher
                        this.$scope.hasPermission = this.$scope.getCurrentUser().id == this.$scope.courseDetail.course.createdUserId;

                        //is approved member
                        this.$scope.canSeeQuizeResult = _.filter(this.$scope.courseDetail.students, (item: IStudentDetail, index: number) => {
                            return item.id.toString() == this.$scope.getCurrentUser().id && item.activated;
                        }).length > 0;

                        //is member
                        if (this.$scope.hasPermission) {
                            this.$scope.canTakeCourse = false;
                        } else {
                            this.$scope.canTakeCourse = _.filter(this.$scope.courseDetail.students, (item: IStudentDetail, index: number) => {
                                return item.id.toString() == this.$scope.getCurrentUser().id && this.$scope.getCurrentUser().selectedRoleName == "Student";
                            }).length == 0;
                        }
                    }
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
                                imageUrl: value.imageUrl,
                                activated: value.activated
                            });
                        } else {
                            this.$scope.splitStudents2.push({
                                id: value.id,
                                number: key + 1,
                                studentId: value.studentId,
                                name: value.name,
                                description: value.description,
                                imageUrl: value.imageUrl,
                                activated: value.activated
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
                                <button title='Remove' type='button' class='mfp-close2' ng-show='hasPermission' ng-click='removePhoto(" + value.id + ")'>×</button>\
                                <a href='../../../../"+ value.imageUrl + "' title= '" + value.name + "' by='" + value.uploadBy + "'>\
                                    <img class='img-responsive' alt= '' src= '../../../../"+ value.imageUrl + "'></a>\
                            </div>\
                        <div class='resources-description' ><p>"+ value.displayPublishedDate + "</p>\
                        <h4>"+ value.name + "</h4></div></div>\
                    </div>";
                    html += elements;
                });
                html = "<div class='row'>" + html + "</div>";
                //$('.popup-gallery').html(html);
                //this.$scope.html = $sce.trustAsHtml(html);
                this.$scope.html = html;
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
                        userId: function () {
                            return $scope.currentUser.id;
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
            this.$scope.showResultModal = (id: number) => {
                var options: ng.ui.bootstrap.IModalSettings = {
                    templateUrl: '/Scripts/app/course/view/quizeResult.tmpl.html',
                    controller: QuizeResultController,
                    resolve: {
                        studentScores: function () {
                            return $scope.getStudentScore(id);
                        }
                    },
                    size: "lg"
                };
                this.$uibModal.open(options).result.then(() => {
                    this.$scope.getCourse(this.$scope.id);
                });
            };
            this.$scope.getStudentScore = (id: number): StudentScore => {
                return _.filter(this.$scope.courseDetail.curriculums, (item, index) => {
                    return item.id == id;
                })[0].studentScores;
            };
            this.$scope.takeCourse = () => {
                this.courseService.takeCourse(this.$scope.id.toString(), this.$scope.getCurrentUser().id).then((reponse) => {
                    this.$scope.getCourse(this.$scope.id);
                    this.toastr.success("Success");
                }, (error) => { });
            };
            this.$scope.removeCourse = (id: string) => {
                this.courseService.removeCourse(this.$scope.id.toString(), id).then((reponse) => {
                    this.$scope.getCourse(this.$scope.id);
                    this.toastr.success("Success");
                }, (error) => { });
            };
            this.$scope.approve = (id: string) => {
                this.courseService.approveTakeCourse(this.$scope.id.toString(), id).then((reponse) => {
                    this.$scope.getCourse(this.$scope.id);
                    this.toastr.success("Success");
                }, (error) => { });
            };
            this.$scope.addNewPhoto = (id: string): void => {
                var options: ng.ui.bootstrap.IModalSettings = {
                    templateUrl: '/Scripts/app/course/view/photo.tmpl.html',
                    controller: PhotoModalController,
                    resolve: {
                        id: function () {
                            return id;
                        },
                        courseId: function () {
                            return $scope.id;
                        },
                        userId: function () {
                            return $scope.currentUser.id;
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
            this.$scope.removePhoto = (id: number): void => {
                this.courseService.removePhoto(id).then((response) => {
                    this.$scope.getCourse(this.$scope.id);
                    this.toastr.success("Success");
                }, (error) => {
                    this.toastr.error("Error");
                });
            };
            this.init();
        }
        init(): void {
            this.$scope.splitStudents1 = [];
            this.$scope.splitStudents2 = [];
            this.$scope.hasPermission = false;
            this.$scope.getCourse(this.$scope.id);
        };

    }
}