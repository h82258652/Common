(function () {
    "use strict";
    Array.prototype.map = Array.prototype.map || function (fn) {
        var thisArg = arguments[1];
        var arr = [];
        for (var i = 0, len = this.length; i < len; i++) {
            arr.push(fn.call(thisArg, this[i], i, this));
        }
        return arr;
    };
}());
