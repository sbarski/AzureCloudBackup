$(function () {
    // Proxy created on the fly          
    var backup = $.connection.backup;
    var app = null;

    // Declare a function on the chat hub so the server can invoke it          
    backup.client.broadcastMessage = function (message) {
        app.commands.addMessage(message);
    };
    
    $.connection.hub.start()
        .done(function () {
            console.log("Azure Cloud Backup: Connected to the server with ID=" + $.connection.hub.id);
            app = new backupApp();
        })
        .fail(function () { console.log("Azure Cloud Backup: Could not connect to the server..."); });

    var backupApp = function () {
        var azureViewModel = function() {
            var self = this;

            self.connectionString = ko.observable("");
            self.databaseName = ko.observable("");
            self.blobStorageAccount = ko.observable("");
            self.blobStorageKey = ko.observable("");
            self.messageList = ko.observableArray([]);

            self.addMessage = function(entry) {
                self.messageList.push({ message: entry });
            };

            self.removeAll = function() {
                self.messageList.removeAll();
            };

            self.removeLastMessage = function() {
                self.messageList.pop();
            };

            self.allFieldsEntered = ko.computed(function() {
                return self.databaseName().length > 0 && self.connectionString().length > 0 && self.blobStorageAccount().length > 0 && self.blobStorageKey().length > 0;
            });

            self.download = function() {
                self.removeAll();

                backup.server.create(self.connectionString(), self.databaseName(), self.blobStorageAccount(), self.blobStorageKey(), $(event.target).data("export-type"));
            };
        };

        var viewModel = new azureViewModel();

        ko.applyBindings(viewModel);

        viewModel.addMessage("Please enter the connection string and database name...");

        return {
            commands: viewModel
        };
    };
});