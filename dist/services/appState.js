var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
define(["require", "exports", 'aurelia-framework', 'lockr'], function (require, exports, aurelia_framework_1, Lockr) {
    "use strict";
    var AppState = (function () {
        function AppState() {
            this.isAuthenticated = false;
            this.UserInfo = {};
            if (Lockr.get('UserInfo')) {
                this.UserInfo = Lockr.get('UserInfo');
            }
            else {
            }
        }
        AppState.prototype.setMyInFo = function () {
            Lockr.set('tung', { value: 'we are the rule' });
        };
        AppState.prototype.CheckNav = function (roles) {
            if (Lockr.get('UserInfo')) {
                if (roles) {
                    for (var i in roles) {
                        var rls = Lockr.get('UserInfo').Roles;
                        for (var j in rls) {
                            if (rls[j].Code.toLowerCase() == roles[i].toLowerCase()) {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        };
        AppState = __decorate([
            aurelia_framework_1.transient(), 
            __metadata('design:paramtypes', [])
        ], AppState);
        return AppState;
    }());
    exports.AppState = AppState;
});

//# sourceMappingURL=appState.js.map
