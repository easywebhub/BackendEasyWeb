define(["require", "exports"], function (require, exports) {
    "use strict";
    var VietNamDongValueConverter = (function () {
        function VietNamDongValueConverter() {
        }
        VietNamDongValueConverter.prototype.toView = function (value) {
            if (value) {
                return numeral(value).format('(0,0)') + ' ₫';
            }
            else {
                return 'chưa xác định';
            }
        };
        return VietNamDongValueConverter;
    }());
    exports.VietNamDongValueConverter = VietNamDongValueConverter;
});

//# sourceMappingURL=currency-format.js.map
