(function () {
    "use strict";
    Array.prototype.indexOf = Array.prototype.indexOf || function (item, index) {
        var n = this.length;
        var i = index == null ? 0 : index < 0 ? Math.max(0, n + index) : index;
        for (; i < n; i++) {
            if (i in this && this[i] === item) {
                return i;
            }
        }
        return -1;
    };
}());
