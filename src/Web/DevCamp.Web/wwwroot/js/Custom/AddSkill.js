function addSkill() {
    $.ajax({
        type: "GET",
        url: "/Skills/AddSkill",
        success: function (data) {
            $('#AddSkill').html(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(response.responseText);
        }
    });
};
