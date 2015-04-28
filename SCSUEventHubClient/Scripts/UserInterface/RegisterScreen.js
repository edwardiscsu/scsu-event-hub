﻿function RegisterScreen(contentPaneId, openButtonId, userService) {
    this.contentPaneId = contentPaneId;
    this.openButtonId = openButtonId;
    this.userService = userService;
    this.animationTime = 500;
    this.contentPanelObjects = [];
    this.isOpen = false;

    $('#' + this.openButtonId).on("click", $.proxy(this.handleOpenClickEvent, this));
}

RegisterScreen.prototype.open = function () {
    var originalThis = this;
    this.closeContentPanels();
    setTimeout(
        function () {
            $("#" + originalThis.contentPaneId).css("display", "block");
            $("#" + originalThis.contentPaneId).animate({
                opacity: 1.0
            }, originalThis.animationTime, function () {
                originalThis.isOpen = true;
            });
        },
        this.animationTime
    );
}

RegisterScreen.prototype.close = function () {
    var originalThis = this;
    $("#" + this.contentPaneId).animate({
        opacity: 0.3
    }, this.animationTime, function () {
        $("#" + originalThis.contentPaneId).css("display", "none");
        originalThis.isOpen = false;
    });
}

RegisterScreen.prototype.handleOpenClickEvent = function () {
    if (!this.isOpen) {
        this.open();
    }
}

RegisterScreen.prototype.closeContentPanels = function () {
    var length = this.contentPanelObjects.length;
    for (var i = 0; i < length; i++) {
        if (this.contentPanelObjects[i] != this) {
            this.contentPanelObjects[i].close();
        }
    }
}