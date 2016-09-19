var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
define(["require", "exports", 'aurelia-framework', '..//services/appState'], function (require, exports, aurelia_framework_1, appState_1) {
    "use strict";
    var AuthorizeStep = (function () {
        function AuthorizeStep(appState) {
            this.appState = appState;
        }
        AuthorizeStep.prototype.run = function (navigationInstruction, next) {
            return next();
        };
        AuthorizeStep = __decorate([
            aurelia_framework_1.inject(appState_1.AppState), 
            __metadata('design:paramtypes', [Object])
        ], AuthorizeStep);
        return AuthorizeStep;
    }());
    exports.AuthorizeStep = AuthorizeStep;
});

//# sourceMappingURL=authorizeStep.js.map
