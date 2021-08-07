function addLanguage() {
    $.ajax({
        type: "GET",
        url: "/Languages/AddLanguage",
        success: function (data) {
            $('#AddLanguage').html(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(response.responseText);
        }
    });
};