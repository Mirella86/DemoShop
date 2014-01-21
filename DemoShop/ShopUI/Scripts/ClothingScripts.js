/// <reference path="knockout-2.2.0.js" />
/// <reference path="knockout-2.2.0.debug.js" />
$(document).ready(function () {

    // Class to represent a row in the seat reservations grid
    function Clothing(id, name, size) {
        var self = this;
        self.ID = ko.observable(id);
        self.Name = ko.observable(name);
        self.Size = ko.observable(size);
        self.validObject = ko.computed(function () {
            if (self.Name() != "" && self.Size() != "")
                return true;
            else return false;

        });
    }

    // Overall viewmodel for this screen, along with initial state
    function ClothingViewModel() {
        var self = this;

        self.clothings = ko.observableArray([]);

        self.getClothings = function () {
            $.ajax({
                url: 'http://localhost/ShopWebAPI/Clothing/',
                type: 'GET',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {

                    $.each(data, function(index, value) {
                        self.clothings.push(new Clothing(value.Id, value.Name, value.Size));
                    });
                },
                error: function () {
                    alert("Error gettin data from server");
                }
            });
        };

        self.validObjects = ko.computed(function() {
            $.each(self.clothings, function(index, value) {
                if (!value.validObject)
                    return false;
                return true;
            });
        });

        self.updateClothing = function () {
            var model = new ClothingModel();
            model.Id = self.Id();
            model.Name = self.Name();
            model.Size = self.Size();

            $.ajax({
                url: 'http://localhost/ShopWebAPI/Clothing/',
                type: 'POST',
        });
        };

        self.addClothing = function () {
            self.clothings.push(new Clothing("", "", ""));

        };

        self.removeClothing = function (clothing) {
            self.clothings.remove(clothing);
        };
    }

    var clothingViewModel = new ClothingViewModel();
    clothingViewModel.getClothings();
    ko.applyBindings(clothingViewModel);
});