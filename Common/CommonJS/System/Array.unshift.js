(function () {
    "use strict";
    if ([].unshift(1) !== 1) {
        var _unshift = Array.prototype.unshift;
        Array.prototype.unshift = function () {
            _unshift.apply(this, arguments);
            return this.length;
        };
    }
}());