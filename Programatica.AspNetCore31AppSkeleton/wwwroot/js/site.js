

$(document).on("click", ".btn", function (e) {
    var target = $(this);
    var text = $(target).text();
    var atr = $(target).attr("data-loading-text");

    if (atr) {
        $(target).prop('disabled', true);
        $(target).text(atr);

        /* perform processing then reset button when done */
        setTimeout(function () {
            $(target).text(text);
            $(target).prop('disabled', false);
        }, 1000);
    }
});
