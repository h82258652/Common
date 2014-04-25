(function () {
    "use strict";
    Array.prototype.filter = Array.prototype.filter || function (fn) {
        var thisArg = arguments[1];
        var arr = [];
        for (var i = 0, len = this.length; i < len; i++) {
            if (!fn.call(thisArg, this[i], i, this)) {
                continue;
            }
            arr.push(this[i]);
        }
        return arr;
    };
}());
