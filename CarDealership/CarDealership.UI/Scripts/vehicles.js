$(function () {
    //$.ajax({
    //    type: "GET",
    //    url: "/admin/getmakes",
    //    datatype: "Json",
    //    success: function (data) {
    //        $.each(data, function (index, make) {
    //            $('#carMakeDropdown').append('<option value="' + make.CarMakeId + '">' + make.Manufacturer + '</option>');
    //        });
    //    }
    //});

    $('#carMakeDropdown').change(function () {

        $('#carModelDropdown').empty();
        var makeId = $('#carMakeDropdown').val();
        if (jQuery.isEmptyObject(makeId)) {
            $('#carModelDropdown').append('<option>-Select Make-</option>');
        }
        else {
            $.ajax({
                type: "POST",
                url: "/admin/GetModelsByMake",
                datatype: "Json",
                data: { makeId: $('#carMakeDropdown').val() },
                success: function (data) {
                    $.each(data, function (index, model) {
                        $('#carModelDropdown').append('<option value="' + model.CarModelId + '">' + model.CarModelName + '</option>');
                    });
                }
            });
        }
    });
});