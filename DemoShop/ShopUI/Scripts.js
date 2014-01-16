function AddClothing() {
    jQuery.support.cors = true;
    var clothing = {

        Name: $('#txtName').val(),
        Size: $('#txtSize').val(),
    };

    $.ajax({
        url: 'http://localhost:55926/api/CustomerApi/Post',
        type: 'POST',
        data: JSON.stringify(clothing),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            alert("Customer was saved in database with ID : " + data);
            __doPostBack('updatePanelCustomers', '');
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}