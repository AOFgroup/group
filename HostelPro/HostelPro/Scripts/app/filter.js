
    function duration()
    {
        var from = $('#DateFrom').val()
        var to = $('#DateEnd').val()
        $.ajax({
            url: "DateFilter",
            data: {
                DateStart: from,
                DateEnd:to

            },
            success:callback



        });
        $("#pop-up").data("kendoWindow").close();
        console.log()
    }

    function city()
    {
        var hostels = $('.view-body li');
        var city = $('#cityName').val();
        console.log(city)
        $.each(hostels, function () {

            if ($(this).children().children().last().text() != city) {
                $(this).hide();

            }
            else
            {
                $(this).show();

            }
            if (city == "") {
                $(this).show();
            }
           
        });
        console.log(city);
        //$.ajax({
        //    url: "CityFilter",
        //    data: {
        //        City: ,
                

        //    },
        //    success: callback



        //});


    }
    
    function callback(data)
    {

        $('.view-body').replaceWith(data)
    }


$(document).ready(function(){


    $('#Fil-Date').click(duration);
    $('#ci-btn').click(city);


});

