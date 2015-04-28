function UserService(baseUrl, postLoginScreen) {
    this.baseUrl = baseUrl;
    this.postLoginScreen = postLoginScreen;
    this.user = undefined;
    this.isLoggedIn = false;
};

UserService.prototype.loginRequest = function (data) {
    var originalThis = this;
    var requestUrl = this.baseUrl + "?email=" + data["email"];
    $.ajax({
        url: requestUrl,
        dataType: "json",
        method: "GET",
    }).done(function (data) {
        originalThis.user = data;
        originalThis.login();
        this.isLoggedIn = true;
    }).fail(function (xhr) {
        console.log(xhr);
        var alert = $('<div class="alert alert-danger alert-dismissible fade in" role="alert"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">×</span></button><h4>Error</h4><p>' + xhr.responseText + '</p></div>');
        $("#login-screen-form").append(alert);
    });
};

UserService.prototype.registerRequest = function (data) {
    var originalThis = this;
    var requestUrl = this.baseUrl;
    $.ajax({
        url: requestUrl,
        dataType: "json",
        method: "POST",
        data: data
    }).done(function (data) {
        originalThis.user = data;
        originalThis.login();
        console.log(data);
    }).fail(function (xhr) {
        console.log(xhr);
        var alert = $('<div class="alert alert-danger alert-dismissible fade in" role="alert"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">×</span></button><h4>Error</h4><p>' + xhr.responseText + '</p></div>');
        $("#register-screen-form").append(alert);
    });
};

UserService.prototype.login = function () {
    this.isLoggedIn = true;
    $("#app-login-pending").css("display", "none");
    $("#app-login-done").css("display", "block");
    $("#user-welcome").text(this.user.UserName);
    this.postLoginScreen.open();
};

UserService.prototype.logout = function () {
    this.user = undefined;
    this.isLoggedIn = false;
    $("#app-login-pending").css("display", "block");
    $("#app-login-done").css("display", "none");
    $("#user-welcome").text("");
};

UserService.prototype.handleRegiserEvent = function (event) {
    data = {
        "Email": $("#register-screen-form-email").val(),
        "Password": $("#register-screen-form-password").val(),
        "ConfirmPassword": $("#register-screen-form-confirm-password").val()
    }; 
    console.log(data);
    this.registerRequest(data);
};

UserService.prototype.handleLoginEvent = function (event) {
    data = {
        "email": $("#login-screen-form-email").val()
    };
    console.log(data);
    this.loginRequest(data);
};

UserService.prototype.handleLogoutEvent = function (event) {
    this.logout();
};