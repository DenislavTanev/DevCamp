function editDescription() {
        $.ajax({
            type: "GET",
            url: "/Users/EditDescription",
            success: function (data) {
                $('#PartialDescription').html(data);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(response.responseText);
            }
        });
};
