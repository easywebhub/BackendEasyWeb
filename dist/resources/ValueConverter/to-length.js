define(["require", "exports"], function (require, exports) {
    "use strict";
    var TolengthValueConverter = (function () {
        function TolengthValueConverter() {
        }
        TolengthValueConverter.prototype.toView = function (array) {
            return array.length;
        };
        return TolengthValueConverter;
    }());
    exports.TolengthValueConverter = TolengthValueConverter;
});

//# sourceMappingURL=to-length.js.map
