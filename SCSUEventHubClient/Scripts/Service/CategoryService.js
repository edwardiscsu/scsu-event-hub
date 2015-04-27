function CategoryService(baseUrl) {
    this.baseUrl = baseUrl;
    this.categories = [];
};

CategoryService.prototype.loadAllCategories = function () {
    var requestUrl = this.baseUrl;
    $.ajax({
        url: requestUrl,
        method: "GET"
    }).done(function (data) {
        var length = data.length;
        for (var i = 0; i < length; i++) {
            this.categories.push({ID: data[i].ID, CategoryName: data[i].CategoryName});
        }
    }).fail(function () {
        console.log("loadAllCategories");
    });
};

CategoryService.prototype.loadCategoryById = function (id) {
    var requestUrl = this.baseUrl + "/" + id;
    $.ajax({
        url: requestUrl,
        method: "GET"
    }).done(function (data) {
        this.categories.push({ ID: data.ID, CategoryName: data.CategoryName });
    }).fail(function () {
        console.log("loadCategoryById: failed");
    });
};

CategoryService.prototype.getCategoryId = function (name) {
    this.categories.map(function (obj) {
        if (obj.CategoryName == name) {
            return obj.ID;
        }
    });
};