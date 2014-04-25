(function (window) {
    "use strict";
    window.String.prototype.trim = window.String.prototype.trim || function () {
        return this.replace(/^\s\s*/, '').replace(/\s\s*$/, '');
    };
}(window));