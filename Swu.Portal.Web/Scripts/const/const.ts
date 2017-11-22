﻿/// <reference path="../_references.ts" />
module Swu {

    @Module("app")
    @Constant({ name: "AppConstant" })
    export class AppConstant {
        constructor() {

        }
        timeoutExpired = 30;
        defaultLang = "en";
        web = {
            protocal: "http",
            ip: "localhost",
            port: "2255",
        };
        api = {
            protocal: "http",
            ip: "localhost",
            port: "2255",
            versionName: "V1",
        };
        exceptGotoTopStateList = [
            "board.forum",
            "board.course",
            "board.research",
            "settings",
            "settings.courses",
            "settings.users",
            "settings.events",
            "settings.videos",
            "settings.news",
            "settings.categories"
        ];
        authorizeStateList = [
            {
                name: "settings",
                roles:["Admin","Teacher","Student","Parent","Officer"]
            },
            {
                name: "settings.courses",
                roles: ["Admin", "Teacher","Officer"]
            },
            {
                name: "settings.users",
                roles: ["Admin","Officer"]
            },
            {
                name: "settings.events",
                roles: ["Admin", "Officer"]
            },
            {
                name: "settings.videos",
                roles: ["Admin", "Officer"]
            },
            {
                name: "settings.news",
                roles: ["Admin", "Officer"]
            },
            {
                name: "settings.categories",
                roles: ["Admin", "Officer"]
            }
            
        ];
    }
}