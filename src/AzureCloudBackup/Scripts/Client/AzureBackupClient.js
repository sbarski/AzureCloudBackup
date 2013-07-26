$(function () {
    var azureViewModel = function () {
        var self = this;

        self.connectionString = ko.observable("");
        self.databaseName = ko.observable("");
        self.blobStorageAccount = ko.observable("");
        self.blobStorageKey = ko.observable("");
        self.messageList = ko.observableArray([]);

        self.addMessage = function (entry) {
            self.messageList.push({ message: entry });
        };

        self.removeAll = function () {
            self.messageList.removeAll();
        };

        self.removeLastMessage = function () {
            self.messageList.pop();
        };
    };


    var app = new azureViewModel();

    ko.applyBindings(app);

    app.addMessage("Please enter the connection string and database name...");

    // Proxy created on the fly          
    var backup = $.connection.backup;

    // Declare a function on the chat hub so the server can invoke it          
    backup.client.broadcastMessage = function (message) {
        app.addMessage(message);
    };

    // Start the connection
    $.connection.hub.start().done(function () {
        $("#download-backpac").click(function () {

            app.removeAll();

            // Call the chat method on the server
            backup.server.create($('#inputConnectionString').val(), $('#inputDatabaseName').val());
        });
    });
});