
//$(document).ready(function () {
//function InitializeEvents() {

    function EventsViewModel() {
        var self = this;

        self.eventDetail = ko.observable({
            ID: "",
            CategoryID: "",
            AdminID: "",
            EventName: "",
            Date: "",
            Time: "",
            ImageURL: "",
            Description: "",
            Subscribed: false
        });

        self.events = ko.observableArray([]);
        self.categoryTitle = ko.observable('All Categories')

        self.refreshEventDetail = function (newEvent) {
            self.eventDetail(newEvent);
            $('#event-detail-container').toggleClass('display-none');
        }
        self.toggleEventDetail = function () {
            $('#event-detail-container').toggleClass('display-none');
        }

        self.refreshSubscription = function (newEvent) {
            for (i = 0; i < self.events().length; i++)
                if (self.events()[i].ID == newEvent.ID)
                    self.events()[i].Subscribed = true;
            $('#event-subscription-container').toggleClass('display-none');
        }
        self.toggleSubscription = function () {
            $('#event-subscription-container').toggleClass('display-none');
        }

        self.refreshEvents = function (categoryID, categoryName) {
            var params = categoryID !== null ? '?categoryID=' + categoryID : '';
            self.categoryTitle(categoryID !== null ? categoryName : 'All Categories');

            $.ajax({
                type: 'GET',
                url: 'http://localhost:8001/events/get/' + params,
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
                            Description: newEvent.Description,
                            Subscribed: false
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