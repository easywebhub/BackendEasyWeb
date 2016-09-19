define(["require", "exports"], function (require, exports) {
    "use strict";
    var TakeFromToValueConverter = (function () {
        function TakeFromToValueConverter() {
        }
        TakeFromToValueConverter.prototype.toView = function (array, from, to) {
            if (array) {
                array = array.slice(from, to);
            }
            return array;
        };
        return TakeFromToValueConverter;
    }());
    exports.TakeFromToValueConverter = TakeFromToValueConverter;
});

//# sourceMappingURL=take-from-to.js.map
