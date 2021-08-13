function addImages(_id) {
    $.ajax({
        type: "GET",
        url: "/Listings/AddImages",
        data: { "id": _id },
        success: function (data) {
            $('#AddImages').html(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(response.responseText);
        }
    });
};
