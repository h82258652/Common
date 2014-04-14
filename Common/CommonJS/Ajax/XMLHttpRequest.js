(function (window) {
    if (!window.XMLHttpRequest) {
        var xhr;
        try {
            xhr = new window.ActiveXObject("Msxml2.XMLHTTP");
            window.XMLHttpRequest = function () {
                return new window.ActiveXObject("Msxml2.XMLHTTP");
            };
        } catch (e) {
            try {
                xhr = new window.ActiveXObject("Microsoft.XMLHTTP");
                window.XMLHttpRequest = function () {
                    return new window.ActiveXObject("Microsoft.XMLHTTP");
                };
            } catch (e) {
            }
        }
    }
}(window));
