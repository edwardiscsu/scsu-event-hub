function CategoryService(baseUrl) {
    this.baseUrl = baseUrl;
    this.categories = [];
};

CategoryService.prototype.loadAllCategories = function () {
    var url = this.baseUrl;
    $.ajax({
        url: "test.html",
        context: document.body
    }).done(function () {

    }).fail(function () {

    });
};

CategoryService.prototype.loadCategoryById = function (id) {
    

};

CategoryService.prototype.getCategoryId = function (name) {

};