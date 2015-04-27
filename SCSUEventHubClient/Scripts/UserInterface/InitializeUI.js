$(document).ready(function () {
    $('a').click(function (e) {
        e.preventDefault();
    });

    var userService = new UserService("api/Account");
    var eventService = new EventService("/api/events");

    var loginScreen = new LoginScreen("login-screen", "cmd-login-screen", userService);
    var registerScreen = new RegisterScreen("register-screen", "cmd-register-screen", userService);
    var eventScreen = new EventScreen("event-browser", eventService);

    var contentPanelObjects = [];
    contentPanelObjects.push(loginScreen);
    contentPanelObjects.push(registerScreen);
    contentPanelObjects.push(eventScreen);
    loginScreen.contentPanelObjects = contentPanelObjects;
    registerScreen.contentPanelObjects = contentPanelObjects;
    eventScreen.contentPanelObjects = contentPanelObjects;

    var appMenu = new AppMenuShelf("master-detail-menu", "cmd-app-menu-open");
    var filterMenu = new CategoriesFilterMenu("category-filter-menu", "cmd-categories-all", "cmd-categories-menu");
    filterMenu.addCategoryClickedListener($.proxy(eventScreen.handleCategoryClicked, eventScreen));

    var categoryService = new CategoryService("/api/categories");
    categoryService.addCategoriesLoadedListener(function () {
        filterMenu.addCategoriesToList(categoryService.categories);
    });
    categoryService.loadAllCategories();
});