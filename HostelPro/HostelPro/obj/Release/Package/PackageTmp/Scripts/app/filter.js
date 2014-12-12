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
     
    }

    function city()
    {
        var hostels = $('.view-body form');
        var city = $('#cityName').val();
        $.each(hostels, function () {

            if ($(this).find('a').children().eq(2).text() != city) {
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
       

    }
    
    function callback(data)
    {
        var viewBody = $('.view-body form');
        $('.item-con').bind("click", bed.submitForm);
    }
    function people()
    {
        $('.bed-val').val($('#in-fil').val());
        $("#pop-up").data("kendoWindow").close();
       
    }

    $(document).ready(function(){


        $('#Fil-Date').click(duration);
        $('#ci-btn').click(city);
        $('#pe-fil').click(people);


});

