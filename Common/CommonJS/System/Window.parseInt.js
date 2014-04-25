(function (window) {
    "use strict";
    if (window.parseInt('09') !== 9) {
        var _parseInt = window.parseInt;
        window.parseInt = function (s, radix) {
            if (s.charAt(0) === '0' && s.charAt(1) !== 'x' && s.charAt(1) !== 'X' && radix == undefined) {
                s = s.replace(/^0*/, '');
            }
            return _parseInt(s, radix);
        };
    }
}(window));
