function UserService(baseUrl) {
    this.baseUrl = baseUrl;
};

UserService.prototype.login = function (username, password) {
    var originalThis = this;
    var requestUrl = this.baseUrl + "/Login";
    $.ajax({
        url: requestUrl,
        dataType: "json",
        method: "POST"
    }).done(function (data) {

    }).fail(function () {

    });
};

UserService.prototype.register = function (username, password) {
    var originalThis = this;
    var requestUrl = this.baseUrl + "/Register";
    $.ajax({
        url: requestUrl,
        dataType: "json",
        method: "POST"
    }).done(function (data) {

    }).fail(function () {

    });
};

UserService.prototype.logout = function () {
    var originalThis = this;
    var requestUrl = this.baseUrl + "/Logout";
    $.ajax({
        url: requestUrl,
        dataType: "json",
        method: "POST"
    }).done(function (data) {

    }).fail(function () {

    });
};

UserService.prototype.handleRegiserEvent = function (event) {

};

UserService.prototype.handleLoginEvent = function (event) {

};

UserService.prototype.handleLogoutEvent = function (event) {

};