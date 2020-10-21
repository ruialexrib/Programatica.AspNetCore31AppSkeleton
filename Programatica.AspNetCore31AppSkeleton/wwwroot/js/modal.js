var modal = modal || {};

modal.url = null;
modal.returnurl = null;
modal.prevreturnurl = null;
modal.size = null;
modal.guid = null;

const modalsizes = {
    SMALL: 'modal-sm',
    NORMAL: '',
    LARGE: 'modal-lg'
}

modal.show = function (url, returnurl, prevreturnurl) {
    return new Promise((resolve, reject) => {

        var container = $(cfg.modal.container);
        var content = $(cfg.modal.content);

        modal.url = url;
        modal.returnurl = returnurl;
        modal.prevreturnurl = prevreturnurl;
        modal.guid = global.guid();

        global.get(url)
            .then((html) => {
                container.modal({
                    backdrop: 'static',
                    keyboard: false
                });
                content.html(html);
                resolve(html);
            })
            .catch((error) => {
                reject(error);
            });
    });
};

/// set size
modal.setsize = function (size) {
    var dialog = $(cfg.modal.dialog);
    dialog.removeClass('modal-sm').removeClass('modal-lg').removeClass('modal-xl').removeClass('modal-xxl');
    if (size) {
        modal.size = size;
        dialog.addClass(size);
    }
}

/// closes modal
modal.close = function () {
    var container = $(cfg.modal.container);
    var content = $(cfg.modal.content);

    modal.url = "";
    modal.returnurl = "";
    modal.size = "";

    content.empty();
    container.modal('hide');
};