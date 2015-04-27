
$(document).ready(function () {

    function EventsViewModel() {
        var self = this;

        self.events = ko.observableArray([]);

        self.refreshEvents = function () {
            $.ajax({
                type: 'GET',
                url: 'http://localhost:63188/events/get/',
                contentType: 'application/json; charset=utf-8',
                dataType: "json",
                beforeSend: function (xhr) {
                    
                },
                success: function (data) {

                },
                error: function (jqXHR, status, error) {

                },
                complete: function () {

                }
            });
        };
        self.refreshEvents(); //Initial values
    }

    ko.applyBindings(new EventsViewModel());

});