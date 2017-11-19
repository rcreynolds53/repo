$('#filterSearchButton').click(function () {
    $('#userSales').empty();
    var userId = $('#selectUser').val();
    var toDate = $('#ToDate').val();
    var fromDate = $('#FromDate').val();

    $.ajax({
        type: 'POST',
        url: "/reports/generatesalesreport",
        data: JSON.stringify({
            userId: userId,
            toDate: toDate,
            fromDate: fromDate
        }),

        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'dataType': 'json',
        success: function (data) {
            $.each(data, function (index, report) {
                var row = '<tr>';
                row += '<td>' + report.User.FullName + '</td>';
                row += '<td>$' + report.TotalSales + '</td>';
                row += '<td>' + report.TotalVehicles + '</td>';
                row += '</tr>';
                $('#userSales').append(row);
            });
            $('#salesReportTable').show();
        }
    })
});