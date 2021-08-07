function SelectCategory() {
    var sectorId = document.getElementById('SectorSelect');
    var value = sectorId.options[sectorId.selectedIndex].value;
    $.ajax({
        type: "GET",
        url: "/Listings/GetCategories",
        data: {"sectorId": value},
        success: function (data) {
            $('#CategoriesInput').html(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(response.responseText);
        }
    });
};