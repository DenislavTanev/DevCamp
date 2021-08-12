function editDetails(_id) {
    $.ajax({
        type: "GET",
        url: "/Listings/EditDetails",
        data: { "Id": _id },
        success: function (data) {
            $('#EditDetails').html(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(response.responseText);
        }
    });
};

