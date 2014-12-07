var CheckElement = (function () {

    function CheckBeds() {

        alert("Hello")

    }
    return {

        CheckBeds: CheckBeds
    }


})();


$(document).ready(function () {
   
    function login() {
        $('#window').css("display", "block");
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
                position: {

                    top: 58,
                    left: 735
                },
                close: onClose
            });
        }



    }

    
    function register() {
     
        $('.k-window').hide()
     
        $('#window2').css("display", "block");
        var win = $("#window2"),
        un = $("#register")
                .bind("click", function () {
                    win.data("kendoWindow").open();
                    un.hide();
                });

        var onClose = function () {
            un.show();

        }

        if (!win.data("kendoWindow")) {
            win.kendoWindow({
                width: "15%",
                title: "Create account",
                actions: [
                    "Pin",
                    "Minimize",
                    "Maximize",
                    "Close"
                ],
                position: {

                    top: 58,
                    left: 735
                },
                close: onClose
            });
        }


     
    }

    function hide()
    {
      
     $('.k-window').hide()

       
    }
    function NewCity() {
        $('#window').css("display", "block");
        var window = $("#window"),
        undo = $("#ciLink")
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
                position: {

                    top: 58,
                    left: 735
                },
                close: onClose
            });
        }



    }


    $("#ciLink").click(function () {
        NewCity()
    })


    $('#login').click(login);
    $('#register').click(register);
    $('#btn-login').click(register);
});