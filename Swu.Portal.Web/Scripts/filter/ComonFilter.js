var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var FloorPlan;
(function (FloorPlan) {
    var nospace = (function () {
        function nospace() {
            this.return = function (value) {
                return (!value) ? '' : value.replace(/ /g, '');
            };
        }
        nospace = __decorate([
            Filter({ name: "nospace" })
        ], nospace);
        return nospace;
    }());
    var humanizeDoc = (function () {
        function humanizeDoc() {
            this.return = function (doc) {
                return function (doc) {
                    if (!doc)
                        return;
                    if (doc.type === 'directive') {
                        return doc.name.replace(/([A-Z])/g, function ($1) {
                            return '-' + $1.toLowerCase();
                        });
                    }
                    return doc.label || doc.name;
                };
            };
        }
        humanizeDoc = __decorate([
            Filter({ name: "humanizeDoc" })
        ], humanizeDoc);
        return humanizeDoc;
    }());
})(FloorPlan || (FloorPlan = {}));
