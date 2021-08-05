function editDescription() {
    if (true) {
        $.ajax({
            cache: false,
            type: "GET",
            url: "/Users/EditDescription",
            success: function () {
                $('#PartialDescription').html("");
            }
        });
    }
};
