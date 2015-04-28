$(document).ready(function () {
    $('a').click(function (e) {
        e.preventDefault();
    });

    var userService = new UserService("/api/users");
    $("#cmd-login-execute").on("click", $.proxy(userService.handleLoginEvent, userService));
    $("#cmd-register-execute").on("click", $.proxy(userService.handleRegiserEvent, userService));
    $("#cmd-logout-execute").on("click", $.proxy(userService.handleLogoutEvent, userService));
    //var eventService = new EventService("/api/events");

    var loginScreen = new LoginScreen("login-screen", "cmd-login-screen", userService);
    var registerScreen = new RegisterScreen("register-screen", "cmd-register-screen", userService);
    var eventScreen = new EventScreen("event-browser");
    userService.postLoginScreen = eventScreen;

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
    filterMenu.addCategoryClickedListener(function () {
        appMenu.close();
    });

    var categoryService = new CategoryService("/api/categories");
    categoryService.addCategoriesLoadedListener(function () {
        filterMenu.addCategoriesToList(categoryService.categories);
    });
    categoryService.loadAllCategories();
});