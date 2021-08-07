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

