﻿function LoginScreen(contentPaneId, openButtonId) {
    this.contentPaneId = contentPaneId;
    this.openButtonId = openButtonId;
    this.animationTime = 600;
    this.isOpen = false;

    $('#' + this.openButtonId).on("click", $.proxy(this.handleOpenClickEvent, this));
}

LoginScreen.prototype.open = function () {
    var originalThis = this;
    $("#" + this.contentPaneId).css("display", "block");
    $("#" + this.contentPaneId).animate({

        opacity: 1.0
    }, this.animationTime, function () {
        originalThis.isOpen = true;
    });
}

LoginScreen.prototype.close = function () {
    var originalThis = this;
    $("#" + this.contentPaneId).animate({
        opacity: 0.3
    }, this.animationTime, function () {
        $("#" + originalThis.contentPaneId).css("display", "none");
        originalThis.isOpen = false;
    });
}

LoginScreen.prototype.handleOpenClickEvent = function () {
    if (this.isOpen) {
        this.close();
    }
    else {
        this.open();
    }
}