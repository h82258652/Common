(function () {
    "use strict";
    Array.prototype.distinct = Array.prototype.distinct || function () {
        var arr = [];
        for (var i = 0; i < this.length; i++) {
            var hasInclude = false;
            for (var j = 0; j < arr.length; j++) {
                if (arr[j] === this[i]) {
                    hasInclude = true;
                    break;
                }
            }
            if (hasInclude === false) {
                arr.push(this[i]);
            }
        }
        return arr;
    };
}());
