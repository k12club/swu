var ngAnnotations;
(function (ngAnnotations) {
    'use strict';
    function Module(name) {
        return function (constrFn) {
            constrFn.$_providerFn(name, constrFn);
        };
    }
    ngAnnotations.Module = Module;
    function Config(constrFn) {
        constrFn.$_providerFn = _provideConfig;
    }
    ngAnnotations.Config = Config;
    function Constant(constrFn) {
        constrFn.$_providerFn = _provideConstant;
    }
    ngAnnotations.Constant = Constant;
    function Controller(constrFn) {
        constrFn.$_providerFn = _provideController;
    }
    ngAnnotations.Controller = Controller;
    function Directive(constrFn) {
        constrFn.$_providerFn = _provideDirective;
    }
    ngAnnotations.Directive = Directive;
    function Factory(constrFn) {
        constrFn.$_providerFn = _provideFactory;
    }
    ngAnnotations.Factory = Factory;
    function Provider(constrFn) {
        constrFn.$_providerFn = _provideProvider;
    }
    ngAnnotations.Provider = Provider;
    function Run(constrFn) {
        constrFn.$_providerFn = _provideRun;
    }
    ngAnnotations.Run = Run;
    function Service(constrFn) {
        constrFn.$_providerFn = _provideService;
    }
    ngAnnotations.Service = Service;
    function Value(constrFn) {
        constrFn.$_providerFn = _provideValue;
    }
    ngAnnotations.Value = Value;
    function _provideConfig(module, constrFn) {
        angular.module(module).config(_normalizeFunction(constrFn));
    }
    function _provideConstant(module, constrFn) {
        var constant = new constrFn();
        var name = _getContructorFunctionName(constrFn);
        angular.module(module).constant(name, constant);
    }
    function _provideController(module, constrFn) {
        var name = _getContructorFunctionName(constrFn);
        angular.module(module).controller(name, _normalizeFunction(constrFn));
    }
    function _provideDirective(module, constrFn) {
        if (!constrFn.prototype.compile) {
            constrFn.prototype.compile = function () {
            };
        }
        var originalCompileFn = _cloneFunction(constrFn.prototype.compile);
        _override(constrFn.prototype, 'compile', function () {
            return function () {
                originalCompileFn.apply(this, arguments);
                if (constrFn.prototype.link) {
                    return constrFn.prototype.link.bind(this);
                }
            };
        });
        var inlineArrayAnnotation = _createInlineArrayAnnotation(_normalizeFunction(constrFn));
        var name = _toCamelCase(_getContructorFunctionName(constrFn));
        angular.module(module).directive(name, inlineArrayAnnotation);
    }
    function _provideFactory(module, constrFn) {
        var inlineArrayAnnotation = _createInlineArrayAnnotation(_normalizeFunction(constrFn));
        var name = _getContructorFunctionName(constrFn);
        angular.module(module).factory(name, inlineArrayAnnotation);
    }
    function _provideProvider(module, constrFn) {
        var name = _getContructorFunctionName(constrFn);
        var providerName = name.replace('Provider', '');
        angular.module(module).provider(providerName, _creaetServiceProvider(constrFn));
    }
    function _provideService(module, constrFn) {
        var name = _getContructorFunctionName(constrFn);
        angular.module(module).service(name, _normalizeFunction(constrFn));
    }
    function _provideRun(module, constrFn) {
        angular.module(module).run(_normalizeFunction(constrFn));
    }
    function _provideValue(module, constrFn) {
        var val = new constrFn();
        var name = _getContructorFunctionName(constrFn);
        angular.module(module).value(name, val);
    }
    function _createInlineArrayAnnotation(constrFn) {
        var injects = constrFn.$inject || [];
        var inlineArrayAnnotation = injects.slice();
        inlineArrayAnnotation.push(function () {
            var args = [];
            for (var _i = 0; _i < arguments.length; _i++) {
                args[_i - 0] = arguments[_i];
            }
            args.unshift(this);
            var instance = new (Function.prototype.bind.apply(constrFn, args));
            return instance;
        });
        return inlineArrayAnnotation;
    }
    function _cloneFunction(original) {
        return function () {
            return original.apply(this, arguments);
        };
    }
    function _override(object, methodName, callback) {
        object[methodName] = callback(object[methodName]);
    }
    function _normalizeFunction(constrFn) {
        if (constrFn.$inject) {
            return constrFn;
        }
        else {
            var paramNames = _getParamNames(constrFn);
            constrFn.$inject = paramNames;
            return constrFn;
        }
    }
    function _getParamNames(constrFn) {
        var STRIP_COMMENTS = /((\/\/.*$)|(\/\*[\s\S]*?\*\/))/mg;
        var ARGUMENT_NAMES = /([^\s,]+)/g;
        var fnStr = constrFn.toString().replace(STRIP_COMMENTS, '');
        var result = fnStr.slice(fnStr.indexOf('(') + 1, fnStr.indexOf(')')).match(ARGUMENT_NAMES);
        if (result === null)
            result = [];
        return result;
    }
    function _toCamelCase(str) {
        return str
            .replace(/\s(.)/g, function ($1) {
                return $1.toUpperCase();
            })
            .replace(/\s/g, '')
            .replace(/^(.)/, function ($1) {
                return $1.toLowerCase();
            });
    }
    function _getContructorFunctionName(constrFn) {
        return constrFn.toString().match(/^function\s*([^\s(]+)/)[1];
    }
    function _creaetServiceProvider(constrFn) {
        if (!constrFn.prototype.$get) {
            constrFn.prototype.$get = function () {
            };
        }
        constrFn.prototype.$get = _normalizeFunction(constrFn.prototype.$get);
        return constrFn;
    }
})(ngAnnotations || (ngAnnotations = {}));