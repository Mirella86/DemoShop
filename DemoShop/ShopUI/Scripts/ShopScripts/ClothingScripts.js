/// <reference path="knockout-2.2.0.js" />
/// <reference path="knockout-2.2.0.debug.js" />
$(document).ready(function () {

    function Category(id, name) {
        var self = this;
        self.Id = ko.observable(id);
        self.Name = ko.observable(name);
    }

    function Brand(id, name) {
        var self = this;
        self.Id = ko.observable(id);
        self.Name = ko.observable(name);
    }

    function Gender(id, name) {
        var self = this;
        self.Id = ko.observable(id);
        self.Name = ko.observable(name);
    }

    //class for Clothing object
    function Clothing(id, name, gender, brand, category) {
        var self = this;
        self.ID = ko.observable(id);
        self.Name = ko.observable(name);
        self.Brand = ko.observable(brand);
        self.Category = ko.observable(category);
        self.Gender = ko.observable(gender);

        //self.validObject = ko.computed(function () {
        //    if (self.Name() != "" && self.Size() != "")
        //        return true;
        //    else return false;
        //});
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

                    $.each(data, function (index, value) {
                        var gender = new Gender(value.GenderId, value.GenderName);
                        var category = new Category(value.CategoryId, value.CategoryName);
                        var brand = new Brand(value.BrandId, value.BrandName);
                        self.clothings.push(new Clothing(value.Id, value.Name, gender, brand, category));
                    });
                },
                error: function () {
                    alert("Error gettin data from server");
                }
            });
        };

        //self.validObjects = ko.computed(function () {
        //    $.each(self.clothings, function (index, value) {
        //        if (!value.validObject)
        //            return false;
        //        return true;
        //    });
        //});

        //self.updateClothing = function () {
        //    var model = new ClothingModel();
        //    model.Id = self.Id();
        //    model.Name = self.Name();
        //    model.Size = self.Size();

        //    $.ajax({
        //        url: 'http://localhost/ShopWebAPI/Clothing/',
        //        type: 'POST',
        //    });
        //};

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