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
    var UserServices = (function () {
        function UserServices(httpService) {
            this.http = httpService.httpInstance;
        }
        UserServices.prototype.GetByMeta = function (meta) {
            var _this = this;
            return new Promise(function (resolve, reject) {
                _this.http.fetch("user-api/GetUsers", {
                    method: 'post',
                    body: aurelia_fetch_client_1.json(meta),
                })
                    .then(function (response) { return response.json(); })
                    .then(function (data) {
                    resolve(data);
                })
                    .catch(function (err) { return reject(Error(err)); });
            });
        };
        UserServices.prototype.GetUserRoles = function () {
            var _this = this;
            return new Promise(function (resolve, reject) {
                _this.http.fetch("user-api/GetUserRoles", { method: 'get' }).then(function (response) { return response.json(); }).then(function (data) { resolve(data); }).catch(function (err) { return reject(Error(err)); });
            });
        };
        UserServices.prototype.UpdateByUser = function (meta) {
            var _this = this;
            return new Promise(function (resolve, reject) {
                _this.http.fetch("user-api/UpdateUser", {
                    method: 'post',
                    body: aurelia_fetch_client_1.json(meta),
                })
                    .then(function (response) { return response.json(); })
                    .then(function (data) {
                    resolve(data);
                })
                    .catch(function (err) { return reject(Error(err)); });
            });
        };
        UserServices.prototype.GetUserHistory = function (meta) {
            var _this = this;
            return new Promise(function (resolve, reject) {
                _this.http.fetch("user-api/GetHistoryByUserId", {
                    method: 'post',
                    body: aurelia_fetch_client_1.json(meta),
                })
                    .then(function (response) { return response.json(); })
                    .then(function (data) {
                    resolve(data);
                })
                    .catch(function (err) { return reject(Error(err)); });
            });
        };
        UserServices.prototype.GetListStudent = function () {
            var _this = this;
            return new Promise(function (resolve, reject) {
                _this.http.fetch("api/student/GetAllStudent", { method: 'get' }).then(function (response) { return response.json(); }).then(function (data) { resolve(data); }).catch(function (err) { return reject(Error(err)); });
            });
        };
        UserServices.prototype.SentActiveMailRequest = function (id) {
            var _this = this;
            return new Promise(function (resolve, reject) {
                _this.http.fetch("user-api/SentActiveMailRequest?userId=" + id, { method: 'get' }).then(function (response) { return response.json(); }).then(function (data) { resolve(data); }).catch(function (err) { return reject(Error(err)); });
            });
        };
        UserServices = __decorate([
            aurelia_framework_1.inject(HttpService_1.HttpService),
            aurelia_framework_1.transient(), 
            __metadata('design:paramtypes', [HttpService_1.HttpService])
        ], UserServices);
        return UserServices;
    }());
    exports.UserServices = UserServices;
});

//# sourceMappingURL=UserServices.js.map
