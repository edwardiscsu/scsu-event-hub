function AppMenuShelf(appMenuId, openButtonId) {
    this.appMenuId = appMenuId;
    this.openButtonId = openButtonId;
    this.isOpen = false;

    $('#' + this.openButtonId).on("click", $.proxy(this.handleClickEvent, this));
};

AppMenuShelf.prototype.open = function () {
    var originalThis = this;
    $("#" + this.appMenuId).animate({
        width: "100%",
        opacity: 1.0
    }, 2000, function () {
        originalThis.isOpen = true;
    });
}

AppMenuShelf.prototype.close = function () {
    var originalThis = this;
    $("#" + this.appMenuId).animate({
        width: "0%",
        opacity: 0.5
    }, 2000, function () {
        originalThis.isOpen = false;
    });
}

AppMenuShelf.prototype.handleClickEvent = function () {
    if (this.isOpen) {
        this.close();
    }
    else {
        this.open();
    }
}