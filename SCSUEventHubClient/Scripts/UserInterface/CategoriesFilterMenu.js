function CategoriesFilterMenu(categoryMenuId, openButtonId) {
    this.categoryMenuId = categoryMenuId;
    this.openButtonId = openButtonId;
    this.animationTime = 600;
    this.isOpen = false;

    $('#' + this.openButtonId).on("click", $.proxy(this.handleMenuClickEvent, this));
};

CategoriesFilterMenu.prototype.open = function () {
    var originalThis = this;
    $("#" + this.categoryMenuId).children().each(function () {
        $(this).css("display", "block");
        $(this).animate({

            opacity: 1.0
        }, this.animationTime, function () {
            originalThis.isOpen = true;
        });
    });


}

CategoriesFilterMenu.prototype.close = function () {
    var originalThis = this;
    $("#" + this.categoryMenuId).children().each(function () {
        $(this).animate({

            opacity: 0.3
        }, this.animationTime, function () {
            
            $(this).css("display", "none");
            originalThis.isOpen = false;
        });
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
    console.log("IN");
    console.log(categories);
    var length = categories.length;
    for (var i = 0; i < length; i++) {
        this.addCategoryToList(categories[i]);
    }
}

CategoriesFilterMenu.prototype.addCategoryToList = function (category) {
    console.log(category);
    $("#" + this.categoryMenuId).append(
        $("<li></li>")
            .addClass("list-group-item")
            .addClass("main-menu-clickable")
            .addClass("main-menu-subitem")
            .css("display", "none")
            .data("category-id", category.ID)
            .text(category.CategoryName)
    );
}