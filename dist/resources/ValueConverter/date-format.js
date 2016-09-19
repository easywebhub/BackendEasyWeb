define(["require", "exports"], function (require, exports) {
    "use strict";
    var DateFormatValueConverter = (function () {
        function DateFormatValueConverter() {
        }
        DateFormatValueConverter.prototype.toView = function (value, format) {
            return moment(value).format(format);
        };
        return DateFormatValueConverter;
    }());
    exports.DateFormatValueConverter = DateFormatValueConverter;
});

//# sourceMappingURL=date-format.js.map
