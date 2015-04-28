
//$(document).ready(function () {
//function InitializeEvents() {

    function EventsViewModel() {
        var self = this;

        self.events = ko.observableArray([]);
        self.categoryTitle = ko.observable('All Categories')

        self.refreshEvents = function (categoryID, categoryName) {
            var params = categoryID !== null ? '?categoryID=' + categoryID : '';
            self.categoryTitle(categoryID !== null ? categoryName : 'All Categories');

            $.ajax({
                type: 'GET',
                url: 'http://localhost:63188/events/get/' + params,
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
                            Date: newEvent.Date,
                            Time: newEvent.Time,
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
        self.refreshEvents(null, null); //Initial values
    }

    //ko.applyBindings(new EventsViewModel());

//});
//}