function editProfilePic() {
    $.ajax({
        type: "GET",
        url: "/Users/EditProfilePic",
        success: function (data) {
            $('#ProfilePic').html(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(response.responseText);
        }
    });
};

