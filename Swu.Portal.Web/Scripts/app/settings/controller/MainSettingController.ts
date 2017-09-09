module Swu {
    export interface SettingMenu {
        name: string;
        stateName: string;
        icon: string;
    }
    interface MainSettingScope extends ng.IScope {
        currentUser: IUserProfile;
        file: any;
        menus: SettingMenu[];
        displayMenus: SettingMenu[];

        edit(): void;
        getCurrentUser(): void;
        save(): void;
    }
    @Module("app")
    @Controller({ name: "MainSettingController" })
    export class MainSettingController {
        static $inject: Array<string> = ["$scope","AuthServices", "AppConstant"];
        constructor(private $scope: MainSettingScope, private auth: IAuthServices, private AppConstant: AppConstant) {
            this.$scope.menus = [];
            this.$scope.displayMenus = [];
            this.$scope.menus.push({ stateName: "settings", name: "Personal Info", icon:"glyphicon glyphicon-user" });
            this.$scope.menus.push({ stateName: "settings.users", name: "User Management", icon: "flaticon-arrows-3" });
            this.$scope.menus.push({ stateName: "settings.courses", name: "Courses", icon: "flaticon-arrows-3"});
            this.$scope.displayMenus = _.filter(this.$scope.menus, (menu: SettingMenu, index: number) => {
                var currentUserRole = this.auth.getCurrentUser().selectedRoleName;
                var permission = _.filter(this.AppConstant.authorizeStateList, (item: any, index: number) => {
                    return item.name == menu.stateName
                })[0];
                if (_.contains(permission.roles, currentUserRole)) {
                    return true;
                } else {
                    return false;
                }
            });
        }
    }
}