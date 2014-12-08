var bed = (function() {

    function popup() {
        var partial = $(this).text();
      
        
            

    }
    return {
        popup:popup
    }
    


})();
$(document).ready(function () {

    function openWindow() {
        var partial = $(this).text();
        var w2 = $("#pop-up");
        w2.kendoWindow({
            width: "320px",
            height: "250px",
            actions: ["Pin", "Refresh", "Maximize", "Close"],
            content: {
                url: partial
            },
            position: {

                top: 28,
                left: 2
            }
            
        });
        w2.data("kendoWindow").open();
    }
    

    $(".li-a").click(openWindow);
   
});