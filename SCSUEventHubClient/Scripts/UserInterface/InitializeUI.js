$(document).ready(function () {
    $('a').click(function (e) {
        e.preventDefault();
    });

    var appMenu = new AppMenuShelf("master-detail-menu", "cmd-app-menu-open");
    var filterMenu = new CategoriesFilterMenu("category-filter-menu", "cmd-categories-menu");

    var categoryService = new CategoryService("/api/categories");
    categoryService.addCategoriesLoadedListener(function () {
        filterMenu.addCategoriesToList(categoryService.categories);
    });
    categoryService.loadAllCategories();
});