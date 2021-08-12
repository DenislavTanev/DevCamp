function editFaq(_Id) {
    $.ajax({
        type: "GET",
        url: "/Faqs/Edit",
        data: { "Id": _Id },
        success: function (data) {
            $('#AddFaq').html(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(response.responseText);
        }
    });
};
