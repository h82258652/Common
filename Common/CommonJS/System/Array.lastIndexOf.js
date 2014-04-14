(function () {
    Array.prototype.lastIndexOf = function (el, index) {
        var n = this.length;
        var i = index == null ? n - 1 : index;
        if (i<0) {
            i = Math.max(0, n + i);
        }
        for (;  i>=0;i--) {
            if (i in this && this[i]===el) {
                return i;
            }
        }
        return -1;
    };
}());
