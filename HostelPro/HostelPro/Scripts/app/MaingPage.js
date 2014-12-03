$(document).ready(function () {
    var window = $("#window"),
        undo = $("#login")
                .bind("click", function () {
                    window.data("kendoWindow").open();
                    undo.hide();
                });

    var onClose = function () {
        undo.show();
    

    }

    if (!window.data("kendoWindow")) {
        window.kendoWindow({
            width: "15%",
            title: "LogIn",
            actions: [
                "Pin",
                "Minimize",
                "Maximize",
                "Close"
            ],
            position:{

                top:58,
                left:735
            },
            close: onClose
        });
    }
    function hide() {
        $('.k-widget.k-window').hide();
        $('#login').css('display','block')
    }
    $('#register').click(hide);


});