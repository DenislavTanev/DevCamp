function editCertification(_id) {
    $.ajax({
        type: "GET",
        url: "/Certifications/EditCertification",
        data: { "Id": _id },
        success: function (data) {
            $('#AddCertification').html(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(response.responseText);
        }
    });
};
