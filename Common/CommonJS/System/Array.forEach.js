(function () {
    "use strict";
    Array.prototype.forEach = Array.prototype.forEach || function (fn) {
        var thisArg = arguments[1];
        for (var i = 0, len = this.length; i < len; i++) {
            fn.call(thisArg, this[i], i, this);
        }
    };
}());
