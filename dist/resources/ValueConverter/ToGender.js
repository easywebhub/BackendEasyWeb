define(["require", "exports"], function (require, exports) {
    "use strict";
    var GenderValueConverter = (function () {
        function GenderValueConverter() {
        }
        GenderValueConverter.prototype.toView = function (str) {
            if (str) {
                if (str == 'F')
                    return "Nữ";
                if (str == 'M')
                    return "Nam";
            }
            else
                return "none";
        };
        return GenderValueConverter;
    }());
    exports.GenderValueConverter = GenderValueConverter;
});

//# sourceMappingURL=ToGender.js.map
