function editEducation(_id) {
    $.ajax({
        type: "GET",
        url: "/Educations/EditEducation",
        data: { "Id": _id },
        success: function (data) {
            $('#AddEducation').html(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(response.responseText);
        }
    });
};
