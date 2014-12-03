$(document).ready(function () {

    $("#ciLink").click(function () {
        $("#window").show();
    })


    function callback(data) {
        $(".tab").hide()
        //$("tbody[data-model='model']").replaceWith(data)
        $('#CityList option').remove();
        var select = $('#CityList');
        $.each(data, function (key, value) {

            $(select).append('<option value=' + data.Zip + '>' + value.CITY1 + '</option>')

        })

    }


});




