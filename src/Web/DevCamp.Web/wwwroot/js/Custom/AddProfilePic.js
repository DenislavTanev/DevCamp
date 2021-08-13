function addProfilePic() {
    $.ajax({
        type: "GET",
        url: "/Users/AddProfilePic",
        success: function (data) {
            $('#ProfilePic').html(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(response.responseText);
        }
    });
};
