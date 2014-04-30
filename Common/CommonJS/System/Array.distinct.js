(function () {
    "use strict";
    Array.prototype.distinct = Array.prototype.distinct || function () {
        var arr = [];
        for (var i = 0; i < this.length; i++) {
            if (arr.indexOf(this[i]) < 0) {
                arr.push(this[i]);
            }
        }
        return arr;
    };
}());
