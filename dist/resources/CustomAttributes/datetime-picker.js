var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
define(["require", "exports", 'aurelia-framework', 'moment', 'datetimepicker'], function (require, exports, aurelia_framework_1, moment) {
    "use strict";
    var DateTimePicker = (function () {
        function DateTimePicker(element) {
            this.element = element;
            this.element = element;
        }
        DateTimePicker.prototype.attached = function () {
            console.log('this :', this);
            $(this.element).datetimepicker({})
                .on('dp.change', function (e) { fireEvent(e.target, 'input'), console.log('event: ', e); });
            var dateControl = new Date(this.vl);
            dateControl.setHours((dateControl.getHours() - 7));
            $(this.element).val(moment(dateControl).format('MM/DD/YYYY HH:MM:ss'));
        };
        DateTimePicker.prototype.detached = function () {
            $(this.element).datetimepicker('destroy')
                .off('dp.change');
        };
        __decorate([
            aurelia_framework_1.bindable, 
            __metadata('design:type', Object)
        ], DateTimePicker.prototype, "vl", void 0);
        DateTimePicker = __decorate([
            aurelia_framework_1.inject(Element),
            aurelia_framework_1.customAttribute('datetime-picker'), 
            __metadata('design:paramtypes', [Element])
        ], DateTimePicker);
        return DateTimePicker;
    }());
    exports.DateTimePicker = DateTimePicker;
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

//# sourceMappingURL=datetime-picker.js.map
