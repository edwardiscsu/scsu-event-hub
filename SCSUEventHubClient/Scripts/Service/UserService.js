function UserService(baseUrl) {
    this.baseUrl = baseUrl;
    this.userId = undefined;
    this.username = undefined;
};

UserService.prototype.login = function (data) {
    var originalThis = this;
    var requestUrl = this.baseUrl + data;
    $.ajax({
        url: requestUrl,
        dataType: "json",
        method: "GET"
    }).done(function (data) {

    }).fail(function () {

    });
};

UserService.prototype.register = function (data) {
    var originalThis = this;
    var requestUrl = this.baseUrl;
    $.ajax({
        url: requestUrl,
        dataType: "json",
        method: "POST",
        data: data
    }).done(function (data) {
        console.log(data);
    }).fail(function (xhr) {
        console.log(xhr);
        var alert = $('<div class="alert alert-danger alert-dismissible fade in" role="alert"><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">×</span></button><h4>Error</h4><p>' + xhr.responseText + '</p></div>');
        $("#register-screen-form").append(alert);
    });
};

UserService.prototype.logout = function (data) {
    var originalThis = this;
    var requestUrl = this.baseUrl + data;
    $.ajax({
        url: requestUrl,
        dataType: "json",
        method: "POST"
    }).done(function (data) {

    }).fail(function () {

    });
};

UserService.prototype.handleRegiserEvent = function (event) {
    data = {
        "Email": $("#register-screen-form-email").val(),
        "Password": $("#register-screen-form-password").val(),
        "ConfirmPassword": $("#register-screen-form-confirm-password").val()
    }; 
    console.log(data);
    this.register(data);
};

UserService.prototype.handleLoginEvent = function (event) {
    data = $("#login-screen-form-email").val();
    console.log(data);
    this.login(data);
};

UserService.prototype.handleLogoutEvent = function (event) {
    data = $("#login-screen-form-email").val();
    console.log(data);
    this.logout(data);
};