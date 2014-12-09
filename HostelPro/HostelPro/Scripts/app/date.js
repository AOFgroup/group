
    function duration()
    {
        var from = $('#DateFrom').val()
        var to = $('#DateEnd').val()
        $.ajax({
            url: "Filter",
            data: {
                DateStart: from,
                DateEnd:to

            },
            success:callback



        });
        $("#pop-up").data("kendoWindow").close();
        console.log()
    }
    
    function callback(data)
    {

        $('.view-body').replaceWith(data)
    }


$(document).ready(function(){


    $('#Fil-Date').click(duration);


});

