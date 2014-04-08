(function (window) {
    "use strict";
    window.Array.isArray = window.Array.isArray || function (object) {
        return Object.prototype.toString.call(object) === "[object Array]" || object instanceof Array;
    };
}(window));