(function (window) {
    "use strict";
    window.String.prototype.trimStart = window.string.prototype.trimStart || function () {
        return this.replace(/^\s\s*/, '');
    };
}(window));