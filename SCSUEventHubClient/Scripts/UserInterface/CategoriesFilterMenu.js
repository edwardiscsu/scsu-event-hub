function CategoriesFilterMenu(categoryMenuId, openButtonId) {
    this.categoryMenuId = categoryMenuId;
    this.openButtonId = openButtonId;
    this.animationTime = 600;
    this.isOpen = false;

    $('#' + this.openButtonId).on("click", $.proxy(this.handleMenuClickEvent, this));
};

CategoriesFilterMenu.prototype.open = function () {
    var originalThis = this;
    $("#" + this.categoryMenuId).css("display", "block");
    $("#" + this.categoryMenuId).animate({

        opacity: 0.9
    }, this.animationTime, function () {
        originalThis.isOpen = true;
    });
}

CategoriesFilterMenu.prototype.close = function () {
    var originalThis = this;
    $("#" + this.categoryMenuId).animate({

        opacity: 0.3
    }, this.animationTime, function () {
        originalThis.isOpen = false;
        $("#" + originalThis.categoryMenuId).css("display", "none");
    });
    
}

CategoriesFilterMenu.prototype.handleMenuClickEvent = function () {
    if (this.isOpen) {
        this.close();
    }
    else {
        this.open();
    }
}

CategoriesFilterMenu.prototype.addCategoriesToList = function (categories) {

}