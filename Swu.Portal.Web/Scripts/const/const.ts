/// <reference path="../_references.ts" />
module Swu {

    @Module("app")
    @Constant({ name: "AppConstant" })
    export class AppConstant {
        constructor() {

        }
        defaultLang = "th";
        api = {
            protocal: "http",
            ip: "localhost",
            port: "8081",
            versionName: "V1",
        };
        exceptGotoTopStateList = [
            "settings",
            "settings.courses"
        ];
    }
}