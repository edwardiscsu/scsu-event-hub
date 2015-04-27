function LoginScreen(contentPaneId, openButtonId) {
    this.contentPaneId = contentPaneId;
    this.openButtonId = openButtonId;
    this.animationTime = 600;
    this.isOpen = false;

    $('#' + this.openButtonId).on("click", $.proxy(this.handleOpenClickEvent, this));
}

AppMenuShelf.prototype.handleOpenClickEvent = function () {
    
}