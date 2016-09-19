var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
define(["require", "exports", 'aurelia-framework', '../../helpers/lib'], function (require, exports, aurelia_framework_1, lib_1) {
    "use strict";
    var PanelCustomElement = (function () {
        function PanelCustomElement() {
            this.pId = lib_1.Lib.generateUUID();
            this.pCanClose = false;
            this.pIsClosed = false;
            this.pCss = "col-md-12 col-lg-12";
        }
        PanelCustomElement.prototype.bind = function (ct) {
            console.log('Context from panel:', ct);
        };
        PanelCustomElement.prototype.attached = function () {
            var _this = this;
            this.pIsClosed = false;
            $(document).ready(function () {
                $('#full-' + _this.pId).click(function (e) {
                    e.preventDefault();
                    var $this = $(this);
                    if ($this.children('i').hasClass('glyphicon-resize-full')) {
                        $this.children('i').removeClass('glyphicon-resize-full');
                        $this.children('i').addClass('glyphicon-resize-small');
                    }
                    else if ($this.children('i').hasClass('glyphicon-resize-small')) {
                        $this.children('i').removeClass('glyphicon-resize-small');
                        $this.children('i').addClass('glyphicon-resize-full');
                    }
                    $(this).closest('.panel').toggleClass('panel-fullscreen');
                });
            });
        };
        PanelCustomElement.prototype.detached = function () {
        };
        PanelCustomElement.prototype.close = function () {
            if (this.pCanClose === "true" || this.pCanClose === true) {
                this.pIsClosed = true;
                this.pIsClosed = true;
                $('#' + this.pId).remove();
            }
        };
        __decorate([
            aurelia_framework_1.bindable, 
            __metadata('design:type', String)
        ], PanelCustomElement.prototype, "pTitle", void 0);
        __decorate([
            aurelia_framework_1.bindable, 
            __metadata('design:type', Object)
        ], PanelCustomElement.prototype, "pView", void 0);
        __decorate([
            aurelia_framework_1.bindable, 
            __metadata('design:type', String)
        ], PanelCustomElement.prototype, "pId", void 0);
        __decorate([
            aurelia_framework_1.bindable, 
            __metadata('design:type', Object)
        ], PanelCustomElement.prototype, "pCanClose", void 0);
        __decorate([
            aurelia_framework_1.bindable, 
            __metadata('design:type', Object)
        ], PanelCustomElement.prototype, "pModel", void 0);
        __decorate([
            aurelia_framework_1.bindable, 
            __metadata('design:type', Object)
        ], PanelCustomElement.prototype, "pViewModel", void 0);
        __decorate([
            aurelia_framework_1.bindable, 
            __metadata('design:type', Boolean)
        ], PanelCustomElement.prototype, "pIsClosed", void 0);
        __decorate([
            aurelia_framework_1.bindable, 
            __metadata('design:type', Object)
        ], PanelCustomElement.prototype, "pCss", void 0);
        return PanelCustomElement;
    }());
    exports.PanelCustomElement = PanelCustomElement;
});

//# sourceMappingURL=panel.js.map
