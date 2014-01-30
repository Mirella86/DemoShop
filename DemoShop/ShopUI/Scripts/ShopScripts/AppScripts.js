/// <reference path="knockout-2.2.0.js" />
/// <reference path="knockout-2.2.0.debug.js" />
$(document).ready(function () {

    var pattern = {
        number: '^([1-9]|[1-9][0-9]|[1-9][0-9][0-9])$',
        name: '^[a-zA-Z _-]{1,50}$',
        alphanumeric: '^[a-zA-Z0-9 ]{1,5}$'
    };

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
        self.Size = ko.observable(size).extend(
        {
            required: { message: "Field required" },
            pattern: {
                message: "Must be alphanumeric value  of max 5 characters",
                params: pattern.alphanumeric
            }
        });
        self.Stock = ko.observable(stock).extend(
        {
            required: { message: "Field required" },
            pattern: {
                message: "Must be a numeric value",
                params: pattern.number
            }
        });


        self.stockErrors = ko.validation.group(self.Stock(), self.Size());

        self.saveStock = function (stock) {
            if (self.stockErrors().length == 0) {

                $.ajax({
                    url: 'http://localhost/ShopWebApi/api/ClothingStock/',
                    type: 'POST',
                    contentType: 'application/json; charset=utf-8',
                    data: ko.toJSON(stock),
                    success: function () {
                        alert("Stock succesfully saved");
                    },
                    error: function () {
                        alert("Error saving stock");
                    }
                });
            } else {
                self.showAllMessages();
            }
        };

    }


    //class for Product object
    function Product(id, name, genderId, genderName, brandId, brandName, categoryId, categoryName, stock, stockList, areFieldsEditable) {
        var self = this;
        self.ID = ko.observable(id);
        self.Name = ko.observable(name).extend({
            required: { message: "Field required" },
            pattern: {
                message: 'Must be maximum 50 alphabetic characters',
                params: pattern.name
            }
        });
        self.GenderId = ko.observable(genderId);
        self.GenderName = ko.observable(genderName);
        self.BrandId = ko.observable(brandId);
        self.BrandName = ko.observable(brandName);
        self.CategoryId = ko.observable(categoryId);
        self.CategoryName = ko.observable(categoryName);

        self.Stock = ko.observable(stock).extend({
            required: {
                message: "Field required"
            },
            pattern: {
                message: "Value must be numeric",
                params: pattern.number
            }
        });

        self.StockList = ko.observableArray([]);
        if (stockList != undefined) {
            $.each(stockList, function (index, value) {
                self.StockList.push(new Stock(value.Id, value.ClothingId, value.Size, value.Stock));
            });
        }


        self.productErrors = ko.validation.group(self.Name(), self.Stock());

        self.addStock = function () {
            self.StockList.push(new Stock(0, self.ID, 0, 0));
        };

        self.removeStock = function (stockItem) {
            var urlDelete = 'http://localhost/ShopWebApi/api/ClothingStock/Delete?Id=' + stockItem.Id();
            self.StockList.remove(stockItem);
            $.ajax({
                url: urlDelete,
                type: 'DELETE',
                contentType: 'application/json; charset=utf-8',
                success: function () {
                },
                error: function () {
                    alert("Error deleting stock");
                }
            });
        };

        self.areFieldsEditable = ko.observable(areFieldsEditable);

        self.setFieldsEditable = function () {
            self.areFieldsEditable(true);

        };

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
                url: 'http://localhost/ShopWebApi/api/ShopMain/',
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
            var urlGet = 'http://localhost/ShopWebApi/api/Brands/GetBrands?productType=' + self.chosenProductTypeId();

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
            var urlGet = 'http://localhost/ShopWebApi/api/Categories/GetCategories?productType=' + self.chosenProductTypeId();
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
                url: 'http://localhost/ShopWebApi/api/Genders/GetGenders',
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

            if (self.chosenProductTypeId() == 1) {

                $.ajax({
                    url: 'http://localhost/ShopWebApi/api/Clothing/',
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
                        url: 'http://localhost/ShopWebApi/api/Cosmetic/',
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


        self.addProduct = function () {
            self.products.push(new Product("", "", "", "", "", "", "", "", "", "", true));

        };

        self.removeProduct = function (product) {
            self.products.remove(product);

            if (self.chosenProductTypeId() == 1 || self.chosenProductTypeId() == undefined) {

                var url = 'http://localhost/ShopWebApi/api/Clothing/' + product.ID();
                $.ajax({
                    url: url,
                    type: 'DELETE',
                    contentType: 'application/json; charset=utf-8',
                    success: function () {
                        //        alert("delete succesful");
                    },
                    error: function () {
                        alert("error deleting product");
                    }
                });
            } else {
                if (self.chosenProductTypeId() == 2) {

                    $.ajax({
                        url: 'http://localhost/ShopWebApi/api/Cosmetic/',
                        type: 'GET',
                        contentType: 'application/json; charset=utf-8',
                        success: function (data) {
                        },
                        error: function () {
                            alert("Error deleting product");
                        }
                    });
                };
            }
        };

        self.saveProduct = function (product) {
            if (product.productErrors.length == 0) {
                product.areFieldsEditable(false);
                if (self.chosenProductTypeId() == 1 || self.chosenProductTypeId() == undefined) {
                    $.ajax({
                        url: 'http://localhost/ShopWebApi/api/Clothing/',
                        type: 'POST',
                        contentType: 'application/json; charset=utf-8',
                        data: ko.toJSON(product),
                        success: function () {
                            //        alert('save product success');
                        },
                        error: function () {
                            alert("Error at saving clothing");
                        }
                    });
                } else {
                    $.ajax({
                        url: 'http://localhost/ShopWebApi/api/Cosmetic/',
                        type: 'POST',
                        contentType: 'application/json; charset=utf-8',
                        data: ko.toJSON(product),
                        success: function () {
                            //             alert('save product success');
                        },
                        error: function () {
                            alert("Error saving cosmetic");
                        }
                    });

                }
            } else {
                product.showAllMessages();
            }
        };


    }

    var viewModel = new ViewModel();
    viewModel.initializePage();

    ko.applyBindings(viewModel);
});