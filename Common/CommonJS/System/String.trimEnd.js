(function(window) {
    "use strict";
    window.String.prototype.trimEnd = window.String.prototype.trimEnd || function() {
        return this.replace(/\s\s*$/, '');
    };
}(window));