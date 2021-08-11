function addEducation() {
    $.ajax({
        type: "GET",
        url: "/Educations/AddEducation",
        success: function (data) {
            $('#AddEducation').html(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(response.responseText);
        }
    });
};
