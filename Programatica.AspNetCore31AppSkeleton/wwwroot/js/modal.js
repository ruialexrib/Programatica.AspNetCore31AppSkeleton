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

modal.show = function (url, level = 1) {
    return new Promise((resolve, reject) => {

        var container = $(cfg.modal["container" + level]);
        var content = $(cfg.modal["content" + level])

        modal.url = url;
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

modal.setsize = function (size, level = 1) {

    var dialog = $(cfg.modal["dialog" + level]);

    dialog.removeClass('modal-sm').removeClass('modal-lg').removeClass('modal-xl').removeClass('modal-xxl');
    if (size) {
        modal.size = size;
        dialog.addClass(size);
    }
}

modal.close = function (level = 1) {

    var container = $(cfg.modal["container" + level]);
    var content = $(cfg.modal["content" + level])

    switch (level) {
        case 1:
            container = $(cfg.modal.container1);
            content = $(cfg.modal.content1);
            break;
        case 2:
            container = $(cfg.modal.container2);
            content = $(cfg.modal.content2);
            break;
        default:
    }

    modal.url = "";
    modal.size = "";

    content.empty();
    container.modal('hide');
};