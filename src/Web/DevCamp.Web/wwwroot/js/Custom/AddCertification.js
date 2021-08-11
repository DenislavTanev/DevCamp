function addCertification() {
    $.ajax({
        type: "GET",
        url: "/Certifications/AddCertification",
        success: function (data) {
            $('#AddCertification').html(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(response.responseText);
        }
    });
};