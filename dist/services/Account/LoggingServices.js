var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
define(["require", "exports", 'aurelia-framework', 'aurelia-fetch-client', '../..//services/HttpService'], function (require, exports, aurelia_framework_1, aurelia_fetch_client_1, HttpService_1) {
    "use strict";
    var LoggingServices = (function () {
        function LoggingServices(httpService) {
            this.http = httpService.httpInstance;
        }
        LoggingServices.prototype.GetListLogging = function (meta) {
            var _this = this;
            return new Promise(function (resolve, reject) {
                _this.http.fetch("api/logging/GetAllLogging", { method: 'post', body: aurelia_fetch_client_1.json(meta) }).then(function (response) { return response.json(); }).then(function (data) { resolve(data); }).catch(function (err) { return reject(Error(err)); });
            });
        };
        LoggingServices = __decorate([
            aurelia_framework_1.inject(HttpService_1.HttpService),
            aurelia_framework_1.transient(), 
            __metadata('design:paramtypes', [HttpService_1.HttpService])
        ], LoggingServices);
        return LoggingServices;
    }());
    exports.LoggingServices = LoggingServices;
});

//# sourceMappingURL=LoggingServices.js.map
