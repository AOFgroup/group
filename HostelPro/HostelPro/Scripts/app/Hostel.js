$(document).ready(function () {

    function callback(data) {
        $(".tab").hide()
        //$("tbody[data-model='model']").replaceWith(data)
        $('#CityList option').remove();
        var select = $('#CityList');
        $.each(data, function (key, value) {

            $(select).append('<option value=' + data.Zip + '>' + value.CITY1 + '</option>')

        })

    }
  
        $(document).ready(function () {

        $("#ciLink").click(function () {
            $("#window").show();
        })





    });

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

var element = (function () {
    var count = 0;
    var input = ('<label>Room</lable><input class="BedInput"/>')
    function addInput() {
        var val=$('#RoomInput').val();
        if(val>count)
        {
            for (i=count; i<val; i++)
            {
                $('.input-room').append('<div ><label>Room ' + i + '</lable><br><input name="bedInput" placeholder="Add number of beds" type="number" /><input name="Price" type="number" value="00" placeholder="Set price pr. bed"/></div>');

            }
            count = val
        }
        else if(val<count)
        {
           
            var sl=count-val;
            $('.input-room div').slice(-sl).remove()
            count = val;

        }
      
    }

    return {
        addInput: addInput
    }

})();



