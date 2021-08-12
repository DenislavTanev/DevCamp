function addFaq(_listingId) {
    $.ajax({
        type: "GET",
        url: "/Faqs/Create",
        data: { "ListingId": _listingId },
        success: function (data) {
            $('#AddFaq').html(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(response.responseText);
        }
    });
};