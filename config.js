System.config({
  defaultJSExtensions: true,
  transpiler: false,
  paths: {
    "*": "dist/*",
    "github:*": "jspm_packages/github/*",
    "npm:*": "jspm_packages/npm/*",
    "lockr": "bower_components/lockr/lockr.min.js",
    "sweetalert": "bower_components/sweetalert/dist/sweetalert.min.js",
    "lodash": "bower_components/lodash/dist/lodash.min.js",
    "numeral": "bower_components/numeral/min/numeral.min.js",
    "ckeditor": "bower_components/ckeditor/ckeditor.js",
    "summernote": "bower_components/summernote/dist/summernote.min.js",
    "datetimepicker": "bower_components/eonasdan-bootstrap-datetimepicker/build/js/bootstrap-datetimepicker.min.js",
    "magnificPopup": "bower_components/magnific-popup/dist/jquery.magnific-popup.min.js",
    "semantic": "bower_components/semantic/dist/semantic.min.js"
  },
  meta: {
    "bootstrap": {
      "deps": [
        "jquery"
      ]
    }
  },
  map: {
    "aurelia-animator-css": "npm:aurelia-animator-css@1.0.1",
    "aurelia-binding": "npm:aurelia-binding@1.0.4",
    "aurelia-bootstrapper": "npm:aurelia-bootstrapper@1.0.0",
    "aurelia-dialog": "npm:aurelia-dialog@1.0.0-beta.3.0.0",
    "aurelia-event-aggregator": "npm:aurelia-event-aggregator@1.0.0",
    "aurelia-fetch-client": "npm:aurelia-fetch-client@1.0.0",
    "aurelia-framework": "npm:aurelia-framework@1.0.3",
    "aurelia-history": "npm:aurelia-history@1.0.0",
    "aurelia-history-browser": "npm:aurelia-history-browser@1.0.0",
    "aurelia-loader-default": "npm:aurelia-loader-default@1.0.0",
    "aurelia-logging-console": "npm:aurelia-logging-console@1.0.0",
    "aurelia-pal-browser": "npm:aurelia-pal-browser@1.0.0",
    "aurelia-polyfills": "npm:aurelia-polyfills@1.1.1",
    "aurelia-router": "npm:aurelia-router@1.0.3",
    "aurelia-tabs": "github:vheissu/aurelia-tabs@1.0.2",
    "aurelia-templating-binding": "npm:aurelia-templating-binding@1.0.0",
    "aurelia-templating-resources": "npm:aurelia-templating-resources@1.0.0",
    "aurelia-templating-router": "npm:aurelia-templating-router@1.0.0",
    "aurelia-validation": "npm:aurelia-validation@0.12.5",
    "bluebird": "npm:bluebird@3.4.1",
    "bootstrap": "github:twbs/bootstrap@3.3.7",
    "fetch": "github:github/fetch@1.0.0",
    "font-awesome": "npm:font-awesome@4.6.3",
    "jquery": "npm:jquery@2.2.4",
    "jquery-ui": "github:components/jqueryui@1.12.1",
    "moment": "npm:moment@2.15.1",
    "select2": "github:select2/select2@4.0.3",
    "text": "github:systemjs/plugin-text@0.0.8",
    "tungptvn/aurelia-paginator": "github:tungptvn/aurelia-paginator@0.1.8",
    "github:components/jqueryui@1.12.1": {
      "jquery": "npm:jquery@2.2.4"
    },
    "github:jspm/nodelibs-assert@0.1.0": {
      "assert": "npm:assert@1.4.1"
    },
    "github:jspm/nodelibs-buffer@0.1.0": {
      "buffer": "npm:buffer@3.6.0"
    },
    "github:jspm/nodelibs-process@0.1.2": {
      "process": "npm:process@0.11.9"
    },
    "github:jspm/nodelibs-util@0.1.0": {
      "util": "npm:util@0.10.3"
    },
    "github:jspm/nodelibs-vm@0.1.0": {
      "vm-browserify": "npm:vm-browserify@0.0.4"
    },
    "github:select2/select2@4.0.3": {
      "jquery": "npm:jquery@2.2.4"
    },
    "github:tungptvn/aurelia-paginator@0.1.8": {
      "aurelia-framework": "npm:aurelia-framework@1.0.3"
    },
    "github:twbs/bootstrap@3.3.7": {
      "jquery": "npm:jquery@2.2.4"
    },
    "github:vheissu/aurelia-tabs@1.0.2": {
      "aurelia-binding": "npm:aurelia-binding@1.0.4",
      "aurelia-dependency-injection": "npm:aurelia-dependency-injection@1.0.0",
      "aurelia-event-aggregator": "npm:aurelia-event-aggregator@1.0.0",
      "aurelia-templating": "npm:aurelia-templating@1.1.0"
    },
    "npm:assert@1.4.1": {
      "assert": "github:jspm/nodelibs-assert@0.1.0",
      "buffer": "github:jspm/nodelibs-buffer@0.1.0",
      "process": "github:jspm/nodelibs-process@0.1.2",
      "util": "npm:util@0.10.3"
    },
    "npm:aurelia-animator-css@1.0.1": {
      "aurelia-metadata": "npm:aurelia-metadata@1.0.0",
      "aurelia-pal": "npm:aurelia-pal@1.0.0",
      "aurelia-templating": "npm:aurelia-templating@1.1.0"
    },
    "npm:aurelia-binding@1.0.4": {
      "aurelia-logging": "npm:aurelia-logging@1.0.0",
      "aurelia-metadata": "npm:aurelia-metadata@1.0.0",
      "aurelia-pal": "npm:aurelia-pal@1.0.0",
      "aurelia-task-queue": "npm:aurelia-task-queue@1.0.0"
    },
    "npm:aurelia-bootstrapper@1.0.0": {
      "aurelia-event-aggregator": "npm:aurelia-event-aggregator@1.0.0",
      "aurelia-framework": "npm:aurelia-framework@1.0.3",
      "aurelia-history": "npm:aurelia-history@1.0.0",
      "aurelia-history-browser": "npm:aurelia-history-browser@1.0.0",
      "aurelia-loader-default": "npm:aurelia-loader-default@1.0.0",
      "aurelia-logging-console": "npm:aurelia-logging-console@1.0.0",
      "aurelia-pal": "npm:aurelia-pal@1.0.0",
      "aurelia-pal-browser": "npm:aurelia-pal-browser@1.0.0",
      "aurelia-polyfills": "npm:aurelia-polyfills@1.1.1",
      "aurelia-router": "npm:aurelia-router@1.0.3",
      "aurelia-templating": "npm:aurelia-templating@1.1.0",
      "aurelia-templating-binding": "npm:aurelia-templating-binding@1.0.0",
      "aurelia-templating-resources": "npm:aurelia-templating-resources@1.0.0",
      "aurelia-templating-router": "npm:aurelia-templating-router@1.0.0"
    },
    "npm:aurelia-dependency-injection@1.0.0": {
      "aurelia-metadata": "npm:aurelia-metadata@1.0.0",
      "aurelia-pal": "npm:aurelia-pal@1.0.0"
    },
    "npm:aurelia-dialog@1.0.0-beta.3.0.0": {
      "aurelia-dependency-injection": "npm:aurelia-dependency-injection@1.0.0",
      "aurelia-metadata": "npm:aurelia-metadata@1.0.0",
      "aurelia-pal": "npm:aurelia-pal@1.0.0",
      "aurelia-templating": "npm:aurelia-templating@1.1.0"
    },
    "npm:aurelia-event-aggregator@1.0.0": {
      "aurelia-logging": "npm:aurelia-logging@1.0.0"
    },
    "npm:aurelia-framework@1.0.3": {
      "aurelia-binding": "npm:aurelia-binding@1.0.4",
      "aurelia-dependency-injection": "npm:aurelia-dependency-injection@1.0.0",
      "aurelia-loader": "npm:aurelia-loader@1.0.0",
      "aurelia-logging": "npm:aurelia-logging@1.0.0",
      "aurelia-metadata": "npm:aurelia-metadata@1.0.0",
      "aurelia-pal": "npm:aurelia-pal@1.0.0",
      "aurelia-path": "npm:aurelia-path@1.0.0",
      "aurelia-task-queue": "npm:aurelia-task-queue@1.0.0",
      "aurelia-templating": "npm:aurelia-templating@1.1.0"
    },
    "npm:aurelia-history-browser@1.0.0": {
      "aurelia-history": "npm:aurelia-history@1.0.0",
      "aurelia-pal": "npm:aurelia-pal@1.0.0"
    },
    "npm:aurelia-loader-default@1.0.0": {
      "aurelia-loader": "npm:aurelia-loader@1.0.0",
      "aurelia-metadata": "npm:aurelia-metadata@1.0.0",
      "aurelia-pal": "npm:aurelia-pal@1.0.0"
    },
    "npm:aurelia-loader@1.0.0": {
      "aurelia-metadata": "npm:aurelia-metadata@1.0.0",
      "aurelia-path": "npm:aurelia-path@1.0.0"
    },
    "npm:aurelia-logging-console@1.0.0": {
      "aurelia-logging": "npm:aurelia-logging@1.0.0"
    },
    "npm:aurelia-metadata@1.0.0": {
      "aurelia-pal": "npm:aurelia-pal@1.0.0"
    },
    "npm:aurelia-pal-browser@1.0.0": {
      "aurelia-pal": "npm:aurelia-pal@1.0.0"
    },
    "npm:aurelia-polyfills@1.1.1": {
      "aurelia-pal": "npm:aurelia-pal@1.0.0"
    },
    "npm:aurelia-route-recognizer@1.0.0": {
      "aurelia-path": "npm:aurelia-path@1.0.0"
    },
    "npm:aurelia-router@1.0.3": {
      "aurelia-dependency-injection": "npm:aurelia-dependency-injection@1.0.0",
      "aurelia-event-aggregator": "npm:aurelia-event-aggregator@1.0.0",
      "aurelia-history": "npm:aurelia-history@1.0.0",
      "aurelia-logging": "npm:aurelia-logging@1.0.0",
      "aurelia-path": "npm:aurelia-path@1.0.0",
      "aurelia-route-recognizer": "npm:aurelia-route-recognizer@1.0.0"
    },
    "npm:aurelia-task-queue@1.0.0": {
      "aurelia-pal": "npm:aurelia-pal@1.0.0"
    },
    "npm:aurelia-templating-binding@1.0.0": {
      "aurelia-binding": "npm:aurelia-binding@1.0.4",
      "aurelia-logging": "npm:aurelia-logging@1.0.0",
      "aurelia-templating": "npm:aurelia-templating@1.1.0"
    },
    "npm:aurelia-templating-resources@1.0.0": {
      "aurelia-binding": "npm:aurelia-binding@1.0.4",
      "aurelia-dependency-injection": "npm:aurelia-dependency-injection@1.0.0",
      "aurelia-loader": "npm:aurelia-loader@1.0.0",
      "aurelia-logging": "npm:aurelia-logging@1.0.0",
      "aurelia-metadata": "npm:aurelia-metadata@1.0.0",
      "aurelia-pal": "npm:aurelia-pal@1.0.0",
      "aurelia-path": "npm:aurelia-path@1.0.0",
      "aurelia-task-queue": "npm:aurelia-task-queue@1.0.0",
      "aurelia-templating": "npm:aurelia-templating@1.1.0"
    },
    "npm:aurelia-templating-router@1.0.0": {
      "aurelia-dependency-injection": "npm:aurelia-dependency-injection@1.0.0",
      "aurelia-logging": "npm:aurelia-logging@1.0.0",
      "aurelia-metadata": "npm:aurelia-metadata@1.0.0",
      "aurelia-pal": "npm:aurelia-pal@1.0.0",
      "aurelia-path": "npm:aurelia-path@1.0.0",
      "aurelia-router": "npm:aurelia-router@1.0.3",
      "aurelia-templating": "npm:aurelia-templating@1.1.0"
    },
    "npm:aurelia-templating@1.1.0": {
      "aurelia-binding": "npm:aurelia-binding@1.0.4",
      "aurelia-dependency-injection": "npm:aurelia-dependency-injection@1.0.0",
      "aurelia-loader": "npm:aurelia-loader@1.0.0",
      "aurelia-logging": "npm:aurelia-logging@1.0.0",
      "aurelia-metadata": "npm:aurelia-metadata@1.0.0",
      "aurelia-pal": "npm:aurelia-pal@1.0.0",
      "aurelia-path": "npm:aurelia-path@1.0.0",
      "aurelia-task-queue": "npm:aurelia-task-queue@1.0.0"
    },
    "npm:aurelia-validation@0.12.5": {
      "aurelia-binding": "npm:aurelia-binding@1.0.4",
      "aurelia-dependency-injection": "npm:aurelia-dependency-injection@1.0.0",
      "aurelia-logging": "npm:aurelia-logging@1.0.0",
      "aurelia-pal": "npm:aurelia-pal@1.0.0",
      "aurelia-task-queue": "npm:aurelia-task-queue@1.0.0",
      "aurelia-templating": "npm:aurelia-templating@1.1.0"
    },
    "npm:bluebird@3.4.1": {
      "process": "github:jspm/nodelibs-process@0.1.2"
    },
    "npm:buffer@3.6.0": {
      "base64-js": "npm:base64-js@0.0.8",
      "child_process": "github:jspm/nodelibs-child_process@0.1.0",
      "fs": "github:jspm/nodelibs-fs@0.1.2",
      "ieee754": "npm:ieee754@1.1.6",
      "isarray": "npm:isarray@1.0.0",
      "process": "github:jspm/nodelibs-process@0.1.2"
    },
    "npm:font-awesome@4.6.3": {
      "css": "github:systemjs/plugin-css@0.1.27"
    },
    "npm:inherits@2.0.1": {
      "util": "github:jspm/nodelibs-util@0.1.0"
    },
    "npm:process@0.11.9": {
      "assert": "github:jspm/nodelibs-assert@0.1.0",
      "fs": "github:jspm/nodelibs-fs@0.1.2",
      "vm": "github:jspm/nodelibs-vm@0.1.0"
    },
    "npm:util@0.10.3": {
      "inherits": "npm:inherits@2.0.1",
      "process": "github:jspm/nodelibs-process@0.1.2"
    },
    "npm:vm-browserify@0.0.4": {
      "indexof": "npm:indexof@0.0.1"
    }
  },
  bundles: {
    "aurelia.js": [
      "github:github/fetch@1.0.0.js",
      "github:github/fetch@1.0.0/fetch.js",
      "github:select2/select2@4.0.3.js",
      "github:select2/select2@4.0.3/js/select2.js",
      "github:systemjs/plugin-text@0.0.8.js",
      "github:systemjs/plugin-text@0.0.8/text.js",
      "github:tungptvn/aurelia-paginator@0.1.8.js",
      "github:tungptvn/aurelia-paginator@0.1.8/index.js",
      "github:twbs/bootstrap@3.3.7.js",
      "github:twbs/bootstrap@3.3.7/css/bootstrap.css!github:systemjs/plugin-text@0.0.8.js",
      "github:twbs/bootstrap@3.3.7/js/bootstrap.js",
      "npm:aurelia-animator-css@1.0.1.js",
      "npm:aurelia-animator-css@1.0.1/aurelia-animator-css.js",
      "npm:aurelia-binding@1.0.4.js",
      "npm:aurelia-binding@1.0.4/aurelia-binding.js",
      "npm:aurelia-bootstrapper@1.0.0.js",
      "npm:aurelia-bootstrapper@1.0.0/aurelia-bootstrapper.js",
      "npm:aurelia-dependency-injection@1.0.0.js",
      "npm:aurelia-dependency-injection@1.0.0/aurelia-dependency-injection.js",
      "npm:aurelia-dialog@1.0.0-beta.3.0.0.js",
      "npm:aurelia-dialog@1.0.0-beta.3.0.0/ai-dialog-body.js",
      "npm:aurelia-dialog@1.0.0-beta.3.0.0/ai-dialog-footer.js",
      "npm:aurelia-dialog@1.0.0-beta.3.0.0/ai-dialog-header.js",
      "npm:aurelia-dialog@1.0.0-beta.3.0.0/ai-dialog.js",
      "npm:aurelia-dialog@1.0.0-beta.3.0.0/attach-focus.js",
      "npm:aurelia-dialog@1.0.0-beta.3.0.0/aurelia-dialog.js",
      "npm:aurelia-dialog@1.0.0-beta.3.0.0/dialog-configuration.js",
      "npm:aurelia-dialog@1.0.0-beta.3.0.0/dialog-controller.js",
      "npm:aurelia-dialog@1.0.0-beta.3.0.0/dialog-options.js",
      "npm:aurelia-dialog@1.0.0-beta.3.0.0/dialog-renderer.js",
      "npm:aurelia-dialog@1.0.0-beta.3.0.0/dialog-result.js",
      "npm:aurelia-dialog@1.0.0-beta.3.0.0/dialog-service.js",
      "npm:aurelia-dialog@1.0.0-beta.3.0.0/lifecycle.js",
      "npm:aurelia-dialog@1.0.0-beta.3.0.0/renderer.js",
      "npm:aurelia-event-aggregator@1.0.0.js",
      "npm:aurelia-event-aggregator@1.0.0/aurelia-event-aggregator.js",
      "npm:aurelia-fetch-client@1.0.0.js",
      "npm:aurelia-fetch-client@1.0.0/aurelia-fetch-client.js",
      "npm:aurelia-framework@1.0.3.js",
      "npm:aurelia-framework@1.0.3/aurelia-framework.js",
      "npm:aurelia-history-browser@1.0.0.js",
      "npm:aurelia-history-browser@1.0.0/aurelia-history-browser.js",
      "npm:aurelia-history@1.0.0.js",
      "npm:aurelia-history@1.0.0/aurelia-history.js",
      "npm:aurelia-loader-default@1.0.0.js",
      "npm:aurelia-loader-default@1.0.0/aurelia-loader-default.js",
      "npm:aurelia-loader@1.0.0.js",
      "npm:aurelia-loader@1.0.0/aurelia-loader.js",
      "npm:aurelia-logging-console@1.0.0.js",
      "npm:aurelia-logging-console@1.0.0/aurelia-logging-console.js",
      "npm:aurelia-logging@1.0.0.js",
      "npm:aurelia-logging@1.0.0/aurelia-logging.js",
      "npm:aurelia-metadata@1.0.0.js",
      "npm:aurelia-metadata@1.0.0/aurelia-metadata.js",
      "npm:aurelia-pal-browser@1.0.0.js",
      "npm:aurelia-pal-browser@1.0.0/aurelia-pal-browser.js",
      "npm:aurelia-pal@1.0.0.js",
      "npm:aurelia-pal@1.0.0/aurelia-pal.js",
      "npm:aurelia-path@1.0.0.js",
      "npm:aurelia-path@1.0.0/aurelia-path.js",
      "npm:aurelia-polyfills@1.1.1.js",
      "npm:aurelia-polyfills@1.1.1/aurelia-polyfills.js",
      "npm:aurelia-route-recognizer@1.0.0.js",
      "npm:aurelia-route-recognizer@1.0.0/aurelia-route-recognizer.js",
      "npm:aurelia-router@1.0.3.js",
      "npm:aurelia-router@1.0.3/aurelia-router.js",
      "npm:aurelia-task-queue@1.0.0.js",
      "npm:aurelia-task-queue@1.0.0/aurelia-task-queue.js",
      "npm:aurelia-templating-binding@1.0.0.js",
      "npm:aurelia-templating-binding@1.0.0/aurelia-templating-binding.js",
      "npm:aurelia-templating-resources@1.0.0.js",
      "npm:aurelia-templating-resources@1.0.0/abstract-repeater.js",
      "npm:aurelia-templating-resources@1.0.0/analyze-view-factory.js",
      "npm:aurelia-templating-resources@1.0.0/array-repeat-strategy.js",
      "npm:aurelia-templating-resources@1.0.0/aurelia-hide-style.js",
      "npm:aurelia-templating-resources@1.0.0/aurelia-templating-resources.js",
      "npm:aurelia-templating-resources@1.0.0/binding-mode-behaviors.js",
      "npm:aurelia-templating-resources@1.0.0/binding-signaler.js",
      "npm:aurelia-templating-resources@1.0.0/compose.js",
      "npm:aurelia-templating-resources@1.0.0/css-resource.js",
      "npm:aurelia-templating-resources@1.0.0/debounce-binding-behavior.js",
      "npm:aurelia-templating-resources@1.0.0/dynamic-element.js",
      "npm:aurelia-templating-resources@1.0.0/focus.js",
      "npm:aurelia-templating-resources@1.0.0/hide.js",
      "npm:aurelia-templating-resources@1.0.0/html-resource-plugin.js",
      "npm:aurelia-templating-resources@1.0.0/html-sanitizer.js",
      "npm:aurelia-templating-resources@1.0.0/if.js",
      "npm:aurelia-templating-resources@1.0.0/map-repeat-strategy.js",
      "npm:aurelia-templating-resources@1.0.0/null-repeat-strategy.js",
      "npm:aurelia-templating-resources@1.0.0/number-repeat-strategy.js",
      "npm:aurelia-templating-resources@1.0.0/repeat-strategy-locator.js",
      "npm:aurelia-templating-resources@1.0.0/repeat-utilities.js",
      "npm:aurelia-templating-resources@1.0.0/repeat.js",
      "npm:aurelia-templating-resources@1.0.0/replaceable.js",
      "npm:aurelia-templating-resources@1.0.0/sanitize-html.js",
      "npm:aurelia-templating-resources@1.0.0/set-repeat-strategy.js",
      "npm:aurelia-templating-resources@1.0.0/show.js",
      "npm:aurelia-templating-resources@1.0.0/signal-binding-behavior.js",
      "npm:aurelia-templating-resources@1.0.0/throttle-binding-behavior.js",
      "npm:aurelia-templating-resources@1.0.0/update-trigger-binding-behavior.js",
      "npm:aurelia-templating-resources@1.0.0/with.js",
      "npm:aurelia-templating-router@1.0.0.js",
      "npm:aurelia-templating-router@1.0.0/aurelia-templating-router.js",
      "npm:aurelia-templating-router@1.0.0/route-href.js",
      "npm:aurelia-templating-router@1.0.0/route-loader.js",
      "npm:aurelia-templating-router@1.0.0/router-view.js",
      "npm:aurelia-templating@1.1.0.js",
      "npm:aurelia-templating@1.1.0/aurelia-templating.js",
      "npm:aurelia-validation@0.12.5.js",
      "npm:aurelia-validation@0.12.5/aurelia-validation.js",
      "npm:aurelia-validation@0.12.5/implementation/rules.js",
      "npm:aurelia-validation@0.12.5/implementation/standard-validator.js",
      "npm:aurelia-validation@0.12.5/implementation/util.js",
      "npm:aurelia-validation@0.12.5/implementation/validation-messages.js",
      "npm:aurelia-validation@0.12.5/implementation/validation-parser.js",
      "npm:aurelia-validation@0.12.5/implementation/validation-rules.js",
      "npm:aurelia-validation@0.12.5/property-info.js",
      "npm:aurelia-validation@0.12.5/validate-binding-behavior.js",
      "npm:aurelia-validation@0.12.5/validate-trigger.js",
      "npm:aurelia-validation@0.12.5/validation-controller-factory.js",
      "npm:aurelia-validation@0.12.5/validation-controller.js",
      "npm:aurelia-validation@0.12.5/validation-error.js",
      "npm:aurelia-validation@0.12.5/validation-errors-custom-attribute.js",
      "npm:aurelia-validation@0.12.5/validation-renderer-custom-attribute.js",
      "npm:aurelia-validation@0.12.5/validator.js",
      "npm:jquery@2.2.4.js",
      "npm:jquery@2.2.4/dist/jquery.js",
      "npm:moment@2.15.1.js",
      "npm:moment@2.15.1/moment.js",
      "numeral"
    ],
    "app-build.js": [
      "app.html!github:systemjs/plugin-text@0.0.8.js",
      "app.js",
      "configs/appConfig.js",
      "configs/authorizeStep.js",
      "main.js",
      "models/login.js",
      "nav-bar.html!github:systemjs/plugin-text@0.0.8.js",
      "resources/CustomAttributes/bootstrap-tooltip.js",
      "resources/CustomAttributes/datetime-picker.js",
      "resources/CustomAttributes/manific-popup.js",
      "resources/CustomAttributes/select2.js",
      "resources/CustomAttributes/summernote.js",
      "resources/CustomElements/panel/panel.html!github:systemjs/plugin-text@0.0.8.js",
      "resources/CustomElements/panel/panel.js",
      "resources/Excel/importExcel.js",
      "resources/ValueConverter/ObjectKeyConverter.js",
      "resources/ValueConverter/ToGender.js",
      "resources/ValueConverter/convert-to-image.js",
      "resources/ValueConverter/currency-format.js",
      "resources/ValueConverter/date-format.js",
      "resources/ValueConverter/index.js",
      "resources/ValueConverter/json.js",
      "resources/ValueConverter/number.js",
      "resources/ValueConverter/take-from-to.js",
      "resources/ValueConverter/take.js",
      "resources/ValueConverter/to-length.js",
      "resources/helpers/lib.js",
      "resources/index.js",
      "resources/validation-render/bootstrap-render.js",
      "services/Account/CustomerServices.js",
      "services/Account/LoggingServices.js",
      "services/Account/StudentServices.js",
      "services/Account/UserServices.js",
      "services/HttpService.js",
      "services/appState.js",
      "viewmodels/DashBoardVM/dash_board.html!github:systemjs/plugin-text@0.0.8.js",
      "viewmodels/DashBoardVM/dash_board.js",
      "viewmodels/LoginVM/login.html!github:systemjs/plugin-text@0.0.8.js",
      "viewmodels/LoginVM/login.js",
      "viewmodels/LoginVM/logout.html!github:systemjs/plugin-text@0.0.8.js",
      "viewmodels/LoginVM/logout.js",
      "views/entity-header.html!github:systemjs/plugin-text@0.0.8.js",
      "welcome.html!github:systemjs/plugin-text@0.0.8.js",
      "welcome.js"
    ]
  },
  depCache: {
    "app.js": [
      "aurelia-framework",
      "./services/appState",
      "./configs/authorizeStep",
      "aurelia-history"
    ],
    "configs/authorizeStep.js": [
      "aurelia-framework",
      "../services/appState"
    ],
    "main.js": [
      "bootstrap",
      "lockr",
      "sweetalert",
      "numeral",
      "jquery",
      "semantic"
    ],
    "models/login.js": [
      "aurelia-validation"
    ],
    "resources/CustomAttributes/bootstrap-tooltip.js": [
      "aurelia-framework"
    ],
    "resources/CustomAttributes/datetime-picker.js": [
      "aurelia-framework",
      "moment",
      "datetimepicker"
    ],
    "resources/CustomAttributes/manific-popup.js": [
      "aurelia-framework",
      "magnificPopup"
    ],
    "resources/CustomAttributes/select2.js": [
      "aurelia-framework",
      "select2"
    ],
    "resources/CustomAttributes/summernote.js": [
      "aurelia-framework",
      "summernote"
    ],
    "resources/CustomElements/panel/panel.js": [
      "aurelia-framework",
      "../../helpers/lib"
    ],
    "services/Account/CustomerServices.js": [
      "aurelia-framework",
      "aurelia-fetch-client",
      "../..//services/HttpService"
    ],
    "services/Account/LoggingServices.js": [
      "aurelia-framework",
      "aurelia-fetch-client",
      "../..//services/HttpService"
    ],
    "services/Account/StudentServices.js": [
      "aurelia-framework",
      "aurelia-fetch-client",
      "../..//services/HttpService"
    ],
    "services/Account/UserServices.js": [
      "aurelia-framework",
      "aurelia-fetch-client",
      "../..//services/HttpService"
    ],
    "services/appState.js": [
      "aurelia-framework",
      "lockr"
    ],
    "services/HttpService.js": [
      "aurelia-framework",
      "aurelia-fetch-client",
      "..//Configs/appConfig"
    ],
    "viewmodels/DashBoardVM/dash_board.js": [
      "aurelia-framework",
      "aurelia-fetch-client",
      "../../services/appState"
    ],
    "viewmodels/LoginVM/login.js": [
      "../../services/appState",
      "aurelia-router",
      "aurelia-dependency-injection",
      "aurelia-validation",
      "../../models/login",
      "../../resources/validation-render/bootstrap-render"
    ],
    "viewmodels/LoginVM/logout.js": [
      "aurelia-framework",
      "aurelia-router"
    ],
    "welcome.js": [
      "aurelia-dependency-injection",
      "aurelia-validation",
      "./resources/validation-render/bootstrap-render"
    ]
  }
});