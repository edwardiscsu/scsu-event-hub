function CategoriesFilterMenu(categoryMenuId, categoryAllId, openButtonId) {
    this.categoryMenuId = categoryMenuId;
    this.openButtonId = openButtonId;
    this.categoryAllId = categoryAllId;
    this.animationTime = 500;
    this.isOpen = false;
    this.onCategoryClicked = [];
    this.categorySelected = -1;

    $('#' + this.categoryAllId).on("click", $.proxy(this.handleCategoryClicked, this))
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
    var length = categories.length;
    for (var i = 0; i < length; i++) {
        this.addCategoryToList(categories[i]);
    }
    ko.applyBindings(new EventsViewModel());
}

CategoriesFilterMenu.prototype.addCategoryToList = function (category) {
    $("#" + this.categoryMenuId).append(
        $("<li></li>")
            .addClass("list-group-item")
            .addClass("main-menu-clickable")
            .addClass("main-menu-subitem")
            .css("display", "none")
            .data("category-id", category.ID)
            .text(category.CategoryName)
            .on("click", $.proxy(this.handleCategoryClicked, this))
            .attr("data-bind", "click: function() {$root.refreshEvents(" + category.ID + ",'" + category.CategoryName + "')}")
    );
}

CategoriesFilterMenu.prototype.categoryClicked = function () {
    var length = this.onCategoryClicked.length;
    for (var i = 0; i < length; i++) {
        this.onCategoryClicked[i](this);
    }
}

CategoriesFilterMenu.prototype.addCategoryClickedListener = function (func) {
    this.onCategoryClicked.push(func);
}

CategoriesFilterMenu.prototype.handleCategoryClicked = function (event) {
    var categoryId = parseInt($(event.target).data("category-id"));
    this.categorySelected = categoryId;
    console.log(this.categorySelected);
    this.categoryClicked();
}