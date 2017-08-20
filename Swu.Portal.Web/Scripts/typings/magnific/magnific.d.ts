//Magnific Popup Definition File
interface ImagnificPopupOptions {
    items?: any;
    type: string;
    closeOnBgClick?:boolean;
}

interface JQuery {
    magnificPopup(options?: ImagnificPopupOptions,callback?: () => void): JQuery;
}

interface JQueryStatic {
    magnificPopup: JQueryMagnificPopupStatic;
}

interface JQueryMagnificPopupStatic {
    open: any;
    (): JQuery;
    parameter(name: string): string;
    parameter(name: string, value: string, append?: boolean): JQuery;
}