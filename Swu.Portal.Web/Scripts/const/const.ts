/// <reference path="../_references.ts" />
module Swu {

    @Module("app")
    @Constant({ name: "AppConstant" })
    export class AppConstant {
        constructor() {

        }
        timeoutExpired = 30;
        defaultLang = "en";
        api = {
            protocal: "http",
            ip: "localhost",
            port: "8081",
            versionName: "V1",
        };
        exceptGotoTopStateList = [
            "board.forum",
            "board.course",
            "board.research",
            "settings",
            "settings.courses",
            "settings.users"
        ];
        authorizeStateList = [
            {
                name: "settings",
                roles:["Admin","Teacher","Student","Parent","Officer"]
            },
            {
                name: "settings.courses",
                roles: ["Admin","Teacher"]
            },
            {
                name: "settings.users",
                roles: ["Admin","Officer"]
            }
        ];
    }
}