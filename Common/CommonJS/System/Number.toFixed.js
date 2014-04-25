(function () {
    "use strict";
    if (0.9.toFixed(0) !== '1') {
        Number.prototype.toFixed = function (n) {
            var power = Math.pow(10, n);
            var fixed = (Math.round(this * power) / power).toString();
            if (n == 0) {
                return fixed;
            }
            if (fixed.indexOf('.')<0) {
                fixed += '.';
            }
            var padding = n + 1 - (fixed.length - fixed.indexOf('.'));
            for (var i = 0; i < padding; i++) {
                fixed += '0';
            }
            return fixed;
        };
    }
}());