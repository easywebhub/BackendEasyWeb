var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
define(["require", "exports", 'aurelia-framework', 'select2'], function (require, exports, aurelia_framework_1) {
    "use strict";
    var Select2CustomAttribute = (function () {
        function Select2CustomAttribute(element) {
            this.element = element;
        }
        Select2CustomAttribute.prototype.attached = function () {
            var _this = this;
            $(this.element).select2(this.value)
                .on('change', function () { return _this.element.dispatchEvent(new Event('change')); });
        };
        Select2CustomAttribute.prototype.detached = function () {
            $(this.element).select2('destroy');
        };
        Select2CustomAttribute = __decorate([
            aurelia_framework_1.inject(Element),
            aurelia_framework_1.customAttribute('select2'), 
            __metadata('design:paramtypes', [Object])
        ], Select2CustomAttribute);
        return Select2CustomAttribute;
    }());
    exports.Select2CustomAttribute = Select2CustomAttribute;
});

//# sourceMappingURL=select2.js.map
