$(document).on("click", ".btn", function (e) {
    var target = $(this);
    var text = $(target).text();
    var atr = $(target).attr("data-loading-text");

    if (atr) {
        $(target).prop('disabled', true);
        $(target).text(atr);
        $(target).append(' <span class="spinner-grow spinner-grow-sm" role="status" aria-hidden="true"></span>');

        /* perform processing then reset button when done */
        setTimeout(function () {
            $(target).empty();
            $(target).text(text);
            $(target).prop('disabled', false);
        }, 10000);
    }
});

$(document).ajaxStart(function () {
    Pace.restart();
});



