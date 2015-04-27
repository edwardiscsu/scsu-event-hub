function EventScreen(contentPaneId, openButtonId) {
    this.contentPaneId = contentPaneId;
    this.openButtonId = openButtonId;
    this.animationTime = 600;
    this.isOpen = false;

    $('#' + this.openButtonId).on("click", $.proxy(this.handleOpenClickEvent, this));
}

EventScreen.prototype.open = function () {
    var originalThis = this;
    $("#" + this.contentPaneId).css("display", "block");
    $("#" + this.contentPaneId).animate({

        opacity: 1.0
    }, this.animationTime, function () {
        originalThis.isOpen = true;
    });
}

EventScreen.prototype.close = function () {
    var originalThis = this;
    $("#" + this.contentPaneId).animate({

        opacity: 0.3
    }, this.animationTime, function () {
        $("#" + originalThis.contentPaneId).css("display", "none");
        originalThis.isOpen = false;
    });
}

EventScreen.prototype.handleOpenClickEvent = function () {

}