define(["require", "exports"], function (require, exports) {
    "use strict";
    var TakeValueConverter = (function () {
        function TakeValueConverter() {
        }
        TakeValueConverter.prototype.toView = function (array, count) {
            return array.slice(0, count);
        };
        return TakeValueConverter;
    }());
    exports.TakeValueConverter = TakeValueConverter;
});

//# sourceMappingURL=take.js.map
