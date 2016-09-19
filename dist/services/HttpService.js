var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
define(["require", "exports", 'aurelia-framework', 'aurelia-fetch-client'], function (require, exports, aurelia_framework_1, aurelia_fetch_client_1) {
    "use strict";
    var HttpService = (function () {
        function HttpService(http) {
            this.logger = aurelia_framework_1.LogManager.getLogger('HttpService');
            http.configure(function (config) {
                config
                    .useStandardConfiguration()
                    .withDefaults({
                    headers: {
                        'SessionToken': (Lockr.get('UserInfo') == null || typeof Lockr.get('UserInfo') === "undefined") ? "" : Lockr.get('UserInfo').SessionToken
                    }
                });
            });
            this.httpInstance = http;
        }
        HttpService = __decorate([
            aurelia_framework_1.inject(aurelia_fetch_client_1.HttpClient),
            aurelia_framework_1.transient(), 
            __metadata('design:paramtypes', [Object])
        ], HttpService);
        return HttpService;
    }());
    exports.HttpService = HttpService;
});

//# sourceMappingURL=HttpService.js.map
