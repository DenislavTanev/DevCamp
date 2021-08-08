function addLocation() {
    $.ajax({
        type: "GET",
        url: "/Users/EditLocation",
        success: function (data) {
            $('#AddLocation').html(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(response.responseText);
        }
    });
};