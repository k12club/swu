/// <reference path="../../_references.ts" />

module Swu {
    @Module("app")
    @Factory({ name: "apiService" })
    export class apiService {
        static $inject = ['$q', '$http', 'AppConstant'];
        constructor(
            public $q: ng.IQService,
            public $http: ng.IHttpService,
            private constant: AppConstant) {
        }
        public getData<T>(url?: string): ng.IPromise<T> {

            var def = this.$q.defer();
            var url = this.constant.api.versionName + "/" + url;
            //this.$http.get(url)
            //    .then((successResponse) => {
            //        if (successResponse)
            //            def.resolve(successResponse.data);
            //        else
            //            def.reject('server error');

            //    }, (errorRes) => {

            //        def.reject(errorRes.statusText);
            //    });
            this.$http({
                url: url,
                method: 'GET',
                withCredentials: true,
                headers: {
                    'Cache-Control':'no-cache'
                }
            }).then((successResponse) => {
                def.resolve(successResponse.data);
            }, (errorRes) => {
                def.reject(errorRes);
            });
            return def.promise;
        }
        public postData<T>(data: any, url?: string, contentType?: string): ng.IPromise<T> {
            var url = this.constant.api.versionName + "/" + url;
            var def = this.$q.defer();
            this.$http({
                url: url,
                method: 'POST',
                data: data,
                withCredentials: true,
                headers: {
                    'Content-Type': contentType || 'application/json'
                }
            }).then((successResponse) => {
                def.resolve(successResponse.data);
            }, (errorRes) => {
                def.reject(errorRes);
            });
            return def.promise;
        }
        public postWithFormData<T>(models: NamePairValue[], url?: string, contentType?: string): ng.IPromise<T> {
            var url = this.constant.api.versionName + "/" + url;
            var def = this.$q.defer();
            this.$http({
                url: url,
                method: 'POST',
                transformRequest: function (data) {
                    var formData = new FormData();
                    angular.forEach(models, (value, key) => {
                        if (models[key].name == "file") {
                            formData.append(models[key].name, models[key].value);
                        } else {
                            formData.append(models[key].name, angular.toJson(models[key].value));
                        }
                    });
                    return formData;
                },
                headers: { 'Content-Type': undefined },
                data: models
            }).then((successResponse) => {
                def.resolve(successResponse.data);
            }, (errorRes) => {
                def.reject(errorRes);
            });
            return def.promise;
        }
    }
}