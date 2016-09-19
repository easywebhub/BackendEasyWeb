define(["require", "exports", 'aurelia-validation'], function (require, exports, aurelia_validation_1) {
    "use strict";
    var Login = (function () {
        function Login() {
        }
        return Login;
    }());
    exports.Login = Login;
    aurelia_validation_1.ValidationRules
        .ensure(function (x) { return x.UserName; }).required().maxLength(20).minLength(4)
        .ensure(function (x) { return x.Password; }).required().maxLength(20).minLength(4)
        .on(Login);
});

//# sourceMappingURL=login.js.map
