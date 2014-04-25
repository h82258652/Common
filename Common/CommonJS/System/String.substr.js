(function () {
    "use strict";
    if ('ab'.substr(-1) !== 'b') {
        var _substr = String.prototype.substr;
        String.prototype.substr = function (start, length) {
            start = start < 0 ? Math.max(this.length + start, 0) : start;
            return substr.call(this, start, length);
        };
    }
}());
