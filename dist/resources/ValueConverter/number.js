define(["require", "exports"], function (require, exports) {
    "use strict";
    var NumberValueConverter = (function () {
        function NumberValueConverter() {
        }
        NumberValueConverter.prototype.toView = function (value) {
            if (+value) {
                return numeral(value).format('(0,0)');
            }
            else {
                return 'NAN';
            }
        };
        return NumberValueConverter;
    }());
    exports.NumberValueConverter = NumberValueConverter;
});

//# sourceMappingURL=number.js.map
