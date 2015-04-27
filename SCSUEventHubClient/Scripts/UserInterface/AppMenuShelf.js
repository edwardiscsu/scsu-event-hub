function AppMenuShelf(appMenuId, openButtonId) {
    this.appMenuId = appMenuId;
    this.openButtonId = openButtonId;
    this.animationTime = 600;
    this.isOpen = false;

    $('#' + this.openButtonId).on("click", $.proxy(this.handleMenuClickEvent, this));
};

AppMenuShelf.prototype.open = function () {
    var originalThis = this;
    $("#" + this.appMenuId).css("display","block");
    $("#" + this.appMenuId).animate({
        width: "400px",
        opacity: 0.9
    }, this.animationTime, function () {
        originalThis.isOpen = true;
    });
}

AppMenuShelf.prototype.close = function () {
    var originalThis = this;
    $("#" + this.appMenuId).animate({
        width: "0px",
        opacity: 0.3
    }, this.animationTime, function () {
        originalThis.isOpen = false;
        $("#" + originalThis.appMenuId).css("display", "none");
    });
}

AppMenuShelf.prototype.handleMenuClickEvent = function () {
    if (this.isOpen) {
        this.close();
    }
    else {
        this.open();
    }
}