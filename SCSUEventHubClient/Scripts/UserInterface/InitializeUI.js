$(document).ready(function () {
    $('a').click(function (e) {
        e.preventDefault();
    });

    var categoryService = new CategoryService("/api/categories");
    categoryService.loadAllCategories();

    var appMenu = new AppMenuShelf("master-detail-menu", "cmd-app-menu-open");
    var filterMenu = new CategoriesFilterMenu("category-filter-menu", "cmd-categories-menu");
    filterMenu.addCategoriesToList(categoryService.categories);
});