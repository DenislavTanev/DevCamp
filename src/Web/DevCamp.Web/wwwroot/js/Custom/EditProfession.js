function editProfession() {
    $.ajax({
        type: "GET",
        url: "/Users/EditProfession",
        success: function (data) {
            $('#EditProfession').html(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(response.responseText);
        }
    });
};
