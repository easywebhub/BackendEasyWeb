define(["require", "exports"], function (require, exports) {
    "use strict";
    var ConvertToImangeValueConverter = (function () {
        function ConvertToImangeValueConverter() {
        }
        ConvertToImangeValueConverter.prototype.toView = function (obj) {
            if (obj) {
                return 'https://cdn1.vienthonga.vn/image/' + obj.replace('~/Upload', '');
            }
            else
                return 'http://www.dominicanajournal.org/wp-content/plugins/special-recent-posts-pro/images/no-thumb.png';
        };
        return ConvertToImangeValueConverter;
    }());
    exports.ConvertToImangeValueConverter = ConvertToImangeValueConverter;
});

//# sourceMappingURL=convert-to-image.js.map
