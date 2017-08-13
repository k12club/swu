module Swu {
    export interface baseControllerScope extends ng.IScope {
        swapLanguage(lang: string): void;
    }
}