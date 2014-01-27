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

    function Stock(id, clothingid, size, stock) {
        var self = this;
        self.Id = ko.observable(id);
        self.ClothingId = ko.observable(clothingid);
        self.Size = ko.observable(size);
        self.Stock = ko.observable(stock);

        self.saveStock = function () {
        };
    }


    //class for Product object
    function Product(id, name, genderId, genderName, brandId, brandName, categoryId, categoryName, stock, stockList, areFieldsEditable) {
        var self = this;
        self.ID = ko.observable(id);
        self.Name = ko.observable(name);
        self.GenderId = ko.observable(genderId);
        self.GenderName = ko.observable(genderName);
        self.BrandId = ko.observable(brandId);
        self.BrandName = ko.observable(brandName);
        self.CategoryId = ko.observable(categoryId);
        self.CategoryName = ko.observable(categoryName);

        self.Stock = ko.observable(stock);
        self.StockList = ko.observableArray([]);
        if (stockList != undefined) {
            $.each(stockList, function (index, value) {
                self.StockList.push(new Stock(value.Id, value.ClothingId, value.Size, value.Stock));
            });
        }

        self.addStock = function () {
            self.StockList.push(new Stock("", self.ID, "", 0));
        };

        self.areFieldsEditable = ko.observable(areFieldsEditable);
        //   self.saveVisible = ko.observable(false);

        self.setFieldsEditable = function () {
            self.areFieldsEditable(true);

        };

        self.saveProduct = function (product) {
            self.areFieldsEditable(false);

            $.ajax({
                url: 'http://localhost/WebApi/api/Clothing/',
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: ko.toJSON(product),
                success: function () {
                    alert('save product success');
                },
                error: function () {
                    alert("Error gettin data from server");
                }
            });
        };

        //    self.Stock = ko.observable(stock);
        //     self.StockList = ko.observableArray([]);

    }

    // Overall viewmodel for this screen, along with initial state
    function ViewModel() {
        var self = this;

        self.products = ko.observableArray([]);
        self.productTypes = ko.observableArray([]);
        self.chosenProductTypeId = ko.observable(1);

        self.availableBrands = ko.observableArray([]);
        self.availableCategories = ko.observableArray([]);
        self.availableGenders = ko.observableArray([]);

        self.getProductTypes = function () {

            $.ajax({
                url: 'http://localhost/WebApi/api/ShopMain/',
                type: 'GET',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    self.productTypes.removeAll();
                    $.each(data, function (index, value) {
                        self.productTypes.push(new ProductType(value.Id, value.Name));
                    });
                },
                error: function () {
                    alert("Error gettin data from server");
                }
            });
        };


        self.initializePage = function () {

            self.getProductTypes();
            self.initializeDropDowns();

            self.getProducts();
        };

        self.initializeDropDowns = function () {

            self.getAvailableBrands();
            self.getAvailableGenders();
            self.getAvailableCategories();
        };

        self.getAvailableBrands = function () {
            var urlGet = 'http://localhost/WebApi/api/Brands/GetBrands?productType=' + self.chosenProductTypeId();

            $.ajax({
                url: urlGet,
                type: 'GET',
                //     data: ko.toJSON(self.chosenProductTypeId()),
                data: JSON.stringify(1),
                contentType: 'application/json;',
                success: function (data) {
                    self.availableBrands.removeAll();
                    $.each(data, function (index, value) {
                        self.availableBrands.push(new Brand(value.Id, value.Name));
                    });
                },
                error: function () {
                }
            });
        };

        self.getAvailableCategories = function () {
            var urlGet = 'http://localhost/WebApi/api/Categories/GetCategories?productType=' + self.chosenProductTypeId();
            $.ajax({
                url: urlGet,
                type: 'GET',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    self.availableCategories.removeAll();
                    $.each(data, function (index, value) {
                        self.availableCategories.push(new Category(value.Id, value.Name));
                    });


                },
                error: function () {
                    alert("Error gettin categories");
                }
            });
        };

        self.getAvailableGenders = function () {

            $.ajax({
                url: 'http://localhost/WebApi/api/Genders/GetGenders',
                type: 'GET',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    self.availableGenders.removeAll();
                    $.each(data, function (index, value) {
                        self.availableGenders.push(new Gender(value.Id, value.Name));
                    });


                },
                error: function () {
                    alert("Error gettin genders");
                }
            });
        };

        self.goToProduct = function (product) {
            if (product.Id() == 1)
                self.chosenProductTypeId(1);
            if (product.Id() == 2)
                self.chosenProductTypeId(2);

            self.getProducts();

        };

        self.getProducts = function () {
            if (self.chosenProductTypeId() == undefined)
                self.chosenProductTypeId(1);

            if (self.chosenProductTypeId() == 1)  {

                $.ajax({
                    url: 'http://localhost/WebApi/api/Clothing/',
                    type: 'GET',
                    contentType: 'application/json; charset=utf-8',
                    success: function (data) {
                        self.products.removeAll();
                        $.each(data, function (index, value) {
                            self.products.push(new Product(value.Id, value.Name, value.GenderId, value.GenderName, value.BrandId, value.BrandName, value.CategoryId, value.CategoryName, "", value.Stocks, false));
                       
                        });
                    },
                    error: function () {
                        alert("Error gettin data from server");
                    }
                });
            } else {
                if (self.chosenProductTypeId() == 2) {

                    $.ajax({
                        url: 'http://localhost/WebApi/api/Cosmetic/',
                        type: 'GET',
                        contentType: 'application/json; charset=utf-8',
                        success: function (data) {
                            self.products.removeAll();
                            $.each(data, function (index, value) {
                                self.products.push(new Product(value.Id, value.Name, null, null, value.BrandId, value.BrandName, value.CategoryId, value.CategoryName, value.Stock, null));
                            });
                        },
                        error: function () {
                            alert("Error gettin data from server");
                        }
                    });
                };
            }

            self.initializeDropDowns(self.chosenProductTypeId());
        };


        self.addClothing = function () {
            self.products.push(new Product("", "", "", "", "", "", "", "", "", "", true));

        };

        self.removeProduct = function (product) {
            self.products.remove(product);

            if (self.chosenProductTypeId() == 1 || self.chosenProductTypeId() == undefined) {

                var url = 'http://localhost/WebApi/api/Clothing/' + product.ID();
                $.ajax({
                    url: url,
                    type: 'DELETE',
                    contentType: 'application/json; charset=utf-8',
                    success: function () {
                        alert("delete succesful");
                    },
                    error: function () {
                        alert("deleting");
                    }
                });
            } else {
                if (self.chosenProductTypeId() == 2) {

                    $.ajax({
                        url: 'http://localhost/WebApi/api/Cosmetic/',
                        type: 'GET',
                        contentType: 'application/json; charset=utf-8',
                        success: function (data) {
                        },
                        error: function () {
                            alert("Error gettin data from server");
                        }
                    });
                };
            }
        };


    }

    var viewModel = new ViewModel();
    viewModel.initializePage();

    ko.applyBindings(viewModel);
});