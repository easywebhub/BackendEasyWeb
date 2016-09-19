define(["require", "exports"], function (require, exports) {
    "use strict";
    var BootstrapFormRenderer = (function () {
        function BootstrapFormRenderer() {
        }
        BootstrapFormRenderer.prototype.render = function (instruction) {
            for (var _i = 0, _a = instruction.unrender; _i < _a.length; _i++) {
                var _b = _a[_i], error = _b.error, elements = _b.elements;
                for (var _c = 0, elements_1 = elements; _c < elements_1.length; _c++) {
                    var element_1 = elements_1[_c];
                    this.remove(element_1, error);
                }
            }
            for (var _d = 0, _e = instruction.render; _d < _e.length; _d++) {
                var _f = _e[_d], error = _f.error, elements = _f.elements;
                for (var _g = 0, elements_2 = elements; _g < elements_2.length; _g++) {
                    var element_2 = elements_2[_g];
                    this.add(element_2, error);
                }
            }
        };
        BootstrapFormRenderer.prototype.add = function (element, error) {
            var formGroup = element.closest('.form-group');
            if (!formGroup) {
                return;
            }
            formGroup.classList.add('has-error');
            var message = document.createElement('span');
            message.className = 'help-block validation-message';
            message.textContent = error.message;
            message.id = "validation-message-" + error.id;
            formGroup.appendChild(message);
        };
        BootstrapFormRenderer.prototype.remove = function (element, error) {
            var formGroup = element.closest('.form-group');
            if (!formGroup) {
                return;
            }
            var message = formGroup.querySelector("#validation-message-" + error.id);
            if (message) {
                formGroup.removeChild(message);
                if (formGroup.querySelectorAll('.help-block.validation-message').length === 0) {
                    formGroup.classList.remove('has-error');
                }
            }
        };
        return BootstrapFormRenderer;
    }());
    exports.BootstrapFormRenderer = BootstrapFormRenderer;
});

//# sourceMappingURL=bootstrap-render.js.map
