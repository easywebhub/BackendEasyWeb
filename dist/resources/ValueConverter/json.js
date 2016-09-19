define(["require", "exports"], function (require, exports) {
    "use strict";
    var jsonValueConverter = (function () {
        function jsonValueConverter() {
        }
        jsonValueConverter.prototype.toView = function (value) {
            return JSON.stringify(value, null, 4);
        };
        return jsonValueConverter;
    }());
    exports.jsonValueConverter = jsonValueConverter;
});

//# sourceMappingURL=json.js.map
