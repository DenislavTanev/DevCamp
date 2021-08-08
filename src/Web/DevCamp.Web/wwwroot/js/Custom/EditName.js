function editName() {
    $.ajax({
        type: "GET",
        url: "/Users/EditName",
        success: function (data) {
            $('#EditName').html(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(response.responseText);
        }
    });
};
