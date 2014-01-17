/// <reference path="knockout-2.2.0.js" />
/// <reference path="knockout-2.2.0.debug.js" />
$(document).ready(function () {

    // Class to represent a row in the seat reservations grid
    function Clothing(id, name, size) {
        var self = this;
        self.ID = ko.observable(id);
        self.Name = ko.observable(name);
        self.Size = ko.observable(size);

    }

    // Overall viewmodel for this screen, along with initial state
    function ClothingViewModel() {
        var self = this;

        // Editable data
        self.clothings = ko.observableArray([]);
        //$.getJSON('Clothing', function (data) {
        //    $.each(data, function (i, val) {
        //        self.clothings.push(new Clothing(val.Id, val.Name, val.Size, self));
        //    });
        //});

        self.getClothings = function () {
            $.ajax({
                url: 'http://localhost/ShopWebAPI/Clothing/',
                type: 'GET',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    self.clothings(data);
                 //   alert('succes');
                },
                error: function () {
                    alert("error");
                }
            });
        };

        self.updateClothing = function() {};

        self.addClothing = function () {
            self.clothings.push(new Clothing("", "", ""));

        //    var clothing=new Object{id=}
        //    $.ajax({
        //        url: 'http://localhost/ShopWebAPI/Clothing/',
        //        type: 'PUT',
        //        data: 
        //        contentType: 'application/json; charset=utf-8',
        //        success: function (data) {
        //            self.clothings(data);
        //            alert('succes');
        //        },
        //        error: function () {
        //            alert("error");
        //        }
        //});

        };

        self.validateFields = function () {
            $.each(self.clothings, function(index, value) {
                if (value.Name.length == 0 || value.Size.length == 0)
                    return false;
            });
            return true;
        };

        self.removeClothing = function (clothing) {
            self.clothings.remove(clothing);
        };
    }

    var clothingViewModel = new ClothingViewModel();
    clothingViewModel.getClothings();
    ko.applyBindings(clothingViewModel);
});