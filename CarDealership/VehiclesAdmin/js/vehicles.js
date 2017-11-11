$(document).ready(function () {
    loadVehicles();
    $('#createVehicleBtn').on('click', function () {
        $('#addVehicleDiv').toggle('slow');
        $('#vehicleTableDiv').hide();
        $('editVehicleDiv').hide();
    });

    $('#addVehicleBtn').click(function (event) {
        // var haveValidationErrors = checkAndDisplayValidationErrors($('#addMovieFormDiv').find('input'));

        // if (haveValidationErrors) {
        //     return false;
        // }
        $.ajax({
            type: 'POST',
            url: 'http://localhost:51193/vehicle',
            data: JSON.stringify({
                vin: $('#vehicleVin').val()
                //[InteriorColor.InteriorColorName]: $('#vehicleIntColor').val()


            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'dataType': 'json',
            success: function (data, status) {
                $('#errorMessages').empty();
                $('#addVehicleTitle').val('');
                $('#addVehicleContent').val('');
                $('#editVehicleDiv').hide('');
                loadVehicles();


            },
            error: function (jpXHR, textStatus, errorThrown) {
                $('#errorMessages')
                    .append($('<li>')
                        .attr({ class: 'list-group-item list-group-item-danger' })
                        .text('Error calling webservice. Please try again later.'));

            }
        });
    });
});
function hideAddVehicleForm() {
    $('#vehicleTableDiv').show();
    $('#addMovieFormDiv').hide();
}
function loadVehicles() {
    clearMoviesTable();
    var contentRows = $('#contentRows');
    $('#addVehicleDiv').hide();
    $('#vehicleTableDiv').show();
    $('#editVehicleDiv').hide();

    $.ajax({
        type: 'GET',
        url: 'http://localhost:51193/vehicles',
        success: function (vehicleArray) {
            $.each(vehicleArray, function (index, vehicle) {
                var make = vehicle.CarModel.CarMake.Manufacturer;
                var vin = vehicle.Vin;
                var model = vehicle.CarModel.CarModelName;

                var row = '<tr>';
                row += '<td>' + vin + '</td>';
                row += '<td>' + make + '</td>';
                row += '<td>' + model + '</td>';
                row += '<td><a onclick ="showEditVehicle(' + vin + ')">Edit |</a><a onclick ="deleteVehicle(' + vin + ')"> Delete</a></td>';
                row += '</tr>';

                contentRows.append(row);
            });
        },
        error: function (jpXHR, textStatus, errorThrown) {
            $('#errorMessages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling webservice. Please try again later.'));

        }
    });
}

$('#editVehicleBtn').click(function (event) {

    var vehicleId = $('#vehicleId').val();
    $.ajax({
        type: 'PUT',
        url: 'http://localhost:60542/vehicle/' + vehicleId,
        data: JSON.stringify({
            vehicleId: parseInt(vehicleId),
            title: $('#editVehicleTitle').val(),
            content: $('#editVehicleContent').val().replace(/<\/?[^>]+>/gi, ''),
            tagsToVehicle: editTags(),
            categories: editCategories()

        }),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'dataType': 'json',
        success: function (data, status) {
            $('#errorMessages').empty();
            $('#editVehicleTitle').val('');
            $('#editVehicleContent').val('');
            loadVehicles();



        },
        error: function (jpXHR, textStatus, errorThrown) {
            $('#errorMessages')
                .append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling webservice. Please try again later.'));

        }
    });
});
function deleteVehicle(vehicleId) {

    var deleteVehicle = confirm("Are you sure you want to delete this DVD from the collection?");
    if (deleteVehicle) {

        $.ajax({
            type: "DELETE",
            url: 'http://localhost:60542/vehicle/' + vehicleId,
            success: function () {
                loadVehicles();
            },
            error: function (jpXHR, textStatus, errorThrown) {
                $('#errorMessages')
                    .append($('<li>')
                        .attr({ class: 'list-group-item list-group-item-danger' })
                        .text('Error calling webservice. Please try again later.'));
            }
        });
    }
}

function clearMoviesTable() {
    $('#contentRows').empty();
}
function showEditVehicle(vehicleId) {
    $('#errorMessages').empty();
    $('#vehicleTableDiv').hide();
    $('#editVehicleDiv').show();
    $('#vehicleId').val(vehicleId);

    var tagNames = "";
    var catagoryNames = "";
    $.ajax({
        type: 'GET',
        url: 'http://localhost:60542/vehicle/' + vehicleId,
        success: function (vehicle, status) {
            // $('#editVehicleTitle').val(vehicle.title),
            //     $('#editVehicleContent').val(vehicle.content),
            //     $.each(vehicle.tags, function (index, tag) {
            //         tagNames += String(tag.tagName) + ",";
            //     });
            // $('#editTags').val(String(tagNames)),
            //     $('#editTags').tagsInput(),
            //     $.each(vehicle.categories, function (index, catagory) {
            //         catagoryNames += String(catagory.categoryName) + ",";
            //     });
            // $('#editCategories').val(String(catagoryNames)),

            //     $('#editCategories').tagsInput();


        },
        error: function (jqXHR, testStatus, errorThrow) {
            $('#editErrorMessages').append($('<li>')
                .attr({ class: 'list-group-item list-group-item' })
                .text('Error communicating with web service'));
        }

    });
}

function hideEditVehicleForm() {
    $('#vehicleTableDiv').show();
    $('#editVehicleDiv').hide();
}
function checkAndDisplayValidationErrors(input) {
    // clear displayed error message if there are any
    $('#errorMessages').empty();
    // check for HTML5 validation errors and process/display appropriately
    // a place to hold error messages
    var errorMessages = [];

    // loop through each input and check for validation errors
    input.each(function () {
        // Use the HTML5 validation API to find the validation errors
        if (!this.validity.valid) {
            var errorField = $('label[for=' + this.id + ']').text();
            errorMessages.push(errorField + ' ' + this.validationMessage);
        }
    });

    // put any error messages in the errorMessages div
    if (errorMessages.length > 0) {
        $.each(errorMessages, function (index, message) {
            $('#errorMessages').append($('<li>').attr({ class: 'list-group-item list-group-item-danger' }).text(message));
        });
        // return true, indicating that there were errors
        return true;
    } else {
        // return false, indicating that there were no errors
        return false;
    }
}

function getMakes() {

    $.ajax({
        type: 'GET',
        url: 'http://localhost:51193/makes',
        success: function (makesArray) {
            $.each(makesArray, function (index, make) {
                var manufacturer = make.Manufacturer;
                var makeId = make.CarMakeId
                var makeOption = '<option value="' + makeId + '">' + manufacturer + '</option>';
                $('#vehicleMake').append(makeOption);
            })
        }
    });
}
function getModels() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:51193/models',
        success: function (modelsArray) {
            $.each(modelsArray, function (index, model) {
                var modelName = model.CarModelName;
                var modelId = model.CarModelId;
                var modelOption = '<option value="' + modelName + '">' + modelName + '</option>';
                $('#vehicleModel').append(modelOption);
            })
        }
    });
}