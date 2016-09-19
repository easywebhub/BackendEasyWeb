define(["require", "exports", 'bootstrap', 'lockr', 'sweetalert', 'numeral', 'jquery', 'moment', 'semantic'], function (require, exports) {
    "use strict";
    function configure(aurelia) {
        aurelia.use
            .standardConfiguration()
            .developmentLogging()
            .plugin('aurelia-validation')
            .feature('resources')
            .plugin('tungptvn/aurelia-paginator')
            .plugin('aurelia-dialog', function (config) {
            config.useDefaults();
            config.settings.lock = false;
            config.settings.centerHorizontalOnly = false;
            config.settings.startingZIndex = 10005;
        });
        aurelia.start().then(function (a) { return a.setRoot(); });
    }
    exports.configure = configure;
});

//# sourceMappingURL=main.js.map
