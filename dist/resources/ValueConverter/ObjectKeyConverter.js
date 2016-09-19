define(["require", "exports"], function (require, exports) {
    "use strict";
    var ObjectKeysValueConverter = (function () {
        function ObjectKeysValueConverter() {
        }
        ObjectKeysValueConverter.prototype.toView = function (obj) {
            var temp = [];
            for (var prop in obj) {
                if (obj.hasOwnProperty(prop)) {
                    temp.push(obj[prop]);
                }
            }
            return temp;
        };
        return ObjectKeysValueConverter;
    }());
    exports.ObjectKeysValueConverter = ObjectKeysValueConverter;
    var ObjectValuesValueConverter = (function () {
        function ObjectValuesValueConverter() {
        }
        ObjectValuesValueConverter.prototype.toView = function (obj) {
            var temp = [];
            for (var _i = 0, obj_1 = obj; _i < obj_1.length; _i++) {
                var val = obj_1[_i];
                temp.push(val);
            }
            return temp;
        };
        return ObjectValuesValueConverter;
    }());
    exports.ObjectValuesValueConverter = ObjectValuesValueConverter;
});

//# sourceMappingURL=ObjectKeyConverter.js.map
