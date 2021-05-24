$(function () {

    $('#CenterID').hide();
    $('#CenterID').hide();

    $('#CenterID').change(function () {
        var URL = $('#CenterID').data('grantNumberListAction');
        $.getJSON(URL + '/' + $('#CenterID').val(), function (data) {
            var items = '<option>Select a Grant Number</option>';
            $.each(data, function (i, center) {
                items += "<option value='" + center.centerID + "'>" + center.GrantNumber + "</option>";
                // state.Value cannot contain ' character. We are OK because state.Value = cnt++; 
            });
            $('#CenterID').html(items);
            $('#centerID').show();

        });
    });

    $('#CenterID').change(function () {
        $('#CeneterID').show();
    });
});
