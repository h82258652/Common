(function (window) {
    "use strict";
    var document = window.document;

    // 指示是否已经 onReady。
    document.isReady = document.isReady || false;

    // 添加 onReady 方法。
    document.onReady = document.onReady || function (fn) {
        if (document.isReady === true) {
            fn();
        } else {
            fnList.push(fn);
        }
    };

    // 存放执行 onReady 的方法。
    var fnList = [];

    // 执行 onReady 方法。
    function fireReady() {
        if (document.isReady === false) {
            if (!document.body) {
                window.setTimeout(fireReady, 16);
            }
            document.isReady = true;
            for (var i = 0; i < fnList.length; i++) {
                fnList[i]();
            }
        }
    }

    if (document.readyState === "complete") {
        fireReady();
    } else if (document.addEventListener) {
        document.addEventListener("DOMContentLoaded", function () {
            document.removeEventListener("DOMContentLoaded", arguments.callee, false);
            fireReady();
        }, false);
    } else if (document.attachEvent) {
        document.attachEvent("onreadystatechange", function () {
            if (document.readyState === "complete") {
                document.detachEvent("onreadystatechange", arguments.callee);
                fireReady();
            }
        });

        (function () {
            if (document.isReady === true) {
                return;
            }

            var node = new window.Image();
            try {
                node.doScroll();
                node = null;
            } catch (e) {
                window.setTimeout(arguments.callee, 64);
                return;
            }
            fireReady();
        })();
    }
}(window));
