$(document).ready(function () {
    $('a').click(function (e) {
        e.preventDefault();
    });

    var loginScreen = new LoginScreen("login-screen", "cmd-login-screen");
    var eventScreen = new EventScreen("event-browser", "");

    var contentPaneObjects = [];
    contentPaneObjects.push(loginScreen);
    contentPaneObjects.push(eventScreen);
    loginScreen.contentPaneObjects = contentPaneObjects;
    eventScreen.contentPaneObjects = contentPaneObjects;

    var appMenu = new AppMenuShelf("master-detail-menu", "cmd-app-menu-open");
    var filterMenu = new CategoriesFilterMenu("category-filter-menu", "cmd-categories-all", "cmd-categories-menu");

    var categoryService = new CategoryService("/api/categories");
    categoryService.addCategoriesLoadedListener(function () {
        filterMenu.addCategoriesToList(categoryService.categories);
    });
    categoryService.loadAllCategories();
});