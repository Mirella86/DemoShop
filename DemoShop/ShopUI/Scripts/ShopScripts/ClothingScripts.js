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

    function ProductType(id, name) {
        var self = this;
        self.Id = ko.observable(id);
        self.Name = ko.observable(name);
    }

    //class for Product object
    function Product(id, name, gender, brand, category, stock, stockList) {
        var self = this;
        self.ID = ko.observable(id);
        self.Name = ko.observable(name);
        self.Brand = ko.observable(brand);
        self.Category = ko.observable(category);
       // if (gender != null)
            self.Gender = ko.observable(gender);

        //    self.Stock = ko.observable(stock);
        //     self.StockList = ko.observableArray([]);

    }

    function StockSize(size, stock) {
        var self = this;
        self.Size = size;
        self.Stock = stock;
    }

    function StockList(stockList) {
        $.each(stockList, function (index, value) {
            var stockSize = new StockSize(value.Size, value.Stock);
        });
    }

    // Overall viewmodel for this screen, along with initial state
    function ViewModel() {
        var self = this;

        self.products = ko.observableArray([]);
        self.productTypes = ko.observableArray([]);
        self.chosenProductTypeId = ko.observable();


        self.getProductTypes = function () {

            $.ajax({
                url: 'http://localhost/ShopWebAPI/ShopMain/',
                type: 'GET',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    self.productTypes.removeAll();
                    $.each(data, function (index, value) {
                        self.productTypes.push(new ProductType(value.Id, value.Name));
                    });

                    self.getProducts();
                    self.chosenProductTypeId = ko.observable(1);
                },
                error: function () {
                    alert("Error gettin data from server");
                }
            });
        };

        self.goToProduct = function (product) {
            //       self.chosenProductTypeId = product;
            if (product.Id() == 1)
                self.chosenProductTypeId = ko.observable(1);

            if (product.Id() == 2)
                self.chosenProductTypeId = ko.observable(2);

            self.getProducts();

        };

        self.getProducts = function () {

            if (self.chosenProductTypeId() == 1 || self.chosenProductTypeId() == undefined) {

                $.ajax({
                    url: 'http://localhost/ShopWebAPI/Clothing/',
                    type: 'GET',
                    contentType: 'application/json; charset=utf-8',
                    success: function (data) {
                        self.products.removeAll();
                        $.each(data, function (index, value) {
                            var gender = new Gender(value.GenderId, value.GenderName);
                            var category = new Category(value.CategoryId, value.CategoryName);
                            var brand = new Brand(value.BrandId, value.BrandName);
                            //      var stockList = new StockList(value.StockList);
                            self.products.push(new Product(value.Id, value.Name, gender, brand, category, null, null));
                        });
                    },
                    error: function () {
                        alert("Error gettin data from server");
                    }
                });
            } else {
                if (self.chosenProductTypeId() == 2) {

                    $.ajax({
                        url: 'http://localhost/ShopWebAPI/Cosmetic/',
                        type: 'GET',
                        contentType: 'application/json; charset=utf-8',
                        success: function (data) {
                            self.products.removeAll();
                            $.each(data, function (index, value) {
                                var category = new Category(value.CategoryId, value.CategoryName);
                                var brand = new Brand(value.BrandId, value.BrandName);
                                //       var stockList = new StockList(value.StockList);
                                self.products.push(new Product(value.Id, value.Name, null, brand, category, null, null));
                            });
                        },
                        error: function () {
                            alert("Error gettin data from server");
                        }
                    });
                };
            }
        };


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
            self.products.push(new Product("", "", ""));

        };

        self.removeClothing = function (clothing) {
            self.products.remove(clothing);
        };
    }

    var viewModel = new ViewModel();
    viewModel.getProductTypes();

    ko.applyBindings(viewModel);
});