var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
define(["require", "exports", '../../services/appState', 'aurelia-router', 'aurelia-dependency-injection', 'aurelia-validation', '../../models/login', '../../resources/validation-render/bootstrap-render'], function (require, exports, appState_1, aurelia_router_1, aurelia_dependency_injection_1, aurelia_validation_1, login_1, bootstrap_render_1) {
    "use strict";
    var LoginViewModel = (function () {
        function LoginViewModel(appState, router, controllerFact) {
            this.Login = new login_1.Login();
            this.controller = null;
            {
                this.appState = appState;
                this.theRouter = router;
                this.controller = controllerFact.createForCurrentScope();
                this.controller.addRenderer(new bootstrap_render_1.BootstrapFormRenderer());
            }
        }
        LoginViewModel.prototype.submit = function () {
            var _this = this;
            var errors = this.controller.validate()
                .then(function (errors) {
                if (errors.length == 0) {
                    _this.login();
                }
            });
        };
        LoginViewModel.prototype.reset = function () {
            this.controller.reset();
        };
        LoginViewModel.prototype.login = function () {
            swal('Đăng nhập', 'Đăng nhập thành công', 'success');
        };
        LoginViewModel = __decorate([
            aurelia_dependency_injection_1.inject(appState_1.AppState, aurelia_router_1.Router, aurelia_validation_1.ValidationControllerFactory), 
            __metadata('design:paramtypes', [appState_1.AppState, aurelia_router_1.Router, aurelia_validation_1.ValidationControllerFactory])
        ], LoginViewModel);
        return LoginViewModel;
    }());
    exports.LoginViewModel = LoginViewModel;
});

//# sourceMappingURL=login.js.map
