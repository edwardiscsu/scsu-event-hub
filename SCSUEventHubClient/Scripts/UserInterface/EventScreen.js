function EventScreen(contentPaneId, eventService) {
    this.contentPaneId = contentPaneId;
    this.eventService = eventService;
    this.animationTime = 500;
    this.contentPanelObjects = [];
    this.isOpen = false;
}

EventScreen.prototype.open = function () {
    var originalThis = this;
    this.closeContentPanels();
    setTimeout(
        function () {
            //originalThis.switchAppHeader();
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
    if (this.isOpen) {
        this.close();
    }
    else {
        this.open();
    }
}

EventScreen.prototype.reset = function (filterId) {

}

EventScreen.prototype.addEvent = function (data) {

}

EventScreen.prototype.closeContentPanels = function () {
    var length = this.contentPanelObjects.length;
    for (var i = 0; i < length; i++) {
        if (this.contentPanelObjects[i] != this) {
            this.contentPanelObjects[i].close();
        }
    }
}

EventScreen.prototype.handleCategoryClicked = function (filter) {
    if (!this.isOpen) {
        this.open();
    }
    this.reset(filter.categorySelected);
}

EventScreen.prototype.switchAppHeader = function () {
    $("#app-page-header").children.each(function () {
        var child = $(this);
        child.animate({
            opacity: 0.0
        }, this.animationTime / 2, function () {
            child.remove();
            var header = $('<h4 style="color:#ffffff;padding-top:8px;opacity:0.0"></h4>');
            $("#app-page-header").append(header);
            header.animate({
                opacity: 1.0
            }, this.animationTime / 2, function () {

            });
        });
    })
}