var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
define(["require", "exports", 'aurelia-dependency-injection', 'aurelia-validation', './resources/validation-render/bootstrap-render'], function (require, exports, aurelia_dependency_injection_1, aurelia_validation_1, bootstrap_render_1) {
    "use strict";
    var RegistrationForm = (function () {
        function RegistrationForm(controller) {
            this.controller = null;
            this.controller = controller.createForCurrentScope();
            this.controller.addRenderer(new bootstrap_render_1.BootstrapFormRenderer());
        }
        RegistrationForm.prototype.activate = function () {
        };
        RegistrationForm.prototype.submit = function () {
            var errors = this.controller.validate();
        };
        RegistrationForm.prototype.reset = function () {
            this.firstName = '';
            this.lastName = '';
            this.email = '';
            this.controller.reset();
        };
        RegistrationForm = __decorate([
            aurelia_dependency_injection_1.inject(aurelia_validation_1.ValidationControllerFactory), 
            __metadata('design:paramtypes', [aurelia_validation_1.ValidationControllerFactory])
        ], RegistrationForm);
        return RegistrationForm;
    }());
    exports.RegistrationForm = RegistrationForm;
    aurelia_validation_1.ValidationRules
        .ensure('firstName').required().withMessage('yêu cầu nhập first name')
        .ensure('lastName').required()
        .ensure('email').required().email()
        .on(RegistrationForm);
});

//# sourceMappingURL=welcome.js.map
