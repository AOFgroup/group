var state = (function () {

    function activeTab() {
        var currentAttr = $(this).attr("data-tab");
        $('.tab').hide();
        $('.tab' + currentAttr).show()
        //$(this).parent('li').addClass("content-tab-active").siblings().removeClass("content-tab-active")
    }

    //function activeCheckBox() {

    //    var attrVal = $(this).attr("data-element-name");
    //    $('.tab > .tab').hide();
    //    $('#' + attrVal).show();

    //}
    return {
        activeTab: activeTab,
        //activeCheckBox: activeCheckBox
    }


})();

(function () {
    $("#Hostel").show();
    $("[data-tab]").on("click", state.activeTab)

   


})()
