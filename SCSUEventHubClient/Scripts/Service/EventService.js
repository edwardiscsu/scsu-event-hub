
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
                    self.events([]);
                    var newEvents = data;
                    ko.utils.arrayForEach(newEvents, function (newEvent) {
                        self.events.push({
                            ID: newEvent.ID,
                            CategoryID: newEvent.CategoryID,
                            AdminID: newEvent.AdminID,
                            EventName: newEvent.EventName,
                            DateTime: newEvent.DateTime,
                            ImageURL: newEvent.ImageURL,
                            Description: newEvent.Description
                        });
                    });
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