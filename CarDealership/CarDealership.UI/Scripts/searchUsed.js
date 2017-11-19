$(document).ready(function () {
    $('.vehicleButton').text('Details');
    var select = $('.pricing');
    var yearSelect = $('.yearMade');
    var year = (new Date()).getFullYear();

    for (var v = 5000; v < 105000; v += 5000) {
        select.append('<option value="' + v + '">' + v + '</option>');
    }

    for (var y = 1950; y < year + 2; y++) {
        yearSelect.append('<option value="' + y + '">' + y + '</option>');
    }
});

function vehicleAction(vehicleId) {
    location = "/Inventory/VehicleDetails/" + vehicleId;
}

$('#searchButton').on('click', function (e) {
    $('.panel.panel-default').hide();
    e.preventDefault();
    var makeModelYear = $('#makeModelYear').val();
    var minPrice = $('#minPrice option:selected').val();
    var maxPrice = $('#maxPrice option:selected').val();
    var minYear = $('#minYear option:selected').val();
    var maxYear = $('#maxYear option:selected').val();


    $.ajax({
        type: "POST",
        url: "/search/usedresults",
        data: JSON.stringify({
            makeModelYear: $('#makeModelYear').val(),
            minPrice: $('#minPrice option:selected').val(),
            maxPrice: $('#maxPrice option:selected').val(),
            minYear: $('#minYear option:selected').val(),
            maxYear: $('#maxYear option:selected').val()
        }),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'dataType': 'json',
        success: function (data) {
            $.each(data, function (index, vehicle) {
                $('#vehicle' + vehicle.VehicleId).show();
            });
        }
    });

});