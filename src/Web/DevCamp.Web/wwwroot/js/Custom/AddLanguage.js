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

function SelectSubCategory() {
    var categoryId = document.getElementById('categorySelect');
    var value = categoryId.options[categoryId.selectedIndex].value;
    $.ajax({
        type: "GET",
        url: "/Listings/GetSubCategories",
        data: { "categoryId": value },
        success: function (data) {
            $('#SubCategoriesInput').html(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(response.responseText);
        }
    });
};
