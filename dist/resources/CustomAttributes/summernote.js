var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
define(["require", "exports", 'aurelia-framework', 'summernote'], function (require, exports, aurelia_framework_1) {
    "use strict";
    var SummerNote = (function () {
        function SummerNote(element) {
            this.element = element;
            this.element = element;
            console.log("element: ", element);
        }
        SummerNote.prototype.attached = function () {
            var _this = this;
            console.log('this.value as any: ', this.value);
            $(this.element).val(this.vl);
            $(this.element).summernote({
                callbacks: {
                    onChange: function (contents, $editable) {
                        console.log('onChange:', contents, $editable);
                        $(_this.element).val(contents);
                        console.log(" from callback: ", $(_this.element).val());
                        _this.element.dispatchEvent(new Event("change"));
                    }
                }
            });
        };
        SummerNote.prototype.detached = function () {
            $(this.element).summernote('destroy');
        };
        __decorate([
            aurelia_framework_1.bindable, 
            __metadata('design:type', Object)
        ], SummerNote.prototype, "vl", void 0);
        SummerNote = __decorate([
            aurelia_framework_1.inject(Element),
            aurelia_framework_1.customAttribute('summernote'), 
            __metadata('design:paramtypes', [Object])
        ], SummerNote);
        return SummerNote;
    }());
    exports.SummerNote = SummerNote;
    function createEvent(name) {
        var event = document.createEvent('Event');
        event.initEvent(name, true, true);
        return event;
    }
    function fireEvent(element, name) {
        var event = createEvent(name);
        element.dispatchEvent(event);
    }
});

//# sourceMappingURL=summernote.js.map
