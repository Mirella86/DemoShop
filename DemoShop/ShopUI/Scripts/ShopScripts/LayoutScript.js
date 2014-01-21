$(document).ready(function () {

    function ProductType(id, name) {
        var self = this;
        self.Id = id;
        self.Name = name;
    }

    function ProductViewModel() {
        // Data
        var self = this;
        self.Products = ko.observableArray([]);
        self.ChosenProductId = ko.observable();

        self.getProductTypes = function () {
            $.ajax({
                url: 'http://localhost/ShopWebAPI/ShopMain/',
                type: 'GET',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {

                    $.each(data, function (index, value) {
                        self.Products.push(new ProductType(value.Id, value.Name));

                    });
                },
                error: function () {
                    alert("Error gettin data from server");
                }
            });
        };


        self.goToProduct = function (product) {
            self.chosenProductId(product);
        };
    }

    var productViewModel = new ProductViewModel();
    productViewModel.getProductTypes();
    ko.applyBindings(new ProductViewModel());

});