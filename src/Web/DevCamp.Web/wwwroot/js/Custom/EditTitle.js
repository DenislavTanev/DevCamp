function editTitle(_id) {
    $.ajax({
        type: "GET",
        url: "/Listings/EditTitle",
        data: { "Id": _id },
        success: function (data) {
            $('#EditTitle').html(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(response.responseText);
        }
    });
};
