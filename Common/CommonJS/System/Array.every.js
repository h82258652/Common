(function () {
    "use strict";
    Array.prototype.every = Array.prototype.every || function (fn) {
        var thisArg = arguments[1];
        for (var i = 0, len = this.length; i < len; i++) {
            if (!fn.call(thisArg, this[i], i, this)) {
                return false;
            }
        }
        return true;
    };
}());
