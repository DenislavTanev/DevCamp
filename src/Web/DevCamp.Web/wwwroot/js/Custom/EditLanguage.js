function editLanguage(_id) {
    $.ajax({
        type: "GET",
        url: "/Languages/EditLanguage",
        data: {"Id": _id},
        success: function (data) {
            $('#AddLanguage').html(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(response.responseText);
        }
    });
};
