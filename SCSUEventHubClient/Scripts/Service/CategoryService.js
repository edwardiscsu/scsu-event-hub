function CategoryService(baseUrl) {
    this.baseUrl = baseUrl;
    this.categories = [];
    this.onCategoriesLoaded = [];
};

CategoryService.prototype.loadAllCategories = function () {
    var originalThis = this;
    var requestUrl = this.baseUrl;
    $.ajax({
        url: requestUrl,
        dataType: "json",
        method: "GET"
    }).done(function (data) {
        var length = data.length;
        for (var i = 0; i < length; i++) {
            originalThis.categories.push({ ID: data[i].ID, CategoryName: data[i].CategoryName });
        }
        originalThis.categoriesLoaded();
    }).fail(function () {
        console.log("loadAllCategories");
    });
};

CategoryService.prototype.getCategoryId = function (name) {
    this.categories.map(function (obj) {
        if (obj.CategoryName == name) {
            return obj.ID;
        }
    });
};

CategoryService.prototype.categoriesLoaded = function () {
    var length = this.onCategoriesLoaded.length;
    for (var i = 0; i < length; i++) {
        this.onCategoriesLoaded[i](this);
    }
}

CategoryService.prototype.addCategoriesLoadedListener = function (func) {
    this.onCategoriesLoaded.push(func);
}