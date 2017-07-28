/// <reference path="../../typings/angularjs/angular.d.ts" />
module ngAnnotations {

    'use strict';

    export module route {
        export interface IRoute {
            path: string;
            route: ng.route.IRoute;
        }
    }

    /* tslint:disable:interface-name */
    export interface AngularProviderClass {
        [index: string]: any;
    }
    /* tslint:disable:interface-name */
    export interface Function {
        $$annotationConfig?: IAngularAnnotationClassConfig;
        $inject?: string[];
        $get?: any;
        new (...args: any[]): AngularProviderClass;
    }

    export interface IAngularConstructorFunction {
        (module: string, constrFn: Function): void;
    }

    export interface IConstruct {
        (constrFn: any): void;
    }

    export interface IAngularAnnotationClassConfig {
        name: string;
        providerFn?: IAngularConstructorFunction;
    }

    export interface IProviderClassConfig extends IAngularAnnotationClassConfig {
        service: any;
    }

    export interface IControllerClassConfig extends IAngularAnnotationClassConfig {
        when?: route.IRoute;
    }

    export function Module(name: string) {
        return provideAngularComponent;

        function provideAngularComponent(constrFn: any) {
            constrFn.$$annotationConfig.providerFn(name, constrFn);
        }
    }

    export function Config(constrFn: any): void {
        constrFn.$$annotationConfig = { providerFn: _provideConfig };
    }

    export function Constant(config: IAngularAnnotationClassConfig): IConstruct {
        config.providerFn = _provideConstant;
        return _decorateProviderClass(config);
    }

    export function Controller(config: IControllerClassConfig): IConstruct {
        config.providerFn = _provideController;
        return _decorateProviderClass(config);
    }

    export function Directive(config: IAngularAnnotationClassConfig): IConstruct {
        config.providerFn = _provideDirective;
        return _decorateProviderClass(config);
    }

    export function Factory(config: IAngularAnnotationClassConfig): IConstruct {
        config.providerFn = _provideFactory;
        return _decorateProviderClass(config);
    }

    export function Provider(config: IProviderClassConfig): IConstruct {
        config.providerFn = _provideProvider;
        return _decorateProviderClass(config);
    }

    export function Run(constrFn: any): void {
        constrFn.$$annotationConfig = { providerFn: _provideRun };
    }

    export function Service(config: IAngularAnnotationClassConfig): IConstruct {
        config.providerFn = _provideService;
        return _decorateProviderClass(config);
    }

    export function Value(config: IAngularAnnotationClassConfig): IConstruct {
        config.providerFn = _provideValue;
        return _decorateProviderClass(config);

    }

    export function Decorator(config: IAngularAnnotationClassConfig): IConstruct {
        config.providerFn = _provideDecorator;
        return _decorateProviderClass(config);
    }

    export function Filter(config: IAngularAnnotationClassConfig): IConstruct {
        config.providerFn = _provideFilter;
        return _decorateProviderClass(config);
    }

    ////////////////////////////////// private method /////////////////////////////////////////

    function _decorateProviderClass(config: IAngularAnnotationClassConfig) {
        return (constrFn: any) => {
            constrFn.$$annotationConfig = config;
        };
    }

    function _provideConfig(module: string, constrFn: Function) {
        angular.module(module).config(_normalizeFunction(constrFn));
    }

    function _provideConstant(module: string, constrFn: Function) {
        let constant = angular.isFunction(constrFn) ? new constrFn() : constrFn;
        let name = constrFn.$$annotationConfig.name;

        angular.module(module).constant(name, constant);
    }

    function _provideController(module: string, constrFn: Function) {
        let config = <IControllerClassConfig>constrFn.$$annotationConfig;
        let name = config.name;
        angular.module(module).controller(name, _normalizeFunction(constrFn));

        // route config
        if (config.when) {
            let routeConfig = ['$routeProvider', ($routeProvider: ng.route.IRouteProvider) => {
                $routeProvider.when(config.when.path, config.when.route);
            }];
            angular.module(module).config(routeConfig);
        }
    }

    function _provideDirective(module: string, constrFn: Function) {

        /* tslint:disable:no-empty  */
        if (!constrFn.prototype.compile) {
            // create an empty compile function if none was defined.
            constrFn.prototype.compile = () => {
            };
        }

        let originalCompileFn = _cloneFunction(constrFn.prototype.compile);

        // Decorate the compile method to automatically return the link method (if it exists)
        // and bind it to the context of the constrFnuctor (so `this` works correctly).
        // This gets around the problem of a non-lexical "this" which occurs when the directive class itself
        // returns `this.link` from within the compile function.
        _override(constrFn.prototype, 'compile', function () {
            return function () {
                originalCompileFn.apply(this, arguments);

                if (constrFn.prototype.link) {
                    return constrFn.prototype.link.bind(this);
                }
            };
        });

        let inlineArrayAnnotation = _createInlineArrayAnnotation(_normalizeFunction(constrFn));
        let name = constrFn.$$annotationConfig.name;
        angular.module(module).directive(_toCamelCase(name), inlineArrayAnnotation);

    }

    function _provideFactory(module: string, constrFn: Function) {
        let inlineArrayAnnotation = _createInlineArrayAnnotation(_normalizeFunction(constrFn));
        let name = constrFn.$$annotationConfig.name;
        angular.module(module).factory(name, inlineArrayAnnotation);
    }

    function _provideProvider(module: string, constrFn: Function) {
        let config = <IProviderClassConfig>constrFn.$$annotationConfig;
        let name = config.name;
        let providerName = name.replace(/[pP]+rovider/i, '');
        angular.module(module).provider(providerName, _createServiceProvider(constrFn));
    }

    function _provideService(module: string, constrFn: Function) {
        let name = constrFn.$$annotationConfig.name;
        angular.module(module).service(name, _normalizeFunction(constrFn));
    }

    function _provideRun(module: string, constrFn: Function) {
        angular.module(module).run(_normalizeFunction(constrFn));
    }

    function _provideValue(module: string, constrFn: Function) {
        let val = angular.isFunction(constrFn) ? new constrFn() : constrFn;
        let name = constrFn.$$annotationConfig.name;
        angular.module(module).value(name, val);
    }

    function _provideDecorator(module: string, constrFn: Function) {
        angular.module(module).config(['$provide', ($provide: ng.auto.IProvideService) => {
            let name = constrFn.$$annotationConfig.name;
            $provide.decorator(name, constrFn);
        }]);
    }

    function _provideFilter(module: string, constrFn: Function) {
        let name = constrFn.$$annotationConfig.name;
        angular.module(module).filter(name, constrFn);
    }

    /**
     * Convert a constrFnuctor function into a factory function which returns a new instance of that
     * constrFnuctor, with the correct dependencies automatically injected as arguments.
     *
     * In order to inject the dependencies, they must be attached to the constrFnuctor function with the
     * `$inject` property annotation.
     *
     * @param constrFn
     * @returns {inlineArrayAnnotation: any[]}
     * @private
     */
    function _createInlineArrayAnnotation(constrFn: Function, provider?: Function): any[] {
        // get the array of dependencies that are needed by this component (as contained in the `$inject` array)
        let injects = constrFn.$inject || [];
        let inlineArrayAnnotation = <any[]>injects.slice(); // create a copy of the array
        // The factoryArray uses Angular's array notation whereby each element of the array is the name of a
        // dependency, and the final item is the factory function itself.
        inlineArrayAnnotation.push(function (...args: any[]) {
            //return new FunctionConstr();
            args.unshift(this);
            let instance = new (Function.prototype.bind.apply(constrFn, args));
            return instance;
        });
        return inlineArrayAnnotation;
    }

    /**
     * Clone a function
     * @param original
     * @returns {Function}
     */
    function _cloneFunction(original: any) {
        return function () {
            return original.apply(this, arguments);
        };
    }

    /**
     * Override an object's method with a new one specified by `callback`.
     * @param object
     * @param methodName
     * @param callback
     */
    function _override(object: any, methodName: any, callback: any) {
        object[methodName] = callback(object[methodName]);
    }

    /**
     * Override an object's method with a new one specified by `callback`.
     * @param function
     * @param methodName
     * @param callback
     */
    function _normalizeFunction(constrFn: any): Function {
        if (constrFn.$inject) {
            return constrFn;
        } else {
            let paramNames = _getParamNames(constrFn);
            constrFn.$inject = paramNames;
            return constrFn;
        }
    }

    function _getParamNames(constrFn: Function): string[] {
        let STRIP_COMMENTS = /((\/\/.*$)|(\/\*[\s\S]*?\*\/))/mg;
        let ARGUMENT_NAMES = /([^\s,]+)/g;
        let fnStr = constrFn.toString().replace(STRIP_COMMENTS, '');
        let result = fnStr.slice(fnStr.indexOf('(') + 1, fnStr.indexOf(')')).match(ARGUMENT_NAMES);
        if (result === null)
            result = [];
        return result;
    }

    function _toCamelCase(str: string): string {
        return str
            .replace(/\s(.)/g, function ($1: string) {
                return $1.toUpperCase();
            })
            .replace(/\s/g, '')
            .replace(/^(.)/, function ($1: string) {
                return $1.toLowerCase();
            });
    }

    //function _getContructorFunctionName(constrFn:Function):string {
    //    return constrFn.toString().match(/^function\s*([^\s(]+)/)[1];
    //}

    function _createServiceProvider(constrFn: any): any[] {
        /* tslint:disable:no-empty  */
        let config = <IProviderClassConfig>constrFn.$$annotationConfig;

        let injects = config.service.$inject || [];
        let inlineArrayAnnotation = <any[]>injects.slice(1); // create a copy of the array
        // The factoryArray uses Angular's array notation whereby each element of the array is the name of a
        // dependency, and the final item is the factory function itself.
        inlineArrayAnnotation.push(function (...args: any[]) {
            //return new FunctionConstr();
            args.unshift(null, this);
            let instance = new (Function.prototype.bind.apply(config.service, args));
            return instance;
        });

        constrFn.prototype.$get = inlineArrayAnnotation;
        return _createInlineArrayAnnotation(constrFn);
    }
}